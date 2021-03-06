using System.Threading.Tasks;
using API.Interfaces;
using AutoMapper;

namespace API.Data
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DataContext _context;
        public UnitOfWork(DataContext context, IMapper mapper)
        {
            _context = context;
            UserRepository = new UserRepository(context, mapper);
            MessageRepository = new MessageRepository(context, mapper);
            LikesRepository = new LikesRepository(context);
        }

        public IUserRepository UserRepository { get; }

        public IMessageRepository MessageRepository { get; }

        public ILikesRepository LikesRepository { get; }

        public async Task<bool> Complete()
        {
            return await _context.SaveChangesAsync() > 0;
        }

        public bool HasChanges()
        {
            return _context.ChangeTracker.HasChanges();
        }
    }
}