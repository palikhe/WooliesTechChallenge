using System.Collections.Generic;

namespace WooliesTechChallenge.Service.Utility
{
    public static class DictionaryExtensions
    {
        public static int TryGetValue(this Dictionary<string, int> dict, string key)
        {
            if (dict.ContainsKey(key)){
                return dict[key];
            }

            return 0;
        }
    }
}
