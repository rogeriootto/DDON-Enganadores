/**
 * @brief Adventure Spot Guide: Megadosys Plateau I
 */

#load "libs.csx"

public class ScriptedQuest : IQuest
{
    public override QuestType QuestType => QuestType.Tutorial;
    public override QuestId QuestId => QuestId.AdventureSpotGuideMegadosysPlateauI;
    public override ushort RecommendedLevel => 90;
    public override byte MinimumItemRank => 0;
    public override bool IsDiscoverable => true;
    public override bool? EnableCancel => true;
    public override StageInfo StageInfo => Stage.EliGuardTower;
    public override QuestAdventureGuideCategory? AdventureGuideCategory => QuestAdventureGuideCategory.QuestUsefulForAdventure;

    protected override void InitializeState()
    {
        AddQuestOrderCondition(QuestOrderCondition.HasAreaRank(QuestAreaId.MegadosysPlateau, 2));
    }

    protected override void InitializeRewards()
    {
        AddPointReward(PointType.ExperiencePoints, 105000);
        AddWalletReward(WalletType.Gold, 11000);
        AddWalletReward(WalletType.RiftPoints, 2000);
        AddFixedItemReward(ItemId.CaveShrimpEggs, 1);
    }

    protected override void InitializeBlocks()
    {
        var process0 = AddNewProcess(0);
		process0.AddRawBlock(QuestAnnounceType.None)
            .AddCheckCmdIsMainQuestClear(QuestId.TheRoadToTheRoyalCapital);
        process0.AddNpcTalkAndOrderBlock(Stage.EliGuardTower, NpcId.Lucas, 28037);
        process0.AddRawBlock(QuestAnnounceType.Accept)
            .AddResultCmdQstTalkChg(NpcId.Lucas, 28038)
            .AddCheckCommands([
                QuestManager.CheckCommand.IsEnemyFound(1006, 10, -1, 1)
            ]);
        process0.AddRawBlock(QuestAnnounceType.Update)
            .AddCheckCmdSceHitIn(Stage.QuietConcealedCave, 0);
        process0.AddTalkToNpcBlock(QuestAnnounceType.CheckpointAndUpdate, Stage.EliGuardTower, NpcId.Lucas, 28039);
        process0.AddProcessEndBlock(true);
    }
}

return new ScriptedQuest();
