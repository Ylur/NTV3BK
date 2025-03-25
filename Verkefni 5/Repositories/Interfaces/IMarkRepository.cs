using System.Collections.Generic;
using System.Threading.Tasks;
using SchoolDatabase;

namespace Verkefni_5.Repositories.Interfaces
{
    public interface IMarkRepository : IRepository<Mark>
    {
        Task<IEnumerable<Mark>> GetMarksByStudentAsync(int studentId);
        Task<IEnumerable<Mark>> GetMarksBySubjectAsync(int subjectId);
    }
}
