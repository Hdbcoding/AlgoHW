using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace AlgoHW.Common
{
    public static class FileReaderExtensions
    {
        public static IEnumerable<string> WhereNotNull(this IEnumerable<string> data)
        {
            return data.Select(n => n.Trim())
                .Where(n => !string.IsNullOrEmpty(n));
        }

        public static IEnumerable<T> ParseMany<T>(this string data, Func<string, T> parser)
        {
            return data.Split(' ')
                .Select(n => n.Trim())
                .Where(n => !string.IsNullOrEmpty(n))
                .Select(parser);
        }
    }
}
