using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ProductList.Mvc.Models
{
    [Table("CustomerAddress", Schema = "SalesLT")]
    [Index("rowguid", Name = "AK_CustomerAddress_rowguid", IsUnique = true)]
    public partial class CustomerAddress
    {
        [Key]
        public int CustomerID { get; set; }
        [Key]
        public int AddressID { get; set; }
        [StringLength(50)]
        public string AddressType { get; set; } = null!;
        public Guid rowguid { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime ModifiedDate { get; set; }

        [ForeignKey("AddressID")]
        [InverseProperty("CustomerAddresses")]
        public virtual Address Address { get; set; } = null!;
        [ForeignKey("CustomerID")]
        [InverseProperty("CustomerAddresses")]
        public virtual Customer Customer { get; set; } = null!;
    }
}
