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
    public class DepartmanManager : IDepartmanService
    {
        IDepartmanDal _departmanDal;

        public DepartmanManager(IDepartmanDal depertmanDal)
        {
            _departmanDal = depertmanDal;
        }

        public void Add(Departman entity)
        {
            _departmanDal.Add(entity);
        }

        public void Delete(Departman entity)
        {
            _departmanDal.Delete(entity);
        }

        public List<Departman> GetAll()
        {
            return _departmanDal.GetAll();
        }

        public Departman GetById(int departmanId)
        {
            return _departmanDal.Get(d => d.DepartmanId == departmanId);
        }

        public void Update(Departman entity)
        {
            _departmanDal.Update(entity);
        }
    }
}
