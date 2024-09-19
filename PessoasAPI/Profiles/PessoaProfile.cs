using AutoMapper;
using PessoasAPI.Data.Dtos;
using PessoasAPI.Models;

namespace PessoasAPI.Profiles;

public class PessoaProfile : Profile
{
    public PessoaProfile()
    {
        CreateMap<CreatePessoaDto, Pessoa>();
        CreateMap<UpdatePessoaDto, Pessoa>();
        CreateMap<Pessoa, UpdatePessoaDto>();
        CreateMap<Pessoa, ReadPessoaDto>();

    }
}
