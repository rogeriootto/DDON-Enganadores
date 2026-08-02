/**
 * @brief Enemy Spot in "Megadosys Plateau" for "Firefall Mountain Eroded Rock"
 */

#load "libs.csx"

public class MonsterSpotInfo : IMonsterSpotInfo
{
    public override StageLayoutId StageLayoutId => Stage.MegadosysPlateau.AsStageLayoutId(19);
    public override QuestAreaId AreaId => QuestAreaId.MegadosysPlateau;
    public override uint RequiredAreaRank => 1;

    public override void Initialize()
    {
        var dropsTableGrimwarg = LibDdon.Enemy.GetDropsTable(EnemyId.Grimwarg, 90).Clone()
            .AddDrop(ItemId.GiantAnimalSkull, 1, 1, DropRate.VERY_RARE)
            .AddDrop(ItemId.Phlogopite, 1, 1, DropRate.RARE)
            .AddDrop(ItemId.BlazingOre, 1, 1, DropRate.RARE)
            .AddDrop(ItemId.RedGarnet, 1, 1, DropRate.RARE);

        var dropsTableCaptainAncestorOrc = LibDdon.Enemy.GetDropsTable(EnemyId.CaptainAncestorOrc, 90).Clone()
            .AddDrop(ItemId.GiantAnimalSkull, 1, 1, DropRate.VERY_RARE)
            .AddDrop(ItemId.Phlogopite, 1, 1, DropRate.RARE)
            .AddDrop(ItemId.BlazingOre, 1, 1, DropRate.RARE)
            .AddDrop(ItemId.RedGarnet, 1, 1, DropRate.RARE);

        var dropsTableProgenitor = LibDdon.Enemy.GetDropsTable(EnemyId.AncestorOrigin, 90).Clone()
            .AddDrop(ItemId.GiantAnimalSkull, 1, 1, DropRate.RARE)
            .AddDrop(ItemId.Phlogopite, 1, 1, DropRate.UNCOMMON)
            .AddDrop(ItemId.BlazingOre, 1, 1, DropRate.UNCOMMON)
            .AddDrop(ItemId.RedGarnet, 1, 1, DropRate.UNCOMMON);

        AddEnemies(new List<InstancedEnemy>()
        {
            LibDdon.Enemy.Create(EnemyId.CaptainAncestorOrc, 90, 4200, 0)
                .SetDropsTable(dropsTableCaptainAncestorOrc),
            LibDdon.Enemy.Create(EnemyId.Grimwarg, 90, 4200, 1)
                .SetDropsTable(dropsTableGrimwarg),
            LibDdon.Enemy.Create(EnemyId.CaptainAncestorOrc, 90, 4200, 2)
                .SetDropsTable(dropsTableCaptainAncestorOrc),
            LibDdon.Enemy.Create(EnemyId.Grimwarg, 90, 4200, 3)
                .SetDropsTable(dropsTableGrimwarg),
            LibDdon.Enemy.Create(EnemyId.AncestorOrigin, 90, 21000, 4)
                .SetDropsTable(dropsTableProgenitor)
                .SetIsBoss(true),
        });
    }
}

return new MonsterSpotInfo();
