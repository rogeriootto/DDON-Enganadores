/**
 * @brief Banging the Gates of the Clan Hall
 */

#load "libs.csx"

public class ScriptedQuest : IQuest
{
    public override QuestType QuestType => QuestType.Tutorial;
    public override QuestId QuestId => (QuestId)60200005;
    public override ushort RecommendedLevel => 10;
    public override byte MinimumItemRank => 0;
    public override bool IsDiscoverable => false;
    public override bool? EnableCancel => true;
    public override StageInfo StageInfo => Stage.TheWhiteDragonTemple0;
    public override QuestAdventureGuideCategory? AdventureGuideCategory => QuestAdventureGuideCategory.QuestUsefulForAdventure;

    protected override void InitializeState()
    {
        AddQuestOrderCondition(QuestOrderCondition.PersonalQuestCleared(QuestId.GatheringInTheClanTavernContinued));
        AddQuestOrderCondition(QuestOrderCondition.SoloWithPawns());
    }

    protected override void InitializeRewards()
    {
        AddPointReward(PointType.ExperiencePoints, 700);
        AddWalletReward(WalletType.Gold, 450);
        AddWalletReward(WalletType.RiftPoints, 45);

        AddFixedItemReward(ItemId.RefinedParaffin, 2);
    }

    protected override void InitializeBlocks()
    {
        var process0 = AddNewProcess(0);
        process0.AddRawBlock(QuestAnnounceType.None)
            .AddCheckCmdIsTutorialQuestClear(QuestId.GatheringInTheClanTavern);
        process0.AddNpcTalkAndOrderBlock(Stage.TheWhiteDragonTemple0, NpcId.Kibiza, 18661);
        process0.AddRawBlock(QuestAnnounceType.Accept)
			.AddResultCmdQstTalkChg(NpcId.Kibiza, 18662)
			.AddCheckCmdTouchClanBoard();
        process0.AddTalkToNpcBlock(QuestAnnounceType.CheckpointAndUpdate, Stage.TheWhiteDragonTemple0, NpcId.Kibiza, 18663);
        process0.AddNewTalkToNpcBlock(QuestAnnounceType.CheckpointAndUpdate, Stage.TheWhiteDragonTemple0, 0, 0, NpcId.ArisenCorpsRegimentalSoldier7, 18665)
			.AddResultCmdQstTalkChg(NpcId.Kibiza, 18664)
			.AddResultCmdQstLayoutFlagOn(4041);
        process0.AddProcessEndBlock(true)
			.AddResultCmdTutorialDialog(TutorialId.ClanLevelsandClanHalls);
    }
}

return new ScriptedQuest();
