/**
 * @brief Crown and Scepter II
 */

#load "libs.csx"

public class ScriptedQuest : IQuest
{
    public override QuestType QuestType => QuestType.Tutorial;
    public override QuestId QuestId => QuestId.CrownAndScepterII;
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
        return client.Character.HasQuestCompleted(QuestId.CrownAndScepterI);
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
        public const uint Set8265 = 8265;
    }

    private class NamedParamId
    {
        public const uint TheReincarnatedWarlordsPet = 2660;
    }

    protected override void InitializeEnemyGroups()
    {
        AddEnemies(EnemyGroupId.Set8265, Stage.TheRoyalFamilyMausoleum, 1, QuestEnemyPlacementType.Manual, new()
        {
            LibDdon.Enemy.Create(EnemyId.BlazeChimera, 97, 16738, 4)
                .SetNamedEnemyParams(NamedParamId.TheReincarnatedWarlordsPet)
                .SetIsBoss(true),
        });
    }

    protected override void InitializeBlocks()
    {
        var process0 = AddNewProcess(0);
        process0.AddRawBlock(QuestAnnounceType.None)
            .AddCheckCmdIsTutorialQuestClear(QuestId.CrownAndScepterI);
        process0.AddNpcTalkAndOrderBlock(Stage.MegadosysPlateau, NpcId.Kirsty0, 30946);
        process0.AddIsStageNoBlock(QuestAnnounceType.Accept, Stage.TheRoyalFamilyMausoleum)
            .AddResultCmdQstTalkChg(NpcId.Kirsty0, 30947);
        process0.AddNewTalkToNpcBlock(QuestAnnounceType.Update, Stage.TheRoyalFamilyMausoleum, 0, 0, NpcId.Kirsty0, 30948)
            .AddQuestFlag(QuestFlagAction.Clear, QuestFlags.MegadosysPlateau.Kirsty)
            .AddQuestFlag(QuestFlagType.QstLayout, QuestFlagAction.Set, 8264);
        process0.AddDiscoverGroupBlock(QuestAnnounceType.Update, EnemyGroupId.Set8265)
            .AddQuestFlag(QuestFlagType.MyQst, QuestFlagAction.Set, 5037);
        process0.AddDestroyGroupBlock(QuestAnnounceType.Update, EnemyGroupId.Set8265, resetGroup: false)
            .AddResultCmdPlayMessage(30952, 10)
            .AddResultCmdPlayMessage(30953, 10)
            .AddResultCmdPlayMessage(30954, 10)
            .AddResultCmdPlayMessage(30955, 10)
            .AddResultCmdPlayMessage(30956, 10);
        process0.AddNewTalkToNpcBlock(QuestAnnounceType.Update, Stage.TheRoyalFamilyMausoleum, 1, 0, NpcId.Kirsty0, 30949)
            .AddQuestFlag(QuestFlagType.QstLayout, QuestFlagAction.Clear, 8264)
            .AddQuestFlag(QuestFlagType.QstLayout, QuestFlagAction.Set, 8267)
            .AddResultCmdPlayCameraEvent(Stage.TheRoyalFamilyMausoleum, 90)
            .AddResultCmdStopMessage();
        process0.AddTalkToNpcBlock(QuestAnnounceType.CheckpointAndUpdate, Stage.MegadosysPlateau, NpcId.Kirsty0, 30950)
            .AddQuestFlag(QuestFlagAction.Set, QuestFlags.MegadosysPlateau.Kirsty)
            .AddQuestFlag(QuestFlagType.MyQst, QuestFlagAction.Set, 5040);
        process0.AddProcessEndBlock(true);

        var process1 = AddNewProcess(1);
        process1.AddRawBlock(QuestAnnounceType.None)
            .AddCheckCmdMyQstFlagOn(5040)
            .AddCheckCmdStageNoNotEq(Stage.BeforetheSecretSpring);
        process1.AddProcessEndBlock(false)
            .AddQuestFlag(QuestFlagType.QstLayout, QuestFlagAction.Clear, 8267)
            .AddResultCmdQstTalkChg(NpcId.Kirsty0, 30951);
    }
}

return new ScriptedQuest();
