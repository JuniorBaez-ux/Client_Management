using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client_Management.Models
{
    public class Customers
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string? CustName { get; set; }

        [Required]
        public string? Adress { get; set; }
        [Required]
        public bool Status { get; set; }
        [ForeignKey("CustomerTypeId")]
        public int CustomerTypeId { get; set; }

        public virtual CustomerTypes? CustomerType { get; set; }
    }
}
