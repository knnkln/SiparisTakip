using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using SiparisTakip.Dal.Abstract.KullaniciDal;
using SiparisTakip.Dal.Abstract.StokDal;
using SiparisTakip.Interfaces.Stok;
using SiparisTakip.Dal.Concrete.EntityFramework.Repository;
using SiparisTakip.Interfaces.Kullanici;

namespace SiparisTakip.Bll.Kullanici
{
    public class KullaniciManager : IKullaniciService
    {
        private IKullaniciDal _kullaniciDal;

        public KullaniciManager(IKullaniciDal kullaniciDal)
        {
            _kullaniciDal = kullaniciDal;
        }

        public Entity.Models.Kullanici Kaydet(Entity.Models.Kullanici entity)
        {
            return _kullaniciDal.Kaydet(entity);
        }

        public List<Entity.Models.Kullanici> Listele()
        {
            return _kullaniciDal.Listele();
        }

        public List<Entity.Models.Kullanici> Listele(Expression<Func<Entity.Models.Kullanici, bool>> predicateExpression)
        {
            return _kullaniciDal.Listele(predicateExpression);
        }

        public Entity.Models.Kullanici Getir(int id)
        {
            return _kullaniciDal.Getir(id);
        }

        public int Guncelle(Entity.Models.Kullanici entity)
        {
            return _kullaniciDal.Guncelle(entity);
        }

        public bool Sil(int id)
        {
            return _kullaniciDal.Sil(id);
        }

        public bool Sil(Entity.Models.Kullanici entity)
        {
            return _kullaniciDal.Sil(entity);
        }

        public Entity.Models.Kullanici KullaniciGiris(string kullaniciAdi, string kullaniciSifre)
        {
            try
            {
                if (String.IsNullOrWhiteSpace(kullaniciAdi.Trim()) || String.IsNullOrWhiteSpace(kullaniciAdi.Trim()))
                {
                    throw new Exception("Kullanıcı Adı ve Sifre Boş Geçilemez");
                }

                var sifre = new ToPasswordRepository().Md5(kullaniciSifre);
                Entity.Models.Kullanici kullanici = _kullaniciDal.KullaniciGiris(kullaniciAdi, sifre);

                if (kullanici == null)
                    throw new Exception("Kullanıcı Adı veya Şifre Hatalı");
                else
                    return kullanici;
            }
            catch (Exception e)
            {
                throw new Exception("Kullanıcı giriş Hata : " + e.Message);
            }
        }
    }
}
