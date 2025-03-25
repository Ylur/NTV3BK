using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using SchoolDB;
using Repositories.Interfaces;

namespace Repositories.Implementations
{
    public class SubjectTeacherRepository : Repository<SubjectTeacher>, ISubjectTeacherRepository
    {
        public SubjectTeacherRepository(SchoolContext context) : base(context)
        {
        }
        
        // Implement entity-specific methods here
    }
}
