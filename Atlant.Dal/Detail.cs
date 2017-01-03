using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Atlant.Dal
{
    [Table("Detail")]
    public class Detail
    {
        public int Id { get; set; }

        [Required]
        public string ItemCode { get; set; }//номенклатурный код

        [Required]
        public string Name { get; set; }//Наименование

        public int? Amount { get; set; }//Количество

        public bool? SpecialConsideration { get; set; }//Особоучитываемая

        [Required]
        public DateTime DateAdded { get; set; }//дата добовления

        
        public int  StorekeeperId { get; set; }//кладовщик


    }
}
