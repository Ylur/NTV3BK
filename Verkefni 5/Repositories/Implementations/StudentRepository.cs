using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SchoolDatabase;
using Verkefni_5.Repositories.Interfaces;

namespace Verkefni_5.Repositories.Implementations
{
    public class StudentRepository : Repository<Student>, IStudentRepository
    {
        public StudentRepository(SchoolContext context) : base(context) { }

        public async Task<IEnumerable<Student>> GetStudentsByGroupAsync(int groupId)
        {
            return await _dbSet
                .Where(s => s.GroupId == groupId)
                .ToListAsync();
        }

        public async Task<IEnumerable<Student>> GetStudentsWithMarksAsync()
        {
            return await _dbSet
                .Include(s => s.Group)
                .Include(s => s.Marks)
                    .ThenInclude(m => m.Subject)
                .ToListAsync();
        }
    }
}
