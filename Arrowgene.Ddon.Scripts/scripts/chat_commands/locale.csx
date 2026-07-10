using Arrowgene.Ddon.Shared.Model.Localization;
using System.Collections.Concurrent;

public class ChatCommand : IChatCommand
{
    public override AccountStateType AccountState => AccountStateType.Muted;
    public override string CommandName => "locale";
    public override string HelpText => "usage: `/locale [region]` - Set your account region";

    public override void Execute(DdonGameServer server, string[] command, GameClient client, ChatMessage message, List<ChatResponse> responses)
    {
        string T(Translated key, string locale, params object[] args) => server.AssetRepository.LocalizationAssets.GetLocalizedString(key, locale, args);
        ConcurrentDictionary<string,string> Locales = new(server.AssetRepository.LocalizationAssets.NotFound);

        if (command.Length >= 1)
        {
            if (Locales.ContainsKey(command[0]))
            {
                string localeCode = command[0];
                client.Account.Locale = localeCode;
                server.Database.UpdateAccount(client.Account);
                responses.Add(ChatResponse.ServerChat(client, T(Translated.LocaleUpdated, localeCode, localeCode)));
                return;
            }
            else
            {
                responses.Add(ChatResponse.CommandError(client, T(Translated.InvalidLocale, client.Account.Locale,  string.Join(", ", Locales.Keys))));
                return;
            }
        }
        responses.Add(ChatResponse.ServerChat(client, T(Translated.CurrentLocale, client.Account.Locale, client.Account.Locale)));
        responses.Add(ChatResponse.ServerChat(client, T(Translated.AvailableLocales, client.Account.Locale, string.Join(", ", Locales.Keys))));
    }
}

return new ChatCommand();
