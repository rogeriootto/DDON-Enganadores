/**
 * @brief Enemy Spot in "Zandora Wastelands" for "Banded Haunt"
 */

#load "libs.csx"

public class MonsterSpotInfo : IMonsterSpotInfo
{
    public override StageLayoutId StageLayoutId => Stage.Lestania.AsStageLayoutId(438);
    public override QuestAreaId AreaId => QuestAreaId.ZandoraWastelands;
    public override uint RequiredAreaRank => 4;

    public class NamedParamId
    {
        public const uint RustedAlchemizedGoblin = 250; // Rusted Alchemized Goblin
    }

    public override void Initialize()
    {
        AddEnemies(new List<InstancedEnemy>()
        {
            LibDdon.Enemy.Create(EnemyId.DamnedSlingGoblinFlask, 49, 236, 5)
                .SetNamedEnemyParams(NamedParamId.RustedAlchemizedGoblin),
            LibDdon.Enemy.Create(EnemyId.DamnedSlingGoblinFlask, 49, 236, 6)
                .SetNamedEnemyParams(NamedParamId.RustedAlchemizedGoblin),
            LibDdon.Enemy.Create(EnemyId.DamnedSlingGoblinFlask, 49, 236, 7)
                .SetNamedEnemyParams(NamedParamId.RustedAlchemizedGoblin),
            LibDdon.Enemy.Create(EnemyId.DamnedSlingGoblinFlask, 49, 236, 8)
                .SetNamedEnemyParams(NamedParamId.RustedAlchemizedGoblin),
            LibDdon.Enemy.Create(EnemyId.DamnedSlingGoblinFlask, 49, 236, 9)
                .SetNamedEnemyParams(NamedParamId.RustedAlchemizedGoblin),
        });
    }
}

return new MonsterSpotInfo();
