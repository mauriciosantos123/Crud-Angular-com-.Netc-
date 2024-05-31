using CRUDAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CRUDAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PessoasController : ControllerBase
    {
        private readonly Contexto _contexto;

        public PessoasController(Contexto contexto){

            _contexto = contexto;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Pessoa>>>PegarTodosAsync(){

            return await _contexto.Pessoas.ToListAsync();
        } 

        [HttpGet("{pessoaId}")]
        public async Task<ActionResult<Pessoa>> PegarPessoaPeloId (int pessoaId){

            Pessoa pessoa = await _contexto.Pessoas.FindAsync(pessoaId);
            return pessoa;
        }

        [HttpPost]
        public async Task<ActionResult<Pessoa>> SalvarPessoaAsync(Pessoa pessoa){

            await _contexto.Pessoas.AddAsync(pessoa);
            await _contexto.SaveChangesAsync();
            return Ok();
        }

        [HttpPut]
        public async Task<ActionResult> AtualizarPessoaAsunc(Pessoa pessoa){

            _contexto.Update(pessoa);
            await _contexto.SaveChangesAsync();
            return Ok();
        }

        [HttpDelete("{pessoaId}")]
        public async Task<ActionResult> ExcluirPessoa(int pessoaId){
            Pessoa pessoa = await _contexto.Pessoas.FindAsync(pessoaId);
            if (pessoa == null)
                return  NotFound();
            _contexto.Remove(pessoa);
            await _contexto.SaveChangesAsync();
            return Ok();
        }

    }
}