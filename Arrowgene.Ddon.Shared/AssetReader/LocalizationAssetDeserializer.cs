using Arrowgene.Ddon.Shared.Asset;
using Arrowgene.Ddon.Shared.Model.Localization;
using Arrowgene.Logging;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

namespace Arrowgene.Ddon.Shared.AssetReader
{
    public class LocalizationAssetDeserializer : IDirectoryAssetHandler
    {
        private static readonly ILogger Logger = LogProvider.Logger(typeof(LocalizationAssetDeserializer));

        private readonly LocalizationAsset _liveAsset;

        public LocalizationAssetDeserializer(LocalizationAsset liveAsset)
        {
            _liveAsset = liveAsset;
        }
        public string DirectoryKey => AssetRepository.LocalizationKey;
        public string Filter => "*.json";
        public object LiveAsset => _liveAsset;

        public bool OnFileChanged(string filePath)
        {
            if (!LoadLocalizationFromFile(filePath, _liveAsset))
                return false;
            return true;
        }

        public void OnFileRemoved(string filePath)
        {
            //Do nothing
        }

        public bool LoadLocalizationsFromDirectory(string path, LocalizationAsset asset)
        {
            DirectoryInfo info = new DirectoryInfo(path);
            if (!info.Exists)
            {
                Logger.Error($"The directory '{path}' does not exist");
                return false;
            }

            Logger.Info($"Reading localization files from {path}");
            foreach (var file in info.EnumerateFiles())
            {
                LoadLocalizationFromFile(file.FullName, asset);
            }

            return true;
        }

        public bool LoadLocalizationFromFile(string filePath, LocalizationAsset asset)
        {
            Logger.Info($"{filePath}");

            string json = Util.ReadAllText(filePath);
            JsonDocument document = JsonDocument.Parse(json);
            JsonElement root = document.RootElement;

            if (root.TryGetProperty("locale", out JsonElement language) == false)
            {
                Logger.Error("Missing locale property, aborting asset load.");
                return false;
            }

            if (root.TryGetProperty("NotFound", out JsonElement notFound) == false)
            {
                Logger.Error("Missing NotFound property, aborting asset load.");
                return false;
            }

            string locale = language.ToString();
            JsonElement translations = root.GetProperty("translations");
            Dictionary<string, string> toAdd = JsonSerializer.Deserialize<Dictionary<string, string>>(translations) ?? [];

            CheckKeys(toAdd, locale);

            if (!asset.NotFound.ContainsKey(locale))
            {
                asset.NotFound.Add(locale, notFound.ToString());
            }

            _liveAsset.Translations.AddOrUpdate(locale, toAdd, (key, existingDict) => {
                foreach (var kvp in toAdd)
                {
                    existingDict[kvp.Key] = kvp.Value;
                }
                return existingDict;
            });

            return true;
        }

        private void CheckKeys(Dictionary<string,string> dict, string locale)
        {
            foreach (string name in System.Enum.GetNames(typeof(Translated)))
            {
                if (!dict.ContainsKey(name))
                {
                    Logger.Error($"Missing translation for {name} in {locale}");
                }
            }
        }
    }
}
