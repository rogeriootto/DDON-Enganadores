/**
 * @brief Rathnite Foothills Trial: Captives in the Hills
 */

#load "libs.csx"

public class ScriptedQuest : IQuest
{
    public override QuestType QuestType => QuestType.Tutorial;
    public override QuestId QuestId => (QuestId)60318000;
    public override ushort RecommendedLevel => 83;
    public override byte MinimumItemRank => 0;
    public override bool IsDiscoverable => false;
    public override StageInfo StageInfo => Stage.PiremothTravelersInn;
    public override QuestAdventureGuideCategory? AdventureGuideCategory => QuestAdventureGuideCategory.AreaTrialOrMission;

    private class EnemyGroupId
    {
        public const uint Encounter0 = 10;
        public const uint Encounter1 = 11;
        public const uint Keik1 = 20;
        public const uint Keik2 = 21;
        public const uint Shenay1 = 30;
        public const uint Shenay2 = 31;
        public const uint Empty1 = 40;
    }

    private class NamedParamId
    {
        public const uint ExecutionOfficer = 1836;
        public const uint ExecutionHead = 1837;
    }

    protected override void InitializeState()
    {
        AddQuestOrderCondition(QuestOrderCondition.HasAreaRank(QuestAreaId.RathniteFoothills, 3));
        AddQuestOrderCondition(QuestOrderCondition.MainQuestCompleted(QuestId.InSearchOfHope));
    }

    protected override void InitializeRewards()
    {
        AddPointReward(PointType.ExperiencePoints, 42000);
        AddWalletReward(WalletType.Gold, 11000);
        AddWalletReward(WalletType.RiftPoints, 2000);

        AddFixedItemReward(ItemId.RoyalCrestMedalRathniteDistrict, 3);
        AddFixedItemReward(ItemId.BlazeGrass, 1);
        AddFixedItemReward(ItemId.NaturalCharcoal, 1);
    }

    protected override void InitializeEnemyGroups()
    {
        AddEnemies(EnemyGroupId.Keik1, Stage.RathniteFoothills, 54, QuestEnemyPlacementType.Manual, new()
        {
            LibDdon.Enemy.Create(EnemyId.GrimGoblinFighter, 83, 4200, 6),
            LibDdon.Enemy.Create(EnemyId.GrimGoblinFighter, 83, 4200, 8),
        });

        AddEnemies(EnemyGroupId.Keik2, Stage.RathniteFoothills, 36, QuestEnemyPlacementType.Manual, new()
        {
            LibDdon.Enemy.Create(EnemyId.GrimGoblinFighter, 83, 4200, 2),
            LibDdon.Enemy.Create(EnemyId.GrimGoblinFighter, 83, 4200, 3),
        });

        AddEnemies(EnemyGroupId.Shenay1, Stage.RathniteFoothills, 33, QuestEnemyPlacementType.Manual, new()
        {
            LibDdon.Enemy.Create(EnemyId.SwordSoldierDwarfOrc, 83, 4200, 0),
            LibDdon.Enemy.Create(EnemyId.SwordSoldierDwarfOrc, 83, 4200, 1),
        });

        AddEnemies(EnemyGroupId.Shenay2, Stage.RathniteFoothills, 4, QuestEnemyPlacementType.Manual, new()
        {
            LibDdon.Enemy.Create(EnemyId.SwordSoldierDwarfOrc, 83, 4200, 3),
            LibDdon.Enemy.Create(EnemyId.SwordSoldierDwarfOrc, 83, 4200, 4),
        });

        AddEnemies(EnemyGroupId.Empty1, Stage.RathniteFoothills, 66, QuestEnemyPlacementType.Manual, new()
        {
        });

        AddEnemies(EnemyGroupId.Encounter0, Stage.RathniteFoothills, 39, QuestEnemyPlacementType.Manual, new()
        {
            LibDdon.Enemy.Create(EnemyId.SwordSoldierDwarfOrc, 83, 4200, 0)
                .SetNamedEnemyParams(NamedParamId.ExecutionOfficer),
            LibDdon.Enemy.Create(EnemyId.HeavySoldierDwarfOrc, 83, 4200, 2)
                .SetNamedEnemyParams(NamedParamId.ExecutionOfficer),
            LibDdon.Enemy.Create(EnemyId.SwordSoldierDwarfOrc, 83, 4200, 3)
                .SetNamedEnemyParams(NamedParamId.ExecutionOfficer),
        });

        AddEnemies(EnemyGroupId.Encounter1, Stage.RathniteFoothills, 66, QuestEnemyPlacementType.Manual, new()
        {
            LibDdon.Enemy.Create(EnemyId.RangedSoldierDwarfOrc, 83, 4200, 0)
                .SetNamedEnemyParams(NamedParamId.ExecutionOfficer),
            LibDdon.Enemy.Create(EnemyId.RangedSoldierDwarfOrc, 83, 4200, 1)
                .SetNamedEnemyParams(NamedParamId.ExecutionOfficer),
            LibDdon.Enemy.Create(EnemyId.SquadLeaderDwarfOrc, 83, 21000, 2)
                .SetNamedEnemyParams(NamedParamId.ExecutionHead),
            LibDdon.Enemy.Create(EnemyId.HeavySoldierDwarfOrc, 83, 4200, 3)
                .SetNamedEnemyParams(NamedParamId.ExecutionOfficer),
            LibDdon.Enemy.Create(EnemyId.HeavySoldierDwarfOrc, 83, 4200, 4)
                .SetNamedEnemyParams(NamedParamId.ExecutionOfficer),
        });
    }

