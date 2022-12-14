using Business.Abstract;
using DataAccess.Abstract;
using Entity.Concrete;
using Entity.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class MasaManager : IMasaService
    {
        IMasaDal _masaDal;

        public MasaManager(IMasaDal masaDal)
        {
            _masaDal = masaDal;
        }

        public void Add(Masa entity)
        {
            _masaDal.Add(entity);
        }

        public void Delete(Masa entity)
        {
            _masaDal.Delete(entity);
        }

        public List<Masa> GetAll()
        {
            return _masaDal.GetAll(m => m.Aktif == true);
        }

        public Masa GetById(int id)
        {
            return _masaDal.Get(m => m.MasaId == id);
        }

        public List<Masa> GetByOfisId(int id)
        {
            return _masaDal.GetAll(m => m.OfisId == id);
        }

        public List<Masa> GetInactive()
        {
            return _masaDal.GetAll(m => m.Aktif == false);
        }

        public List<MasaDTO> GetInactiveMasaDto()
        {
            return _masaDal.GetInactiveMasaDto();
        }

        public List<MasaDTO> GetMasaDto()
        {
            return _masaDal.GetMasaDto();
        }

        public void Update(Masa entity)
        {
            _masaDal.Update(entity);
        }
    }
}
