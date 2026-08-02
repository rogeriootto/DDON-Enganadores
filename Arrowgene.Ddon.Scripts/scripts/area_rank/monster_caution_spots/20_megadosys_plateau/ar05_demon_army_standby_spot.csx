/**
 * @brief Enemy Spot in "Megadosys Plateau" for "Demon Army Standby Spot"
 */

#load "libs.csx"

public class MonsterSpotInfo : IMonsterSpotInfo
{
    public override StageLayoutId StageLayoutId => Stage.MegadosysPlateau.AsStageLayoutId(52);
    public override QuestAreaId AreaId => QuestAreaId.MegadosysPlateau;
    public override uint RequiredAreaRank => 5;
    public override QuestId QuestUnlockId => QuestId.MegadosysPlateauPursueAndDefeatEnemies;

    public override void Initialize()
    {
        var dropsTableBluntSoldier = LibDdon.Enemy.GetDropsTable(EnemyId.BluntSoldierDwarfOrc, 93).Clone()
            .AddDrop(ItemId.AlchemySealerStone, 1, 1, DropRate.VERY_RARE)
            .AddDrop(ItemId.AlchemySealerStoneShard, 1, 1, DropRate.RARE)
            .AddDrop(ItemId.GiantAnimalSkull, 1, 1, DropRate.VERY_RARE)
            .AddDrop(ItemId.RoseMegadosys, 1, 1, DropRate.RARE);

        var dropsTableRangedSoldier = LibDdon.Enemy.GetDropsTable(EnemyId.RangedSoldierDwarfOrc, 93).Clone()
            .AddDrop(ItemId.AlchemySealerStone, 1, 1, DropRate.VERY_RARE)
            .AddDrop(ItemId.AlchemySealerStoneShard, 1, 1, DropRate.RARE)
            .AddDrop(ItemId.GiantAnimalSkull, 1, 1, DropRate.VERY_RARE)
            .AddDrop(ItemId.RoseMegadosys, 1, 1, DropRate.RARE);

        var dropsTableSquadLeader = LibDdon.Enemy.GetDropsTable(EnemyId.SquadLeaderDwarfOrc, 93).Clone()
            .AddDrop(ItemId.AlchemySealerStone, 1, 1, DropRate.RARE)
            .AddDrop(ItemId.AlchemySealerStoneShard, 1, 1, DropRate.UNCOMMON)
            .AddDrop(ItemId.GiantAnimalSkull, 1, 1, DropRate.RARE)
            .AddDrop(ItemId.RoseMegadosys, 1, 1, DropRate.UNCOMMON);

        AddEnemies(new List<InstancedEnemy>()
        {
            LibDdon.Enemy.Create(EnemyId.SquadLeaderDwarfOrc, 93, 4200, 0)
                .SetDropsTable(dropsTableSquadLeader),
            LibDdon.Enemy.Create(EnemyId.RangedSoldierDwarfOrc, 93, 4200, 1)
                .SetDropsTable(dropsTableRangedSoldier),
            LibDdon.Enemy.Create(EnemyId.BluntSoldierDwarfOrc, 93, 4200, 2)
                .SetDropsTable(dropsTableBluntSoldier),
            LibDdon.Enemy.Create(EnemyId.RangedSoldierDwarfOrc, 93, 4200, 3)
                .SetDropsTable(dropsTableRangedSoldier),
            LibDdon.Enemy.Create(EnemyId.BluntSoldierDwarfOrc, 93, 4200, 4)
                .SetDropsTable(dropsTableBluntSoldier),
            LibDdon.Enemy.Create(EnemyId.RangedSoldierDwarfOrc, 93, 4200, 5)
                .SetDropsTable(dropsTableRangedSoldier),
            LibDdon.Enemy.Create(EnemyId.BluntSoldierDwarfOrc, 93, 4200, 6)
                .SetDropsTable(dropsTableBluntSoldier),
            LibDdon.Enemy.Create(EnemyId.RangedSoldierDwarfOrc, 93, 4200, 7)
                .SetDropsTable(dropsTableRangedSoldier),
            LibDdon.Enemy.Create(EnemyId.BluntSoldierDwarfOrc, 93, 4200, 8)
                .SetDropsTable(dropsTableBluntSoldier),
        });
    }
}

return new MonsterSpotInfo();
