using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using SiparisTakip.Dal.Abstract.FaturaDal;
using SiparisTakip.Interfaces.Fatura;

namespace SiparisTakip.Bll.Fatura
{
    public class FaturaManager: IFaturaService
    {
        private IFaturaDal _faturaDal;

        public FaturaManager(IFaturaDal faturaDal)
        {
            _faturaDal = faturaDal;
        }

        public Entity.Models.Fatura Kaydet(Entity.Models.Fatura entity)
        {
            return _faturaDal.Kaydet(entity);
        }

        public List<Entity.Models.Fatura> Listele()
        {
            return _faturaDal.Listele();
        }

        public List<Entity.Models.Fatura> Listele(Expression<Func<Entity.Models.Fatura, bool>> predicateExpression)
        {
            return _faturaDal.Listele(predicateExpression);
        }

        public Entity.Models.Fatura Getir(int id)
        {
            return _faturaDal.Getir(id);
        }

        public int Guncelle(Entity.Models.Fatura entity)
        {
            return _faturaDal.Guncelle(entity);
        }

        public bool Sil(int id)
        {
            return _faturaDal.Sil(id);
        }

        public bool Sil(Entity.Models.Fatura entity)
        {
            return _faturaDal.Sil(entity);
        }

        public IQueryable FaturaRaporu(DateTime baslangic, DateTime bitis)
        {
            throw new NotImplementedException();
        }
    }
}
