/**
 * @brief Information on Wild Hunt
 */

#load "libs.csx"

public class ScriptedQuest : IQuest
{
    public override QuestType QuestType => QuestType.Tutorial;
    public override QuestId QuestId => (QuestId)61000000; // Schedule ID:
    public override ushort RecommendedLevel => 100;
    public override byte MinimumItemRank => 0;
    public override bool IsDiscoverable => false;
    public override StageInfo StageInfo => Stage.TheWhiteDragonTemple0;
    public override QuestAdventureGuideCategory? AdventureGuideCategory => QuestAdventureGuideCategory.QuestUsefulForAdventure;
    public override bool Enabled => false;

    protected override void InitializeState()
    {
        AddQuestOrderCondition(QuestOrderCondition.MinimumLevel(70));
        AddQuestOrderCondition(QuestOrderCondition.MainQuestCompleted(QuestId.TheNewGeneration));
        AddQuestOrderCondition(QuestOrderCondition.PersonalQuestCleared(QuestId.RoadToMastery));
    }

    protected override void InitializeRewards()
    {
        AddPointReward(PointType.ExperiencePoints, 105000);
        AddWalletReward(WalletType.Gold, 11000);
        AddWalletReward(WalletType.RiftPoints, 2000);

        AddFixedItemReward(ItemId.MandragoraPottedPlant3Passport, 1);
    }

    protected override void InitializeBlocks()
    {
        var process0 = AddNewProcess(0);
        process0.AddRawBlock(QuestAnnounceType.None)
            .AddCheckCmdIsTutorialQuestClear(QuestId.RoadToMastery);
        process0.AddNpcTalkAndOrderBlock(Stage.TheWhiteDragonTemple0, NpcId.Lisa, 31111);
        process0.AddTalkToNpcBlock(QuestAnnounceType.Accept, Stage.TheWhiteDragonTemple0, NpcId.Lisa, 31157);
        process0.AddRawBlock(QuestAnnounceType.CheckpointAndUpdate)
            .AddResultCmdQstTalkChg(NpcId.Lisa, 31113)
            .AddResultCmdReleaseAnnounce(ContentsRelease.WildHuntQuests, TutorialId.WildHuntBasics)
            .AddCheckCmdIsWildHuntClear();
        process0.AddTalkToNpcBlock(QuestAnnounceType.Update, Stage.TheWhiteDragonTemple0, NpcId.Lisa, 31156);
        process0.AddProcessEndBlock(true)
            .AddResultCmdReleaseAnnounce(ContentsRelease.WildHunt, TutorialId.WildHuntAdditionalNotes);
    }
}

return new ScriptedQuest();
