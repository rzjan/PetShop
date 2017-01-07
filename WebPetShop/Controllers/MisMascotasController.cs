using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Model;
using WebPetShop.ViewModels;
using AutoMapper;
using Repositories.Repositorios;
using WebPetShop.Helper;
using System.IO;
using System.Globalization;

namespace WebPetShop.Controllers
{
    [Authorize]
    public class MisMascotasController : Controller
    {
        private readonly MascotaRepositorio _MascotasRepositorio = new MascotaRepositorio();
        private readonly AnimalRepositorio _AnimalRepositorio = new AnimalRepositorio();
        private readonly RazaRepositorio _RazaRepositorio = new RazaRepositorio();
        private readonly UsuarioRepositorio _UsuarioRepositorio = new UsuarioRepositorio();
        private readonly EstadoRepositorio _EstadoRepositorio = new EstadoRepositorio();
        

        //private PetShopContext db = new PetShopContext();

        // GET: MisMascotas
      
        public ActionResult Index()
        {            
            string emailUser = User.Identity.Name;
            int _usuarioID = _UsuarioRepositorio.GetIDUserByEmail(emailUser);
           
            var lstEstado = Mapper.Map<IEnumerable<Estado>, IEnumerable<EstadoViewModel>>(_EstadoRepositorio.GetAll());
            var lstRaza = Mapper.Map<IEnumerable<Raza>, IEnumerable<RazaViewModel>>(_RazaRepositorio.GetAll());       
          
            var mascotaVM = Mapper.Map<IEnumerable<Mascota>, IEnumerable<MascotaViewModel>>(_MascotasRepositorio.GetAllByUser(_usuarioID));  
          
            ViewBag.RazaList = lstRaza;
            ViewBag.EstadoList = lstEstado;                       
           
            return View(mascotaVM);          
        }

        // GET: MisMascotas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var lstEstado = Mapper.Map<IEnumerable<Estado>, IEnumerable<EstadoViewModel>>(_EstadoRepositorio.GetAll());
            ViewBag.EstadoList = lstEstado;
            var mascotaVM = Mapper.Map<Mascota, MascotaViewModel>(_MascotasRepositorio.GetById(id));

            if (mascotaVM == null)
            {
                return HttpNotFound();
            }
            return View(mascotaVM);
        }

        // GET: MisMascotas/Create
        public ActionResult Create()
        {
            MascotaViewModel mascotaVM = new MascotaViewModel()
            {
                SelectAnimal = new SelectList(_AnimalRepositorio.GetAll(), "AnimalID", "Descripcion"),
                SelectRaza = new SelectList(_RazaRepositorio.GetAll(), "RazaID", "DescripcionRaza"),
                SelectEstado = new SelectList(_EstadoRepositorio.GetAll(), "EstadoID", "EstadoDescripcion")

            };
            return View(mascotaVM);
        }            


        // POST: MisMascotas/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(MascotaViewModel mascotaVM)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    //Upload Image
                    string pic = string.Empty;
                    string path = string.Empty;

                    if (mascotaVM.imagen != null)
                    {
                        pic = Path.GetFileName(mascotaVM.imagen.FileName);
                        path = Path.Combine(Server.MapPath("~/Content/Images/Mascotas/MiMascota/"), pic);

                        mascotaVM.imagen.SaveAs(path);
                        using (MemoryStream ms = new MemoryStream())
                        {
                            mascotaVM.imagen.InputStream.CopyTo(ms);
                            byte[] arrary = ms.GetBuffer();                          
                        }
                    }
                    var _estado = _EstadoRepositorio.GetAll();

