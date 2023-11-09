using CQRSMediatrCRUD.Commands.Request;
using CQRSMediatrCRUD.Commands.Response;
using MediatR;

namespace CQRSMediatrCRUD.Handlers.CommandHandlers
{
    public class UpdateProductCommandHandler : IRequestHandler<UpdateProductCommandRequest, UpdateProductCommandResponse>
    {
        private readonly AppDbContext _appDbContext;

        public UpdateProductCommandHandler(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task<UpdateProductCommandResponse> Handle(UpdateProductCommandRequest request, CancellationToken cancellationToken)
        {
            var product = _appDbContext.Products.FirstOrDefault(p => p.Id == request.Id);
            if (product == null)
            {
                return new UpdateProductCommandResponse
                {
                    IsSuccess = false,
                    ProductId = 0
                };
            }

            product.Name = request.Name;
            product.Price = request.Price;
            product.Quantity = request.Quantity;

            _appDbContext.Products.Update(product);
            await _appDbContext.SaveChangesAsync();

            return new UpdateProductCommandResponse
            {
                IsSuccess = true,
                ProductId = product.Id
            };
        }
    }
}
