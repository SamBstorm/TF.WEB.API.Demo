using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GestionStockCore.DAL.Entities
{
    [Table("OrderLines")]
    public class OrderLine
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("id", TypeName = "INT")]
        public int Id { get; set; }

        [Column("orderRef", TypeName = "CHAR")]
        [MaxLength(10)]
        [Required]
        public string OrderRef { get; set; }

        [Column("productRef", TypeName = "CHAR")]
        [MaxLength(8)]
        [Required]
        public string ProductRef { get; set; }

        [Column("quantity", TypeName = "INT")]
        [Required]
        public int Quantity { get; set; }

        [Column("unitPrice", TypeName = "MONEY")]
        public decimal? UnitPrice { get; set; }

        [ForeignKey(nameof(OrderRef))]
        public Order Order { get; set; }

        [ForeignKey(nameof(ProductRef))]
        public Product Product { get; set; }
    }
}
