/**
 * @brief Monster Gathering Spot in "Megadosys Plateau" for "Bridge Training Ground"
 */

#load "libs.csx"

public class MonsterSpotInfo : IMonsterSpotInfo
{
    public override StageLayoutId StageLayoutId => Stage.MegadosysPlateau.AsStageLayoutId(80);
    public override QuestAreaId AreaId => QuestAreaId.MegadosysPlateau;
    public override uint RequiredAreaRank => 6;

    public override void Initialize()
    {
        var dropsTableWarReadyGorecyclopsLightArmor0 = LibDdon.Enemy.GetDropsTable(EnemyId.WarReadyGorecyclopsLightArmor0, 93).Clone()
            .AddDrop(ItemId.LowGradeReinforcedArmor, 1, 1, DropRate.RARE)
            .AddDrop(ItemId.BattleArmorFragment, 1, 1, DropRate.UNCOMMON)
            .AddDrop(ItemId.GiantAnimalSkull, 1, 1, DropRate.RARE);

        var dropsTableRangedSoldierDwarfOrc = LibDdon.Enemy.GetDropsTable(EnemyId.RangedSoldierDwarfOrc, 93).Clone()
            .AddDrop(ItemId.LowGradeReinforcedArmor, 1, 1, DropRate.VERY_RARE)
            .AddDrop(ItemId.BattleArmorFragment, 1, 1, DropRate.RARE)
            .AddDrop(ItemId.GiantAnimalSkull, 1, 1, DropRate.VERY_RARE);

        var dropsTableHeavySoldierDwarfOrc = LibDdon.Enemy.GetDropsTable(EnemyId.HeavySoldierDwarfOrc, 93).Clone()
            .AddDrop(ItemId.LowGradeReinforcedArmor, 1, 1, DropRate.VERY_RARE)
            .AddDrop(ItemId.BattleArmorFragment, 1, 1, DropRate.RARE)
            .AddDrop(ItemId.GiantAnimalSkull, 1, 1, DropRate.VERY_RARE);

        AddEnemies(new List<InstancedEnemy>()
        {
            LibDdon.Enemy.Create(EnemyId.WarReadyGorecyclopsLightArmor0, 93, 21000, 14)
                .SetDropsTable(dropsTableWarReadyGorecyclopsLightArmor0)
                .SetIsBoss(true),
            LibDdon.Enemy.Create(EnemyId.RangedSoldierDwarfOrc, 93, 4200, 15)
                .SetDropsTable(dropsTableRangedSoldierDwarfOrc),
            LibDdon.Enemy.Create(EnemyId.RangedSoldierDwarfOrc, 93, 4200, 16)
                .SetDropsTable(dropsTableRangedSoldierDwarfOrc),
            LibDdon.Enemy.Create(EnemyId.RangedSoldierDwarfOrc, 93, 4200, 17)
                .SetDropsTable(dropsTableRangedSoldierDwarfOrc),
            LibDdon.Enemy.Create(EnemyId.HeavySoldierDwarfOrc, 93, 4200, 18)
                .SetDropsTable(dropsTableHeavySoldierDwarfOrc),
            LibDdon.Enemy.Create(EnemyId.HeavySoldierDwarfOrc, 93, 4200, 19)
                .SetDropsTable(dropsTableHeavySoldierDwarfOrc),
            LibDdon.Enemy.Create(EnemyId.HeavySoldierDwarfOrc, 93, 4200, 20)
                .SetDropsTable(dropsTableHeavySoldierDwarfOrc),
            LibDdon.Enemy.Create(EnemyId.HeavySoldierDwarfOrc, 93, 4200, 21)
                .SetDropsTable(dropsTableHeavySoldierDwarfOrc),
            LibDdon.Enemy.Create(EnemyId.RangedSoldierDwarfOrc, 93, 4200, 22)
                .SetDropsTable(dropsTableRangedSoldierDwarfOrc),
        });
    }
}

return new MonsterSpotInfo();
