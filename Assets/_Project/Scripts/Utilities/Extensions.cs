using System.Collections.Generic;
using System.Linq;

namespace MightyAdventures.Utilities
{
    public static class Extensions
    {
        public static T Random<T>(this IEnumerable<T> sequence)
        {
            var array = sequence as T[] ?? sequence.ToArray();
            var rn=UnityEngine.Random.Range(0, array.Length);
            return array[rn];
        }
    }
}