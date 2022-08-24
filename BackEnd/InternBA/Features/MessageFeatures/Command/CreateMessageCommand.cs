using MediatR;

namespace InternBA.Features.MessageFeatures.Command
{
    public partial class CreateMessageCommand : MessageViewModel, IRequest<Message>
    {
        public Guid ID { get; set; }
        public Guid UserID { get; set; }
        public string content { get; set; }
    }
}
