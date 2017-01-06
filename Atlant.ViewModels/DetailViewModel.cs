using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Atlant.ViewModels
{
    public class DetailViewModel
    {
        [UIHint("HiddenInput")]
        public int Id { get; set; }

        [Display(Name ="Номенклатурный код")]
        public string ItemCode { get; set; }

        [Display(Name = "Наименование")]
        public string Name { get; set; }

        [Display(Name = "Количество")]
        public int Amount { get; set; }

        [Display(Name = "Особоучитываемая")]
        public bool SpecialConsideration { get; set; }

        [Display(Name = "Дата добовления")]
        //[DataType(DataType.Date)]
        public string DateAdded { get; set; }

        [Display(Name = "Кладовщик")]
        public  string Storekeeper { get; set; }
    }
}
