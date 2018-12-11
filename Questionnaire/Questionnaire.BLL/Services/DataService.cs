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
    public class DataService : IDataService
    {
        private IUnitOfWork _unitOfWork { get; set; }
        public DataService(IUnitOfWork uow)
        {
            _unitOfWork = uow;
        }

        public DataDTO Get(int id)
        {
            Data data = _unitOfWork.Datas.Get(id);

            return Mapper.Map<DataDTO>(data);
        }

        public DataDTO Get(int? id)
        {
            if (id == null)
                throw new ArgumentNullException();

            Data data = _unitOfWork.Datas.Get(id);
            if (data == null)
                throw new NotFoundException();

            return Mapper.Map<DataDTO>(data);
        }

        public IEnumerable<DataDTO> GetAll()
        {
            List<Data> datas = _unitOfWork.Datas.GetAll().ToList();

            return Mapper.Map<IEnumerable<DataDTO>>(datas);
        }

        public void Add(DataDTO dataDTO)
        {
            Data data = Mapper.Map<Data>(dataDTO);

            _unitOfWork.Datas.Create(data);
            _unitOfWork.Save();
        }

        public void Update(DataDTO dataDTO)
        {
            Data data = Mapper.Map<Data>(dataDTO);

            _unitOfWork.Datas.Update(data);
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
