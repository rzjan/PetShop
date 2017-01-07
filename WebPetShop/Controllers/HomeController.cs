using AutoMapper;
using Model;
using Repositories.Repositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebPetShop.ViewModels;

namespace WebPetShop.Controllers
{
    public class HomeController : Controller
    {
        private readonly MascotaRepositorio _MascotasRepositorio = new MascotaRepositorio();
        private readonly EstadoRepositorio _EstadoRepositorio = new EstadoRepositorio();
        
        public ActionResult Portal()
        {
            //Retornar la lista de todas las mascotas disponibles para su compra o adopcion
            var mascotaVM = Mapper.Map<IEnumerable<Mascota>, IEnumerable<MascotaViewModel>>(_MascotasRepositorio.GetAll());           
            return View(mascotaVM);
        }

        public ActionResult Index()
        {
            //Retornar la lista de todas las mascotas disponibles para su compra o adopcion
           //ViewBag.MascotaList = _MascotasRepositorio.GetLastMascotasRegistered();
            var lstMascota = Mapper.Map<IEnumerable<Mascota>, IEnumerable<MascotaViewModel>>(_MascotasRepositorio.GetLastMascotasRegistered());
            var lstEstado = Mapper.Map<IEnumerable<Estado>, IEnumerable<EstadoViewModel>>(_EstadoRepositorio.GetAll());
            ViewBag.MascotaList = lstMascota;
            ViewBag.EstadoList = lstEstado;

            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}