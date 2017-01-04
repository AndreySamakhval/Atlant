using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Atlant.Dal
{
    public class Storekeeper
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }//Имя

        public override string ToString()
        {
            return Name;
        }
    }
}
