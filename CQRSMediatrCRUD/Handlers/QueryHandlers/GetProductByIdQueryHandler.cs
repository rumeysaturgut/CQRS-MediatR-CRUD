using CQRSMediatrCRUD.Queries.Request;
using CQRSMediatrCRUD.Queries.Response;
using MediatR;

namespace CQRSMediatrCRUD.Handlers.QueryHandlers
{
    public class GetProductByIdQueryHandler : IRequestHandler<GetProductByIdQueryRequest, GetProductByIdQueryResponse>
    {
        private readonly AppDbContext _appDbContext;

        public GetProductByIdQueryHandler(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task<GetProductByIdQueryResponse> Handle(GetProductByIdQueryRequest request, CancellationToken cancellationToken)
        {
            var product = _appDbContext.Products.FirstOrDefault(p => p.Id == request.Id);

            return new GetProductByIdQueryResponse
            {
                Id = product.Id,
                Name = product.Name,
                Price = product.Price,
                Quantity = product.Quantity,
                CreateTime = product.CreateTime
            };
        }
    }
}
