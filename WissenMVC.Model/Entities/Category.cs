using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WissenMVC.Model
{
    public class Category:BaseEntity
    {
        public Category()
        {
            Posts = new HashSet<Post>();
        }
        [Required]
        [Display(Name="Ad")]
        public string Name { get; set; }

        [Required]
        [Display(Name = "Açıklama")]
        public string Descripton { get; set; }


        public virtual ICollection<Post> Posts { get; set; }
    }
}
