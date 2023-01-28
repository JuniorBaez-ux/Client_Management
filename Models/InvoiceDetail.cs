using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client_Management.Models
{
    public class InvoiceDetail
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int Qty { get; set; }
        [Required]
        public double Price { get; set; }
        [Required]
        public double Totalitbis { get; set; }
        [Required]
        public double SubTotal { get; set;}
        [Required]
        public double Total { get; set;}

        [ForeignKey("CustomerId")]
        public int CustomerId { get; set; }
        public virtual Invoice? Invoice{ get; set; }
    }
}
