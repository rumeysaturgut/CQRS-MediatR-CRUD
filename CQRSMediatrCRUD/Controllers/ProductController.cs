using CQRSMediatrCRUD.Commands.Request;
using CQRSMediatrCRUD.Commands.Response;
using CQRSMediatrCRUD.Queries.Request;
using CQRSMediatrCRUD.Queries.Response;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CQRSMediatrCRUD.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        IMediator _mediator;

        public ProductController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("getAllProducts")]
        public async Task<IActionResult> Get([FromQuery] GetAllProductQueryRequest requestModel)
        {
            List<GetAllProductQueryResponse> allProducts = await _mediator.Send(requestModel);
            return Ok(allProducts);
        }

        [HttpGet("getById")]
        public async Task<IActionResult> Get([FromQuery] GetProductByIdQueryRequest requestModel)
        {
            GetProductByIdQueryResponse product = await _mediator.Send(requestModel);
            return Ok(product);
        }

        [HttpPost("addProduct")]
        public async Task<IActionResult> Post([FromBody] CreateProductCommandRequest requestModel) 
        {
            CreateProductCommandResponse response = await _mediator.Send(requestModel); // MediatR kütüphanesi verdiğimiz request modeline göre zaten hangi Handlera gideceğini ve hangi db işlemlerini yapacağını kendisi belirlemiş oluyor.
            return Ok(response);
        }

        [HttpPut("updateProduct")]
        public async Task<IActionResult> Put([FromBody] UpdateProductCommandRequest requestModel)
        {
            UpdateProductCommandResponse response = await _mediator.Send(requestModel);
            return Ok(response);
        }

        [HttpDelete("deleteProduct")]
        public async Task<IActionResult> Delete([FromQuery] DeleteProductCommandRequest requestModel)
        {
            DeleteProductCommandResponse response = await _mediator.Send(requestModel);
            return Ok(response);
        }
    }
}
