using System.Linq;
using System.Threading.Tasks;

namespace EasyProfiler.Core.Abstractions
{
    public interface IEasyProfilerContext
    {
        IQueryable<T> Get<T>() where T : class;
        Task InsertAsync<T>(T entity) where T : class;
    }
}