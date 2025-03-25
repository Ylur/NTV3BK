using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SchoolDatabase;
using Verkefni_5.Repositories.Interfaces;

namespace Verkefni_5.Repositories.Implementations
{
    public class MarkRepository : Repository<Mark>, IMarkRepository
    {
        public MarkRepository(SchoolContext context) : base(context) { }

        public async Task<IEnumerable<Mark>> GetMarksByStudentAsync(int studentId)
        {
            return await _dbSet
                .Where(m => m.StudentId == studentId)
                .Include(m => m.Subject)
                .ToListAsync();
        }

        public async Task<IEnumerable<Mark>> GetMarksBySubjectAsync(int subjectId)
        {
            return await _dbSet
                .Where(m => m.SubjectId == subjectId)
                .Include(m => m.Student)
                .ToListAsync();
        }
    }
}
