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
    public class HousingTypeService : IHousingTypeService
    {
        private IUnitOfWork _unitOfWork { get; set; }
        public HousingTypeService(IUnitOfWork uow)
        {
            _unitOfWork = uow;
        }

        public HousingTypeDTO Get(int id)
        {
            HousingType housingType = _unitOfWork.HousingTypes.Get(id);

            return Mapper.Map<HousingTypeDTO>(housingType);
        }

        public HousingTypeDTO Get(int? id)
        {
            if (id == null)
                throw new ArgumentNullException();

            HousingType housingType = _unitOfWork.HousingTypes.Get(id);
            if (housingType == null)
                throw new NotFoundException();

            return Mapper.Map<HousingTypeDTO>(housingType);
        }

        public IEnumerable<HousingTypeDTO> GetAll()
        {
            List<HousingType> housingTypes = _unitOfWork.HousingTypes.GetAll().ToList();

            return Mapper.Map<IEnumerable<HousingTypeDTO>>(housingTypes);
        }

        public IEnumerable<HousingTypeDTO> GetListOrderedByName()
        {
            List<HousingType> housingTypes = _unitOfWork.HousingTypes.GetAll().OrderBy(n => n.Name).ToList();

            return Mapper.Map<IEnumerable<HousingTypeDTO>>(housingTypes);
        }

        public void Add(HousingTypeDTO housingTypeDTO)
        {
            HousingType housingType = Mapper.Map<HousingType>(housingTypeDTO);
            _unitOfWork.HousingTypes.Create(housingType);
            _unitOfWork.Save();
        }

        public void Update(HousingTypeDTO housingTypeDTO)
        {
            HousingType housingType = Mapper.Map<HousingType>(housingTypeDTO);

            _unitOfWork.HousingTypes.Update(housingType);
            _unitOfWork.Save();
        }


        public void Delete(int id)
        {
            if (HasRelations(id))
                throw new HasRelationsException();

            _unitOfWork.HousingTypes.Delete(id);
            _unitOfWork.Save();
        }

        public bool HasRelations(int id)
        {
            var relations = _unitOfWork.Forms.Find(h => h.HousingTypeId == id);

            return relations.Count() > 0;
        }

        public void Dispose()
        {
            _unitOfWork.Dispose();
        }
    }
}
