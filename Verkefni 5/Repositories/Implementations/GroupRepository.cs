using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Verkefni_5.Data;
using Verkefni_5.Data.Models;
using Verkefni_5.Repositories.Interfaces;

namespace Verkefni_5.Repositories.Implementations
{
    public class GroupRepository : Repository<Group>, IGroupRepository
    {
        public GroupRepository(SchoolContext context) : base(context) { }

        public async Task<IEnumerable<Group>> GetGroupsWithStudentsAsync()
        {
            return await _dbSet
                .Include(g => g.Students)
                .ToListAsync();
        }
    }
}
