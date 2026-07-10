using Arrowgene.Logging;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace Arrowgene.Ddon.Shared.Asset
{
    public class LocalizationAsset
    {
        private static readonly ILogger Logger = LogProvider.Logger(typeof(LocalizationAsset));

        public ConcurrentDictionary<string, Dictionary<string, string>> Translations = new();
        public Dictionary<string, string> NotFound = new();
        private const string FallbackLocale = "en-US";

        public LocalizationAsset()
        {
            Translations = new ConcurrentDictionary<string, Dictionary<string, string>>();
        }

        public string GetLocalizedString(string key, string locale, params object[] args)
        {
            if (Translations.ContainsKey(locale))
            {
                var localizationData = Translations[locale];
                if (localizationData.TryGetValue(key, out var value))
                {
                    return SafeFormat(value,args);
                }
            }

            Logger.Error($"Missing {locale} translation for: {key}");

            if (locale != FallbackLocale)
            {
                if (Translations.ContainsKey(FallbackLocale))
                {
                    var fallbackData = Translations[FallbackLocale];
                    if (fallbackData.TryGetValue(key, out var fallbackValue))
                    {
                        return SafeFormat(fallbackValue,args);
                    }
                }
            }

            //Handle cases where even en-US isn't loaded
            string missing = "MISSING";
            if (NotFound.ContainsKey(locale))
            {
                missing = NotFound[locale];
            }
            return $"[{missing}:{key}:{locale}]";
        }

        public string GetLocalizedString(Enum key, string locale, params object[] args)
        {
            return GetLocalizedString(key.ToString(), locale, args);
        }

        private string SafeFormat(string format, params object[] args)
        {
            if (string.IsNullOrEmpty(format)) return string.Empty;
            if (args == null || args.Length == 0) return format;

            // Find the indexes used in the provided string
            int maxIndex = -1;
            var matches = Regex.Matches(format, @"\{([0-9]+)(?:,.*?)?(?::.*?)?\}");

            foreach (Match match in matches)
            {
                if (int.TryParse(match.Groups[1].Value, out int index))
                {
                    maxIndex = Math.Max(maxIndex, index);
                }
            }

            if (maxIndex >= args.Length)
            {
                Array.Resize(ref args, maxIndex + 1);
            }

            return string.Format(format, args);
        }
    }
}
