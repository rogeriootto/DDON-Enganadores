/**
 * @brief Adventure Spot Guide: Megadosys Plateau II
 */

#load "libs.csx"

public class ScriptedQuest : IQuest
{
    public override QuestType QuestType => QuestType.Tutorial;
    public override QuestId QuestId => QuestId.AdventureSpotGuideMegadosysPlateauII;
    public override ushort RecommendedLevel => 92;
    public override byte MinimumItemRank => 0;
    public override bool IsDiscoverable => true;
    public override bool? EnableCancel => true;
    public override StageInfo StageInfo => Stage.EliGuardTower;
    public override QuestAdventureGuideCategory? AdventureGuideCategory => QuestAdventureGuideCategory.QuestUsefulForAdventure;

    protected override void InitializeState()
    {
        AddQuestOrderCondition(QuestOrderCondition.HasAreaRank(QuestAreaId.MegadosysPlateau, 5));
    }

    protected override void InitializeRewards()
    {
        AddPointReward(PointType.ExperiencePoints, 105000);
        AddWalletReward(WalletType.Gold, 11000);
        AddWalletReward(WalletType.RiftPoints, 2000);
        AddFixedItemReward(ItemId.SimplePurificationCrystal, 1);
    }

    protected override void InitializeBlocks()
    {
        var process0 = AddNewProcess(0);
		process0.AddRawBlock(QuestAnnounceType.None)
            .AddCheckCmdIsMainQuestClear(QuestId.TheRoadToTheRoyalCapital);
        process0.AddNpcTalkAndOrderBlock(Stage.EliGuardTower, NpcId.Lucas, 28077);
        process0.AddRawBlock(QuestAnnounceType.Accept)
            .AddResultCmdQstTalkChg(NpcId.Lucas, 28078)
            .AddCheckCommands([
                QuestManager.CheckCommand.IsEnemyFound(1025, 10, 0, 1)
            ]);
        process0.AddRawBlock(QuestAnnounceType.Update)
            .AddCheckCmdSceHitIn(Stage.MegadoWaterSupplyNetwork, 0);
        process0.AddTalkToNpcBlock(QuestAnnounceType.CheckpointAndUpdate, Stage.EliGuardTower, NpcId.Lucas, 28079);
        process0.AddProcessEndBlock(true);
    }
}

return new ScriptedQuest();
