using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GestionStockCore.DAL.Entities
{
    [Table("Customers")]
    [Index(nameof(Email), IsUnique = true)]
    public class Customer
    {
        [Key]
        [Column("reference", TypeName = "CHAR")]
        [MaxLength(8)]
        public string Reference { get; set; }

        [Column("lastName", TypeName = "VARCHAR")]
        [MaxLength(50)]
        [Required]
        public string LastName { get; set; }

        [Column("firstName", TypeName = "VARCHAR")]
        [MaxLength(50)]
        [Required]
        public string FirstName { get; set; }

        [Column("email", TypeName = "VARCHAR")]
        [MaxLength(255)]
        [Required]
        public string Email { get; set; }

        [Column("phone", TypeName = "VARCHAR")]
        [MaxLength(25)]
        public string Phone { get; set; }

        [Column("deleted", TypeName = "BIT")]
        [Required]
        public bool Deleted { get; set; }

        public ICollection<Order> Orders { get; set; }
    }
}
