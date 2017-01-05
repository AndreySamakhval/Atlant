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
        [Display(Name = "Номенклатурный код")]
        [Required(ErrorMessage ="Введите номенклатурный код")]
        [RegularExpression(@"[A-Z]{3}-\d{6}",ErrorMessage ="Номенклатурный код должен иметь вид:XXX-111111")]
        public string ItemCode { get; set; }

        [Display(Name = "Наименование")]
        [Required(ErrorMessage = "Введите наименование")]
        public string Name { get; set; }

        [Display(Name = "Количество деталей")]
        [Required]
        [Range(0,2147483646,ErrorMessage ="Недопустимое кол-во деталей")]
        public int Amount { get; set; }

        [Display(Name = "Особоучитываемая")]
        [UIHint("Boolean")]
        public bool SpecialConsideration { get; set; }

        [Display(Name = "Дата добавления")]
        [Required(ErrorMessage = "Выберите дату")]
        [DataType(DataType.Date)]
        public DateTime DateAdded { get; set; }

        [Display(Name = "Кладовщик")]
        [Required(ErrorMessage = "Выберите кладовщика")]
        public string Storekeeper { get; set; }
    }
}
