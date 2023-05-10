using AutoMapper;
using Dongi.Entities;
using Dongi.Pages.TxManager;
using Dongi.Services.Dtos;

namespace Dongi.ObjectMapping;

public class DongiAutoMapperProfile : Profile
{
    public DongiAutoMapperProfile()
    {
        /* Create your AutoMapper object mappings here */
        CreateMap<Person, PersonDto>();
        CreateMap<CreateUpdatePersonDto, Person>();
        CreateMap<PersonDto, CreateUpdatePersonDto>();
        CreateMap<Tx, TxDto>();
        //CreateMap<CreateUpdateTxDto, Tx>();
        CreateMap<TxDetail, TxDetailDto>();
        //CreateMap<CreateUpdateTxDetailDto, TxDetail>();
        CreateMap<CreateTxViewModel, CreateUpdateTxDto>();
        //CreateMap<List<Person>, List<PersonDto>>();
    }
}