    protected override void InitializeBlocks()
    {
        var process0 = AddNewProcess(0);
        process0.AddRawBlock(QuestAnnounceType.None)
            .AddCheckCmdCheckAreaRank(QuestAreaId.RathniteFoothills, 3);
        process0.AddNpcTalkAndOrderBlock(Stage.PiremothTravelersInn, NpcId.Endale, 23630)
            .AddQuestFlag(QuestFlagAction.Set, QuestFlags.PiremothTravelersInn.Endale);
		process0.AddRawBlock(QuestAnnounceType.Accept)
			.AddResultCommands([
				QuestManager.ResultCommand.QstTalkChg(NpcId.Endale, 23631),
				QuestManager.ResultCommand.QstTalkChg(NpcId.Youin, 23632)
			])
			.AddCheckCommands([
				QuestManager.CheckCommand.RandomGreater(1, 0)
			])
			.AddCheckCommands([
				QuestManager.CheckCommand.RandomGreater(2, 0)
			])
			.AddCheckCommands([
				QuestManager.CheckCommand.TalkNpc(130, NpcId.Youin),
				QuestManager.CheckCommand.DummyNotProgress()
			]);
		process0.AddRawBlock(QuestAnnounceType.Update)
			.AddResultCommands([
				QuestManager.ResultCommand.QstTalkChg(NpcId.Youin, 23633)
			])
			.AddCheckCommands([
				QuestManager.CheckCommand.MyQstFlagOn(0)
			]);
        process0.AddSpawnGroupsBlock(QuestAnnounceType.CheckpointAndUpdate, [EnemyGroupId.Encounter0, EnemyGroupId.Empty1])
			.AddResultCommands([
				QuestManager.ResultCommand.QstLayoutFlagOn(6140),
				QuestManager.ResultCommand.QstLayoutFlagOn(6141),
				QuestManager.ResultCommand.QstLayoutFlagOn(6142),
				QuestManager.ResultCommand.QstLayoutFlagOn(6143),
				QuestManager.ResultCommand.QstLayoutFlagOn(6144),
				QuestManager.ResultCommand.QstLayoutFlagOn(6145)
			])
			.AddCheckCommands([
				QuestManager.CheckCommand.IsEnemyFoundWithoutMarker(130, 39, -1)
			]);
		process0.AddRawBlock(QuestAnnounceType.Update)
			.AddCheckCommands([
				QuestManager.CheckCommand.MyQstFlagOn(3127)
			])
			.AddCheckCommands([
				QuestManager.CheckCommand.MyQstFlagOn(3128)
			])
			.AddCheckCommands([
				QuestManager.CheckCommand.MyQstFlagOn(3129)
			]);
		process0.AddRawBlock(QuestAnnounceType.Update)
			.AddCheckCommands([
				QuestManager.CheckCommand.MyQstFlagOn(3127),
				QuestManager.CheckCommand.MyQstFlagOn(3128)
			])
			.AddCheckCommands([
				QuestManager.CheckCommand.MyQstFlagOn(3127),
				QuestManager.CheckCommand.MyQstFlagOn(3129)
			])
			.AddCheckCommands([
				QuestManager.CheckCommand.MyQstFlagOn(3128),
				QuestManager.CheckCommand.MyQstFlagOn(3129)
			]);
		process0.AddRawBlock(QuestAnnounceType.Update)
			.AddCheckCommands([
				QuestManager.CheckCommand.MyQstFlagOn(3127),
				QuestManager.CheckCommand.MyQstFlagOn(3128),
				QuestManager.CheckCommand.MyQstFlagOn(3129)
			]);
        process0.AddDestroyGroupBlock(QuestAnnounceType.None, EnemyGroupId.Encounter0, resetGroup: false);
        process0.AddNewTalkToNpcBlock(QuestAnnounceType.Update, Stage.RathniteFoothills, 4, 0, NpcId.Guy, 24247);
        process0.AddDestroyGroupBlock(QuestAnnounceType.Update, EnemyGroupId.Encounter1)
			.AddResultCommands([
				QuestManager.ResultCommand.CallGeneralAnnounce(1, 100221)
			]);
        process0.AddNewTalkToNpcBlock(QuestAnnounceType.Update, Stage.RathniteFoothills, 4, 0, NpcId.Guy, 24290);
        process0.AddTalkToNpcBlock(QuestAnnounceType.CheckpointAndUpdate, Stage.PiremothTravelersInn, NpcId.Endale, 23634)
			.AddResultCommands([
				QuestManager.ResultCommand.QstLayoutFlagOff(6143),
				QuestManager.ResultCommand.QstLayoutFlagOff(6144),
				QuestManager.ResultCommand.QstLayoutFlagOff(6145)
			]);
        process0.AddProcessEndBlock(true);

		// Branch 1 - Keik
        var process1 = AddNewProcess(1);
		process1.AddRawBlock(QuestAnnounceType.None)
			.AddCheckCommands([
				QuestManager.CheckCommand.TalkNpcChoice(130, NpcId.Youin, 0)
			]);
		process1.AddSpawnGroupsBlock(QuestAnnounceType.None, [EnemyGroupId.Keik1, EnemyGroupId.Keik2])
			.AddResultCommands([
				QuestManager.ResultCommand.SetRandom(1, 1, 2, 0),
				QuestManager.ResultCommand.QstTalkChgFsm(NpcId.Keiku, 24245)
			]);

        var process2 = AddNewProcess(2);
		process2.AddRawBlock(QuestAnnounceType.None)
			.AddCheckCommands([
				QuestManager.CheckCommand.RandomEq(1, 1)
			]);
		process2.AddRawBlock(QuestAnnounceType.None)
			.AddResultCommands([
				QuestManager.ResultCommand.QstLayoutFlagOn(5564)
			])
			.AddCheckCommands([
				QuestManager.CheckCommand.QuestTalkNpcRadius(130, 1, 0, 0)
			]);
		process2.AddRawBlock(QuestAnnounceType.None)
			.AddResultCommands([
				QuestManager.ResultCommand.MyQstFlagOn(0),
				QuestManager.ResultCommand.QstLayoutFlagOff(5564),
				QuestManager.ResultCommand.QstTalkChgFsm(NpcId.Keiku, 24243)
			]);

        var process3 = AddNewProcess(3);
		process3.AddRawBlock(QuestAnnounceType.None)
			.AddCheckCommands([
				QuestManager.CheckCommand.RandomEq(1, 1)
			]);
		process3.AddRawBlock(QuestAnnounceType.None)
			.AddCheckCommands([
				QuestManager.CheckCommand.IsEnemyFoundWithoutMarker(130, 36, -1)
			])
			.AddCheckCommands([
				QuestManager.CheckCommand.IsMyquestLayoutFlagOff(5564)
			])
			.AddCheckCommands([
				QuestManager.CheckCommand.QuestTalkNpcRadius(130, 2, 0, 0),
				QuestManager.CheckCommand.DummyNotProgress()
			]);
		process3.AddRawBlock(QuestAnnounceType.None)
			.AddCheckCommands([
				QuestManager.CheckCommand.IsMyquestLayoutFlagOn(5564)
			]);
		process3.AddRawBlock(QuestAnnounceType.None)
			.AddResultCommands([
				QuestManager.ResultCommand.CallGeneralAnnounce(1, 100312)
			]);

        var process4 = AddNewProcess(4);
		process4.AddRawBlock(QuestAnnounceType.None)
			.AddCheckCommands([
				QuestManager.CheckCommand.RandomEq(1, 2)
			]);
		process4.AddRawBlock(QuestAnnounceType.None)
			.AddResultCommands([
				QuestManager.ResultCommand.QstLayoutFlagOn(6139)
			])
			.AddCheckCommands([
				QuestManager.CheckCommand.QuestTalkNpcRadius(130, 2, 0, 0)
			]);
		process4.AddRawBlock(QuestAnnounceType.None)
			.AddResultCommands([
				QuestManager.ResultCommand.MyQstFlagOn(0),
				QuestManager.ResultCommand.QstLayoutFlagOff(6139),
				QuestManager.ResultCommand.QstTalkChgFsm(NpcId.Keiku, 24243)
			]);

        var process5 = AddNewProcess(5);
		process5.AddRawBlock(QuestAnnounceType.None)
			.AddCheckCommands([
				QuestManager.CheckCommand.RandomEq(1, 2)
			]);
		process5.AddRawBlock(QuestAnnounceType.None)
			.AddCheckCommands([
				QuestManager.CheckCommand.IsEnemyFoundWithoutMarker(130, 54, -1)
			])
			.AddCheckCommands([
				QuestManager.CheckCommand.IsMyquestLayoutFlagOff(6139)
			])
			.AddCheckCommands([
				QuestManager.CheckCommand.QuestTalkNpcRadius(130, 1, 0, 0),
				QuestManager.CheckCommand.DummyNotProgress()
			]);
		process5.AddRawBlock(QuestAnnounceType.None)
			.AddCheckCommands([
				QuestManager.CheckCommand.IsMyquestLayoutFlagOn(6139)
			]);
		process5.AddRawBlock(QuestAnnounceType.None)
			.AddResultCommands([
				QuestManager.ResultCommand.CallGeneralAnnounce(1, 100312)
			]);

		// Branch 2 - Shenay
        var process6 = AddNewProcess(6);
		process6.AddRawBlock(QuestAnnounceType.None)
			.AddCheckCommands([
				QuestManager.CheckCommand.TalkNpcChoice(130, NpcId.Youin, 1)
			]);
		process6.AddSpawnGroupsBlock(QuestAnnounceType.None, [EnemyGroupId.Shenay1, EnemyGroupId.Shenay2])
			.AddResultCommands([
				QuestManager.ResultCommand.SetRandom(2, 1, 2, 0),
				QuestManager.ResultCommand.QstTalkChgFsm(NpcId.Shenai, 24244)
			]);

        var process7 = AddNewProcess(7);
		process7.AddRawBlock(QuestAnnounceType.None)
			.AddCheckCommands([
				QuestManager.CheckCommand.RandomEq(2, 1)
			]);
		process7.AddRawBlock(QuestAnnounceType.None)
			.AddResultCommands([
				QuestManager.ResultCommand.QstLayoutFlagOn(6147)
			])
			.AddCheckCommands([
				QuestManager.CheckCommand.QuestTalkNpcRadius(130, 10, 0, 0)
			]);
		process7.AddRawBlock(QuestAnnounceType.None)
			.AddResultCommands([
				QuestManager.ResultCommand.MyQstFlagOn(0),
				QuestManager.ResultCommand.QstLayoutFlagOff(6147),
				QuestManager.ResultCommand.QstTalkChgFsm(NpcId.Shenai, 24246)
			]);

        var process8 = AddNewProcess(8);
		process8.AddRawBlock(QuestAnnounceType.None)
			.AddCheckCommands([
				QuestManager.CheckCommand.RandomEq(2, 1)
			]);
		process8.AddRawBlock(QuestAnnounceType.None)
			.AddCheckCommands([
				QuestManager.CheckCommand.IsEnemyFoundWithoutMarker(130, 4, -1)
			])
			.AddCheckCommands([
				QuestManager.CheckCommand.IsMyquestLayoutFlagOff(6147)
			])
			.AddCheckCommands([
				QuestManager.CheckCommand.QuestTalkNpcRadius(130, 3, 0, 0),
				QuestManager.CheckCommand.DummyNotProgress()
			]);
		process8.AddRawBlock(QuestAnnounceType.None)
			.AddCheckCommands([
				QuestManager.CheckCommand.IsMyquestLayoutFlagOn(6147)
			]);
		process8.AddRawBlock(QuestAnnounceType.None)
			.AddResultCommands([
				QuestManager.ResultCommand.CallGeneralAnnounce(1, 100312)
			]);

        var process9 = AddNewProcess(9);
		process9.AddRawBlock(QuestAnnounceType.None)
			.AddCheckCommands([
				QuestManager.CheckCommand.RandomEq(2, 2)
			]);
		process9.AddRawBlock(QuestAnnounceType.None)
			.AddResultCommands([
				QuestManager.ResultCommand.QstLayoutFlagOn(6148)
			])
			.AddCheckCommands([
				QuestManager.CheckCommand.QuestTalkNpcRadius(130, 3, 0, 0)
			]);
		process9.AddRawBlock(QuestAnnounceType.None)
			.AddResultCommands([
				QuestManager.ResultCommand.MyQstFlagOn(0),
				QuestManager.ResultCommand.QstLayoutFlagOff(6148),
				QuestManager.ResultCommand.QstTalkChgFsm(NpcId.Shenai, 24246)
			]);

        var process10 = AddNewProcess(10);
		process10.AddRawBlock(QuestAnnounceType.None)
			.AddCheckCommands([
				QuestManager.CheckCommand.RandomEq(2, 2)
			]);
		process10.AddRawBlock(QuestAnnounceType.None)
			.AddCheckCommands([
				QuestManager.CheckCommand.IsEnemyFoundWithoutMarker(130, 33, -1)
			])
			.AddCheckCommands([
				QuestManager.CheckCommand.IsMyquestLayoutFlagOff(6148)
			])
			.AddCheckCommands([
				QuestManager.CheckCommand.QuestTalkNpcRadius(130, 10, 0, 0),
				QuestManager.CheckCommand.DummyNotProgress()
			]);
		process10.AddRawBlock(QuestAnnounceType.None)
			.AddCheckCommands([
				QuestManager.CheckCommand.IsMyquestLayoutFlagOn(6148)
			]);
		process10.AddRawBlock(QuestAnnounceType.None)
			.AddResultCommands([
				QuestManager.ResultCommand.CallGeneralAnnounce(1, 100312)
			]);

		// Branch merge - Rescue allies
        var process11 = AddNewProcess(11);
		process11.AddRawBlock(QuestAnnounceType.None)
			.AddCheckCommands([
				QuestManager.CheckCommand.IsMyquestLayoutFlagOn(6143)
			]);
		process11.AddRawBlock(QuestAnnounceType.None)
			.AddCheckCommands([
				QuestManager.CheckCommand.IsOmBrokenQuest(130, 5, 0)
			]);
		process11.AddRawBlock(QuestAnnounceType.None)
            .AddResultCmdMyQstFlagOn(3128); // Guy FSM

        var process12 = AddNewProcess(12);
		process12.AddRawBlock(QuestAnnounceType.None)
			.AddCheckCommands([
				QuestManager.CheckCommand.IsMyquestLayoutFlagOn(6144)
			]);
		process12.AddRawBlock(QuestAnnounceType.None)
			.AddCheckCommands([
				QuestManager.CheckCommand.IsOmBrokenQuest(130, 7, 0)
			]);
		process12.AddRawBlock(QuestAnnounceType.None)
            .AddResultCmdMyQstFlagOn(3129); // Eileen FSM

        var process13 = AddNewProcess(13);
		process13.AddRawBlock(QuestAnnounceType.None)
			.AddCheckCommands([
				QuestManager.CheckCommand.IsMyquestLayoutFlagOn(6145)
			]);
		process13.AddRawBlock(QuestAnnounceType.None)
			.AddCheckCommands([
				QuestManager.CheckCommand.IsOmBrokenQuest(130, 9, 0)
			]);
		process13.AddRawBlock(QuestAnnounceType.None)
            .AddResultCmdMyQstFlagOn(3127); // Ethel FSM
    }
}

return new ScriptedQuest();
