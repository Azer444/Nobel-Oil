using Core.Models;
using Core.Repositories.Abstraction;
using Data.Contexts;

namespace Data.Repositories.Implementation
{
    public class VMVComponentPhotoRepository : Repository<VMVComponentPhoto>, IVMVComponentPhotoRepository
    {
        public VMVComponentPhotoRepository(NobelContext context)
            : base(context)
        {

        }
    }
}
