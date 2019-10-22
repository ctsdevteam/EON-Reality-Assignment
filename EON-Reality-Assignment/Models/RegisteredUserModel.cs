using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EON_Reality_Assignment.Models
{
    public class RegisteredUserModel
    {
        [Required]
        [StringLength(30)]
        [Display(Name = "Name")]
        public string UserName { get; set; }

        [Required]
        [StringLength(50)]
        [Display(Name = "Email")]
        [EmailAddress]
        public string EmailAddress { get; set; }

        [Required]
        [Display(Name = "Gender")]
        public Boolean Gender { get; set; }

        [Required]
        //[StringLength(10)]
        [Display(Name = "Register Date")]
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime RegisterDate { get; set; }

        [Display(Name = "Selected Days")]
        public IList<SelectedDay> SelectedDays { get; set; }

        [Display(Name = "Additional Request")]
        [StringLength(100)]
        public string AdditionalRequest { get; set; }
    }

    public class SelectedDay
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool Selected { get; set; }
    }
}
