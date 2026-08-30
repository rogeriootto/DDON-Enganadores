/**
 * @brief Enemy Spot in "Zandora Wastelands" for "Twin Wheel Valley"
 */

#load "libs.csx"

public class MonsterSpotInfo : IMonsterSpotInfo
{
    public override StageLayoutId StageLayoutId => Stage.Lestania.AsStageLayoutId(362);
    public override QuestAreaId AreaId => QuestAreaId.ZandoraWastelands;
    public override bool CautionPlayer => false;
    public override uint RequiredAreaRank => 2;

    public class NamedParamId
    {
        public const uint MergodaPatrolCorps = 251; // Mergoda Patrol Corps
    }

    public override void Initialize()
    {
        AddEnemies(new List<InstancedEnemy>()
        {
            LibDdon.Enemy.Create(EnemyId.AlchemizedSkeleton, 46, 444, 6)
                .SetNamedEnemyParams(NamedParamId.MergodaPatrolCorps),
            LibDdon.Enemy.Create(EnemyId.AlchemizedSkeleton, 46, 444, 7)
                .SetNamedEnemyParams(NamedParamId.MergodaPatrolCorps),
            LibDdon.Enemy.Create(EnemyId.AlchemizedSkeleton, 46, 444, 8)
                .SetNamedEnemyParams(NamedParamId.MergodaPatrolCorps),
            LibDdon.Enemy.Create(EnemyId.AlchemizedSkeleton, 46, 444, 9)
                .SetNamedEnemyParams(NamedParamId.MergodaPatrolCorps),
            LibDdon.Enemy.Create(EnemyId.AlchemizedSkeleton, 46, 444, 10)
                .SetNamedEnemyParams(NamedParamId.MergodaPatrolCorps),
            LibDdon.Enemy.Create(EnemyId.AlchemizedSkeleton, 46, 444, 11)
                .SetNamedEnemyParams(NamedParamId.MergodaPatrolCorps),
        });
    }
}

return new MonsterSpotInfo();
