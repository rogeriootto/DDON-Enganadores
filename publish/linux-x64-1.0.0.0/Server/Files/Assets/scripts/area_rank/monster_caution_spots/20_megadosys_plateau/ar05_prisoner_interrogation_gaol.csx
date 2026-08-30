/**
 * @brief Enemy Spot in "Megadosys Plateau" for "Prisoner Interrogation Gaol"
 */

#load "libs.csx"

public class MonsterSpotInfo : IMonsterSpotInfo
{
    public override StageLayoutId StageLayoutId => Stage.MegadosysPlateau.AsStageLayoutId(59);
    public override QuestAreaId AreaId => QuestAreaId.MegadosysPlateau;
    public override uint RequiredAreaRank => 5;
    public override QuestId QuestUnlockId => QuestId.MegadosysPlateauPreventEnemyAttack;

    public override void Initialize()
    {
        var dropsTableRangedSoldier = LibDdon.Enemy.GetDropsTable(EnemyId.RangedSoldierDwarfOrc, 93).Clone()
            .AddDrop(ItemId.CorruptedSealerStone, 1, 1, DropRate.VERY_RARE)
            .AddDrop(ItemId.CorruptedSealerStoneShard, 1, 1, DropRate.RARE)
            .AddDrop(ItemId.GiantAnimalSkull, 1, 1, DropRate.VERY_RARE)
            .AddDrop(ItemId.FlameMushroom, 1, 1, DropRate.RARE);

        var dropsTableWarReadyOgre = LibDdon.Enemy.GetDropsTable(EnemyId.RangedSoldierDwarfOrc, 93).Clone()
            .AddDrop(ItemId.CorruptedSealerStone, 1, 1, DropRate.RARE)
            .AddDrop(ItemId.CorruptedSealerStoneShard, 1, 1, DropRate.UNCOMMON)
            .AddDrop(ItemId.GiantAnimalSkull, 1, 1, DropRate.RARE)
            .AddDrop(ItemId.FlameMushroom, 1, 1, DropRate.UNCOMMON);

        AddEnemies(new List<InstancedEnemy>()
        {
            LibDdon.Enemy.Create(EnemyId.RangedSoldierDwarfOrc, 93, 4200, 3)
                .SetDropsTable(dropsTableRangedSoldier),
            LibDdon.Enemy.Create(EnemyId.RangedSoldierDwarfOrc, 93, 4200, 4)
                .SetDropsTable(dropsTableRangedSoldier),
            LibDdon.Enemy.Create(EnemyId.WarReadyOgreLightArmor, 93, 105000, 5)
                .SetDropsTable(dropsTableWarReadyOgre)
                .SetIsBoss(true),
        });
    }
}

return new MonsterSpotInfo();
