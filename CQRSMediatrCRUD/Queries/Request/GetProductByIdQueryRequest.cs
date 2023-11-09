using CQRSMediatrCRUD.Queries.Response;
using MediatR;

namespace CQRSMediatrCRUD.Queries.Request
{
    public class GetProductByIdQueryRequest : IRequest<GetProductByIdQueryResponse>
    {
        public int Id { get; set; }
    }
}
