using System.Collections.Generic;
using System.Linq;

namespace MightyAdventures.Utilities
{
    public static class Extensions
    {
        public static T Random<T>(this IEnumerable<T> sequence)
        {
            var array = sequence as T[] ?? sequence.ToArray();
            var rn = UnityEngine.Random.Range(0, array.Length);
            return array[rn];
        }

        public static T[] Random<T>(this IEnumerable<T> sequence, int amount)
        {
            var array = (sequence as T[] ?? sequence.ToArray());
            T[] shuffledArray = new T[array.Length];
            array.CopyTo(shuffledArray, 0);
            shuffledArray.Shuffle();
            var targetArray = new T[amount];
            for (int i = 0; i < amount; i++)
            {
                targetArray[i] = shuffledArray[i];
            }

            return targetArray;
        }

        public static T[] Shuffle<T>(this T[] array)
        {
            int count = array.Length;
            for (var i = 0; i < count; i++)
            {
                int r = UnityEngine.Random.Range(i, count);
                (array[i], array[r]) = (array[r], array[i]);
            }

            return array;
        }
    }
}