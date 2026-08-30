/**
 * @brief Crown and Scepter III
 */

#load "libs.csx"

public class ScriptedQuest : IQuest
{
    public override QuestType QuestType => QuestType.Tutorial;
    public override QuestId QuestId => QuestId.CrownAndScepterIII;
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
        return client.Character.HasQuestCompleted(QuestId.CrownAndScepterII);
    }

    protected override void InitializeState()
    {
        AddQuestOrderCondition(QuestOrderCondition.PersonalQuestCleared(QuestId.CrownAndScepterI));
        AddQuestOrderCondition(QuestOrderCondition.SoloWithPawns());
    }

    protected override void InitializeRewards()
    {
        AddPointReward(PointType.ExperiencePoints, 105000);
        AddWalletReward(WalletType.Gold, 11000);
        AddWalletReward(WalletType.RiftPoints, 2000);

        AddFixedItemReward(ItemId.BloodOrb1000Bo, 5);
    }

    private class EnemyGroupId
    {
        public const uint Set8269 = 8269;
    }

    private class NamedParamId
    {
        public const uint AncientUnderworldGateGuardian = 2661;
    }

    protected override void InitializeEnemyGroups()
    {
        AddEnemies(EnemyGroupId.Set8269, Stage.RoyalFamilysSecretPath, 5, QuestEnemyPlacementType.Manual, new()
        {
            LibDdon.Enemy.Create(EnemyId.DeathKnight, 97, 2391, 1)
                .SetNamedEnemyParams(NamedParamId.AncientUnderworldGateGuardian),
            LibDdon.Enemy.Create(EnemyId.Medusa, 97, 7173, 2)
                .SetNamedEnemyParams(NamedParamId.AncientUnderworldGateGuardian)
                .SetIsBoss(true),
            LibDdon.Enemy.Create(EnemyId.DeathKnight, 97, 2391, 6)
                .SetNamedEnemyParams(NamedParamId.AncientUnderworldGateGuardian),
        });
    }

    protected override void InitializeBlocks()
    {
        var process0 = AddNewProcess(0);
        process0.AddRawBlock(QuestAnnounceType.None)
            .AddCheckCmdIsTutorialQuestClear(QuestId.CrownAndScepterII);
        process0.AddNpcTalkAndOrderBlock(Stage.MegadosysPlateau, NpcId.Kirsty0, 30957);
        process0.AddIsStageNoBlock(QuestAnnounceType.Accept, Stage.RoyalFamilysSecretPath)
            .AddResultCmdQstTalkChg(NpcId.Kirsty0, 30958);
        process0.AddNewTalkToNpcBlock(QuestAnnounceType.Update, Stage.RoyalFamilysSecretPath, 0, 0, NpcId.Kirsty0, 30959)
            .AddQuestFlag(QuestFlagAction.Clear, QuestFlags.MegadosysPlateau.Kirsty)
            .AddQuestFlag(QuestFlagType.QstLayout, QuestFlagAction.Set, 8268);
        process0.AddDiscoverGroupBlock(QuestAnnounceType.Update, EnemyGroupId.Set8269)
            .AddQuestFlag(QuestFlagType.MyQst, QuestFlagAction.Set, 5043);
        process0.AddDestroyGroupBlock(QuestAnnounceType.Update, EnemyGroupId.Set8269, resetGroup: false)
            .AddResultCmdPlayMessage(30963, 10)
            .AddResultCmdPlayMessage(30964, 10)
            .AddResultCmdPlayMessage(30965, 10)
            .AddResultCmdPlayMessage(30966, 10)
            .AddResultCmdPlayMessage(30967, 10);
        process0.AddNewTalkToNpcBlock(QuestAnnounceType.Update, Stage.RoyalFamilysSecretPath, 1, 0, NpcId.Kirsty0, 30960)
            .AddQuestFlag(QuestFlagType.QstLayout, QuestFlagAction.Clear, 8268)
            .AddQuestFlag(QuestFlagType.QstLayout, QuestFlagAction.Set, 8271)
            .AddResultCmdPlayCameraEvent(Stage.RoyalFamilysSecretPath, 90)
            .AddResultCmdStopMessage();
        process0.AddTalkToNpcBlock(QuestAnnounceType.CheckpointAndUpdate, Stage.MegadosysPlateau, NpcId.Kirsty0, 30961)
            .AddQuestFlag(QuestFlagAction.Set, QuestFlags.MegadosysPlateau.Kirsty)
            .AddQuestFlag(QuestFlagType.MyQst, QuestFlagAction.Set, 5046);
        process0.AddProcessEndBlock(true);

        var process1 = AddNewProcess(1);
        process1.AddRawBlock(QuestAnnounceType.None)
            .AddCheckCmdMyQstFlagOn(5046)
            .AddCheckCmdStageNoNotEq(Stage.RoyalFamilysSecretPath);
        process1.AddProcessEndBlock(false)
            .AddQuestFlag(QuestFlagType.QstLayout, QuestFlagAction.Clear, 8271)
            .AddResultCmdQstTalkChg(NpcId.Kirsty0, 30962);
    }
}

return new ScriptedQuest();