                    foreach (var item in _estado)
                    {
                        if (item.EstadoID == mascotaVM.EstadoID) {
                            mascotaVM.nEstado = item.EstadoDescripcion;
                        }
                        
                    }
                    mascotaVM.Foto = pic == string.Empty ? string.Empty : string.Format("~/Content/Images/Mascotas/MiMascota/{0}", pic);
                    mascotaVM.FechaAlta = DateTime.Now;
                    //Obtengo el usuario identity logueado                   
                    var emailUser = User.Identity.Name.ToString();
                    mascotaVM.UsuarioID = _UsuarioRepositorio.GetIDUserByEmail(emailUser);                 

                    var mascotaDomain = Mapper.Map<MascotaViewModel, Mascota>(mascotaVM);

                    _MascotasRepositorio.Add(mascotaDomain);
                    return RedirectToAction("Index");
                   
                }
             
                return View(mascotaVM);
            }
            catch
            {
                return View();
            }

        }        

        // GET: MisMascotas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var lstEstado = Mapper.Map<IEnumerable<Estado>, IEnumerable<EstadoViewModel>>(_EstadoRepositorio.GetAll());
            ViewBag.EstadoList = lstEstado;

            var mascotaVM = Mapper.Map<Mascota, MascotaViewModel>(_MascotasRepositorio.GetById(id));

            if (mascotaVM == null)
            {
                return HttpNotFound();
            }
            //ConversorHelper _conversorHelper = new ConversorHelper();

            var animalList = _AnimalRepositorio.GetAll();
            var razaList = _RazaRepositorio.GetAll();
            var estadoList = _EstadoRepositorio.GetAll();

            var animalSelect = _AnimalRepositorio.Filter(x => x.AnimalID == mascotaVM.AnimalID);

            
            mascotaVM.SelectAnimal = new SelectList(animalList, "AnimalID", "Descripcion", mascotaVM.AnimalID);
            mascotaVM.SelectRaza = new SelectList(razaList, "RazaID", "DescripcionRaza", mascotaVM.RazaID);
            mascotaVM.SelectEstado = new SelectList(estadoList, "EstadoID", "EstadoDescripcion", mascotaVM.EstadoID);

            ViewBag.ListaEstado = estadoList;

            //DateTime dt = DateTime.ParseExact(mascotaVM.FechaNacimiento.ToString(), "MM/dd/yyyy hh:mm:ss tt", CultureInfo.InvariantCulture);
            //string s = dt.ToString("dd/M/yyyy", CultureInfo.InvariantCulture);
            //mascotaVM.FecNac = _conversorHelper.convertStringToDateTime(mascotaVM.FechaNacimiento);




            //mascotaVM.FechaAlta = mascotaVM.FechaAlta
            //mascotaVM.Foto = string.Empty;
            return View(mascotaVM);

        }

        // POST: MisMascotas/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(MascotaViewModel mascotaVM)
        {
           
            if (ModelState.IsValid)
            {                               
                string pic = string.Empty;
                string path = string.Empty;

                if (mascotaVM.imagen != null)
                {
                    pic = Path.GetFileName(mascotaVM.imagen.FileName);
                    path = Path.Combine(Server.MapPath("~/Content/Images/Mascotas/MiMascota/"), pic);

                    mascotaVM.imagen.SaveAs(path);
                    using (MemoryStream ms = new MemoryStream())
                    {
                        mascotaVM.imagen.InputStream.CopyTo(ms);
                        byte[] arrary = ms.GetBuffer();                       
                    }
                    mascotaVM.Foto = pic == string.Empty ? string.Empty : string.Format("~/Content/Images/Mascotas/MiMascota/{0}", pic);                   
                }      
                    var emailUser = User.Identity.Name.ToString();
                    mascotaVM.UsuarioID = _UsuarioRepositorio.GetIDUserByEmail(emailUser);   
                    var mascotaDomain = Mapper.Map<MascotaViewModel, Mascota>(mascotaVM);
                    _MascotasRepositorio.Update(mascotaDomain);
             
                    return RedirectToAction("Index");
            }
            return View(mascotaVM);
        }        

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _MascotasRepositorio.Dispose();
                //db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
