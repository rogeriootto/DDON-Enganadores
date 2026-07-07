/**
 * @brief Seeking the Master: Sorcerer
 */

#load "libs.csx"

public class ScriptedQuest : IQuest
{
    public override QuestType QuestType => QuestType.Tutorial;
    public override QuestId QuestId => QuestId.SeekingTheMasterSorcerer;
    public override ushort RecommendedLevel => 18;
    public override byte MinimumItemRank => 0;
    public override bool IsDiscoverable => true;
    public override bool? EnableCancel => true;
    public override StageInfo StageInfo => Stage.TheWhiteDragonTemple0;
    public override QuestAdventureGuideCategory? AdventureGuideCategory => QuestAdventureGuideCategory.VocationQuest;

    public override bool ShowInAdventureGuide(GameClient client)
    {
        return client.Character.AreaRanks[QuestAreaId.MysreeForest].Rank == 5 &&
               client.Character.ActiveCharacterJobData.Job == JobId.Sorcerer;
    }

    protected override void InitializeState()
    {
        AddQuestOrderCondition(QuestOrderCondition.MinimumVocationLevel(JobId.Sorcerer, 18));
    }

    protected override void InitializeRewards()
    {
        AddPointReward(PointType.ExperiencePoints, 2500);
        AddWalletReward(WalletType.Gold, 1000);
        AddWalletReward(WalletType.RiftPoints, 300);

        AddFixedItemReward(ItemId.DemonsAmulet, 1);
    }

    protected override void InitializeBlocks()
    {
        var process0 = AddNewProcess(0);
        process0.AddRawBlock(QuestAnnounceType.None)
            .AddCheckCmdPlJobEq(JobId.Sorcerer)
            .AddCheckCmdJobLevelNotLess(QuestLevelCheckType.Current, 18)
            .AddCheckCmdCheckAreaRank(QuestAreaId.MysreeForest, 5);
        process0.AddNpcTalkAndOrderBlock(Stage.TheWhiteDragonTemple0, NpcId.Renton0, 14028);
        process0.AddTalkToNpcBlock(QuestAnnounceType.Accept, Stage.LoneHouseintheForest, NpcId.Emerada0, 14030)
            .AddResultCmdQstTalkChg(NpcId.Renton0, 14029);
        process0.AddProcessEndBlock(true)
            .AddResultCmdReleaseAnnounce(ContentsRelease.SorcererJobTraining, TutorialId.JobTrainingLog);
    }
}

return new ScriptedQuest();
