/**
 * @brief Enemy Spot in "Zandora Wastelands" for "Black Abyss Valley"
 */

#load "libs.csx"

public class MonsterSpotInfo : IMonsterSpotInfo
{
    public override StageLayoutId StageLayoutId => Stage.Lestania.AsStageLayoutId(375);
    public override QuestAreaId AreaId => QuestAreaId.ZandoraWastelands;
    public override uint RequiredAreaRank => 9;

    public class NamedParamId
    {
        public const uint WailingMora = 263; // Wailing Mora
    }

    public override void Initialize()
    {
        AddEnemies(new List<InstancedEnemy>()
        {
            LibDdon.Enemy.Create(EnemyId.Nightmare, 58, 8831, 1)
                .SetIsBoss(true)
                .SetNamedEnemyParams(NamedParamId.WailingMora)
                .AddDrop(ItemId.TitanBracelet, 1, 1, DropRate.RARE)
                .AddDrop(ItemId.MephistoBracelet, 1, 1, DropRate.RARE)
                .AddDrop(ItemId.YggdrasilBracelet, 1, 1, DropRate.RARE),
        });
    }
}

return new MonsterSpotInfo();
