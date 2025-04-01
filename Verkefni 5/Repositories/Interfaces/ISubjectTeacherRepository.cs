using System.Collections.Generic;
using System.Threading.Tasks;
using Verkefni_5.Data.Models;

namespace Verkefni_5.Repositories.Interfaces
{
    public interface ISubjectTeacherRepository : IRepository<SubjectTeacher>
    {
        Task<IEnumerable<SubjectTeacher>> GetBySubjectIdAsync(int subjectId);
        Task<IEnumerable<SubjectTeacher>> GetByTeacherIdAsync(int teacherId);
    }
}
