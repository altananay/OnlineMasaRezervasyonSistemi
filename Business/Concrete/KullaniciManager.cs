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
    public class KullaniciManager : IKullaniciService
    {
        IKullaniciDal _kullaniciDal;

        public KullaniciManager(IKullaniciDal kullaniciDal)
        {
            _kullaniciDal = kullaniciDal;
        }

        public void Add(Kullanici entity)
        {
            _kullaniciDal.Add(entity);
        }

        public void Delete(Kullanici entity)
        {
            _kullaniciDal.Delete(entity);
        }

        public List<Kullanici> GetAll()
        {
            return _kullaniciDal.GetAll();
        }

        public Kullanici GetById(int id)
        {
            return _kullaniciDal.Get(k => k.KullaniciId == id);
        }

        public List<KullaniciDTO> GetKullaniciDto()
        {
            return _kullaniciDal.GetKullaniciDto();
        }

        public void Update(Kullanici entity)
        {
            _kullaniciDal.Update(entity);
        }
    }
}
