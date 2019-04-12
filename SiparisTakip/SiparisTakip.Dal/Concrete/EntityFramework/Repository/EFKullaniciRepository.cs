using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using SiparisTakip.Dal.Abstract.KullaniciDal;
using SiparisTakip.Dal.Concrete.EntityFramework.Context;
using SiparisTakip.Entity.Models;

namespace SiparisTakip.Dal.Concrete.EntityFramework.Repository
{
    public class EFKullaniciRepository : IKullaniciDal
    {
        public Kullanici Kaydet(Kullanici entity)
        {
            using (SiparisTakipContext context = new SiparisTakipContext())
            {
                context.Kullanici.Add(entity);
                context.SaveChanges();
                return entity;
            }
        }

        public List<Kullanici> Listele()
        {
            using (SiparisTakipContext context = new SiparisTakipContext())
            {
                return context.Kullanici.AsNoTracking().ToList();
            }
        }

        public List<Kullanici> Listele(Expression<Func<Kullanici, bool>> predicateExpression)
        {
            using (SiparisTakipContext context = new SiparisTakipContext())
            {
                return context.Kullanici.AsNoTracking().Where(predicateExpression).ToList();
            }
            throw new NotImplementedException();
        }

        public Kullanici Getir(int id)
        {
            using (SiparisTakipContext context = new SiparisTakipContext())
            {
                return context.Kullanici.AsNoTracking().SingleOrDefault(x => x.KullaniciID == id);
            }
        }

        public int Guncelle(Kullanici entity)
        {
            using (SiparisTakipContext context = new SiparisTakipContext())
            {
                context.Kullanici.AddOrUpdate(entity);
                return context.SaveChanges();
            }
        }

        public bool Sil(int id)
        {
            using (SiparisTakipContext context = new SiparisTakipContext())
            {
                Kullanici silinecek = Getir(id);
                return Sil(silinecek);
            }

        }

        public bool Sil(Kullanici entity)
        {
            using (SiparisTakipContext context = new SiparisTakipContext())
            {
                context.Kullanici.Remove(entity);
                return context.SaveChanges() > 0;
            }
        }

        public Kullanici KullaniciGiris(string kullaniciAdi, string kullaniciSifre)
        {
            using (SiparisTakipContext context = new SiparisTakipContext())
            {
                return context.Kullanici.Where(x => x.KullaniciKodu == kullaniciAdi && x.Sifre == kullaniciSifre).SingleOrDefault();

            }
        }
    }
}
