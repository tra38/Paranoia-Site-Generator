using System;
using System.Collections.Generic;

namespace Paranoia_Site_Generator
{
    public static class PostExtensions
    {
        static Dictionary<int, string> KeyValuePairs = new Dictionary<int, string>
        {
            { 427, "Xai" },
            { 1193, "Richie-R-ICH-1" },
            { 3, "Jazzer" },
            { 4, "Fargmania" },
            { 855, "Silent" },
            { 286, "Costin-U-MOR" },
            { 197, "Allen Varney" },
            { 165, "Takyn-U-RUN" },
            { 698, "saulres" },
            { 413, "Aratos" },
            { 91, "Elle-R-KNO" },
            { 14, "Mike-U-LEM" },
            { 396, "Biggles" }
        };

        public static string Username(this int userId)
            => KeyValuePairs.GetValueOrDefault(userId, $"User Id: { userId }");

        //https://stackoverflow.com/questions/2601477/dictionary-returning-a-default-value-if-the-key-does-not-exist
        public static TValue GetValueOrDefault<TKey, TValue>
            (
                this IDictionary<TKey, TValue> dictionary,
                TKey key,
                TValue defaultValue
            )
        {
            TValue value;
            return dictionary.TryGetValue(key, out value) ? value : defaultValue;
        }

        public static TValue GetValueOrDefault<TKey, TValue>
            (
                this IDictionary<TKey, TValue> dictionary,
                TKey key,
                Func<TValue> defaultValueProvider
            )
        {
            TValue value;
            return dictionary.TryGetValue(key, out value) ? value
                 : defaultValueProvider();
        }


    }
}
