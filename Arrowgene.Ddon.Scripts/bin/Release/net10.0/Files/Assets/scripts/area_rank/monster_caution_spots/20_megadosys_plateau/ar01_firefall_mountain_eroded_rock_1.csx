/**
 * @brief Enemy Spot in "Megadosys Plateau" for "Firefall Mountain Eroded Rock"
 */

#load "libs.csx"

public class MonsterSpotInfo : IMonsterSpotInfo
{
    public override StageLayoutId StageLayoutId => Stage.MegadosysPlateau.AsStageLayoutId(18);
    public override QuestAreaId AreaId => QuestAreaId.MegadosysPlateau;
    public override bool CautionPlayer => false;
    public override uint RequiredAreaRank => 1;

    public override void Initialize()
    {
        var dropsTableAncestorOrc = LibDdon.Enemy.GetDropsTable(EnemyId.AncestorOrc, 90).Clone()
            .AddDrop(ItemId.GiantAnimalSkull, 1, 1, DropRate.VERY_RARE)
            .AddDrop(ItemId.Phlogopite, 1, 1, DropRate.RARE)
            .AddDrop(ItemId.BlazingOre, 1, 1, DropRate.RARE)
            .AddDrop(ItemId.RedGarnet, 1, 1, DropRate.RARE);

        var dropsTableGrimwarg = LibDdon.Enemy.GetDropsTable(EnemyId.Grimwarg, 90).Clone()
            .AddDrop(ItemId.GiantAnimalSkull, 1, 1, DropRate.VERY_RARE)
            .AddDrop(ItemId.Phlogopite, 1, 1, DropRate.RARE)
            .AddDrop(ItemId.BlazingOre, 1, 1, DropRate.RARE)
            .AddDrop(ItemId.RedGarnet, 1, 1, DropRate.RARE);

        AddEnemies(new List<InstancedEnemy>()
        {
            LibDdon.Enemy.Create(EnemyId.AncestorOrc, 90, 4200, 0)
                .SetDropsTable(dropsTableAncestorOrc),
            LibDdon.Enemy.Create(EnemyId.AncestorOrc, 90, 4200, 1)
                .SetDropsTable(dropsTableAncestorOrc),
            LibDdon.Enemy.Create(EnemyId.Grimwarg, 90, 4200, 2)
                .SetDropsTable(dropsTableGrimwarg),
            LibDdon.Enemy.Create(EnemyId.Grimwarg, 90, 4200, 3)
                .SetDropsTable(dropsTableGrimwarg),
        });
    }
}

return new MonsterSpotInfo();
