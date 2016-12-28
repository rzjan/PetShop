using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Model;
using WebPetShop.Models;
using AutoMapper;
using Repositories.Repositorios;
using WebPetShop.ViewModels;

namespace WebPetShop.Controllers
{
    public class MisMascotasController : Controller
    {
        private readonly MascotaRepositorio _MascotasRepositorio = new MascotaRepositorio();
        private readonly AnimalRepositorio _AnimalRepositorio = new AnimalRepositorio();
        private readonly RazaRepositorio _RazaRepositorio = new RazaRepositorio();
        //private PetShopContext db = new PetShopContext();

        // GET: MisMascotas
        public ActionResult Index()
        {
            var mascotaVM = Mapper.Map<IEnumerable<Mascota>, IEnumerable<MascotaViewModel>>(_MascotasRepositorio.GetAll());
            return View(mascotaVM);
            //return View(db.MascotaViewModels.ToList());
        }

        // GET: MisMascotas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            //var clienteDomain = Mapper.Map<ClienteViewModel, Cliente>(cliente);
            //       _clienteRepository.Add(clienteDomain);

            var mascotaVM = Mapper.Map<Mascota, MascotaViewModel>(_MascotasRepositorio.GetById(id));
            //mascotaViewModel mascotaViewModel = db.MascotaViewModels.Find(id);
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
                SelectRaza = new SelectList(_RazaRepositorio.GetAll(), "RazaID", "DescripcionRaza")
            };

            //var AnimalList = new SelectList(Mapper.Map<IEnumerable<Animal>, IEnumerable<AnimalViewModel>>(_AnimalRepositorio.GetAll()), "AnimalID", "Descripcion");
            // ViewBag.AnimalModel = AnimalList;

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
                    mascotaVM.FechaAlta = DateTime.Now;
                    //mascotaVM.AnimalID = _AnimalRepositorio.GetById(mascotaVM.AnimalID);
                    //mascotaVM.AnimalID = _AnimalRepositorio.GetById(mascotaVM.Animal.AnimalID);

                    var mascotaDomain = Mapper.Map<MascotaViewModel, Mascota>(mascotaVM);
                    _MascotasRepositorio.Add(mascotaDomain);

                    return RedirectToAction("Index");
                }
                // TODO: Add insert logic here
                return View(mascotaVM);
            }
            catch
            {
                return View();
            }

        }

        // POST: MisMascotas/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Create([Bind(Include = "MascotaID,Nombre,Edad,FechaNacimiento,Estado,Foto,FechaAlta")] MascotaViewModel mascotaViewModel)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        db.MascotaViewModels.Add(mascotaViewModel);
        //        db.SaveChanges();
        //        return RedirectToAction("Index");
        //    }

        //    return View(mascotaViewModel);
        //}

        // GET: MisMascotas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var mascotaVM = Mapper.Map<Mascota, MascotaViewModel>(_MascotasRepositorio.GetById(id));

            var animalList = _AnimalRepositorio.GetAll();
            var razaList = _RazaRepositorio.GetAll();
            //var regionList = regionRepository.GetAll();

            //var territoryList = territoryRepository.Filter(x => x.RegionID == RegionId);

           
            //EmployeeModel model = new EmployeeModel()
            MascotaViewModel model = new MascotaViewModel()
            {
                SelectAnimal = new SelectList(animalList, "AnimalID", "Descripcion"),
                AnimalID = mascotaVM.AnimalID,

                SelectRaza = new SelectList(razaList, "AnimalID", "Descripcion"),
                RazaID = mascotaVM.RazaID,
               // TerritoryList = new SelectList(territoryList, "TerritoryID", "Description")
            };

            if (model == null)
            {
                return HttpNotFound();
            }

            //return View(mascotaVM);

            return View(model);



            //ViewBag.SelectAnimalID = _AnimalRepositorio.GetAll().Select(a => new SelectListItem
            //{
            //    Value = a.AnimalID.ToString(),
            //    Text = a.Descripcion,
            //});

            //ViewBag.SelectRazaId = _RazaRepositorio.GetAll().Select(r => new SelectListItem
            //{
            //    Value = r.RazaID.ToString(),
            //    Text = r.DescripcionRaza,
            //});
            //MascotaViewModel mVM = new MascotaViewModel()
            //{
            //    SelectAnimal =  SelectAnimals;
                //SelectAnimal =( _AnimalRepositorio.GetAll().Select(a => new SelectListItem{
                //        Value = a.AnimalID.ToString(),
                //        Text = a.Descripcion,
                //})).ToList()

                //SelectAnimal = _AnimalRepositorio.GetById(SelectAnimal)
                //SelectAnimal = new SelectList(_AnimalRepositorio.GetAll(), "AnimalID", "Descripcion"),
                //SelectRaza = new SelectList(_RazaRepositorio.GetAll(), "RazaID", "DescripcionRaza")
            //};

            //aqui recuperas la entidad de la db
            //y asignas el valor asignado al modelo

               



            
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
                var mascotaDomain = Mapper.Map<MascotaViewModel, Mascota>(mascotaVM);
                _MascotasRepositorio.Update(mascotaDomain);

                //db.Entry(mascotaViewModel).State = EntityState.Modified;
                //db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(mascotaVM);
        }

        // GET: MisMascotas/Delete/5
        //public ActionResult Delete(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    MascotaViewModel mascotaViewModel = db.MascotaViewModels.Find(id);
        //    if (mascotaViewModel == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(mascotaViewModel);
        //}

        // POST: MisMascotas/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public ActionResult DeleteConfirmed(int id)
        //{
        //    MascotaViewModel mascotaViewModel = db.MascotaViewModels.Find(id);
        //    //db.MascotaViewModels.Remove(mascotaViewModel);
        //    //db.SaveChanges();
        //    return RedirectToAction("Index");
        //}

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
