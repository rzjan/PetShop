using AutoMapper;

namespace WebPetShop.Map
{
    public class AutoMapperConfig
    {
        public static void RegisterMappings()
        {
            Mapper.Initialize(x =>
               {
                   x.AddProfile<DomainToViewModelMappingProfile>();
                   x.AddProfile<ViewModelToDomainMappingProfile>();
               });            
        }



    }

}