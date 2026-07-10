/**
 * @brief Seeking the Master: Seeker
 */

#load "libs.csx"

public class ScriptedQuest : IQuest
{
    public override QuestType QuestType => QuestType.Tutorial;
    public override QuestId QuestId => QuestId.SeekingTheMasterSeeker;
    public override ushort RecommendedLevel => 18;
    public override byte MinimumItemRank => 0;
    public override bool IsDiscoverable => true;
    public override bool? EnableCancel => true;
    public override StageInfo StageInfo => Stage.TheWhiteDragonTemple0;
    public override QuestAdventureGuideCategory? AdventureGuideCategory => QuestAdventureGuideCategory.VocationQuest;

    public override bool ShowInAdventureGuide(GameClient client)
    {
        return client.Character.AreaRanks[QuestAreaId.DoweValley].Rank == 5 &&
               client.Character.ActiveCharacterJobData.Job == JobId.Seeker;
    }

    protected override void InitializeState()
    {
        AddQuestOrderCondition(QuestOrderCondition.MinimumVocationLevel(JobId.Seeker, 18));
    }

    protected override void InitializeRewards()
    {
        AddPointReward(PointType.ExperiencePoints, 2500);
        AddWalletReward(WalletType.Gold, 1000);
        AddWalletReward(WalletType.RiftPoints, 300);

        AddFixedItemReward(ItemId.ConquerorsAmulet, 1);
    }

    protected override void InitializeBlocks()
    {
        var process0 = AddNewProcess(0);
        process0.AddRawBlock(QuestAnnounceType.None)
            .AddCheckCmdPlJobEq(JobId.Seeker)
            .AddCheckCmdJobLevelNotLess(QuestLevelCheckType.Current, 18)
            .AddCheckCmdCheckAreaRank(QuestAreaId.DoweValley, 5);
        process0.AddNpcTalkAndOrderBlock(Stage.TheWhiteDragonTemple0, NpcId.Renton0, 14025);
        process0.AddTalkToNpcBlock(QuestAnnounceType.Accept, Stage.LoneHouseintheValley, NpcId.Chester0, 14027)
            .AddResultCmdQstTalkChg(NpcId.Renton0, 14026);
        process0.AddProcessEndBlock(true)
            .AddResultCmdReleaseAnnounce(ContentsRelease.SeekerJobTraining, TutorialId.JobTrainingLog);
    }
}

return new ScriptedQuest();
