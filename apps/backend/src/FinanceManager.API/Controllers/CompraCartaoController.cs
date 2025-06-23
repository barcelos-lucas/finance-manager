using FinanceManager.Application.UseCases.CompraCartao.Create;
using FinanceManager.Application.UseCases.CompraCartao.GetByUser;
using FinanceManager.Application.UseCases.CompraCartao.Update;
using FinanceManager.Application.UseCases.CompraCartao.Delete;
using FinanceManager.Application.UseCases.CompraCartao.List;
using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FinanceManager.API.Controllers
{
    //[Authorize]
    [AllowAnonymous]
    [ApiController]
    [Route("api/compra-cartao")]
    public class CompraCartaoController : ControllerBase
    {
        private readonly ICreateCompraCartaoUseCase _createUseCase;
        private readonly IGetCompraCartaoByUserUseCase _getByUserUseCase;
        private readonly IUpdateCompraCartaoUseCase _updateUseCase;
        private readonly IDeleteCompraCartaoUseCase _deleteUseCase;
        private readonly IGetComprasCartaoUseCase _getComprasUseCase;


        public CompraCartaoController(
            ICreateCompraCartaoUseCase createUseCase,
            IGetCompraCartaoByUserUseCase getByUserUseCase,
            IUpdateCompraCartaoUseCase updateUseCase,
            IGetComprasCartaoUseCase getComprasUseCase,
            IDeleteCompraCartaoUseCase deleteUseCase)
        {
            _createUseCase = createUseCase;
            _getByUserUseCase = getByUserUseCase;
            _updateUseCase = updateUseCase;
            _deleteUseCase = deleteUseCase;
            _getComprasUseCase = getComprasUseCase;
        }

        // POST /api/compra-cartao
        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Create([FromBody] CreateCompraCartaoRequest req)
        {
            var resp = await _createUseCase.ExecuteAsync(req);
            return CreatedAtAction(nameof(GetByUser), new { userId = req.UserId }, resp);
        }

        // GET /api/compra-cartao/user/{userId}
        [HttpGet("user/{userId:guid}")]
        [AllowAnonymous]
        public async Task<IActionResult> GetByUser(Guid userId)
        {
            var resp = await _getByUserUseCase.ExecuteAsync(new GetCompraCartaoByUserRequest { UserId = userId });
            return Ok(resp);
        }

        // PUT /api/compra-cartao/{id}
        [HttpPut("{id:guid}")]
        [AllowAnonymous]
        public async Task<IActionResult> Update(Guid id, [FromBody] UpdateCompraCartaoRequest req)
        {
            if (id != req.Id)
                return BadRequest("ID no path e no body devem ser iguais.");

            await _updateUseCase.ExecuteAsync(req);
            return NoContent();
        }

        // DELETE /api/compra-cartao/{id}
        [HttpDelete("{id:guid}")]
        [AllowAnonymous]
        public async Task<IActionResult> Delete(Guid id)
        {
            await _deleteUseCase.ExecuteAsync(id);
            return NoContent();
        }


        [HttpGet]
        public async Task<IActionResult> List(
            [FromQuery] Guid userId,
            [FromQuery] string? cartao,
            [FromQuery] DateTime? dataInicio,
            [FromQuery] DateTime? dataFim)
        {
            var req = new GetComprasCartaoRequest
            {
                UserId = userId,
                Cartao = cartao,
                DataInicio = dataInicio,
                DataFim = dataFim
            };

            var resp = await _getComprasUseCase.ExecuteAsync(req);
            return Ok(resp);
        }
    }
}
