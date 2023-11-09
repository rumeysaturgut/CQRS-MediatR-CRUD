using CQRSMediatrCRUD.Commands.Response;
using MediatR;

namespace CQRSMediatrCRUD.Commands.Request
{
    public class CreateProductCommandRequest : IRequest<CreateProductCommandResponse> // CreateProductCommandResponse classı döneceğini MediatR’a bildirmiş olduk.
    {
        public string Name { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
    }
}
