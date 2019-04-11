using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using SiparisTakip.Interfaces.Stok;
using SiparisTakip.Dal.Concrete.EntityFramework.Repository;

namespace SiparisTakip.Bll.Stok
{
    class StokManager : IStokService
    {
        EFStokRepository _EFStokRepository;

        public StokManager(EFStokRepository EFStokRepository)
        {
            _EFStokRepository = _EFStokRepository;
        }

        public Entity.Models.Stok Kaydet(Entity.Models.Stok entity)
        {
            return _EFStokRepository.Kaydet(entity);
        }

        public List<Entity.Models.Stok> Listele()
        {
            return _EFStokRepository.Listele();
        }

        public List<Entity.Models.Stok> Listele(Expression<Func<Entity.Models.Stok, bool>> predicateExpression)
        {
            return _EFStokRepository.Listele(predicateExpression);
        }

        public Entity.Models.Stok Getir(int id)
        {
            return _EFStokRepository.Getir(id);
        }

        public int Guncelle(Entity.Models.Stok entity)
        {
            return _EFStokRepository.Guncelle(entity);
        }

        public bool Sil(int id)
        {
            return _EFStokRepository.Sil(id);
        }

        public bool Sil(Entity.Models.Stok entity)
        {
            return _EFStokRepository.Sil(entity);
        }
    }
}
