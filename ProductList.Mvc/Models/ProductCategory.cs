using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ProductList.Mvc.Models
{
    [Table("ProductCategory", Schema = "SalesLT")]
    [Index("Name", Name = "AK_ProductCategory_Name", IsUnique = true)]
    [Index("rowguid", Name = "AK_ProductCategory_rowguid", IsUnique = true)]
    public partial class ProductCategory
    {
        public ProductCategory()
        {
            InverseParentProductCategory = new HashSet<ProductCategory>();
            Products = new HashSet<Product>();
        }

        [Key]
        public int ProductCategoryID { get; set; }
        public int? ParentProductCategoryID { get; set; }
        [StringLength(50)]
        public string Name { get; set; } = null!;
        public Guid rowguid { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime ModifiedDate { get; set; }

        [ForeignKey("ParentProductCategoryID")]
        [InverseProperty("InverseParentProductCategory")]
        public virtual ProductCategory? ParentProductCategory { get; set; }
        [InverseProperty("ParentProductCategory")]
        public virtual ICollection<ProductCategory> InverseParentProductCategory { get; set; }
        [InverseProperty("ProductCategory")]
        public virtual ICollection<Product> Products { get; set; }
    }
}
