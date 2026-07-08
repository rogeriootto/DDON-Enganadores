/**
 * @brief Enemy Spot in "Zandora Wastelands" for "Twin Wheel Valley"
 */

#load "libs.csx"

public class MonsterSpotInfo : IMonsterSpotInfo
{
    public override StageLayoutId StageLayoutId => Stage.Lestania.AsStageLayoutId(360);
    public override QuestAreaId AreaId => QuestAreaId.ZandoraWastelands;
    public override uint RequiredAreaRank => 2;

    public class NamedParamId
    {
        public const uint MergodaFemaleOfficer = 252; // Mergoda Female Officer
    }

    public override void Initialize()
    {
        AddEnemies(new List<InstancedEnemy>()
        {
            LibDdon.Enemy.Create(EnemyId.Witch, 47, 3024, 1)
                .SetIsBoss(true)
                .SetNamedEnemyParams(NamedParamId.MergodaFemaleOfficer)
                .AddDrop(ItemId.CrestOfGreaterMagick0, 1, 3, DropRate.UNCOMMON),
        });
    }
}

return new MonsterSpotInfo();
