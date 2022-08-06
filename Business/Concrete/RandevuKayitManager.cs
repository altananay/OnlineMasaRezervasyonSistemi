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
    public class RandevuKayitManager : IRandevuKayitService
    {
        IRandevuKayitDal _randevuKayitDal;

        public RandevuKayitManager(IRandevuKayitDal randevuKayitDal)
        {
            _randevuKayitDal = randevuKayitDal;
        }

        public void Add(RandevuKayit entity)
        {
            _randevuKayitDal.Add(entity);
        }

        public void Delete(RandevuKayit entity)
        {
            _randevuKayitDal.Delete(entity);
        }

        public List<RandevuKayit> GetAll()
        {
            return _randevuKayitDal.GetAll();
        }

        public RandevuKayit GetById(int id)
        {
            return _randevuKayitDal.Get(rk => rk.RandevuId == id);
        }

        public RandevuDTO GetRandevuDto()
        {
            return _randevuKayitDal.GetRandevuDto();
        }

        public void Update(RandevuKayit entity)
        {
            _randevuKayitDal.Update(entity);
        }
    }
}
