using AutoMapper;

namespace todoAPI.Profiles
{
    public class ListProfile : Profile
    {
        public ListProfile() 
        {
            CreateMap<Entities.List, models.ListDto>();
        }
    }
}
