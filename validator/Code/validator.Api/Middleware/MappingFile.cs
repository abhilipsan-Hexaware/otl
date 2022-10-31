using validator.BusinessEntities.Entities;
using validator.Contracts.DTO;
using AutoMapper;

public class MappingFile : Profile
{
    public MappingFile()
    {
        // Mapping variables
		CreateMap<Document , DocumentDto>(); 
    }
}
