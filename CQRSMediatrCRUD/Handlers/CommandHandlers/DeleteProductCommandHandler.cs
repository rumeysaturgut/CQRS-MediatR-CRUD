using CQRSMediatrCRUD.Commands.Request;
using CQRSMediatrCRUD.Commands.Response;
using MediatR;

namespace CQRSMediatrCRUD.Handlers.CommandHandlers
{
    public class DeleteProductCommandHandler : IRequestHandler<DeleteProductCommandRequest, DeleteProductCommandResponse>
    {
        private readonly AppDbContext _appDbContext;

        public DeleteProductCommandHandler(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task<DeleteProductCommandResponse> Handle(DeleteProductCommandRequest request, CancellationToken cancellationToken)
        {
            var product = _appDbContext.Products.FirstOrDefault(p => p.Id == request.Id);
            if (product == null)
            {
                return new DeleteProductCommandResponse
                {
                    IsSuccess = false,
                    ProductId = 0
                };
            }
            _appDbContext.Products.Remove(product);
            await _appDbContext.SaveChangesAsync();

            return new DeleteProductCommandResponse
            {
                IsSuccess = true,
                ProductId = product.Id
            };
        }
    }
}
