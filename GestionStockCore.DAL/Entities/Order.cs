using GestionStockCore.DAL.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GestionStockCore.DAL.Entities
{
    [Table("Orders")]
    public class Order
    {
        [Key]
        [Column("reference", TypeName = "CHAR")]
        [MaxLength(10)]
        public string Reference { get; set; } // yymmddxxxx

        [Column("updateDate", TypeName = "DATETIME2")]
        [Required]
        public DateTime UpdateDate { get; set; }

        [Column("status", TypeName = "INT")]
        [Required]
        public OrderStatus Status { get; set; }

        [Column("customerRef", TypeName = "CHAR")]
        [MaxLength(8)]
        [Required]
        public string CustomerRef { get; set; }

        [ForeignKey(nameof(CustomerRef))]
        public Customer Customer { get; set; }
        public ICollection<OrderLine> OrderLines { get; set; }
    }
}
