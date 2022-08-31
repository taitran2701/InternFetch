using InternBA.ViewModels;
using MediatR;

namespace InternBA.Features.MessageFeatures.Command
{
    public partial class CreateMessageCommand : MessageViewModel, IRequest<Message>
    {
    }
}
