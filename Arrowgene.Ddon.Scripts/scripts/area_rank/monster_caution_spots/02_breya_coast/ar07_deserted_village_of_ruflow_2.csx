/**
 * @brief Enemy Spot in "Breya Coast" for "Deserted Village of Ruflow"
 */

#load "libs.csx"

public class MonsterSpotInfo : IMonsterSpotInfo
{
    public override StageLayoutId StageLayoutId => Stage.Lestania.AsStageLayoutId(104);
    public override QuestAreaId AreaId => QuestAreaId.BreyaCoast;
    public override bool CautionPlayer => false;
    public override uint RequiredAreaRank => 7;

    public class NamedParamId
    {
        public const uint FormerVillager = 204; // Former Villager
    }

    public override void Initialize()
    {
        AddEnemies(new List<InstancedEnemy>()
        {
            LibDdon.Enemy.Create(EnemyId.Skeleton, 20, 73, 4)
                .SetNamedEnemyParams(NamedParamId.FormerVillager)
                .SetSpawnTime(GameTimeManager.NightTime)
				.SetStartThinkTblNo(8)
				.SetIsManualSet(true),
            LibDdon.Enemy.Create(EnemyId.Skeleton, 20, 73, 5)
                .SetNamedEnemyParams(NamedParamId.FormerVillager)
                .SetSpawnTime(GameTimeManager.NightTime)
				.SetStartThinkTblNo(8)
				.SetIsManualSet(true),
            LibDdon.Enemy.Create(EnemyId.Skeleton, 20, 73, 6)
                .SetNamedEnemyParams(NamedParamId.FormerVillager)
                .SetSpawnTime(GameTimeManager.NightTime)
				.SetStartThinkTblNo(8)
				.SetIsManualSet(true),
            LibDdon.Enemy.Create(EnemyId.Skeleton, 20, 73, 7)
                .SetNamedEnemyParams(NamedParamId.FormerVillager)
                .SetSpawnTime(GameTimeManager.NightTime)
				.SetStartThinkTblNo(8)
				.SetIsManualSet(true),
        });
    }
}

return new MonsterSpotInfo();
