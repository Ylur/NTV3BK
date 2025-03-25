using System.Collections.Generic;
using System.Threading.Tasks;
using SchoolDatabase;

namespace Verkefni_5.Repositories.Interfaces
{
    public interface IGroupRepository : IRepository<Group>
    {
        Task<IEnumerable<Group>> GetGroupsWithStudentsAsync();
    }
}
