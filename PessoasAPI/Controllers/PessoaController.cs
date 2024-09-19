using AutoMapper;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using PessoasAPI.Data;
using PessoasAPI.Data.Dtos;
using PessoasAPI.Models;

namespace PessoasAPI.Controllers;

[ApiController]
[Route("[controller]")]


public class PessoaController : ControllerBase
{
    private PessoaContext _context;
    private IMapper _mapper;

    public PessoaController(PessoaContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    [HttpPost]
    public IActionResult AdicionaPessoa([FromBody] CreatePessoaDto pessoaDto)
    {
        Pessoa pessoa = _mapper.Map<Pessoa>(pessoaDto);
        _context.Pessoas.Add(pessoa);
        _context.SaveChanges();
        return CreatedAtAction(nameof(RecupetaPessoaPorId), new { id = pessoa.Id }, pessoa);
     
    }

    [HttpGet]
    public IEnumerable<ReadPessoaDto> RecuperaPessoas([FromQuery] int skip = 0, [FromQuery] int take = 50)
    {
        return _mapper.Map<List<ReadPessoaDto>>(_context.Pessoas.Skip(skip).Take(take));
    }

    [HttpGet("{id}")]
    public IActionResult RecupetaPessoaPorId(int id)
    {
        var pessoa = _context.Pessoas.FirstOrDefault(pessoa => pessoa.Id == id);
        if (pessoa == null) return NotFound();

        var pessoaDto = _mapper.Map<ReadPessoaDto>(pessoa);

        return Ok(pessoaDto);
    }

    [HttpPut("{id}")]
    public IActionResult AtualizaPessoa(int id, [FromBody] UpdatePessoaDto pessoaDto)
    {
        var pessoa = _context.Pessoas.FirstOrDefault(pessoa => pessoa.Id == id);
        if (pessoa == null) return NotFound();
        _mapper.Map(pessoaDto, pessoa);
        _context.SaveChanges();
        return NoContent();
    }

    [HttpPatch("{id}")]
    public IActionResult AtualizaPessoaParcial(int id, JsonPatchDocument<UpdatePessoaDto> patch)
    {
        var pessoa = _context.Pessoas.FirstOrDefault(pessoa => pessoa.Id == id);
        if (pessoa == null) return NotFound();

        var pessoaParaAtualizar = _mapper.Map<UpdatePessoaDto>(pessoa);

        patch.ApplyTo(pessoaParaAtualizar, ModelState);

        if (!TryValidateModel(pessoaParaAtualizar))
        {
            return ValidationProblem(ModelState);
        }

        _mapper.Map(pessoaParaAtualizar, pessoa);
        _context.SaveChanges();
        return NoContent();
    }

    [HttpDelete("{id}")]
    public IActionResult DeletaPessoa(int id)
    {
        var pessoa = _context.Pessoas.FirstOrDefault(pessoa => pessoa.Id == id);
        if (pessoa == null) return NotFound();

        _context.Remove(pessoa);
        _context.SaveChanges();
        return NoContent();
    }






}
