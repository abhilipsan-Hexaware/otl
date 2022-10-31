using logging.BusinessEntities.Entities;
using logging.Contracts.DTO;
using AutoMapper;

public class MappingFile : Profile
{
    public MappingFile()
    {
        // Mapping variables
		CreateMap<Document , DocumentDto>(); 
    }
}
