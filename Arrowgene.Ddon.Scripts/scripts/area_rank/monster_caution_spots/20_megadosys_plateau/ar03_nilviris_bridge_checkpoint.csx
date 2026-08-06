/**
 * @brief Monster Gathering Spot in "Megadosys Plateau" for "Nilviris Bridge Checkpoint"
 */

#load "libs.csx"

public class MonsterSpotInfo : IMonsterSpotInfo
{
    public override StageLayoutId StageLayoutId => Stage.MegadosysPlateau.AsStageLayoutId(70);
    public override QuestAreaId AreaId => QuestAreaId.MegadosysPlateau;
    public override uint RequiredAreaRank => 3;

    public override void Initialize()
    {
        var dropsTableWarReadyNightmare = LibDdon.Enemy.GetDropsTable(EnemyId.WarReadyNightmareLightArmor, 93).Clone()
            .AddDrop(ItemId.LowGradeReinforcedArmor, 1, 1, DropRate.RARE)
            .AddDrop(ItemId.BattleArmorFragment, 1, 1, DropRate.UNCOMMON)
            .AddDrop(ItemId.GiantAnimalSkull, 1, 1, DropRate.RARE);

        var dropsTableRangedSoldierDwarfOrc = LibDdon.Enemy.GetDropsTable(EnemyId.RangedSoldierDwarfOrc, 93).Clone()
            .AddDrop(ItemId.LowGradeReinforcedArmor, 1, 1, DropRate.VERY_RARE)
            .AddDrop(ItemId.BattleArmorFragment, 1, 1, DropRate.RARE)
            .AddDrop(ItemId.GiantAnimalSkull, 1, 1, DropRate.VERY_RARE);

        AddEnemies(new List<InstancedEnemy>()
        {
            LibDdon.Enemy.Create(EnemyId.WarReadyNightmareLightArmor, 93, 21000, 9)
                .SetDropsTable(dropsTableWarReadyNightmare)
                .SetIsBoss(true),
            LibDdon.Enemy.Create(EnemyId.RangedSoldierDwarfOrc, 93, 4200, 10)
                .SetDropsTable(dropsTableRangedSoldierDwarfOrc),
            LibDdon.Enemy.Create(EnemyId.RangedSoldierDwarfOrc, 93, 4200, 11)
                .SetDropsTable(dropsTableRangedSoldierDwarfOrc),
            LibDdon.Enemy.Create(EnemyId.RangedSoldierDwarfOrc, 93, 4200, 12)
                .SetDropsTable(dropsTableRangedSoldierDwarfOrc),
            LibDdon.Enemy.Create(EnemyId.RangedSoldierDwarfOrc, 93, 4200, 13)
                .SetDropsTable(dropsTableRangedSoldierDwarfOrc),
            LibDdon.Enemy.Create(EnemyId.RangedSoldierDwarfOrc, 93, 4200, 14)
                .SetDropsTable(dropsTableRangedSoldierDwarfOrc),
            LibDdon.Enemy.Create(EnemyId.RangedSoldierDwarfOrc, 93, 4200, 15)
                .SetDropsTable(dropsTableRangedSoldierDwarfOrc),
        });
    }
}

return new MonsterSpotInfo();
