using AutoMapper;
using Model;
using System;
using WebPetShop.ViewModels;


namespace WebPetShop.Map
{
    public class ViewModelToDomainMappingProfile:Profile
    {
        public override string ProfileName
        {
            get { return "DomainToViewModelMapping"; }

        }

        [Obsolete]
        protected override void Configure()
        {
            CreateMap<Mascota, MascotaViewModel>();
            CreateMap<Usuario, UsuarioViewModel>();
            CreateMap<Estado, EstadoViewModel>();
            CreateMap<Raza, RazaViewModel>();
            CreateMap<Animal, AnimalViewModel>();

        }
    }
}