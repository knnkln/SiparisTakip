using SiparisTakip.Dal.Abstract.StokDal;
using SiparisTakip.Dal.Concrete.EntityFramework.Context;
using SiparisTakip.Entity.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Linq.Expressions;

namespace SiparisTakip.Dal.Concrete.EntityFramework.Repository
{
    public class EFStokRepository : IStokDal
    {
        public Stok Kaydet(Stok entity)
        {
            using (SiparisTakipContext context = new SiparisTakipContext())
            {
                context.Stok.Add(entity);
                context.SaveChanges();
                return entity;
            }
        }

        public List<Stok> Listele()
        {
            using (SiparisTakipContext context = new SiparisTakipContext())
            {
                return context.Stok.AsNoTracking().ToList();
            }
        }

        public List<Stok> Listele(Expression<Func<Stok, bool>> predicateExpression)
        {
            using (SiparisTakipContext context = new SiparisTakipContext())
            {
                return context.Stok.AsNoTracking().Where(predicateExpression).ToList();
            }
        }

        public Stok Getir(int id)
        {
            using (SiparisTakipContext context = new SiparisTakipContext())
            {
                return context.Stok.AsNoTracking().SingleOrDefault(x => x.StokID == id);
            }
        }

        public int Guncelle(Stok entity)
        {
            using (SiparisTakipContext context = new SiparisTakipContext())
            {
                context.Stok.AddOrUpdate(entity);
                return context.SaveChanges();
            }
        }

        public bool Sil(int id)
        {
            using (SiparisTakipContext context = new SiparisTakipContext())
            {
                Stok silinecek = Getir(id);
                return Sil(silinecek);
            }
        }

        public bool Sil(Stok entity)
        {
            using (SiparisTakipContext context = new SiparisTakipContext())
            {
                context.Stok.Remove(entity);
                return context.SaveChanges() > 0;
            }
        }
    }
}
