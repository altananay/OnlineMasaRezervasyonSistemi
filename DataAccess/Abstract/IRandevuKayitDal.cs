using Core.DataAccess;
using Entity.Concrete;
using Entity.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Abstract
{
    public interface IRandevuKayitDal : IEntityRepository<RandevuKayit>
    {
        RandevuDTO GetRandevuDto();
        List<RandevuDTO> GetAllRandevuDtoById(int id);
    }
}
