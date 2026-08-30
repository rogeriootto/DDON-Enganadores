/**
 * @brief Crown and Scepter IV
 */

#load "libs.csx"

public class ScriptedQuest : IQuest
{
    public override QuestType QuestType => QuestType.Tutorial;
    public override QuestId QuestId => QuestId.CrownAndScepterIV;
    public override ushort RecommendedLevel => 97;
    public override byte MinimumItemRank => 0;
    public override bool IsDiscoverable => false;
    public override bool? EnableCancel => true;
    public override bool? OverrideEnemySpawn => true;
    public override StageInfo StageInfo => Stage.MegadosysPlateau;
    public override QuestAdventureGuideCategory? AdventureGuideCategory => QuestAdventureGuideCategory.QuestUsefulForAdventure;
    public override bool Enabled => false;

    public override bool ShowInAdventureGuide(GameClient client)
    {
        return client.Character.HasQuestCompleted(QuestId.CrownAndScepterIII);
    }

    protected override void InitializeState()
    {
        AddQuestOrderCondition(QuestOrderCondition.PersonalQuestCleared(QuestId.CrownAndScepterIII));
        AddQuestOrderCondition(QuestOrderCondition.SoloWithPawns());
    }

    protected override void InitializeRewards()
    {
        AddPointReward(PointType.ExperiencePoints, 105000);
        AddWalletReward(WalletType.Gold, 11000);
        AddWalletReward(WalletType.RiftPoints, 2000);

        AddFixedItemReward(ItemId.RingOfTheFirstKing, 1);
        AddFixedItemReward(ItemId.BloodOrb1000Bo, 5);
    }

    private class EnemyGroupId
    {
        public const uint Set8273 = 8273;
        public const uint Set8274 = 8274;
    }

    private class NamedParamId
    {
        public const uint AncientUnderworldSpirit = 2662;
        public const uint GuardianOfTheRing = 2679;
    }

    protected override void InitializeEnemyGroups()
    {
        AddEnemies(EnemyGroupId.Set8273, Stage.CrumblingEntrancePath, 0, QuestEnemyPlacementType.Manual, new()
        {
            LibDdon.Enemy.Create(EnemyId.SkeletonLordAbyss, 97, 16738, 1)
                .SetNamedEnemyParams(NamedParamId.AncientUnderworldSpirit),
            LibDdon.Enemy.Create(EnemyId.SkeletonLordAbyss, 97, 16738, 2)
                .SetNamedEnemyParams(NamedParamId.AncientUnderworldSpirit),
        });

        AddEnemies(EnemyGroupId.Set8274, Stage.CrumblingEntrancePath, 0, QuestEnemyPlacementType.Manual, new()
        {
            LibDdon.Enemy.Create(EnemyId.EvilEye0, 97, 23912, 0)
                .SetNamedEnemyParams(NamedParamId.GuardianOfTheRing)
                .SetIsBoss(true),
        });
    }

    protected override void InitializeBlocks()
    {
        var process0 = AddNewProcess(0);
        process0.AddRawBlock(QuestAnnounceType.None)
            .AddCheckCmdIsTutorialQuestClear(QuestId.CrownAndScepterIII);
        process0.AddNpcTalkAndOrderBlock(Stage.MegadosysPlateau, NpcId.Kirsty0, 30968);
        process0.AddIsStageNoBlock(QuestAnnounceType.Accept, Stage.CrumblingEntrancePath)
            .AddResultCmdQstTalkChg(NpcId.Kirsty0, 30969);
        process0.AddNewTalkToNpcBlock(QuestAnnounceType.Update, Stage.CrumblingEntrancePath, 0, 0, NpcId.Kirsty0, 30970)
            .AddQuestFlag(QuestFlagAction.Clear, QuestFlags.MegadosysPlateau.Kirsty)
            .AddQuestFlag(QuestFlagType.QstLayout, QuestFlagAction.Set, 8272);
        process0.AddRawBlock(QuestAnnounceType.Update)
            .AddQuestFlag(QuestFlagType.MyQst, QuestFlagAction.Set, 5049)
            .AddCheckCmdSceHitIn(Stage.CrumblingEntrancePath, 0);
        process0.AddNewTalkToNpcBlock(QuestAnnounceType.Update, Stage.CrumblingEntrancePath, 2, 0, NpcId.Kirsty0, 31031)
            .AddQuestFlag(QuestFlagType.QstLayout, QuestFlagAction.Clear, 8272)
            .AddQuestFlag(QuestFlagType.QstLayout, QuestFlagAction.Set, 8313)
            .AddResultCmdPlayCameraEvent(Stage.CrumblingEntrancePath, 90);
        process0.AddDestroyGroupBlock(QuestAnnounceType.Update, EnemyGroupId.Set8273)
            .AddQuestFlag(QuestFlagType.MyQst, QuestFlagAction.Set, 5051)
            .AddResultCmdPlayMessage(30974, 10)
            .AddResultCmdPlayMessage(30975, 10)
            .AddResultCmdPlayMessage(30976, 10)
            .AddResultCmdPlayMessage(30977, 10)
            .AddResultCmdPlayMessage(30978, 10);
        process0.AddDestroyGroupBlock(QuestAnnounceType.Update, EnemyGroupId.Set8274)
			.AddResultCommands([
				QuestManager.ResultCommand.CallMessage(4513, 31032)
			]);
        process0.AddNewTalkToNpcBlock(QuestAnnounceType.Update, Stage.CrumblingEntrancePath, 1, 0, NpcId.Kirsty0, 30971)
            .AddQuestFlag(QuestFlagType.QstLayout, QuestFlagAction.Clear, 8313)
            .AddQuestFlag(QuestFlagType.QstLayout, QuestFlagAction.Set, 8275)
            .AddResultCmdStopMessage();
        process0.AddTalkToNpcBlock(QuestAnnounceType.CheckpointAndUpdate, Stage.MegadosysPlateau, NpcId.Kirsty0, 30972)
            .AddQuestFlag(QuestFlagType.MyQst, QuestFlagAction.Set, 5052)
            .AddQuestFlag(QuestFlagAction.Set, QuestFlags.MegadosysPlateau.Kirsty)
            .AddResultCmdQstTalkChg(NpcId.Kirsty0, 30950);
        process0.AddProcessEndBlock(true);

        var process1 = AddNewProcess(1);
        process1.AddRawBlock(QuestAnnounceType.None)
            .AddCheckCmdMyQstFlagOn(5052)
            .AddCheckCmdStageNoNotEq(Stage.CrumblingEntrancePath);
        process1.AddProcessEndBlock(false)
            .AddQuestFlag(QuestFlagType.QstLayout, QuestFlagAction.Clear, 8275)
            .AddResultCmdQstTalkChg(NpcId.Kirsty0, 30973);
    }
}

return new ScriptedQuest();
