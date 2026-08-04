/**
 * @brief High Scepter Tactics Trial: A Magick Sword
 */

#load "libs.csx"

public class ScriptedQuest : IQuest
{
    private static readonly ServerLogger Logger = LogProvider.Logger<ServerLogger>(typeof(ScriptedQuest));

    public override QuestType QuestType => QuestType.Tutorial;
    public override QuestId QuestId => QuestId.HighScepterTacticsTrialAMagickSword;
    public override ushort RecommendedLevel => 1;
    public override byte MinimumItemRank => 0;
    public override bool IsDiscoverable => true;
    public override bool? EnableCancel => true;
    public override StageInfo StageInfo => Stage.TheWhiteDragonTemple0;
    public override QuestAdventureGuideCategory? AdventureGuideCategory => QuestAdventureGuideCategory.VocationQuest;

    public override bool ShowInAdventureGuide(GameClient client)
    {
        return client.Character.HasQuestCompleted(QuestId.TheHighSceptersHeir) &&
               client.Character.ActiveCharacterJobData.Job == JobId.HighScepter;
    }

    private class EnemyGroupId
    {
        public const uint Set7418 = 7418;
        public const uint Set7419 = 7419;
    }

    private class NamedParamId
    {
        public const uint Training = 47; // Training <name>
        public const uint CaptiveCyclops = 48; // Captive Cyclops
    }

    private class QstLayoutFlag
    {
        // クエスト指定メッセージOM"
        // GroupNo=2, UnitNo=0
        public const uint HighSceptersMark = 7417;

        // Wilson: GroupNo=0, UnitNo=0
        public const uint WilsonAndBarris = 7416;
    }

    private class MyQstFlag
    {
        // NPC State Machine
        public const uint BarrisFSMStart = 4339;
        public const uint BarrisFSMEnd = 4349;
    }

    public override bool AcceptRequirementsMet(GameClient client)
    {
        return client.Character.ActiveCharacterJobData.Job == JobId.HighScepter;
    }

    protected override void InitializeState()
    {
        AddQuestOrderCondition(QuestOrderCondition.MinimumVocationLevel(JobId.HighScepter, 1));
        AddQuestOrderCondition(QuestOrderCondition.Solo());
        AddQuestOrderCondition(QuestOrderCondition.PersonalQuestCleared(QuestId.TheArisensAbilities));
    }

    protected override void InitializeRewards()
    {
        AddPointReward(PointType.ExperiencePoints, 480);
        AddWalletReward(WalletType.Gold, 500);
        AddWalletReward(WalletType.RiftPoints, 130);

        AddFixedItemReward(ItemId.Scimitar4, 1);
        AddFixedItemReward(ItemId.ConquerorsPeriapt, 1);
    }

    protected override void InitializeEnemyGroups()
    {
        // 4 goblins
        AddEnemies(EnemyGroupId.Set7418, Stage.TrainingChapel, 0, QuestEnemyPlacementType.Manual, new()
        {
            LibDdon.Enemy.Create(EnemyId.GoblinFighter0, 1, 0, 0)
                .SetRepopCount(50)
                .SetNamedEnemyParams(NamedParamId.Training),
            LibDdon.Enemy.Create(EnemyId.GoblinFighter0, 1, 0, 1)
                .SetRepopCount(50)
                .SetNamedEnemyParams(NamedParamId.Training),
            LibDdon.Enemy.Create(EnemyId.GoblinFighter0, 1, 0, 2)
                .SetRepopCount(50)
                .SetNamedEnemyParams(NamedParamId.Training),
            LibDdon.Enemy.Create(EnemyId.GoblinFighter0, 1, 0, 3)
                .SetRepopCount(50)
                .SetNamedEnemyParams(NamedParamId.Training),
        });

        AddEnemies(EnemyGroupId.Set7419, Stage.TrainingChapel, 1, QuestEnemyPlacementType.Manual, new()
        {
            LibDdon.Enemy.Create(EnemyId.Cyclops0, 3, 0, 0)
                .SetIsBoss(true)
                .SetNamedEnemyParams(NamedParamId.CaptiveCyclops),
        });
    }

