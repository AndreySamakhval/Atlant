using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Atlant.ViewModels
{
    public class AddDetailViewModel
    {       
        [Required(ErrorMessage ="Enter Code")]
        public string ItemCode { get; set; }
        [Required]
        public string Name { get; set; }

        public int Amount { get; set; }
        // public bool SpecialConsideration { get; set; }
        [Required]
        public DateTime DateAdded { get; set; }
        [Required]
        public string Storekeeper { get; set; }
    }
}
