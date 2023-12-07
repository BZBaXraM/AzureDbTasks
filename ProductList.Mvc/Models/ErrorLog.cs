using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ProductList.Mvc.Models
{
    [Table("ErrorLog")]
    public partial class ErrorLog
    {
        [Key]
        public int ErrorLogID { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime ErrorTime { get; set; }
        [StringLength(128)]
        public string UserName { get; set; } = null!;
        public int ErrorNumber { get; set; }
        public int? ErrorSeverity { get; set; }
        public int? ErrorState { get; set; }
        [StringLength(126)]
        public string? ErrorProcedure { get; set; }
        public int? ErrorLine { get; set; }
        [StringLength(4000)]
        public string ErrorMessage { get; set; } = null!;
    }
}
