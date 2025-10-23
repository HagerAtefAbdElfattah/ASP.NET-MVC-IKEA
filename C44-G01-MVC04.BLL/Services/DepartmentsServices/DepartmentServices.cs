using AutoMapper;
using C44_G01_MVC04.BLL.Dto_s;
using C44_G01_MVC04.BLL.Dto_s.DepartmentDto_s;
using C44_G01_MVC04.BLL.Factories.DepartmentFactory;
using C44_G01_MVC04.DAL.Models.Department;
using C44_G01_MVC04.DAL.Repositories.DepartmentRepo;
using C44_G01_MVC04.DAL.UOW;

namespace C44_G01_MVC04.BLL.Services.DepartmentsServices
{
    public class DepartmentServices: IDepartmentServices
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;

        public DepartmentServices(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }

        public IEnumerable<DepartmentDto> GetAllDepartments()
        => mapper.Map<IEnumerable<DepartmentDto>>(unitOfWork.DepartmentRepository.GetAll());


        public IEnumerable<DepartmentDto> GetSearchedDepartments(string searchValue)
        => mapper.Map<IEnumerable<DepartmentDto>>(unitOfWork.DepartmentRepository.GetAll(searchValue));

        public DepartmentDetailsDto GetDepartmentById (int id)
        => mapper.Map<Department, DepartmentDetailsDto>(unitOfWork.DepartmentRepository.GetById(id));


        public int AddDepartment(CreatedDepartmentDto cDepartment)
        {
            var dept = mapper.Map<CreatedDepartmentDto,Department>(cDepartment);
            dept.CreatedBy = 1;
            dept.CreatedOn = DateTime.Now;
            dept.LastModifiedBy = 1;
            dept.LastModifiedOn = DateTime.Now;
            unitOfWork.DepartmentRepository.Add(dept);
            return unitOfWork.Complete();
        }

        public int UpdateDepartment(UpdatedDepartmentDto updated)
        {
           var dept = mapper.Map<UpdatedDepartmentDto,Department>(updated);
            dept.LastModifiedBy = 1;
            dept.LastModifiedOn = DateTime.Now;
            unitOfWork.DepartmentRepository.Update(dept);
            return unitOfWork.Complete();
        }

        public int DeleteDepartment(int id)
        {  
            unitOfWork.DepartmentRepository.Delete(id);
            return unitOfWork.Complete();
        }
    }
}
