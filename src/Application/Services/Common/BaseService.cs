using Application.Infrastructure.Persistence;

namespace Application.Services.Common
{
    public abstract class BaseService
    {
        private protected ICarRentalDbContext Context { get; }

        public BaseService(ICarRentalDbContext context)
        {
            Context = context;
        }
    }
}
