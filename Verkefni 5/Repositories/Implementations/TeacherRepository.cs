using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SchoolDatabase;
using Verkefni_5.Repositories.Interfaces;

namespace Verkefni_5.Repositories.Implementations
{
    public class TeacherRepository : Repository<Teacher>, ITeacherRepository
    {
        public TeacherRepository(SchoolContext context) : base(context) { }

        public async Task<IEnumerable<Teacher>> GetTeachersWithSubjectsAsync()
        {
            return await _dbSet
                .Include(t => t.SubjectTeachers)
                    .ThenInclude(st => st.Subject)
                .ToListAsync();
        }
    }
}
