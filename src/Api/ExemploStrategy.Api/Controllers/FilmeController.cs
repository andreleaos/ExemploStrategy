using ExemploStrategy.Domain.Dtos;
using ExemploStrategy.Domain.Interfaces;
using ExemploStrategy.Services.Contexts;
using ExemploStrategy.Services.Requests;
using ExemploStrategy.Services.Responses;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ExemploStrategy.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FilmeController : ControllerBase
    {
        private readonly ExemploStrategyContext _context;

        public FilmeController(ExemploStrategyContext context)
        {
            _context = context;
        }

        [HttpGet]
        public List<FilmeDto> GetAll()
        {
            try
            {
                GetAllFilmeRequest request = new GetAllFilmeRequest();
                var result = _context.Execute(request) as GetAllFilmeResponse;
                if (result.IsSuccess)
                {
                    var filmesDto = result.Filmes;
                    return filmesDto;
                }

                throw new Exception("Listagem não realizada");
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        [HttpGet("{id}")]
        public FilmeDto GetById(int id)
        {
            try
            {
                GetFilmeByIdRequest request = new GetFilmeByIdRequest() { Id = id };
                var result = _context.Execute(request) as GetFilmeByIdResponse;
                if (result.IsSuccess)
                {
                    var filmeDto = result.Filme;
                    return filmeDto;
                }

                throw new Exception("Listagem não realizada");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpPost]
        public ActionResult Create(FilmeDto filme)
        {
            try
            {
                CreateFilmeRequest request = new CreateFilmeRequest { Filme = filme };
                var result = _context.Execute(request) as CreateFilmeResponse;
                if (result.IsSuccess)
                    return Ok("Cadastro efetuado com sucesso");

                return BadRequest("Cadastro não realizado");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        public ActionResult Update(FilmeDto filme)
        {
            try
            {
                UpdateFilmeRequest request = new UpdateFilmeRequest { Filme = filme };
                var result = _context.Execute(request) as UpdateFilmeResponse;
                if (result.IsSuccess)
                    return Ok("Atualização efetuada com sucesso");

                return BadRequest("Atualização não realizada");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            try
            {
                DeleteFilmeRequest request = new DeleteFilmeRequest { Id = id };
                var result = _context.Execute(request) as DeleteFilmeResponse;
                if (result.IsSuccess)
                    return Ok("Exclusão efetuada com sucesso");

                return BadRequest("Exclusão não realizada");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    }
}
