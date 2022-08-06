using Entity.Concrete;
using Entity.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IMasaService : IGenericService<Masa>
    {
        List<MasaDTO> GetMasaDto();
        List<MasaDTO> GetInactiveMasaDto();
        List<Masa> GetByOfisId(int id);
        List<Masa> GetInactive();
    }
}
