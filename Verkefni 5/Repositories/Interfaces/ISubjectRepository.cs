using System.Collections.Generic;
using System.Threading.Tasks;
using Verkefni_5.Data.Models;

namespace Verkefni_5.Repositories.Interfaces
{
    public interface ISubjectRepository : IRepository<Subject>
    {
        Task<IEnumerable<Subject>> GetSubjectsWithTeachersAsync();
    }
}
