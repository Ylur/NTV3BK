using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using SchoolDB;
using Repositories.Interfaces;

namespace Repositories.Implementations
{
    public class TeacherRepository : Repository<Teacher>, ITeacherRepository
    {
        public TeacherRepository(SchoolContext context) : base(context)
        {
        }
        
        // Implement entity-specific methods here
    }
}
