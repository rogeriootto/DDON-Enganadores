/**
 * @brief Fighter Tactics Trial: Break Attack
 */

#load "libs.csx"

public class ScriptedQuest : IQuest
{
    public override QuestType QuestType => QuestType.Tutorial;
    public override QuestId QuestId => QuestId.FighterTacticsTrialBreakAttack;
    public override ushort RecommendedLevel => 5;
    public override byte MinimumItemRank => 0;
    public override bool IsDiscoverable => true;
    public override StageInfo StageInfo => Stage.TheWhiteDragonTemple0;
    public override QuestAdventureGuideCategory? AdventureGuideCategory => QuestAdventureGuideCategory.VocationQuest;

    public override bool ShowInAdventureGuide(GameClient client)
    {
        return client.Character.HasQuestCompleted(QuestId.FighterTacticsTrialAStubbornShield) &&
               client.Character.ActiveCharacterJobData.Job == JobId.Fighter;
    }

    private class EnemyGroupId
    {
        public const uint Set162 = 162;
    }

    private class NamedParamId
    {
        public const uint CaptiveCyclops = 48; // Captive Cyclops
    }

    private class QstLayoutFlag
    {
        // Training Chapel
        // Wilson: GroupNo=1, UnitNo=1
        public const uint NpcWilson = 163;
        public const uint ArisenCorpsRegimentalSoldier = 947;

        // GroupNo = 3, UnitNo = 1
        public const uint MarkOfBreaking = 939;
    }

    private class MyQstFlag
    {
        // NPC State Machine
        public const uint EndFsm = 494;
        public const uint StartFsm = 559;
    }

    public override bool AcceptRequirementsMet(GameClient client)
    {
        return client.Character.ActiveCharacterJobData.Job == JobId.Fighter;
    }

    protected override void InitializeState()
    {
        AddQuestOrderCondition(QuestOrderCondition.Solo());
        AddQuestOrderCondition(QuestOrderCondition.MinimumVocationLevel(JobId.Fighter, 1));
        AddQuestOrderCondition(QuestOrderCondition.PersonalQuestCleared(QuestId.TheArisensAbilities));
    }

    protected override void InitializeRewards()
    {
        AddPointReward(PointType.ExperiencePoints, 650);
        AddWalletReward(WalletType.Gold, 800);
        AddWalletReward(WalletType.RiftPoints, 150);

        AddFixedItemReward(ItemId.SuperiorHealingPotion, 3);
        AddFixedItemReward(ItemId.Mace4, 1);
    }

    protected override void InitializeEnemyGroups()
    {
        AddEnemies(EnemyGroupId.Set162, Stage.TrainingChapel, 1, QuestEnemyPlacementType.Manual, new()
        {
            LibDdon.Enemy.Create(EnemyId.Cyclops0, 3, 0, 0, assignDefaultDrops: false)
                .SetIsBoss(true)
                .SetNamedEnemyParams(NamedParamId.CaptiveCyclops),
        });
    }

