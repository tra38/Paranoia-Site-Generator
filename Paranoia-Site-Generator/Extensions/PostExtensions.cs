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
            { 396, "Biggles" },
            { 89, "Moto42" },
            { 186, "Adamantyr" },
            { 261, "Dystopian Rhetoric" },
            { 506, "Adam-R-LON-1" },
            { 878, "Tombking" },
            { 1048, "Lord_Dourden" },
            { 966, "Bee-R-CAN" },
            { 582, "DashRender" },
            { 152, "Allandaros" },
            { 595, "Zild" },
            { 90, "greymist08" },
            { 487, "Danforth" },
            { 414, "2DMan" },
            { 421, "GirdagFireskull" },
            { 231, "Occam" },
            { 257, "Expend-I-BLE" },
            { 1106, "Phial" },
            { 179, "Fr8monkey" },
            { 107, "Standback" },
            { 237, "Laughing Penguin" }
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
