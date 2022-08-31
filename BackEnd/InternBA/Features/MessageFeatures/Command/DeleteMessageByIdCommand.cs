using InternBA.Infrastructure.Data;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace InternBA.Features.MessageFeatures.Command
{
    public class DeleteMessageByIdCommand : IRequest<Message>
    {
        public Guid ID { get; set; }
        public class DeleteMessageByIdCommandHandler : IRequestHandler<DeleteMessageByIdCommand, Message>
        {
            public readonly InternBADBContext _context;
            public DeleteMessageByIdCommandHandler(InternBADBContext context)
            {
                _context = context;
            }

            public async Task<Message> Handle(DeleteMessageByIdCommand request, CancellationToken cancellationToken)
            {
                var message = await _context.Messages.FindAsync(request.ID);

                if(message == null)
                {
                    return default;
                }

                message.DeleteAt = DateTime.UtcNow;
                _context.Entry(message).State = EntityState.Modified;
                await _context.SaveChangesAsync();
                return message;
            }
        }
    }
}
