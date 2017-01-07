


using System;
using System.Collections.Generic;
using Model;
using Repositories.InfraEstructura;
using Repositories.InfraEstructura.Interfaces;

namespace Repositories.Repositorios
{
    public class AnimalRepositorio : RepositorioGenerico<Animal>, IAnimalRepositorio
    {
        //public List<Animal> GetAllListItemAnimal()
        //{
        //    List<Listitem> items = new List<Animal>();

        //    items.Add(new SelectListItem { Text = "Action", Value = "0" });

        //    items.Add(new SelectListItem { Text = "Drama", Value = "1" });

        //    items.Add(new SelectListItem { Text = "Comedy", Value = "2", Selected = true });

        //    items.Add(new SelectListItem { Text = "Science Fiction", Value = "3" });

        //    ViewBag.MovieType = items;

        //    return View();
        //   // throw new NotImplementedException();
        //}
    }
}
