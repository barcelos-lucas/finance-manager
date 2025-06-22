using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using FinanceManager.Application.UseCases.ContaPagar.Create;
using FinanceManager.Application.UseCases.ContaPagar.Update;
using FinanceManager.Application.UseCases.ContaPagar.Delete;
using FinanceManager.Application.UseCases.ContaPagar.GetByUser;


namespace FinanceManager.API.Controllers
{
    [ApiController]
    [Route("api/contas-pagar")]
    //[Authorize]
    public class ContaPagarController : ControllerBase
    {
        private readonly ICreateContaPagarUseCase _createUseCase;
        private readonly IGetContaPagarByUserUseCase _getByUserUseCase;
        private readonly IUpdateContaPagarUseCase _updateUseCase;
        private readonly IDeleteContaPagarUseCase _deleteUseCase;

        public ContaPagarController(
            ICreateContaPagarUseCase createUseCase,
            IGetContaPagarByUserUseCase getByUserUseCase,
            IUpdateContaPagarUseCase updateUseCase,
            IDeleteContaPagarUseCase deleteUseCase)
        {
            _createUseCase = createUseCase;
            _getByUserUseCase = getByUserUseCase;
            _updateUseCase = updateUseCase;
            _deleteUseCase = deleteUseCase;
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Post([FromBody] CreateContaPagarRequest request)
        {
            var result = await _createUseCase.ExecuteAsync(request);
            return CreatedAtAction(nameof(GetByUser), new { userId = request.UserId }, result);
        }

        [AllowAnonymous]
        [HttpGet("user/{userId:guid}")]
        public async Task<IActionResult> GetByUser(Guid userId)
        {
            var response = await _getByUserUseCase.ExecuteAsync(
                new GetContaPagarByUserRequest { UserId = userId });
            return Ok(response);
        }

        // PUT /api/contas-pagar/{id}
        [HttpPut("{id:guid}")]
        [AllowAnonymous]
        public async Task<IActionResult> Update(Guid id, [FromBody] UpdateContaPagarRequest req)
        {
            if (id != req.Id)
                return BadRequest("ID no PATH e no BODY devem ser =");

            await _updateUseCase.ExecuteAsync(req);
            return NoContent();
        }

        // DELETE /api/contas-pagar/{id}
        [HttpDelete("{id:guid}")]
        [AllowAnonymous]
        public async Task<IActionResult> Delete(Guid id)
        {
            await _deleteUseCase.ExecuteAsync(id);
            return NoContent();
        }
    }
}
