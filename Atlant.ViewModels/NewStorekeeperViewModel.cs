using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Atlant.ViewModels
{
    public class NewStorekeeperViewModel
    {
        [Required]
        public string Name { get; set; }
    }
}
