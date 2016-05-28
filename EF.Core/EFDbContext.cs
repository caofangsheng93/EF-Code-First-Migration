using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace EF.Core
{
   public class EFDbContext:DbContext
    {
       static EFDbContext()
       {
           Database.SetInitializer<EFDbContext>(null);
       }

       public EFDbContext()
           : base("name=DbConnectionstring")
       { 
       
       }

       protected override void OnModelCreating(DbModelBuilder modelBuilder)
       {
           var typesToRegister = Assembly.GetExecutingAssembly().GetTypes()
           .Where(type => !String.IsNullOrEmpty(type.Namespace))
           .Where(type => type.BaseType != null && type.BaseType.IsGenericType
                && type.BaseType.GetGenericTypeDefinition() == typeof(EntityTypeConfiguration<>));
           foreach (var type in typesToRegister)
           {
               dynamic configurationInstance = Activator.CreateInstance(type);
               modelBuilder.Configurations.Add(configurationInstance);
           }  
           //modelBuilder.Configurations.Add(new StudentMap());  
           base.OnModelCreating(modelBuilder);
       }
    }
}
