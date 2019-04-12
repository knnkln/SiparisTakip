using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using SiparisTakip.Dal.Abstract.StokDal;
using SiparisTakip.Interfaces.Stok;
using SiparisTakip.Dal.Concrete.EntityFramework.Repository;

namespace SiparisTakip.Bll.Stok
{
    class StokManager : IStokService
    {
        private IStokDal _stokDal;

        public StokManager(IStokDal stokDal)
        {
            _stokDal = stokDal;
        }

        public Entity.Models.Stok Kaydet(Entity.Models.Stok entity)
        {
            return _stokDal.Kaydet(entity);
        }

        public List<Entity.Models.Stok> Listele()
        {
            return _stokDal.Listele();
        }

        public List<Entity.Models.Stok> Listele(Expression<Func<Entity.Models.Stok, bool>> predicateExpression)
        {
            return _stokDal.Listele(predicateExpression);
        }

        public Entity.Models.Stok Getir(int id)
        {
            return _stokDal.Getir(id);
        }

        public int Guncelle(Entity.Models.Stok entity)
        {
            return _stokDal.Guncelle(entity);
        }

        public bool Sil(int id)
        {
            return _stokDal.Sil(id);
        }

        public bool Sil(Entity.Models.Stok entity)
        {
            return _stokDal.Sil(entity);
        }
    }
}
