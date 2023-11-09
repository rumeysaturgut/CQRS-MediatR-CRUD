using CQRSMediatrCRUD.Queries.Response;
using MediatR;

namespace CQRSMediatrCRUD.Queries.Request
{
    public class GetAllProductQueryRequest : IRequest<List<GetAllProductQueryResponse>>
    { 
    }
}
