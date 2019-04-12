using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SiparisTakip.Bll.Kullanici;
using SiparisTakip.Dal.Concrete.EntityFramework.Repository;
using SiparisTakip.Entity.Models;
using SiparisTakip.Interfaces.Kullanici;

namespace SiparisTakip.AspNetMvcUI.Controllers
{
    public class KullaniciController : Controller
    {
        private IKullaniciService _kullaniciService = new KullaniciManager(new EFKullaniciRepository());

        [HttpGet]
        public ActionResult KullaniciGiris()
        {
            return View();
        }

        [HttpPost]
        public JsonResult KullaniciGiris(Kullanici kullanici)
        {
            try
            {
                var _kullanici = _kullaniciService.KullaniciGiris(kullanici.KullaniciAdi, kullanici.Parola);
                if (_kullanici != null)
                {
                    Session["KullaniciId"] = _kullanici.KullaniciID;
                    Session["KullaniciAdi"] = _kullanici.KullaniciAdi + " " + _kullanici.KullaniciSoyadi;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }

            return null;
        }
    }
}