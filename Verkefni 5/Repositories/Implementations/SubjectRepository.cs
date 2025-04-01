using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Verkefni_5.Data.Models;
using Verkefni_5.Data;
using Verkefni_5.Repositories.Interfaces;

namespace Verkefni_5.Repositories.Implementations
{
    public class SubjectRepository : Repository<Subject>, ISubjectRepository
    {
        public SubjectRepository(SchoolContext context) : base(context) { }

        public async Task<IEnumerable<Subject>> GetSubjectsWithTeachersAsync()
        {
            return await _dbSet
                .Include(s => s.SubjectTeachers)
                    .ThenInclude(st => st.Teacher)
                .ToListAsync();
        }
    }
}
