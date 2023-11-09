using CQRSMediatrCRUD.Commands.Response;
using MediatR;

namespace CQRSMediatrCRUD.Commands.Request
{
    public class UpdateProductCommandRequest : IRequest<UpdateProductCommandResponse>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
    }
}
