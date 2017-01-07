using AutoMapper;
using Model;
using System;
using WebPetShop.ViewModels;


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
            CreateMap<UsuarioViewModel, Usuario>();
            CreateMap<EstadoViewModel, Estado>();
            CreateMap<RazaViewModel, Raza>();
            CreateMap<AnimalViewModel, Animal>();

            //CreateMap<TipoClienteViewModel, TipoCliente>();
        }

        //public DomainToViewModelMappingProfile()
        //{
        //    ConfigureMappings();
        //}


        /// <summary>
        /// Creates a mapping between source (Domain) and destination (ViewModel)
        /// </summary>
        //private void ConfigureMappings()
        //{
        //    CreateMap<ProductDefinition, ProductDefinitionViewModel>().ReverseMap();
        //    CreateMap<CatalogueDefinitionFile, CatalogueDefinitionFileViewModel>().ReverseMap();
        //}
    }
}



