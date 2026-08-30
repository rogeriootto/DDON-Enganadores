/**
 * @brief Crown and Scepter I
 */

#load "libs.csx"

public class ScriptedQuest : IQuest
{
    public override QuestType QuestType => QuestType.Tutorial;
    public override QuestId QuestId => QuestId.CrownAndScepterI;
    public override ushort RecommendedLevel => 97;
    public override byte MinimumItemRank => 0;
    public override bool IsDiscoverable => false;
    public override bool? EnableCancel => true;
    public override bool? OverrideEnemySpawn => true;
    public override StageInfo StageInfo => Stage.FirefallMountainCampsite;
    public override QuestAdventureGuideCategory? AdventureGuideCategory => QuestAdventureGuideCategory.QuestUsefulForAdventure;
    public override bool Enabled => false;

    public override bool ShowInAdventureGuide(GameClient client)
    {
        return client.Character.HasQuestCompleted(QuestId.TheRelicsOfTheFirstKing) &&
               client.Character.HasQuestCompleted(QuestId.TheHighSceptersHeir);
    }

    protected override void InitializeState()
    {
        AddQuestOrderCondition(QuestOrderCondition.MainQuestCompleted(QuestId.TheRelicsOfTheFirstKing));
        AddQuestOrderCondition(QuestOrderCondition.PersonalQuestCleared(QuestId.TheHighSceptersHeir));
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
        public const uint Set8260 = 8260;
    }

    private class NamedParamId
    {
        public const uint GuardianOfTheUnderworldSpring = 2659;
    }

    protected override void InitializeEnemyGroups()
    {
        AddEnemies(EnemyGroupId.Set8260, Stage.BeforetheSecretSpring, 1, QuestEnemyPlacementType.Manual, new()
        {
            LibDdon.Enemy.Create(EnemyId.Angules0, 97, 13629, 1)
                .SetNamedEnemyParams(NamedParamId.GuardianOfTheUnderworldSpring)
                .SetIsAreaBoss(true)
                .SetIsBoss(true)
                .SetEnemyTargetTypesId(TargetTypesId.AreaBoss),
        });
    }

    protected override void InitializeBlocks()
    {
        var process0 = AddNewProcess(0);
        process0.AddRawBlock(QuestAnnounceType.None)
            .AddCheckCmdIsMainQuestClear(QuestId.TheRelicsOfTheFirstKing);
        process0.AddNewNpcTalkAndOrderBlock(Stage.FirefallMountainCampsite, 0, 0, NpcId.LiberationArmySoldier5, 30927)
            .AddQuestFlag(QuestFlagType.QstLayout, QuestFlagAction.Set, 8258);
        process0.AddTalkToNpcBlock(QuestAnnounceType.Accept, Stage.MegadosysPlateau, NpcId.Kirsty0, 30929)
            .AddResultCmdQstTalkChg(NpcId.LiberationArmySoldier5, 30928);
        process0.AddIsStageNoBlock(QuestAnnounceType.CheckpointAndUpdate, Stage.DarkPathtotheSecretSpring)
            .AddResultCmdQstTalkChg(NpcId.Kirsty0, 30930);
        process0.AddNewTalkToNpcBlock(QuestAnnounceType.Update, Stage.DarkPathtotheSecretSpring, 0, 0, NpcId.Kirsty0, 30931)
            .AddQuestFlag(QuestFlagAction.Clear, QuestFlags.MegadosysPlateau.Kirsty)
            .AddQuestFlag(QuestFlagType.QstLayout, QuestFlagAction.Set, 8259);
        process0.AddIsStageNoBlock(QuestAnnounceType.Update, Stage.BeforetheSecretSpring)
            .AddQuestFlag(QuestFlagType.MyQst, QuestFlagAction.Set, 5031);
        process0.AddDiscoverGroupBlock(QuestAnnounceType.None, EnemyGroupId.Set8260)
            .AddQuestFlag(QuestFlagType.QstLayout, QuestFlagAction.Clear, 8259)
            .AddQuestFlag(QuestFlagType.QstLayout, QuestFlagAction.Set, 8263);
        process0.AddDestroyGroupBlock(QuestAnnounceType.Update, EnemyGroupId.Set8260, resetGroup: false)
            .AddResultCmdPlayMessage(30935, 10)
            .AddResultCmdPlayMessage(30936, 10)
            .AddResultCmdPlayMessage(30937, 10)
            .AddResultCmdPlayMessage(30938, 10)
            .AddResultCmdPlayMessage(30939, 10);
        process0.AddNewTalkToNpcBlock(QuestAnnounceType.Update, Stage.BeforetheSecretSpring, 0, 0, NpcId.Kirsty0, 30932)
            .AddQuestFlag(QuestFlagType.QstLayout, QuestFlagAction.Clear, 8263)
            .AddQuestFlag(QuestFlagType.QstLayout, QuestFlagAction.Set, 8261)
            .AddResultCmdPlayCameraEvent(Stage.BeforetheSecretSpring, 90)
            .AddResultCmdStopMessage();
        process0.AddTalkToNpcBlock(QuestAnnounceType.CheckpointAndUpdate, Stage.MegadosysPlateau, NpcId.Kirsty0, 30933)
            .AddQuestFlag(QuestFlagAction.Set, QuestFlags.MegadosysPlateau.Kirsty)
            .AddQuestFlag(QuestFlagType.MyQst, QuestFlagAction.Set, 5034);
        process0.AddProcessEndBlock(true);

        var process1 = AddNewProcess(1);
        process1.AddRawBlock(QuestAnnounceType.None)
            .AddCheckCmdMyQstFlagOn(5034)
            .AddCheckCmdStageNoNotEq(Stage.BeforetheSecretSpring);
        process1.AddProcessEndBlock(false)
            .AddQuestFlag(QuestFlagType.QstLayout, QuestFlagAction.Clear, 8261)
            .AddResultCmdQstTalkChg(NpcId.Kirsty0, 30934);
    }
}

return new ScriptedQuest();
