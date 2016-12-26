using AutoMapper;
using Model;
using Repositories.Repositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebPetShop.Models;

namespace WebPetShop.Controllers
{
    public class HomeController : Controller
    {
        private readonly MascotaRepositorio _MascotasRepositorio = new MascotaRepositorio();
        public ActionResult Portal()
        {
            //Retornar la lista de todas las mascotas disponibles para su compra o adopcion
            var mascotaVM = Mapper.Map<IEnumerable<Mascota>, IEnumerable<MascotaViewModel>>(_MascotasRepositorio.GetAll());           
            return View(mascotaVM);
        }

        public ActionResult Index()
        {
            //Retornar la lista de todas las mascotas disponibles para su compra o adopcion
            //var mascotaVM = Mapper.Map<IEnumerable<Mascota>, IEnumerable<MascotaViewModel>>(_MascotasRepositorio.GetAll());
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