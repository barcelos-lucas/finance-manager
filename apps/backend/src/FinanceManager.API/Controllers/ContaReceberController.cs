using FinanceManager.Application.UseCases.ContaReceber.Create;
using FinanceManager.Application.UseCases.ContaReceber.GetByUser;
using FinanceManager.Application.UseCases.ContaReceber.Update;
using FinanceManager.Application.UseCases.ContaReceber.Delete;
using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FinanceManager.API.Controllers
{
    //[Authorize]
    [AllowAnonymous]
    [ApiController]
    [Route("api/contas-receber")]
    public class ContaReceberController : ControllerBase
    {
        private readonly ICreateContaReceberUseCase _createUseCase;
        private readonly IGetContaReceberByUserUseCase _getByUserUseCase;
        private readonly IUpdateContaReceberUseCase _updateUseCase;
        private readonly IDeleteContaReceberUseCase _deleteUseCase;

        public ContaReceberController(
            ICreateContaReceberUseCase createUseCase,
            IGetContaReceberByUserUseCase getByUserUseCase,
            IUpdateContaReceberUseCase updateUseCase,
            IDeleteContaReceberUseCase deleteUseCase)
        {
            _createUseCase = createUseCase;
            _getByUserUseCase = getByUserUseCase;
            _updateUseCase = updateUseCase;
            _deleteUseCase = deleteUseCase;
        }

        [HttpPost]
        [AllowAnonymous]

        public async Task<IActionResult> Create([FromBody] CreateContaReceberRequest req)
        {
            var resp = await _createUseCase.ExecuteAsync(req);
            return CreatedAtAction(nameof(GetByUser), new { userId = req.UserId }, resp);
        }

        [AllowAnonymous]
        [HttpGet("user/{userId:guid}")]
        public async Task<IActionResult> GetByUser(Guid userId)
            => Ok(await _getByUserUseCase.ExecuteAsync(new GetContaReceberByUserRequest { UserId = userId }));

        [AllowAnonymous]
        [HttpPut("{id:guid}")]
        public async Task<IActionResult> Update(Guid id, [FromBody] UpdateContaReceberRequest req)
        {
            if (id != req.Id) return BadRequest("IDs divergentes");
            await _updateUseCase.ExecuteAsync(req);
            return NoContent();
        }

        [AllowAnonymous]
        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            await _deleteUseCase.ExecuteAsync(id);
            return NoContent();
        }
    }
}
