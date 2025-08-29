using Domain.Entities;

namespace Services.Repositories
{
    public interface IMessageRepository
    {
        Task<List<Message>> GetMessageToSendAsync();
        Task<List<Message>> GetMessagesToRetryAsync();
        Task AddAsync(Message message);
        Task SaveAsync();
    }
}
