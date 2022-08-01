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
    public class OfisManager : IOfisService
    {
        IOfisDal _ofisDal;

        public OfisManager(IOfisDal ofisDal)
        {
            _ofisDal = ofisDal;
        }

        public void Add(Ofis entity)
        {
            _ofisDal.Add(entity);
        }

        public void Delete(Ofis entity)
        {
            _ofisDal.Delete(entity);
        }

        public List<Ofis> GetAll()
        {
            return _ofisDal.GetAll();
        }

        public Ofis GetById(int id)
        {
            return _ofisDal.Get(o => o.OfisId == id);
        }

        public void Update(Ofis entity)
        {
            _ofisDal.Update(entity);
        }
    }
}
