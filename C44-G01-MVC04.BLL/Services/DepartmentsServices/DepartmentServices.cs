using AutoMapper;
using C44_G01_MVC04.BLL.Dto_s;
using C44_G01_MVC04.BLL.Dto_s.DepartmentDto_s;
using C44_G01_MVC04.BLL.Factories.DepartmentFactory;
using C44_G01_MVC04.DAL.Models.Department;
using C44_G01_MVC04.DAL.Repositories.DepartmentRepo;

namespace C44_G01_MVC04.BLL.Services.DepartmentsServices
{
    public class DepartmentServices: IDepartmentServices
    {
        private readonly IDepartmentRepository _reposatory;
        private readonly IMapper mapper;

        public DepartmentServices(IDepartmentRepository reposatory, IMapper mapper)
        {
            _reposatory = reposatory;
            this.mapper = mapper;
        }

        public IEnumerable<DepartmentDto> GetAllDepartments()
        => mapper.Map<IEnumerable<DepartmentDto>>(_reposatory.GetAll());


        public IEnumerable<DepartmentDto> GetSearchedDepartments(string searchValue)
        => mapper.Map<IEnumerable<DepartmentDto>>(_reposatory.GetAll(searchValue));

        public DepartmentDetailsDto GetDepartmentById (int id)
        => mapper.Map<Department, DepartmentDetailsDto>(_reposatory.GetById(id));


        public int AddDepartment(CreatedDepartmentDto cDepartment)
        {
            var dept = mapper.Map<CreatedDepartmentDto,Department>(cDepartment);
            dept.CreatedBy = 1;
            dept.CreatedOn = DateTime.Now;
            dept.LastModifiedBy = 1;
            dept.LastModifiedOn = DateTime.Now;
            return _reposatory.Add(dept);
        }

        public int UpdateDepartment(UpdatedDepartmentDto updated)
        {
           var dept = mapper.Map<UpdatedDepartmentDto,Department>(updated);
            dept.LastModifiedBy = 1;
            dept.LastModifiedOn = DateTime.Now;
            return _reposatory.Update(dept);
        }

        public int DeleteDepartment(int id)
        => _reposatory.Delete(id);

    }
}
