/**
 * @brief Adventure Spot Guide: Megadosys Plateau III
 */

#load "libs.csx"

public class ScriptedQuest : IQuest
{
    public override QuestType QuestType => QuestType.Tutorial;
    public override QuestId QuestId => QuestId.AdventureSpotGuideMegadosysPlateauIII;
    public override ushort RecommendedLevel => 95;
    public override byte MinimumItemRank => 0;
    public override bool IsDiscoverable => true;
    public override bool? EnableCancel => true;
    public override StageInfo StageInfo => Stage.FortressCityMegadoResidentialLevel1;
    public override QuestAdventureGuideCategory? AdventureGuideCategory => QuestAdventureGuideCategory.QuestUsefulForAdventure;

    protected override void InitializeState()
    {
        AddQuestOrderCondition(QuestOrderCondition.HasAreaRank(QuestAreaId.MegadosysPlateau, 8));
    }

    protected override void InitializeRewards()
    {
        AddPointReward(PointType.ExperiencePoints, 105000);
        AddWalletReward(WalletType.Gold, 11000);
        AddWalletReward(WalletType.RiftPoints, 2000);
        AddFixedItemReward(ItemId.RoyalFamilyChantsGrimoire, 1);
    }

    protected override void InitializeBlocks()
    {
        var process0 = AddNewProcess(0);
		process0.AddRawBlock(QuestAnnounceType.None)
            .AddCheckCmdIsMainQuestClear(QuestId.TheFinalBattleOfTheRoyalCapital);
        process0.AddNpcTalkAndOrderBlock(Stage.FortressCityMegadoResidentialLevel1, NpcId.Burj, 28081);
        process0.AddRawBlock(QuestAnnounceType.Accept)
			.AddResultCmdQstTalkChg(NpcId.Burj, 28082)
			.AddCheckCommands([
				QuestManager.CheckCommand.IsEnemyFound(463, 7, -1, 1)
			]);
        process0.AddRawBlock(QuestAnnounceType.Update)
			.AddCheckCmdSceHitIn(Stage.MegadoCathedral, 0);
        process0.AddTalkToNpcBlock(QuestAnnounceType.CheckpointAndUpdate, Stage.FortressCityMegadoResidentialLevel1, NpcId.Burj, 28083);
        process0.AddProcessEndBlock(true);
    }
}

return new ScriptedQuest();
