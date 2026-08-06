/**
 * @brief Enemy Spot in "Megadosys Plateau" for "Merciful Funeral Hall"
 */

#load "libs.csx"

public class MonsterSpotInfo : IMonsterSpotInfo
{
    public override StageLayoutId StageLayoutId => Stage.MegadosysPlateau.AsStageLayoutId(40);
    public override QuestAreaId AreaId => QuestAreaId.MegadosysPlateau;
    public override uint RequiredAreaRank => 2;
    public override QuestId QuestUnlockId => QuestId.MegadosysPlateauRescueRequest;

    public override void Initialize()
    {
        var dropsTableGrudgeGhost = LibDdon.Enemy.GetDropsTable(EnemyId.GrudgeGhost, 92).Clone()
            .AddDrop(ItemId.CursedExorciserStone, 1, 1, DropRate.VERY_RARE)
            .AddDrop(ItemId.CursedExorciserStoneShard, 1, 1, DropRate.RARE)
            .AddDrop(ItemId.GiantAnimalSkull, 1, 1, DropRate.VERY_RARE)
            .AddDrop(ItemId.GiantCaterpillar, 1, 1, DropRate.RARE)
            .AddDrop(ItemId.FlameMushroom, 1, 1, DropRate.RARE);

        var dropsTableDeathKnight = LibDdon.Enemy.GetDropsTable(EnemyId.DeathKnight, 92).Clone()
            .AddDrop(ItemId.CursedExorciserStone, 1, 1, DropRate.RARE)
            .AddDrop(ItemId.CursedExorciserStoneShard, 1, 1, DropRate.UNCOMMON)
            .AddDrop(ItemId.GiantAnimalSkull, 1, 1, DropRate.RARE)
            .AddDrop(ItemId.GiantCaterpillar, 1, 1, DropRate.UNCOMMON)
            .AddDrop(ItemId.FlameMushroom, 1, 1, DropRate.UNCOMMON);

        AddEnemies(new List<InstancedEnemy>()
        {
            LibDdon.Enemy.Create(EnemyId.GrudgeGhost, 92, 4200, 0)
                .SetDropsTable(dropsTableGrudgeGhost),
            LibDdon.Enemy.Create(EnemyId.GrudgeGhost, 92, 4200, 1)
                .SetDropsTable(dropsTableGrudgeGhost),
            LibDdon.Enemy.Create(EnemyId.GrudgeGhost, 92, 4200, 2)
                .SetDropsTable(dropsTableGrudgeGhost),
            LibDdon.Enemy.Create(EnemyId.DeathKnight, 92, 21000, 0)
                .SetDropsTable(dropsTableDeathKnight)
                .SetIsBoss(true),
        });
    }
}

return new MonsterSpotInfo();
