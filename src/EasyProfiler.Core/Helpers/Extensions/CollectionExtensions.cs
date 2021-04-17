using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EasyProfiler.Core.Helpers.Extensions
{
    public static class CollectionExtensions
    {
        public static Task<List<T>> ToListAsync<T>(this IEnumerable<T> source)
        {
            return  Task.Run(source.ToList);
        }
    }
}