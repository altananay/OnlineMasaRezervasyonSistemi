using Business.Abstract;
using DataAccess.Abstract;
using Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class RandevuKatilimcisiManager : IRandevuKatilimcisiService
    {
        IRandevuKatilimcisiDal _randevuKatilimcisiDal;

        public RandevuKatilimcisiManager(IRandevuKatilimcisiDal randevuKatilimcisiDal)
        {
            _randevuKatilimcisiDal = randevuKatilimcisiDal;
        }

        public void Add(RandevuKatilimcisi entity)
        {
            _randevuKatilimcisiDal.Add(entity);
        }

        public void Delete(RandevuKatilimcisi entity)
        {
            _randevuKatilimcisiDal.Delete(entity);
        }

        public List<RandevuKatilimcisi> GetAll()
        {
            return _randevuKatilimcisiDal.GetAll(rka => rka.Aktif == true); 
        }

        public RandevuKatilimcisi GetById(int id)
        {
            return _randevuKatilimcisiDal.Get(rka => rka.RandevuKatilimciId == id);
        }

        public void Update(RandevuKatilimcisi entity)
        {
            _randevuKatilimcisiDal.Update(entity);
        }
    }
}
