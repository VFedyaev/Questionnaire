using AutoMapper;
using Questionnaire.BLL.DTO;
using Questionnaire.BLL.Infrastructure.Exceptions;
using Questionnaire.BLL.Interfaces;
using Questionnaire.DAL.Entities;
using Questionnaire.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Questionnaire.BLL.Services
{
    public class FamilyService : IFamilyService
    {
        private IUnitOfWork _unitOfWork { get; set; }
        public FamilyService(IUnitOfWork uow)
        {
            _unitOfWork = uow;
        }

        public FamilyDTO Get(int id)
        {
            Family family = _unitOfWork.Families.Get(id);

            return Mapper.Map<FamilyDTO>(family);
        }

        public FamilyDTO Get(int? id)
        {
            if (id == null)
                throw new ArgumentNullException();

            Family family = _unitOfWork.Families.Get(id);
            if (family == null)
                throw new NotFoundException();

            return Mapper.Map<FamilyDTO>(family);
        }

        public IEnumerable<FamilyDTO> GetAll()
        {
            List<Family> families = _unitOfWork.Families.GetAll().ToList();

            return Mapper.Map<IEnumerable<FamilyDTO>>(families);
        }

        public IEnumerable<FamilyDTO> GetListOrderedByName()
        {
            List<Family> families = _unitOfWork.Families.GetAll().OrderBy(n => n.Sex).ToList();

            return Mapper.Map<IEnumerable<FamilyDTO>>(families);
        }

        public void Add(FamilyDTO familyDTO)
        {
            Family family = Mapper.Map<Family>(familyDTO);

            _unitOfWork.Families.Create(family);
            _unitOfWork.Save();
        }

        public void Update(FamilyDTO familyDTO)
        {
            Family family = Mapper.Map<Family>(familyDTO);
  
            _unitOfWork.Families.Update(family);
            _unitOfWork.Save();
        }

        public void Delete(int id)
        {
            Family family = _unitOfWork.Families.Get(id);

            if (family == null)
                throw new NotFoundException();

            _unitOfWork.Families.Delete(id);
            _unitOfWork.Save();
        }

        //public IEnumerable<HistoryDTO> GetFilteredList(FilterParamsDTO parameters)
        //{
        //    IEnumerable<HistoryDTO> filteredList = GetAll();

        //    if (!string.IsNullOrEmpty(parameters.EquipmentId))
        //    {
        //        Guid guidEquipmentId = Guid.Parse(parameters.EquipmentId);
        //        filteredList = filteredList.Where(h => h.EquipmentId == guidEquipmentId);
        //    }

        //    if (!string.IsNullOrEmpty(parameters.EmployeeId))
        //    {
        //        int intEmployeeId = int.Parse(parameters.EmployeeId);
        //        filteredList = filteredList.Where(h => h.EmployeeId == intEmployeeId);
        //    }

        //    if (!string.IsNullOrEmpty(parameters.RepairPlaceId))
        //    {
        //        Guid guidRepairPlaceId = Guid.Parse(parameters.RepairPlaceId);
        //        filteredList = filteredList.Where(h => h.RepairPlaceId == guidRepairPlaceId);
        //    }

        //    if (!string.IsNullOrEmpty(parameters.StatusTypeId))
        //    {
        //        Guid guidStatusTypeId = Guid.Parse(parameters.StatusTypeId);
        //        filteredList = filteredList.Where(h => h.StatusTypeId == guidStatusTypeId);
        //    }

        //    return filteredList.OrderBy(h => h.Employee.EmployeeFullName);
        //}

        public void Dispose()
        {
            _unitOfWork.Dispose();
        }
    }
}
