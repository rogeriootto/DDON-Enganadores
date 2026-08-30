/**
 * @brief Enemy Spot in "Breya Coast" for "Hidden Beach"
 */

#load "libs.csx"

public class MonsterSpotInfo : IMonsterSpotInfo
{
    public override StageLayoutId StageLayoutId => Stage.Lestania.AsStageLayoutId(82);
    public override QuestAreaId AreaId => QuestAreaId.BreyaCoast;
    public override uint RequiredAreaRank => 2;

    public class NamedParamId
    {
        public const uint HiddenBeachRogue = 195; // Hidden Beach Rogue
    }

    public override void Initialize()
    {
        var dropsTable = LibDdon.Enemy.GetDropsTable(EnemyId.RogueFighter, 10).Clone()
            .AddDrop(ItemId.DurablePants0, 1, 1, DropRate.RARE)
            .AddDrop(ItemId.ThiefsMask0, 1, 1, DropRate.RARE);

        AddEnemies(new List<InstancedEnemy>()
        {
            LibDdon.Enemy.Create(EnemyId.RogueFighter, 10, 62, 17)
                .SetDropsTable(dropsTable)
                .SetHmPresetNo(HmPresetId.RogueFighter)
                .SetNamedEnemyParams(NamedParamId.HiddenBeachRogue),
            LibDdon.Enemy.Create(EnemyId.RogueSeeker, 10, 62, 18)
                .SetDropsTable(dropsTable)
                .SetHmPresetNo(HmPresetId.RogueSeeker)
                .SetNamedEnemyParams(NamedParamId.HiddenBeachRogue),
            LibDdon.Enemy.Create(EnemyId.RogueHunter, 10, 62, 19)
                .SetDropsTable(dropsTable)
                .SetHmPresetNo(HmPresetId.RogueHunter)
                .SetNamedEnemyParams(NamedParamId.HiddenBeachRogue),
            LibDdon.Enemy.Create(EnemyId.RogueMage, 10, 62, 20)
                .SetDropsTable(dropsTable)
                .SetHmPresetNo(HmPresetId.RogueMage)
                .SetNamedEnemyParams(NamedParamId.HiddenBeachRogue),
        });
    }
}

return new MonsterSpotInfo();
