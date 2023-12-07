using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ProductList.Mvc.Models
{
    [Table("BuildVersion")]
    public partial class BuildVersion
    {
        [Key]
        public byte SystemInformationID { get; set; }
        [Column("Database Version")]
        [StringLength(25)]
        public string Database_Version { get; set; } = null!;
        [Column(TypeName = "datetime")]
        public DateTime VersionDate { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime ModifiedDate { get; set; }
    }
}
