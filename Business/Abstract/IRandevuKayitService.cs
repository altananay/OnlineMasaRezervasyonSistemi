using Entity.Concrete;
using Entity.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IRandevuKayitService : IGenericService<RandevuKayit>
    {
        RandevuDTO GetRandevuDto();
        List<RandevuKayit> GetAllById(int id);
        List<RandevuDTO> GetAllRandevuDtoById(int id);
    }
}