    protected override void InitializeBlocks()
    {
        var process0 = AddNewProcess(0);
        process0.AddRawBlock(QuestAnnounceType.None)
            .AddCheckCmdPlJobEq(JobId.Fighter)
            .AddCheckCmdIsTutorialQuestClear(QuestId.FighterTacticsTrialAStubbornShield);
        process0.AddNpcTalkAndOrderBlock(Stage.TheWhiteDragonTemple0, NpcId.Renton0, 11575);
        process0.AddNewTalkToNpcBlock(QuestAnnounceType.Accept, Stage.TrainingChapel, 1, 1, NpcId.Wilson, 11585)
            .AddResultCmdQstTalkChg(NpcId.Renton0, 11579)
            .AddQuestFlag(QuestFlagType.QstLayout, QuestFlagAction.Set, QstLayoutFlag.NpcWilson)
            .AddQuestFlag(QuestFlagType.QstLayout, QuestFlagAction.Set, QstLayoutFlag.ArisenCorpsRegimentalSoldier);
        process0.AddDiscoverGroupBlock(QuestAnnounceType.Update, EnemyGroupId.Set162)
            .AddResultCmdQstTalkChg(NpcId.Wilson, 11587)
            .AddResultCmdPlayMessage(14687, 0)
            .AddResultCmdResetTutorialFlag()
            .AddResultCmdTutorialEnemyInvincibility(true)
            .AddResultCmdTutorialDialog(TutorialId.FightingLargeEnemies)
            .AddQuestFlag(QuestFlagType.MyQst, QuestFlagAction.Set, MyQstFlag.StartFsm);
        process0.AddRawBlock(QuestAnnounceType.None)
            .AddResultCmdResetTutorialFlag()
            .AddCheckCmdIsTutorialFlagOn(45, 0)  // Cling to the enemy, and strike at it with Gouge (not enraged)
            .AddCheckCmdIsTutorialFlagOn(57, 1); // Cling to the enemy, and strike at it with Gouge (enraged)
        process0.AddRawBlock(QuestAnnounceType.Update)
            .AddResultCmdPlayMessage(14688, 0)
            .AddResultCmdButtonGuideFlagOn(0)
            .AddResultCmdResetTutorialFlag()
            .AddCheckCmdIsTutorialFlagOn(55); // Use Resist to endure the enemy's swing (yellow icon) while climbing them
        process0.AddRawBlock(QuestAnnounceType.Update)
            .AddResultCmdPlayMessage(14689, 0)
            .AddResultCmdButtonGuideFlagOff(0)
            .AddResultCmdButtonGuideFlagOn(2)
            .AddResultCmdResetTutorialFlag()
            .AddCheckCmdIsTutorialFlagOn(56); // While climbing the enemy, jump off during their knock-away attack (red icon)
        process0.AddRawBlock(QuestAnnounceType.Update)
            .AddResultCmdPlayMessage(14690, 0)
            .AddResultCmdButtonGuideFlagOff(2)
            .AddResultCmdResetTutorialFlag()
            .AddCheckCmdIsTutorialFlagOn(53); // Attack and enrage the enemy
        process0.AddRawBlock(QuestAnnounceType.Update)
            .AddResultCmdPlayMessage(14691, 0)
            .AddResultCmdButtonGuideFlagOn(3)
            .AddResultCmdResetTutorialFlag()
            .AddCheckCmdIsTutorialFlagOn(54); // Shake the enemy while they are enraged and tire them out!
        process0.AddDestroyGroupBlock(QuestAnnounceType.Update, EnemyGroupId.Set162, false)
            .AddResultCmdPlayMessage(14692, 0)
            .AddResultCmdButtonGuideFlagOff(3)
            .AddResultCmdTutorialEnemyInvincibility(false)
            .AddResultCmdTutorialDialog(TutorialId.TacticalRoleoftheFighter);
        process0.AddOmInteractEventBlock(QuestAnnounceType.CheckpointAndUpdate, Stage.TrainingChapel, 3, 1, OmQuestType.MyQuest, OmInteractType.Touch)
            .AddResultCmdPlayMessage(14693, 0)
            .AddQuestFlag(QuestFlagType.QstLayout, QuestFlagAction.Set, QstLayoutFlag.MarkOfBreaking);
        process0.AddTalkToNpcBlock(QuestAnnounceType.CheckpointAndUpdate, Stage.TheWhiteDragonTemple0, NpcId.Renton0, 11578)
            .AddQuestFlag(QuestFlagType.MyQst, QuestFlagAction.Set, MyQstFlag.EndFsm)
            .AddResultCmdQstTalkChg(NpcId.ArisenCorpsRegimentalSoldier6, 14694)
            .AddResultCmdQstTalkChg(NpcId.Wilson, 11592)
            .AddQuestFlag(QuestFlagType.QstLayout, QuestFlagAction.Clear, QstLayoutFlag.MarkOfBreaking);
        process0.AddProcessEndBlock(true)
            .AddResultCmdTutorialDialog(TutorialId.Clinging);
    }
}

return new ScriptedQuest();
