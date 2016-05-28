using EF.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF.Core
{
    public class StudentMap:EntityTypeConfiguration<Student>
    {
        public StudentMap()
        {
            //配置主键
            this.HasKey(s => s.ID);

            //字段
            this.Property(s => s.ID).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            this.Property(s => s.StudentName).IsRequired();
            this.Property(s => s.Age).IsRequired();
            this.Property(s => s.Email).IsRequired();

            //totable
            this.ToTable("Student");
        }
    }
}
