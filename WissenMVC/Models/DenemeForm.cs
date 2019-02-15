using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WissenMVC.Models
{
    public class DenemeForm
    {
        [Required(ErrorMessage ="{0} alanı gereklidir.")]
        [MaxLength(50, ErrorMessage ="{0} alanı enfazla {1} karakter uzunluğunda olabilir.")]
        [Display(Name ="Ad")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "{0} alanı gereklidir.")]
        [Display(Name = "Soyad")]
        public string LastName { get; set; }

        [EmailAddress]
        [Required(ErrorMessage = "{0} alanı gereklidir.")]
        [MaxLength(100, ErrorMessage = "{0} alanı enfazla {1} karakter uzunluğunda olabilir.")]
        [Display(Name = "E-posta")]
        public string Email { get; set; }

        [Required(ErrorMessage = "{0} alanı gereklidir.")]
        [Phone]
        [MaxLength(20, ErrorMessage = "{0} alanı enfazla {1} karakter uzunluğunda olabilir.")]
        [Display(Name = "Telefon")]
        public string Phone { get; set; }


    }
}