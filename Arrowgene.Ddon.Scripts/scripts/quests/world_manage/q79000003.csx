/**
 * @brief Quest used to test out flags without reloading the server or changing quest files
 */

#load "libs.csx"

public class ScriptedQuest : IQuest
{
    public override QuestType QuestType => QuestType.WorldManage;
    public override QuestId QuestId => QuestId.WorldManageDebug;
    public override ushort RecommendedLevel => 0;
    public override byte MinimumItemRank => 0;
    public override bool IsDiscoverable => false;

    protected override void InitializeBlocks()
    {
        var process0 = AddNewProcess(0);
        process0.AddNoProgressBlock();
        process0.AddNoProgressBlock();
        process0.AddProcessEndBlock(false);

		// Area Master Doris: Eli Guard Tower (until AR7)
        var process1 = AddNewProcess(1);
        process1.AddRawBlock(QuestAnnounceType.None)
			.AddCheckCmdIsMainQuestClear(QuestId.TheRoadToTheRoyalCapital);
		process1.AddRawBlock(QuestAnnounceType.None)
            .AddQuestFlag(QuestFlagAction.Set, QuestFlags.EliGuardTower.Doris)
			.AddCheckCmdCheckAreaRank(QuestAreaId.MegadosysPlateau, 7)
			.AddCheckCmdStageNoNotEq(Stage.EliGuardTower); // Don't despawn her in front of the player
        process1.AddProcessEndBlock(false)
            .AddQuestFlag(QuestFlagAction.Clear, QuestFlags.EliGuardTower.Doris);
    }
}

return new ScriptedQuest();
