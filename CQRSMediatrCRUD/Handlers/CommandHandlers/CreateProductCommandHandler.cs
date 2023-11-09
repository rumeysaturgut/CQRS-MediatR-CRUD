using CQRSMediatrCRUD.Commands.Request;
using CQRSMediatrCRUD.Commands.Response;
using MediatR;

namespace CQRSMediatrCRUD.Handlers.CommandHandlers
{
    public class CreateProductCommandHandler : IRequestHandler<CreateProductCommandRequest, CreateProductCommandResponse>
    {
        private AppDbContext _appDbContext;

        public CreateProductCommandHandler(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task<CreateProductCommandResponse> Handle(CreateProductCommandRequest request, CancellationToken cancellationToken)
        {
            var product = new Product()
            {
                Name = request.Name,
                Price = request.Price,
                Quantity = request.Quantity,
                CreateTime = DateTime.Now
            };

            _appDbContext.Products.Add(product);

            await _appDbContext.SaveChangesAsync();
            return new CreateProductCommandResponse
            {
                IsSuccess = true,
                ProductId = product.Id
            };

        }
    }
}
