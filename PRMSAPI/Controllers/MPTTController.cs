using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PRMSAPI.Models.Context;
using PRMSAPI.Models.Repository.Abstract;
using PRMSAPI.Models.Repository.Concrete;

namespace PRMSAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MPTTController : ControllerBase
    {
        private readonly PRMSContext _context;
        private IMPTTRepository _iMPTTRepository;

        public MPTTController(PRMSContext context, IMPTTRepository iMPTTRepository)
        {
            _context = context;
            _iMPTTRepository = iMPTTRepository;
        }

        // GET: api/MPTT
        [HttpGet]
        public async Task<ActionResult<IEnumerable<MPTT>>> GetMPTT()
        {
            return await _context.MPTT.ToListAsync();
        }

        // GET: api/MPTT/5
        [HttpGet("{id}")]
        public async Task<ActionResult<MPTT>> GetMPTT(decimal id)
        {
            var mPTT = await _context.MPTT.FindAsync(id);

            if (mPTT == null)
            {
                return NotFound();
            }

            return mPTT;
        }

        // PUT: api/MPTT/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMPTT(decimal id, MPTT mPTT)
        {
            if (id != mPTT.Id)
            {
                return BadRequest();
            }

            _context.Entry(mPTT).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MPTTExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/MPTT
        [HttpPost]
        public async Task<ActionResult<MPTT>> PostMPTT(MPTT mPTT)
        {
            //_context.MPTT.Add(mPTT);
            //await _context.SaveChangesAsync();
            mPTT.IsLeaf = false;
            _iMPTTRepository.Add(mPTT);

            return CreatedAtAction("GetMPTT", new { id = mPTT.Id }, mPTT);
        }

        // DELETE: api/MPTT/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<MPTT>> DeleteMPTT(decimal id)
        {
            var mPTT = await _context.MPTT.FindAsync(id);
            if (mPTT == null)
            {
                return NotFound();
            }

            _context.MPTT.Remove(mPTT);
            await _context.SaveChangesAsync();

            return mPTT;
        }

        private bool MPTTExists(decimal id)
        {
            return _context.MPTT.Any(e => e.Id == id);
        }
    }
}
