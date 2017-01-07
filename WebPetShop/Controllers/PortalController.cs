using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Model;
using AutoMapper;
using WebPetShop.ViewModels;
using Repositories.Repositorios;
using System.IO;

namespace WebPetShop.Controllers
{
    public class PortalController : Controller
    {
        private readonly MascotaRepositorio _MascotasRepositorio = new MascotaRepositorio();
        private readonly UsuarioRepositorio _UsuarioRepositorio = new UsuarioRepositorio();
        private readonly EstadoRepositorio _EstadoRepositorio = new EstadoRepositorio();
        private readonly AnimalRepositorio _AnimalRepositorio = new AnimalRepositorio();
        private readonly RazaRepositorio _RazaRepositorio = new RazaRepositorio();
        

        // GET: Mascotas
        public ActionResult Index()
        {
            var mascotaVM = Mapper.Map<IEnumerable<Mascota>, IEnumerable<MascotaViewModel>>(_MascotasRepositorio.GetAll());
            var usuarioVM = Mapper.Map<IEnumerable<Usuario>, IEnumerable<UsuarioViewModel>>(_UsuarioRepositorio.GetAll());
            var lstEstado = Mapper.Map<IEnumerable<Estado>, IEnumerable<EstadoViewModel>>(_EstadoRepositorio.GetAll());


            ViewBag.EstadoList = lstEstado;
            ViewData["EstadoLista"] = lstEstado;
            ViewBag.UsuarioVM = usuarioVM;

            return View(mascotaVM);
            //return View(db.Mascotas.ToList());
        }

        // GET: MisMascotas/Details/
        [Authorize]
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var lstEstado = Mapper.Map<IEnumerable<Estado>, IEnumerable<EstadoViewModel>>(_EstadoRepositorio.GetAll());
            var lstRaza = Mapper.Map<IEnumerable<Raza>, IEnumerable<RazaViewModel>>(_RazaRepositorio.GetAll());
            var lstAnimal = Mapper.Map<IEnumerable<Animal>, IEnumerable<AnimalViewModel>>(_AnimalRepositorio.GetAll());

            ViewBag.EstadoList = lstEstado;
            ViewBag.RazaList = lstRaza;
            ViewBag.AnimalList = lstAnimal;

            var mascotaVM = Mapper.Map<Mascota, MascotaViewModel>(_MascotasRepositorio.GetById(id));

            if (mascotaVM == null)
            {
                return HttpNotFound();
            }
            return View(mascotaVM);
        }

        [Authorize]
        public ActionResult Comprar(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var lstEstado = Mapper.Map<IEnumerable<Estado>, IEnumerable<EstadoViewModel>>(_EstadoRepositorio.GetAll());
            var lstRaza = Mapper.Map<IEnumerable<Raza>, IEnumerable<RazaViewModel>>(_RazaRepositorio.GetAll());
            var lstAnimal = Mapper.Map<IEnumerable<Animal>, IEnumerable<AnimalViewModel>>(_AnimalRepositorio.GetAll());

            ViewBag.EstadoList = lstEstado;
            ViewBag.RazaList = lstRaza;
            ViewBag.AnimalList = lstAnimal;

            var mascotaVM = Mapper.Map<Mascota, MascotaViewModel>(_MascotasRepositorio.GetById(id));

            if (mascotaVM == null)
            {
                return HttpNotFound();
            }
            return View(mascotaVM);
        }


