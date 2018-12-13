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
    public class DistrictService : IDistrictService
    {
        private IUnitOfWork _unitOfWork { get; set; }
        public DistrictService(IUnitOfWork uow)
        {
            _unitOfWork = uow;
        }

        public DistrictDTO Get(int id)
        {
            District district = _unitOfWork.Districts.Get(id);

            return Mapper.Map<DistrictDTO>(district);
        }

        public DistrictDTO Get(int? id)
        {
            if (id == null)
                throw new ArgumentNullException();

            District district = _unitOfWork.Districts.Get(id);
            if (district == null)
                throw new NotFoundException();

            return Mapper.Map<DistrictDTO>(district);
        }

        public IEnumerable<DistrictDTO> GetAll()
        {
            List<District> districts = _unitOfWork.Districts.GetAll().ToList();

            return Mapper.Map<IEnumerable<DistrictDTO>>(districts);
        }

        public IEnumerable<DistrictDTO> GetListOrderedByName()
        {
            List<District> districts = _unitOfWork.Districts.GetAll().OrderBy(n => n.Name).ToList();

            return Mapper.Map<IEnumerable<DistrictDTO>>(districts);
        }

        public void Add(DistrictDTO districtDTO)
        {
            District district = Mapper.Map<District>(districtDTO);
            _unitOfWork.Districts.Create(district);
            _unitOfWork.Save();
        }

        public void Update(DistrictDTO districtDTO)
        {
            District district = Mapper.Map<District>(districtDTO);

            _unitOfWork.Districts.Update(district);
            _unitOfWork.Save();
        }


        public void Delete(int id)
        {
            if (HasRelations(id))
                throw new HasRelationsException();

            _unitOfWork.Districts.Delete(id);
            _unitOfWork.Save();
        }

        public bool HasRelations(int id)
        {
            var relations = _unitOfWork.Forms.Find(h => h.DistrictId == id);

            return relations.Count() > 0;
        }

        public void Dispose()
        {
            _unitOfWork.Dispose();
        }
    }
}
