/**
 * @brief Seeking the Master: Warrior
 */

#load "libs.csx"

public class ScriptedQuest : IQuest
{
    public override QuestType QuestType => QuestType.Tutorial;
    public override QuestId QuestId => QuestId.SeekingTheMasterWarrior;
    public override ushort RecommendedLevel => 18;
    public override byte MinimumItemRank => 0;
    public override bool IsDiscoverable => true;
    public override bool? EnableCancel => true;
    public override StageInfo StageInfo => Stage.TheWhiteDragonTemple0;
    public override QuestAdventureGuideCategory? AdventureGuideCategory => QuestAdventureGuideCategory.VocationQuest;

    public override bool ShowInAdventureGuide(GameClient client)
    {
        return client.Character.AreaRanks[QuestAreaId.EasternZandora].Rank == 3 &&
               client.Character.ActiveCharacterJobData.Job == JobId.Warrior;
    }

    protected override void InitializeState()
    {
        AddQuestOrderCondition(QuestOrderCondition.MinimumVocationLevel(JobId.Warrior, 18));
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
            .AddCheckCmdPlJobEq(JobId.Warrior)
            .AddCheckCmdJobLevelNotLess(QuestLevelCheckType.Current, 18)
            .AddCheckCmdCheckAreaRank(QuestAreaId.EasternZandora, 3);
        process0.AddNpcTalkAndOrderBlock(Stage.TheWhiteDragonTemple0, NpcId.Renton0, 14034);
        process0.AddTalkToNpcBlock(QuestAnnounceType.Accept, Stage.OswaldsArmorShop, NpcId.Oliver, 14036)
            .AddResultCmdQstTalkChg(NpcId.Renton0, 14035);
        process0.AddProcessEndBlock(true)
            .AddResultCmdReleaseAnnounce(ContentsRelease.WarriorJobTraining, TutorialId.JobTrainingLog);
    }
}

return new ScriptedQuest();
