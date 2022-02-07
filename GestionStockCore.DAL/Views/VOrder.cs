using GestionStockCore.DAL.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionStockCore.DAL.Views
{
    public class VOrder
    {

        [Column("reference")]
        [Display(Name = "Ref.")]
        public string Reference { get; set; }

        [Column("updateDate")]
        [Display(Name = "Date de modification")]
        public DateTime Date { get; set; }

        //[Display(Name = "Total")]
        public decimal Total { get; set; }

        [Column("customerRef")]
        [Display(Name = "Client")]
        public string CustomerRef { get; set; }

        [Column("status")]
        [Display(Name = "Etat")]
        public OrderStatus Status { get; set; }
    }
}
