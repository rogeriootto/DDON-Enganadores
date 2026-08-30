/**
 * @brief Gathering in the Clan Tavern (Continued)
 */

#load "libs.csx"

public class ScriptedQuest : IQuest
{
    public override QuestType QuestType => QuestType.Tutorial;
    public override QuestId QuestId => QuestId.GatheringInTheClanTavernContinued;
    public override ushort RecommendedLevel => 1;
    public override byte MinimumItemRank => 0;
    public override bool IsDiscoverable => false;
    public override bool? EnableCancel => true;
    public override StageInfo StageInfo => Stage.TheWhiteDragonTemple0;
    public override QuestAdventureGuideCategory? AdventureGuideCategory => QuestAdventureGuideCategory.QuestUsefulForAdventure;

    protected override void InitializeBlocks()
    {
        var process0 = AddNewProcess(0);
        process0.AddRawBlock(QuestAnnounceType.None)
            .AddCheckCmdIsTutorialQuestClear(QuestId.GatheringInTheClanTavern);
        process0.AddNpcTalkAndOrderBlock(Stage.TheWhiteDragonTemple0, NpcId.Kibiza, 16727);
        process0.AddRawBlock(QuestAnnounceType.Accept)
			.AddResultCmdQstTalkChg(NpcId.Kibiza, 16728)
			.AddCheckCmdIsSearchClan();
        process0.AddTalkToNpcBlock(QuestAnnounceType.CheckpointAndUpdate, Stage.TheWhiteDragonTemple0, NpcId.Kibiza, 16729);
        process0.AddRawBlock(QuestAnnounceType.CheckpointAndUpdate)
			.AddResultCmdQstTalkChg(NpcId.Kibiza, 16730)
			.AddCheckCmdIsOpenAreaListUi();
        process0.AddTalkToNpcBlock(QuestAnnounceType.CheckpointAndUpdate, Stage.TheWhiteDragonTemple0, NpcId.Kibiza, 16731);
        process0.AddProcessEndBlock(true);
    }
}

return new ScriptedQuest();