        [HttpPost]
        [Authorize]
        public ActionResult Comprar(MascotaViewModel mascotaVM)
        {
            if (ModelState.IsValid)
            {               

                //string pic = string.Empty;
                //string path = string.Empty;

                //if (mascotaVM.imagen != null)
                //{
                //    pic = Path.GetFileName(mascotaVM.imagen.FileName);
                //    path = Path.Combine(Server.MapPath("~/Content/Images/Mascotas/MiMascota/"), pic);

                //    mascotaVM.imagen.SaveAs(path);
                //    using (MemoryStream ms = new MemoryStream())
                //    {
                //        mascotaVM.imagen.InputStream.CopyTo(ms);
                //        byte[] arrary = ms.GetBuffer();
                //    }
                //    mascotaVM.Foto = pic == string.Empty ? string.Empty : string.Format("~/Content/Images/Mascotas/MiMascota/{0}", pic);
                //}

                var emailUser = User.Identity.Name.ToString();
                mascotaVM.UsuarioID = _UsuarioRepositorio.GetIDUserByEmail(emailUser);
                mascotaVM.EstadoID = 4;
                mascotaVM.nEstado = "Vendida";
                var mascotaDomain = Mapper.Map<MascotaViewModel, Mascota>(mascotaVM);
                _MascotasRepositorio.Update(mascotaDomain);              
                return RedirectToAction("Index");
            }
            return View(mascotaVM);
        }
        [Authorize]
        public ActionResult Adoptar(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var lstEstado = Mapper.Map<IEnumerable<Estado>, IEnumerable<EstadoViewModel>>(_EstadoRepositorio.GetAll());
            var lstRaza = Mapper.Map<IEnumerable<Raza>, IEnumerable<RazaViewModel>>(_RazaRepositorio.GetAll());
            var lstAnimal = Mapper.Map<IEnumerable<Animal>, IEnumerable<AnimalViewModel>>(_AnimalRepositorio.GetAll());

            ViewBag.EstadoList = lstEstado;
            ViewBag.RazaList = lstRaza;
            ViewBag.AnimalList = lstAnimal;

            var mascotaVM = Mapper.Map<Mascota, MascotaViewModel>(_MascotasRepositorio.GetById(id));

            if (mascotaVM == null)
            {
                return HttpNotFound();
            }
            return View(mascotaVM);
        }

        [HttpPost]
        [Authorize]
        public ActionResult Adoptar(MascotaViewModel mascotaVM)
        {
            if (ModelState.IsValid)
            {               

                var emailUser = User.Identity.Name.ToString();
                mascotaVM.UsuarioID = _UsuarioRepositorio.GetIDUserByEmail(emailUser);
                mascotaVM.EstadoID = 3;
                mascotaVM.nEstado = "Adoptada";
                var mascotaDomain = Mapper.Map<MascotaViewModel, Mascota>(mascotaVM);
                _MascotasRepositorio.Update(mascotaDomain);               
                return RedirectToAction("Index");
            }
            return View(mascotaVM);
        }

        public ActionResult FiltrarDisponibles()
        {           
            var usuarioVM = Mapper.Map<IEnumerable<Usuario>, IEnumerable<UsuarioViewModel>>(_UsuarioRepositorio.GetAll());
            var lstEstado = Mapper.Map<IEnumerable<Estado>, IEnumerable<EstadoViewModel>>(_EstadoRepositorio.GetAll());


            ViewBag.EstadoList = lstEstado;
            //ViewData["EstadoLista"] = lstEstado;
            ViewBag.UsuarioVM = usuarioVM;

            var mascotaDispVM = Mapper.Map<IEnumerable<Mascota>, IEnumerable<MascotaViewModel>>(_MascotasRepositorio.GetAllByNotAdoptSales());

            return View("Index", mascotaDispVM);
        }

        [Authorize]
        public ActionResult FiltrarNoDisponibles()
        {
            var usuarioVM = Mapper.Map<IEnumerable<Usuario>, IEnumerable<UsuarioViewModel>>(_UsuarioRepositorio.GetAll());
            var lstEstado = Mapper.Map<IEnumerable<Estado>, IEnumerable<EstadoViewModel>>(_EstadoRepositorio.GetAll());


            ViewBag.EstadoList = lstEstado;
            //ViewData["EstadoLista"] = lstEstado;
            ViewBag.UsuarioVM = usuarioVM;

            var mascotaNoDispVM = Mapper.Map<IEnumerable<Mascota>, IEnumerable<MascotaViewModel>>(_MascotasRepositorio.GetAllByAdoptSales());
            return View("Index", mascotaNoDispVM);
        }
       
    }
}
