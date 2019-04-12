using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using SiparisTakip.Dal.Abstract.FaturaDal;
using SiparisTakip.Dal.Concrete.EntityFramework.Context;
using SiparisTakip.Entity.Models;

namespace SiparisTakip.Dal.Concrete.EntityFramework.Repository
{
    public class EFFaturaRepository : IFaturaDal
    {
        public Fatura Kaydet(Fatura entity)
        {
            using (SiparisTakipContext context = new SiparisTakipContext())
            {
                context.Fatura.Add(entity);
                context.SaveChanges();
                return entity;
            }
        }

        public List<Fatura> Listele()
        {
            using (SiparisTakipContext context = new SiparisTakipContext())
            {
                return context.Fatura.AsNoTracking().ToList();
            }
        }

        public List<Fatura> Listele(Expression<Func<Fatura, bool>> predicateExpression)
        {
            using (SiparisTakipContext context = new SiparisTakipContext())
            {
                return context.Fatura.AsNoTracking().Where(predicateExpression).ToList();
            }
        }

        public Fatura Getir(int id)
        {
            using (SiparisTakipContext context = new SiparisTakipContext())
            {
                return context.Fatura.AsNoTracking().SingleOrDefault(x => x.FaturaID == id);
            }
        }

        public int Guncelle(Fatura entity)
        {
            using (SiparisTakipContext context = new SiparisTakipContext())
            {
                context.Fatura.AddOrUpdate(entity);
                return context.SaveChanges();
            }
        }

        public bool Sil(int id)
        {
            using (SiparisTakipContext context = new SiparisTakipContext())
            {
                Fatura silinecek = Getir(id);
                return Sil(silinecek);
            }
        }

        public bool Sil(Fatura entity)
        {
            using (SiparisTakipContext context = new SiparisTakipContext())
            {
                context.Fatura.Remove(entity);
                return context.SaveChanges() > 0;
            }
        }

        public IQueryable FaturaRaporu(DateTime baslangic, DateTime bitis)
        {
            throw new NotImplementedException();
        }
    }
}
