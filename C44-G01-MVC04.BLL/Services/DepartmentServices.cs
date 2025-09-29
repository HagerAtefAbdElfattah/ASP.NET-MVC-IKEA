using C44_G01_MVC04.BLL.Dto_s;
using C44_G01_MVC04.BLL.Dto_s.DepartmentDto_s;
using C44_G01_MVC04.BLL.Factories.DepartmentFactory;
using C44_G01_MVC04.DAL.Reposatories.DepartmentRepo;

namespace C44_G01_MVC04.BLL.Services
{
    public class DepartmentServices: IDepartmentServices
    {
        private readonly IDepartmentReposatory _reposatory;
        public DepartmentServices(IDepartmentReposatory reposatory)
        {
            _reposatory = reposatory;   
        }

        public IEnumerable<DepartmentDto> GetAllDepartments()
        {
            var departments = _reposatory.GetAll();
            //var MappedDepartments = departments.Select(d => new DepartmentDto
            //{
            //    Id = d.Id,
            //    Name = d.Name,
            //    Code = d.Code,
            //    Description = d.Description
            //});

            //mapping by extension method
            List<DepartmentDto> MappedDepartments = new List<DepartmentDto>();
            foreach (var dept in departments)
            {
                MappedDepartments.Add(dept.ToDepartmentDeto());
            }
            return MappedDepartments;
        }

        public DepartmentDetailsDto GetDepartmentById (int id)
        {
            var department = _reposatory.GetById(id);

            if (department == null) return null;
            else
            {
                ///////////////  //Manual mapping //  /////////////////////////////////

                //var departmentToReturn = new DepartmentDetailsDto
                //{
                //    Id = department.Id,
                //    Name = department.Name,
                //    Code = department.Code,
                //    Description = department.Description,
                //    CreatedBy = department.CreatedBy,
                //    CreatedOn = DateOnly.FromDateTime(department.CreatedOn),
                //    LastModifiedBy = department.LastModifiedBy,
                //    LastModifiedOn = DateOnly.FromDateTime(department.LastModifiedOn),
                //};

                //return departmentToReturn;

                ///// //constructor mapping//  ////////////////////////////////////////

                //var departmentToReturn = new DepartmentDetailsDto(department);
                //return departmentToReturn;

                /////////////////////////// //mapping by extension method// ///////////////////////////////////
                var departmentToReturn = department.ToEntity();
                return departmentToReturn;
                
            }
        }

        public int AddDepartment(CreatedDepartmentDto cDepartment)
        {
            var dept = cDepartment.ToDepartment();
            return _reposatory.Add(dept);
        }

        public int UpdateDepartment(UpdatedDepartmentDto updated)
        {
            var dept = updated.FromUpdatedDepartment();
            return _reposatory.Update(dept);
        }

        public int DeleteDepartment(int id)
        {
            return _reposatory.Delete(id);
        }

    }
}
