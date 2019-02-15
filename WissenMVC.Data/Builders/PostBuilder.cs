using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WissenMVC.Model;

namespace WissenMVC.Data.Builders
{
    public class PostBuilder
    {
        public PostBuilder(EntityTypeConfiguration<Post> entity)
        {
            entity.HasKey(e => e.Id);
            entity.Property(p => p.Title).IsRequired().HasMaxLength(100);
            entity.Property(p => p.Description).IsRequired().HasMaxLength(5000);
            entity.HasRequired(p => p.Category).WithMany(m => m.Posts).HasForeignKey(f => f.CategoryId);
        }
    }
}
