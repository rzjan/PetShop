using AutoMapper;
using Model;
using System;
using WebPetShop.Models;


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
            //CreateMap<TipoCliente, TipoClienteViewModel>();

        }
    }
}