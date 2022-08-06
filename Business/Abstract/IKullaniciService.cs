using Entity.Concrete;
using Entity.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IKullaniciService : IGenericService<Kullanici>
    {
        List<KullaniciDTO> GetKullaniciDto();
        List<KullaniciDTO> GetAllByInactive();
        Kullanici GetByEmail(string email);
    }
}
