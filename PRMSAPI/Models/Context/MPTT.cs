using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace PRMSAPI.Models.Context
{
    public class MPTT
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column(TypeName = ("decimal(18,0)"))]
        public decimal Id { get; set; }
        [Required]
        [Column(TypeName = ("decimal(18,0)"))]
        public decimal TreeId { get; set; }
        [Required]
        [Column(TypeName = ("nvarchar(100)"))]
        public string Name { get; set; }
        [Required]
        [Column(TypeName = ("decimal"))]
        public decimal ParentId { get; set; }
        [Required]
        [Column(TypeName = ("int"))]
        public int OrderLevel { get; set; }
        [Required]
        [Column(TypeName = ("decimal"))]
        public decimal LeftValue { get; set; }
        [Required]
        [Column(TypeName = ("decimal"))]
        public decimal RightValue { get; set; }
        [Required]
        [Column(TypeName = ("bit"))]
        public bool IsLeaf { get; set; }
    }
}
