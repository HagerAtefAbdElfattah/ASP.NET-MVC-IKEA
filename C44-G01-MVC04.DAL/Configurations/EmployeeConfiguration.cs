using C44_G01_MVC04.DAL.Models.Employees;
using C44_G01_MVC04.DAL.Models.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C44_G01_MVC04.DAL.Configurations
{
    public class EmployeeConfiguration : IEntityTypeConfiguration<Employee>
    {
        public void Configure(EntityTypeBuilder<Employee> builder)
        {
            builder.Property(d => d.Name).HasColumnType("varchar(50)");
            builder.Property(d => d.Address).HasColumnType("varchar(150)");
            builder.Property(d => d.Salary).HasColumnType("decimal(10,3)");
            builder.Property(d => d.Gender)
                .HasConversion((empGender) => empGender.ToString(), (gender) => (Gender)Enum.Parse(typeof(Gender),gender));
            builder.Property(d => d.EmployeeType)
                .HasConversion((EType) => EType.ToString(), (type) => (EmployeeType)Enum.Parse(typeof(EmployeeType), type));
        }
    }
}
