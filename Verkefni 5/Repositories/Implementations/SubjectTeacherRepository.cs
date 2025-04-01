using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Verkefni_5.Data.Models;
using Verkefni_5.Data;
using Verkefni_5.Repositories.Interfaces;

namespace Verkefni_5.Repositories.Implementations
{
    public class SubjectTeacherRepository : Repository<SubjectTeacher>, ISubjectTeacherRepository
    {
        public SubjectTeacherRepository(SchoolContext context) : base(context) { }

        public async Task<IEnumerable<SubjectTeacher>> GetBySubjectIdAsync(int subjectId)
        {
            return await _dbSet
                .Where(st => st.SubjectId == subjectId)
                .Include(st => st.Teacher)
                .ToListAsync();
        }

        public async Task<IEnumerable<SubjectTeacher>> GetByTeacherIdAsync(int teacherId)
        {
            return await _dbSet
                .Where(st => st.TeacherId == teacherId)
                .Include(st => st.Subject)
                .ToListAsync();
        }
    }
}
