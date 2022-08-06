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
    public class DurumManager : IDurumService
    {
        IDurumDal _durumDal;
        public DurumManager(IDurumDal durumDal)
        {
            _durumDal = durumDal;
        }

        public void Add(Durum entity)
        {
            _durumDal.Add(entity);
        }

        public void Delete(Durum entity)
        {
            _durumDal.Delete(entity);
        }

        public List<Durum> GetAll()
        {
            return _durumDal.GetAll();
        }

        public Durum GetById(int id)
        {
            return _durumDal.Get(d => d.DurumId == id);
        }

        public void Update(Durum entity)
        {
            _durumDal.Update(entity);
        }
    }
}
