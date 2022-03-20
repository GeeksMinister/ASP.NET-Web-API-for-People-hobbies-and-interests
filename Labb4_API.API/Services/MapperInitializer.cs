using AutoMapper;
public class MapperInitializer : Profile
{
    public MapperInitializer()
    {
        CreateMap<InterestDto, Interest>().ReverseMap();
        CreateMap<LinkDto, Link>().ReverseMap();
    }
}