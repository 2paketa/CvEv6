using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

namespace CvECommon
{
    public static class Common
    {
        public static void Shuffle<T> (this Random rng, T[] array)
        {
            int n = array.Length;
            while (n > 1) 
            {
                int k = rng.Next(n--);
                T temp = array[n];
                array[n] = array[k];
                array[k] = temp;
            }
        }

        public static string[] LineToArray(this string item)
        {
            string[] delimiters = { "," };
            StringSplitOptions options = StringSplitOptions.RemoveEmptyEntries;
            var items = item.Split(delimiters, options);
            for (int i = 0; i < items.Length; i++)
                items[i] = items[i].Trim();
            return items;
        }

        public static string[] ToLowerArray(this string[] items)
        {
            for (int i = 0; i < items.Length; i++)
            {
                items[i] = items[i].ToUpper().ElementAt(0) + items[i].Substring(1, items[i].Length - 1).ToLower();
            }
            return items;
        }

    }
}
