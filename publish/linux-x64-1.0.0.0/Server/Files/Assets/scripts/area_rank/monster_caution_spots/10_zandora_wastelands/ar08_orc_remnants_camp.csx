/**
 * @brief Enemy Spot in "Zandora Wastelands" for "Orc Remnants Camp"
 */

#load "libs.csx"

public class MonsterSpotInfo : IMonsterSpotInfo
{
    public override StageLayoutId StageLayoutId => Stage.Lestania.AsStageLayoutId(424);
    public override QuestAreaId AreaId => QuestAreaId.ZandoraWastelands;
    public override uint RequiredAreaRank => 8;

    public class NamedParamId
    {
        public const uint OrcGeneralRemnant = 260; // Orc General Remnant
        public const uint OrcRemnants0 = 261; // Orc Remnants
        public const uint OrcRemnants1 = 262; // Orc Remnants
    }

    public override void Initialize()
    {
        AddEnemies(new List<InstancedEnemy>()
        {
            LibDdon.Enemy.Create(EnemyId.GeneralOrc, 56, 1526, 0)
                .SetNamedEnemyParams(NamedParamId.OrcGeneralRemnant)
                .AddDrop(ItemId.RousingSteak, 1, 3, DropRate.UNCOMMON),
            LibDdon.Enemy.Create(EnemyId.OrcBattler, 56, 356, 1)
                .SetRepopConditions(1, 10)
                .SetNamedEnemyParams(NamedParamId.OrcRemnants0),
            LibDdon.Enemy.Create(EnemyId.OrcBattler, 56, 356, 2)
                .SetRepopConditions(1, 10)
                .SetNamedEnemyParams(NamedParamId.OrcRemnants0),
            LibDdon.Enemy.Create(EnemyId.OrcTrooper, 56, 307, 3)
                .SetRepopConditions(1, 10)
                .SetNamedEnemyParams(NamedParamId.OrcRemnants1),
            LibDdon.Enemy.Create(EnemyId.OrcTrooper, 56, 307, 4)
                .SetRepopConditions(1, 10)
                .SetNamedEnemyParams(NamedParamId.OrcRemnants1),
        });
    }
}

return new MonsterSpotInfo();