    protected override void InitializeBlocks()
    {
        var process0 = AddNewProcess(0);
        process0.AddRawBlock(QuestAnnounceType.None)
            .AddCheckCmdPlJobEq(JobId.HighScepter);
        process0.AddNpcTalkAndOrderBlock(Stage.TheWhiteDragonTemple0, NpcId.Renton0, 28056);
        process0.AddNewTalkToNpcBlock(QuestAnnounceType.Accept, Stage.TrainingChapel, 0, 0, NpcId.Wilson, 28060)
            .AddResultCmdQstTalkChg(NpcId.Renton0, 28057)
            .AddResultCmdResetTutorialFlag()
            .AddQuestFlag(QuestFlagType.QstLayout, QuestFlagAction.Set, QstLayoutFlag.WilsonAndBarris);
        process0.AddDiscoverGroupBlock(QuestAnnounceType.Update, EnemyGroupId.Set7418)
            .AddResultCmdPlayMessage(28089, 0)
            .AddResultCmdQstTalkChg(NpcId.Wilson, 28058)
            .AddResultCmdTutorialDialog(TutorialId.AdvancedTacticsHighScepter)
            .AddQuestFlag(QuestFlagType.MyQst, QuestFlagAction.Set, MyQstFlag.BarrisFSMStart);
        process0.AddRawBlock(QuestAnnounceType.None)
            .AddResultCmdResetTutorialFlag()
            .AddCheckCmdIsTutorialFlagOn(106); // Attack an enemy with Quadruple Slash
        process0.AddRawBlock(QuestAnnounceType.Update)
            .AddResultCmdPlayMessage(28090, 0)
            .AddResultCmdResetTutorialFlag()
            .AddCheckCmdIsTutorialFlagOn(107); // Activate Will Marker
        process0.AddRawBlock(QuestAnnounceType.Update)
            .AddResultCmdPlayMessage(28091, 0)
            .AddResultCmdResetTutorialFlag()
            .AddCheckCmdIsTutorialFlagOn(108); // Activate Ruin Shot
        process0.AddRawBlock(QuestAnnounceType.Update)
            .AddResultCmdPlayMessage(28092, 0)
            .AddResultCmdResetTutorialFlag()
            .AddCheckCmdIsTutorialFlagOn(109); // Avoid an attack with Dodge Counter Slash
        process0.AddDiscoverGroupBlock(QuestAnnounceType.Update, EnemyGroupId.Set7419)
            .AddResultCmdPlayMessage(28244, 0)
            .AddResultCmdTutorialEnemyInvincibility(true)
            .AddResultCmdTutorialDialog(TutorialId.FightingLargeEnemies)
            .AddResultCmdResetTutorialFlag()
            .AddCheckCmdIsTutorialFlagOn(113); // Attack a marked foe with Magick Glyph to grow it
        process0.AddRawBlock(QuestAnnounceType.Update)
            .AddResultCmdPlayMessage(28245, 0)
            .AddResultCmdResetTutorialFlag()
            .AddCheckCmdIsTutorialFlagOn(114); // Accumulate magick
        process0.AddRawBlock(QuestAnnounceType.Update)
            .AddResultCmdPlayMessage(28093, 0)
            .AddResultCmdResetTutorialFlag()
            .AddCheckCmdIsTutorialFlagOn(110); // Move away from an enemy with Back Leap
        process0.AddRawBlock(QuestAnnounceType.Update)
            .AddResultCmdPlayMessage(28094, 0)
            .AddResultCmdResetTutorialFlag()
            .AddCheckCmdIsTutorialFlagOn(111); // Attack an enemy with Ruin Blade
        process0.AddRawBlock(QuestAnnounceType.Update)
            .AddResultCmdPlayMessage(28095, 0)
            .AddResultCmdResetTutorialFlag()
            .AddCheckCmdIsTutorialFlagOn(112); // Move toward an enemy with Return Shift
        process0.AddDestroyGroupBlock(QuestAnnounceType.Update, EnemyGroupId.Set7419, false)
            .AddResultCmdPlayMessage(28096, 0)
            .AddResultCmdTutorialEnemyInvincibility(false);
        process0.AddOmInteractEventBlock(QuestAnnounceType.CheckpointAndUpdate, Stage.TrainingChapel, 2, 0, OmQuestType.MyQuest, OmInteractType.Touch)
            .AddResultCmdPlayMessage(28097, 0)
            .AddResultCmdTutorialDialog(TutorialId.TacticalRoleoftheHighScepter)
            .AddQuestFlag(QuestFlagType.QstLayout, QuestFlagAction.Set, QstLayoutFlag.HighSceptersMark);
        process0.AddTalkToNpcBlock(QuestAnnounceType.CheckpointAndUpdate, Stage.TheWhiteDragonTemple0, NpcId.Renton0, 28062)
            .AddResultCmdQstTalkChg(NpcId.Wilson, 28061)
            .AddResultCmdQstTalkChg(NpcId.Barris, 28088)
            .AddQuestFlag(QuestFlagType.MyQst, QuestFlagAction.Set, MyQstFlag.BarrisFSMEnd)
            .AddQuestFlag(QuestFlagType.QstLayout, QuestFlagAction.Clear, QstLayoutFlag.HighSceptersMark);
        process0.AddProcessEndBlock(true)
            .AddResultCmdReleaseAnnounce(ContentsRelease.HighScepterWarSkillAugmentation)
            .AddResultCmdReleaseAnnounce(ContentsRelease.WarSkillAugmentation, TutorialId.InheritanceSkillsOfBattleTechniques);

        var process1 = AddNewProcess(1);
        process1.AddRawBlock(QuestAnnounceType.None)
            .AddCheckCmdIsMyquestLayoutFlagOn(7419);
        process1.AddRemoveGroupBlock(QuestAnnounceType.None, EnemyGroupId.Set7418);
        process1.AddProcessEndBlock(false);
    }
}

return new ScriptedQuest();
