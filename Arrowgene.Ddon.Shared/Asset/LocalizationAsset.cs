using Arrowgene.Logging;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;

namespace Arrowgene.Ddon.Shared.Asset
{
    public class LocalizationAsset
    {
        private static readonly ILogger Logger = LogProvider.Logger(typeof(LocalizationAsset));

        public ConcurrentDictionary<string, Dictionary<string, string>> Translations = new();
        public ConcurrentDictionary<string, string> NotFound = new();
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
                    return SafeFormat(value, locale, key, args);
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
                        return SafeFormat(fallbackValue, locale, key, args);
                    }
                }
            }

            return GetNotFoundString(locale, key);
        }

        public string GetLocalizedString(Enum key, string locale, params object[] args)
        {
            return GetLocalizedString(key.ToString(), locale, args);
        }

        private string SafeFormat(string format, string locale, string key, params object[] args)
        {
            if (string.IsNullOrEmpty(format)) return string.Empty;
            if (args == null || args.Length == 0) return format;

            try
            {
                return string.Format(format, args);
            }
            catch (FormatException)
            {
                Logger.Error($"Exception in {locale} for key {key}");
                return GetNotFoundString(locale, key);
            }            
        }

        private string GetNotFoundString(string locale, string key)
        {
            NotFound.TryGetValue(locale, out string missing);
            if (string.IsNullOrEmpty(missing)) missing = "MISSING";
            return $"[{missing}:{key}:{locale}]";
        }
    }
}
