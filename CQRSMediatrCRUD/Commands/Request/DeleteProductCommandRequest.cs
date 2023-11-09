using CQRSMediatrCRUD.Commands.Response;
using MediatR;

namespace CQRSMediatrCRUD.Commands.Request
{
    public class DeleteProductCommandRequest : IRequest<DeleteProductCommandResponse>
    {
        public int Id { get; set; }

    }
}
