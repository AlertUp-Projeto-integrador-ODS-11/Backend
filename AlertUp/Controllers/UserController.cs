using AlertUp.Model;
using AlertUp.Service;
using AlertUp.Service.Implements;
using AlertUp.Validator;
using FluentValidation;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;


namespace AlertUp.Controllers
{
    [Route("~/usuarios")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IValidator<User> _userValidator;

        public UserController(IUserService userService, IValidator<User> userValidator)
        {
            _userService = userService;
            _userValidator = userValidator;
        }

        [HttpGet]
        public async Task<ActionResult> GetAll()
        {
            return Ok(await _userService.GetAll());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> GetById(long id)
        {
            var Resposta = await _userService.GetById(id);

            if (Resposta == null)
                return NotFound();

            return Ok(Resposta);
        }

        [HttpPost]
        public async Task<ActionResult> Create([FromBody] User user)
        {
            var validarUser = await _userValidator.ValidateAsync(user);
            if (!validarUser.IsValid)
                return StatusCode(StatusCodes.Status400BadRequest, validarUser);
            await _userService.Create(user);

            return CreatedAtAction(nameof(GetById), new { id = user.Id }, user);
        }

        [HttpPut]
        public async Task<ActionResult> Update([FromBody] User user)
        {
            if (user.Id == 0)
                return BadRequest("Id do usuário é inválido");

            var validarUser = await _userValidator.ValidateAsync(user);
            if (!validarUser.IsValid)
            {
                return StatusCode(StatusCodes.Status400BadRequest, validarUser);

            }
            var Resposta = await _userService.Update(user);
            if (Resposta is null)
                return NotFound("Usuário não encontrado!");


            return Ok(Resposta);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(long id)
        {
            var BuscaUser = await _userService.GetById(id);
            if (BuscaUser is null)
                return NotFound("Usuário não foi encontrado!");
            await _userService.Delete(BuscaUser);
            return NoContent();
        }
    }
}
