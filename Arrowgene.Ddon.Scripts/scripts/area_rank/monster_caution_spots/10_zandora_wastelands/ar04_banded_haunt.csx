/**
 * @brief Enemy Spot in "Zandora Wastelands" for "Banded Haunt"
 */

#load "libs.csx"

public class MonsterSpotInfo : IMonsterSpotInfo
{
    public override StageLayoutId StageLayoutId => Stage.Lestania.AsStageLayoutId(439);
    public override QuestAreaId AreaId => QuestAreaId.ZandoraWastelands;
    public override uint RequiredAreaRank => 4;

    public class NamedParamId
    {
        public const uint RustedIronGiantWarrior = 249; // Rusted Iron Giant Warrior
    }

    public override void Initialize()
    {
        AddEnemies(new List<InstancedEnemy>()
        {
            LibDdon.Enemy.Create(EnemyId.DamnedGolem, 49, 4617, 1)
                .SetIsBoss(true)
                .SetNamedEnemyParams(NamedParamId.RustedIronGiantWarrior),
        });
    }
}

return new MonsterSpotInfo();
