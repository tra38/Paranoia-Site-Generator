using System.Collections.Generic;

namespace Paranoia_Site_Generator
{
    public static class ItemExtensions
    {
        static Dictionary<int, string> KeyValuePairs = new Dictionary<int, string>
        {
            { 0, "INFRARED" },
            { 1, "RED" },
            { 2, "ORANGE" },
            { 3, "YELLOW" },
            { 4, "GREEN" },
            { 5, "BLUE" },
            { 6, "INDIGO" },
            { 7, "VIOLET" },
            { 8, "ULTRAVIOLET" },
            { 9, "TREASONOUS" }
        };

        public static string ClearanceName(this int clearanceId)
            => KeyValuePairs.GetValueOrDefault(clearanceId, $"Clearance Id: { clearanceId }");
    }
}
