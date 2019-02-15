using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WissenMVC.Model;

namespace WissenMVC.Data.Builders
{
    public class CategoryBuilder
    {
        public CategoryBuilder(EntityTypeConfiguration<Category> entity)
        {
            entity.HasKey(e => e.Id);
            entity.Property(p => p.Name).IsRequired().HasMaxLength(50);
            entity.Property(p => p.Descripton).HasMaxLength(50);
        }
    }
}
