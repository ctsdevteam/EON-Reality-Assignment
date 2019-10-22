using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace EON_Reality_Assignment.Models
{
    public class RegisteredUsers
    {
        [Key]
        public int ID { get; set; }

        [Required]
        [StringLength(30)]
        [Display(Name = "Name")]
        public string UserName { get; set; }

        [Required]
        [StringLength(50)]
        [Display(Name = "Email")]
        public string EmailAddress { get; set; }

        [Required]
        [Display(Name = "Gender")]
        public Boolean Gender { get; set; }

        [Required]
        [StringLength(10)]
        [Display(Name = "Register Date")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime RegisterDate { get; set; }

        public string SelectedDays { get; set; }

        [Display(Name = "Additional Request")]
        public string AdditionalRequest { get; set; }
    }
    public class UserSelectedDays
    {
        [ForeignKey("RegisteredUsers")]
        public int UserID { get; set; }

        [Key]
        public int SelectedDay { get; set; }
    }
}
