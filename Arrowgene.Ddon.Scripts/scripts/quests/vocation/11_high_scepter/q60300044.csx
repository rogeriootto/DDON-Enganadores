/**
 * @brief The High Scepter's Heir
 */

#load "libs.csx"

public class ScriptedQuest : IQuest
{
    public override QuestType QuestType => QuestType.Tutorial;
    public override QuestId QuestId => QuestId.TheHighSceptersHeir;
    public override ushort RecommendedLevel => 10;
    public override byte MinimumItemRank => 0;
    public override bool IsDiscoverable => true;
    public override bool? EnableCancel => true;
    public override StageInfo StageInfo => Stage.TheWhiteDragonTemple0;
    public override QuestAdventureGuideCategory? AdventureGuideCategory => QuestAdventureGuideCategory.VocationQuest;

    private class QstLayoutFlag
    {
        // st0503
        public const uint Barris0 = 7411;
        public const uint Barris1 = 7735;
    }

    private class EnemyGroupId
    {
        public const uint Set7413 = 7413;
        public const uint Set7414 = 7414;
    }

    protected override void InitializeState()
    {
        AddQuestOrderCondition(QuestOrderCondition.PersonalQuestCleared(QuestId.TheArisensAbilities));
    }

    protected override void InitializeRewards()
    {
        AddPointReward(PointType.ExperiencePoints, 10000);
        AddWalletReward(WalletType.Gold, 10000);
        AddWalletReward(WalletType.RiftPoints, 3000);

        AddFixedItemReward(ItemId.Scimitar0, 1);
    }

    protected override void InitializeEnemyGroups()
    {
        AddEnemies(EnemyGroupId.Set7413, Stage.SmallCaveTombs, 1, QuestEnemyPlacementType.Manual, new()
        {
            LibDdon.Enemy.Create(EnemyId.WarriorUndead, 10, 88, 0),
            LibDdon.Enemy.Create(EnemyId.UndeadMale, 10, 44, 1),
            LibDdon.Enemy.Create(EnemyId.WarriorUndead, 10, 88, 2),
            LibDdon.Enemy.Create(EnemyId.UndeadMale, 10, 44, 3),
            LibDdon.Enemy.Create(EnemyId.WarriorUndead, 10, 88, 4),
        });

        AddEnemies(EnemyGroupId.Set7414, Stage.SmallCaveTombs, 1, QuestEnemyPlacementType.Manual, new()
        {
            LibDdon.Enemy.Create(EnemyId.SwordUndead, 10, 60, 0),
            LibDdon.Enemy.Create(EnemyId.WarriorUndead, 10, 88, 1),
            LibDdon.Enemy.Create(EnemyId.SwordUndead, 10, 60, 2),
            LibDdon.Enemy.Create(EnemyId.WarriorUndead, 10, 88, 3),
            LibDdon.Enemy.Create(EnemyId.SwordUndead, 10, 60, 4),
        });
    }

    protected override void InitializeBlocks()
    {
        var process0 = AddNewProcess(0);
        process0.AddRawBlock(QuestAnnounceType.None)
            .AddCheckCmdIsMainQuestClear(QuestId.TheSlumberingGod);
        process0.AddNpcTalkAndOrderBlock(Stage.TheWhiteDragonTemple0, NpcId.Renton0, 29199);
        process0.AddTalkToNpcBlock(QuestAnnounceType.Accept, Stage.CraftRoom, NpcId.Craig0, 27144) // Hear what Craig has to say in the Craft Room
            .AddResultCmdQstTalkChg(NpcId.Renton0, 29200);
        process0.AddIsStageNoBlock(QuestAnnounceType.CheckpointAndUpdate, Stage.SmallCaveTombs) // Head to "Small Cave Tombs" and stand-in for Craig
            .AddResultCmdQstTalkChg(NpcId.Craig0, 27145);
        process0.AddDiscoverGroupBlock(QuestAnnounceType.CheckpointAndUpdate, EnemyGroupId.Set7413); // Investigate a mysterious person
        process0.AddDestroyGroupBlock(QuestAnnounceType.Update, EnemyGroupId.Set7413, false); // Defeat the enemy encountered
        process0.AddDestroyGroupBlock(QuestAnnounceType.None, EnemyGroupId.Set7414)
            .AddQuestFlag(QuestFlagType.QstLayout, QuestFlagAction.Set, QstLayoutFlag.Barris0)
            .AddResultCmdPlayMessage(29145, 10)
            .AddResultCmdPlayMessage(29146, 10)
            .AddResultCmdPlayMessage(29147, 10);
        process0.AddNewTalkToNpcBlock(QuestAnnounceType.CheckpointAndUpdate, Stage.SmallCaveTombs, 1, 0, NpcId.Barris, 29148) // Speak to the person who assisted
            .AddQuestFlag(QuestFlagType.QstLayout, QuestFlagAction.Clear, QstLayoutFlag.Barris0)
            .AddQuestFlag(QuestFlagType.QstLayout, QuestFlagAction.Set, QstLayoutFlag.Barris1)
            .AddResultCmdStopMessage();
        process0.AddTalkToNpcBlock(QuestAnnounceType.CheckpointAndUpdate, Stage.CraftRoom, NpcId.Craig0, 27146)  // Return to the Craft Room and report to Craig
            .AddResultCmdQstTalkChg(NpcId.Barris, 29149);
        process0.AddProcessEndBlock(true)
            .AddResultCmdReleaseAnnounce(ContentsRelease.ChangetoHighScepter, TutorialId.BasicTacticsHighScepter)
            .AddResultCmdReleaseAnnounce(ContentsRelease.HighScepterJobTraining, TutorialId.JobTrainingLog);
    }
}

return new ScriptedQuest();
