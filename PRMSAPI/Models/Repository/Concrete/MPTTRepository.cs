using PRMSAPI.Models.Context;
using PRMSAPI.Models.Repository.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PRMSAPI.Models.Repository.Concrete
{
    public class MPTTRepository : IMPTTRepository
    {
        private readonly PRMSContext _context;

        public MPTTRepository(PRMSContext context)
        {
            _context = context;
        }

        public MPTT Add(MPTT mPTT)
        {
            IEnumerable<MPTT> mPTTs = GetAll();

            MPTT isTreeIdExistObj = mPTTs.FirstOrDefault(a => a.TreeId == mPTT.TreeId);
            if(isTreeIdExistObj == null)
            {
                if (mPTT.TreeId == 0)
                {
                    mPTT.TreeId = mPTTs.Count() == 0 ? 1 : (mPTTs.Select(a => a.TreeId).Max() + 1);
                }
                mPTT.OrderLevel = 1;
                mPTT.LeftValue = 1;
                mPTT.RightValue = 2;
                _context.MPTT.Add(mPTT);
            }
            else
            {
                //http://imrannazar.com/Modified-Preorder-Tree-Traversal
                MPTT mPTTObj = null;
                IEnumerable<MPTT> childMPTTs = null;
                decimal valueToComapre = 0;
                #region SetOrderLevel
                mPTT.OrderLevel = mPTTs.Where(a => a.TreeId == mPTT.TreeId && a.Id == mPTT.ParentId).Select(a => a.OrderLevel).Single() + 1;
                #endregion SetOrderLevel

                #region SetLeftRightValue
                mPTTObj = mPTTs.Where(a => a.Id == mPTT.ParentId).Single();
                valueToComapre = mPTTObj.LeftValue;
                childMPTTs = mPTTs.Where(a => a.ParentId == mPTTObj.Id);
                if (childMPTTs.Count() > 0)
                    valueToComapre = childMPTTs.Select(a => a.RightValue).Max();
                IEnumerable<MPTT> addLeftValueMPTTs = mPTTs.Where(a => valueToComapre < a.LeftValue);
                IEnumerable<MPTT> addRightValueMPTTs = mPTTs.Where(a => valueToComapre < a.RightValue);
                foreach(MPTT m in addLeftValueMPTTs)
                {
                    m.LeftValue += 2;
                }
                foreach (MPTT m in addRightValueMPTTs)
                {
                    m.RightValue += 2;
                }

                mPTTObj = mPTTs.Where(a => a.Id == mPTT.ParentId).Single();
                mPTT.RightValue = mPTTObj.RightValue - 1;
                mPTT.LeftValue = mPTT.RightValue - 1;
                #endregion SetLeftRightValue

                _context.MPTT.Add(mPTT);
            }

            _context.SaveChanges();
            return mPTT;
        }

        public IEnumerable<MPTT> GetAll()
        {
            return _context.MPTT;
        }
    }
}
