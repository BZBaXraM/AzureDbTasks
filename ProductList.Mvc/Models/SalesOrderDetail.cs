using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ProductList.Mvc.Models
{
    [Table("SalesOrderDetail", Schema = "SalesLT")]
    [Index("rowguid", Name = "AK_SalesOrderDetail_rowguid", IsUnique = true)]
    [Index("ProductID", Name = "IX_SalesOrderDetail_ProductID")]
    public partial class SalesOrderDetail
    {
        [Key]
        public int SalesOrderID { get; set; }
        [Key]
        public int SalesOrderDetailID { get; set; }
        public short OrderQty { get; set; }
        public int ProductID { get; set; }
        [Column(TypeName = "money")]
        public decimal UnitPrice { get; set; }
        [Column(TypeName = "money")]
        public decimal UnitPriceDiscount { get; set; }
        [Column(TypeName = "numeric(38, 6)")]
        public decimal LineTotal { get; set; }
        public Guid rowguid { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime ModifiedDate { get; set; }

        [ForeignKey("ProductID")]
        [InverseProperty("SalesOrderDetails")]
        public virtual Product Product { get; set; } = null!;
        [ForeignKey("SalesOrderID")]
        [InverseProperty("SalesOrderDetails")]
        public virtual SalesOrderHeader SalesOrder { get; set; } = null!;
    }
}
