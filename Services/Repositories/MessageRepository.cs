using Data;
using Domain.Entities;
using Domain.Enums;
using Microsoft.EntityFrameworkCore;

namespace Services.Repositories
{
    public class MessageRepository
    {
        private readonly EntityContext _context;

        public MessageRepository(EntityContext context)
        {
            _context = context;
        }

        public async Task<List<Message>> GetMessageToSendAsync()
        {
            var states = new List<State>() { State.Initiat, State.ReadyToSend };

            return await _context.Messages
                .Where(x => states.Contains(x.State))
                .ToListAsync();
        }

        public async Task<List<Message>> GetMessagesToRetryAsync()
        {
            return await _context.Messages
                .Where(x => x.State == State.NeedToRetry)
                .ToListAsync();
        }

        public async Task AddAsync(Message message)
        {
            await _context.Messages.AddAsync(message);
        }

        public async Task SaveAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
