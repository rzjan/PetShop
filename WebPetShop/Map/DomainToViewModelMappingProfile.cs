using AutoMapper;
using Model;
using System;
using WebPetShop.Models;


namespace WebPetShop.Map
{
    public class DomainToViewModelMappingProfile:Profile
    {
        public override string ProfileName
        {
            get { return "ViewModelToDomainMapping"; }

        }

        [Obsolete]
        protected override void Configure()
        {
            CreateMap<MascotaViewModel, Mascota>();
            //CreateMap<TipoClienteViewModel, TipoCliente>();
        }       
    }
}