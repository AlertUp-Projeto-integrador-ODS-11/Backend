using AlertUp.Model;
using AlertUp.Service;
using AlertUp.Service.Implements;
using FluentValidation;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace AlertUp.Controllers
{
    //[Route] - Indica o endereço Http
    [Route("~/temas")]
    //[ApiController] indica que a classe é do tipo Controller
    [ApiController]
    public class TemaController : ControllerBase
    {
        private readonly ITemaService _temaService;
        private readonly IValidator<Tema> _temaValidator;

        public TemaController(

            ITemaService temaService,
                IValidator<Tema> temaValidator
        )
        {
            _temaService = temaService;
            _temaValidator = temaValidator;
        }
         
        [HttpGet]
        public async Task<ActionResult> GetAll()
        {
            return Ok(await _temaService.GetAll());
        }
         
        //Path de caminho (id = variavel) 
        [HttpGet("{id}")]
        public async Task<ActionResult> GetById(long id)
        {
            var Resposta = await _temaService.GetById(id);

            if (Resposta == null)
                return NotFound();

            return Ok(Resposta);
        } 

        // o que está em () é um descricao de caminho
        [HttpGet("descricao/{descricao}")]
        public async Task<ActionResult> GetByDescricao(string descricao)
        {
            return Ok(await _temaService.GetByDescricao(descricao));
        }
        //[HttpPost] = Cria um valor
        [HttpPost]
        public async Task<ActionResult> Create([FromBody] Tema tema)
        {
            var validarTema = await _temaValidator.ValidateAsync(tema);
            if (!validarTema.IsValid)
                return StatusCode(StatusCodes.Status400BadRequest, validarTema);
            await _temaService.Create(tema);

            return CreatedAtAction(nameof(GetById), new { id = tema.Id }, tema);
        }

        //[HttpPut] = altera um valor
        [HttpPut]
        public async Task<ActionResult> Update([FromBody] Tema tema)
        {
            if (tema.Id == 0)
                return BadRequest("Id de tema é inválido");

            var validarTema = await _temaValidator.ValidateAsync(tema);
            if (!validarTema.IsValid)
            {
                return StatusCode(StatusCodes.Status400BadRequest, validarTema);

            }
            var Resposta = await _temaService.Update(tema);
            if (Resposta is null)
                return NotFound("tema não encontrado!");


            return Ok(Resposta);
        }

        //[HttpDelete] = Deleta um valor, especificamente chamando pelo id
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(long id)
        {
            var BuscaTema = await _temaService.GetById(id);
            if (BuscaTema is null)
                return NotFound("tema não foi encontrado!");
            await _temaService.Delete(BuscaTema);
            return NoContent();
        }
    }
}