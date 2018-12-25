using AutoMapper;
using Questionnaire.BLL.DTO;
using Questionnaire.BLL.Infrastructure.Exceptions;
using Questionnaire.BLL.Interfaces;
using Questionnaire.DAL.Entities;
using Questionnaire.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Questionnaire.BLL.Services
{
    public class FormService : IFormService
    {
        private IUnitOfWork _unitOfWork { get; set; }
        public FormService(IUnitOfWork uow)
        {
            _unitOfWork = uow;
        }

        public FormDTO Get(int id)
        {
            Form form = _unitOfWork.Forms.Get(id);

            return Mapper.Map<FormDTO>(form);
        }

        public FormDTO Get(int? id)
        {
            if (id == null)
                throw new ArgumentNullException();

            Form form = _unitOfWork.Forms.Get(id);
            if (form == null)
                throw new NotFoundException();

            return Mapper.Map<FormDTO>(form);
        }

        public IEnumerable<FormDTO> GetAll()
        {
            List<Form> forms = _unitOfWork.Forms.GetAll().ToList();

            return Mapper.Map<IEnumerable<FormDTO>>(forms);
        }

        public IEnumerable<FormDTO> GetListOrderedByName()
        {
            List<Form> forms = _unitOfWork.Forms.GetAll().OrderBy(n => n.NumberForm).ToList();

            return Mapper.Map<IEnumerable<FormDTO>>(forms);
        }

        public void Add(FormDTO formDTO)
        {
            try
            {
                Form form = Mapper.Map<Form>(formDTO);

                _unitOfWork.Forms.Create(form);
                _unitOfWork.Save();
            }
            catch (DbUpdateException)
            {
                if (NotUnique(formDTO.NumberForm))
                    throw new UniqueConstraintException();
            }
        }

        public void Update(FormDTO formDTO)
        {
            try
            {
                Form form = Mapper.Map<Form>(formDTO);

                _unitOfWork.Forms.Update(form);
                _unitOfWork.Save();
            }
            catch (DbUpdateException)
            {
                if (NotUnique(formDTO.NumberForm))
                    throw new UniqueConstraintException();
            }

        }

        public void Delete(int id)
        {
            if (HasRelations(id))
                throw new HasRelationsException();

            Form form = _unitOfWork.Forms.Get(id);

            if (form == null)
                throw new NotFoundException();

            _unitOfWork.Forms.Delete(id);
            _unitOfWork.Save();
        }

        public bool NotUnique(int numberForm)
        {
            var relationsCount = _unitOfWork.Forms.Find(h => h.NumberForm == numberForm).ToList().Count();
            return relationsCount > 0;
        }

        public bool HasRelations(int id)
        {
            var relations = _unitOfWork.Families.Find(h => h.FormId == id).Count();
            var relations2 = _unitOfWork.Datas.Find(h => h.FormId == id).Count();
            var relationCount = relations + relations2;
            return relationCount > 0;
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
