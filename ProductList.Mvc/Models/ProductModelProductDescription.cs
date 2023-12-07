using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ProductList.Mvc.Models
{
    [Table("ProductModelProductDescription", Schema = "SalesLT")]
    [Index("rowguid", Name = "AK_ProductModelProductDescription_rowguid", IsUnique = true)]
    public partial class ProductModelProductDescription
    {
        [Key]
        public int ProductModelID { get; set; }
        [Key]
        public int ProductDescriptionID { get; set; }
        [Key]
        [StringLength(6)]
        public string Culture { get; set; } = null!;
        public Guid rowguid { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime ModifiedDate { get; set; }

        [ForeignKey("ProductDescriptionID")]
        [InverseProperty("ProductModelProductDescriptions")]
        public virtual ProductDescription ProductDescription { get; set; } = null!;
        [ForeignKey("ProductModelID")]
        [InverseProperty("ProductModelProductDescriptions")]
        public virtual ProductModel ProductModel { get; set; } = null!;
    }
}
