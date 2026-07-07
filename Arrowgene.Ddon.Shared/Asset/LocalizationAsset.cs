using Arrowgene.Ddon.Shared.AssetReader;
using Arrowgene.Logging;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Globalization;
using System.Reflection.Metadata.Ecma335;
using System.Text;

namespace Arrowgene.Ddon.Shared.Asset
{
    public class LocalizationAsset
    {
        private static readonly ILogger Logger = LogProvider.Logger(typeof(LocalizationAsset));

        public ConcurrentDictionary<string, Dictionary<string, string>> Translations = new();
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
                    return string.Format(value,args);
                }
            }

            if (locale != FallbackLocale)
            {
                if (Translations.ContainsKey(FallbackLocale))
                {
                    var fallbackData = Translations[FallbackLocale];
                    if (fallbackData.TryGetValue(key, out var fallbackValue))
                    {
                        return string.Format(fallbackValue,args);
                    }
                }
            }

            Logger.Error($"Missing {locale} translation for: {key}");
            return string.Format(key,args);
        }
    }
}
