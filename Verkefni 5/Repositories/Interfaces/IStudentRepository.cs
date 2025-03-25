using System.Collections.Generic;
using System.Threading.Tasks;
using SchoolDatabase;

namespace Verkefni_5.Repositories.Interfaces
{
    public interface IStudentRepository : IRepository<Student>
    {
        Task<IEnumerable<Student>> GetStudentsByGroupAsync(int groupId);
        Task<IEnumerable<Student>> GetStudentsWithMarksAsync();
    }
}
