using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client_Management.Models
{
    public class CustomerTypes
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Description { get; set; }

        public CustomerTypes() {
            Id = 0;
        }
    }
}
