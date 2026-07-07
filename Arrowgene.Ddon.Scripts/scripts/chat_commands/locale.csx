public class ChatCommand : IChatCommand
{
    public override AccountStateType AccountState => AccountStateType.Muted;
    public override string CommandName => "locale";
    public override string HelpText => "usage: `/locale [region]` - Set your account region";

    public override void Execute(DdonGameServer server, string[] command, GameClient client, ChatMessage message, List<ChatResponse> responses)
    {
        if (command.Length >= 1)
        {
            if (LocaleDictionary.TryGetValue(command[0], out string localeCode))
            {
                client.Account.Locale = localeCode;
                server.Database.UpdateAccount(client.Account);
                responses.Add(ChatResponse.ServerChat(client, $"Locale updated to {localeCode}"));
            }
            else
            {
                responses.Add(ChatResponse.CommandError(client, $"Invalid locale. It must be one of the following: {string.Join(", ", LocaleDictionary.Keys)}"));
                return;
            }
        } 
    }

    private static readonly Dictionary<string, string> LocaleDictionary = new Dictionary<string, string>()
    {
        {"EN", "en-US"},
        {"JP", "ja-JP"},
        {"DE", "de"},
        {"ES", "es"}
    };
}

return new ChatCommand();
