using C44_G01_MVC04.DAL.Models.Department;


namespace C44_G01_MVC04.DAL.Configurations
{
    public class DepartmentConfiguration : IEntityTypeConfiguration<Department>
    {
        public void Configure(EntityTypeBuilder<Department> D)
        {
            D.Property(d => d.Id).UseIdentityColumn(10,10);
            D.Property(d => d.Name).HasColumnType("varchar(20)");
            D.Property(d => d.Code).HasColumnType("varchar(20)");
        }
    }
}
