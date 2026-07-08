/**
 * @brief Enemy Spot in "Mysree Grove" for "Inias Wetlands"
 */

#load "libs.csx"

public class MonsterSpotInfo : IMonsterSpotInfo
{
    public override StageLayoutId StageLayoutId => Stage.Lestania.AsStageLayoutId(142);
    public override QuestAreaId AreaId => QuestAreaId.MysreeGrove;
    public override uint RequiredAreaRank => 3;

    public class NamedParamId
    {
        public const uint CobaltNewt = 233; // Cobalt Newt
    }

    public override void Initialize()
    {
        var dropsTable = LibDdon.Enemy.GetDropsTable(EnemyId.BlueNewt, 35).Clone()
            .AddDrop(ItemId.SuperiorSaurianTail, 1, 1, DropRate.COMMON)
            .AddDrop(ItemId.BlueAlluvialGold, 1, 3, DropRate.COMMON);

        var enemies = new List<InstancedEnemy>()
        {
            LibDdon.Enemy.Create(EnemyId.BlueNewt, 35, 173, 10)
                .SetDropsTable(dropsTable)
                .SetNamedEnemyParams(NamedParamId.CobaltNewt),
            LibDdon.Enemy.Create(EnemyId.BlueNewt, 35, 173, 11)
                .SetDropsTable(dropsTable)
                .SetNamedEnemyParams(NamedParamId.CobaltNewt),
            LibDdon.Enemy.Create(EnemyId.BlueNewt, 35, 173, 12)
                .SetDropsTable(dropsTable)
                .SetNamedEnemyParams(NamedParamId.CobaltNewt),
        };

        AddEnemies(enemies);
    }
}

return new MonsterSpotInfo();
