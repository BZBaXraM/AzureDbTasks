using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ProductList.Mvc.Models
{
    [Table("SalesOrderHeader", Schema = "SalesLT")]
    [Index("SalesOrderNumber", Name = "AK_SalesOrderHeader_SalesOrderNumber", IsUnique = true)]
    [Index("rowguid", Name = "AK_SalesOrderHeader_rowguid", IsUnique = true)]
    [Index("CustomerID", Name = "IX_SalesOrderHeader_CustomerID")]
    public partial class SalesOrderHeader
    {
        public SalesOrderHeader()
        {
            SalesOrderDetails = new HashSet<SalesOrderDetail>();
        }

        [Key]
        public int SalesOrderID { get; set; }
        public byte RevisionNumber { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime OrderDate { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime DueDate { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? ShipDate { get; set; }
        public byte Status { get; set; }
        [Required]
        public bool? OnlineOrderFlag { get; set; }
        [StringLength(25)]
        public string SalesOrderNumber { get; set; } = null!;
        [StringLength(25)]
        public string? PurchaseOrderNumber { get; set; }
        [StringLength(15)]
        public string? AccountNumber { get; set; }
        public int CustomerID { get; set; }
        public int? ShipToAddressID { get; set; }
        public int? BillToAddressID { get; set; }
        [StringLength(50)]
        public string ShipMethod { get; set; } = null!;
        [StringLength(15)]
        [Unicode(false)]
        public string? CreditCardApprovalCode { get; set; }
        [Column(TypeName = "money")]
        public decimal SubTotal { get; set; }
        [Column(TypeName = "money")]
        public decimal TaxAmt { get; set; }
        [Column(TypeName = "money")]
        public decimal Freight { get; set; }
        [Column(TypeName = "money")]
        public decimal TotalDue { get; set; }
        public string? Comment { get; set; }
        public Guid rowguid { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime ModifiedDate { get; set; }

        [ForeignKey("BillToAddressID")]
        [InverseProperty("SalesOrderHeaderBillToAddresses")]
        public virtual Address? BillToAddress { get; set; }
        [ForeignKey("CustomerID")]
        [InverseProperty("SalesOrderHeaders")]
        public virtual Customer Customer { get; set; } = null!;
        [ForeignKey("ShipToAddressID")]
        [InverseProperty("SalesOrderHeaderShipToAddresses")]
        public virtual Address? ShipToAddress { get; set; }
        [InverseProperty("SalesOrder")]
        public virtual ICollection<SalesOrderDetail> SalesOrderDetails { get; set; }
    }
}
