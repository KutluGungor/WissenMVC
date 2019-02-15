using System;
using System.Collections.Generic;
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


        public string Name { get; set; }
        public string Descripton { get; set; }
        public virtual ICollection<Post> Posts { get; set; }
    }
}
