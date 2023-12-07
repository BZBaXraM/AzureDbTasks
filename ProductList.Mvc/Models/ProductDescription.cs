using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ProductList.Mvc.Models
{
    [Table("ProductDescription", Schema = "SalesLT")]
    [Index("rowguid", Name = "AK_ProductDescription_rowguid", IsUnique = true)]
    public partial class ProductDescription
    {
        public ProductDescription()
        {
            ProductModelProductDescriptions = new HashSet<ProductModelProductDescription>();
        }

        [Key]
        public int ProductDescriptionID { get; set; }
        [StringLength(400)]
        public string Description { get; set; } = null!;
        public Guid rowguid { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime ModifiedDate { get; set; }

        [InverseProperty("ProductDescription")]
        public virtual ICollection<ProductModelProductDescription> ProductModelProductDescriptions { get; set; }
    }
}
