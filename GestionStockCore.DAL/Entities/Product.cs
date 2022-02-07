using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GestionStockCore.DAL.Entities
{
    [Table("Products")]
    public class Product
    {
        [Key]
        [Column("reference", TypeName = "CHAR")]
        [MaxLength(8)]
        public string Reference { get; set; }

        [Column("name", TypeName = "VARCHAR")]
        [MaxLength(100)]
        [Required]
        public string Name { get; set; }

        [Column("description", TypeName = "NVARCHAR(MAX)")]
        public string Description { get; set; }

        [Column("stock", TypeName = "INT")]
        [Required]
        public int Stock { get; set; }

        [Column("price", TypeName = "MONEY")]
        [Required]
        public decimal Price { get; set; }

        [Column("deleted", TypeName = "BIT")]
        [Required]
        public bool Deleted { get; set; }

        public ICollection<OrderLine> OrderLines { get; set; }
    }
}
