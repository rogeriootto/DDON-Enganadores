/**
 * @brief Enemy Spot in "Megadosys Plateau" for "Isolated Beach"
 */

#load "libs.csx"

public class MonsterSpotInfo : IMonsterSpotInfo
{
    public override StageLayoutId StageLayoutId => Stage.MegadosysPlateau.AsStageLayoutId(35);
    public override QuestAreaId AreaId => QuestAreaId.MegadosysPlateau;
    public override uint RequiredAreaRank => 2;
    public override QuestId QuestUnlockId => QuestId.MegadosysPlateauLiberationArmySupport;

    public override void Initialize()
    {
        var dropsTableGiantGeoSaurian = LibDdon.Enemy.GetDropsTable(EnemyId.GiantGeoSaurian, 92).Clone()
            .AddDrop(ItemId.SpiritPurifierStone, 1, 1, DropRate.VERY_RARE)
            .AddDrop(ItemId.SpiritPurifierStoneShard, 1, 1, DropRate.RARE)
            .AddDrop(ItemId.GiantAnimalSkull, 1, 1, DropRate.VERY_RARE)
            .AddDrop(ItemId.Waterweed, 1, 1, DropRate.RARE)
            .AddDrop(ItemId.HighlandAkadama, 1, 1, DropRate.RARE);

        var dropsTableWitch = LibDdon.Enemy.GetDropsTable(EnemyId.Grimwarg, 92).Clone()
            .AddDrop(ItemId.SpiritPurifierStone, 1, 1, DropRate.RARE)
            .AddDrop(ItemId.SpiritPurifierStoneShard, 1, 1, DropRate.UNCOMMON)
            .AddDrop(ItemId.GiantAnimalSkull, 1, 1, DropRate.RARE)
            .AddDrop(ItemId.Waterweed, 1, 1, DropRate.UNCOMMON)
            .AddDrop(ItemId.HighlandAkadama, 1, 1, DropRate.UNCOMMON);

        AddEnemies(new List<InstancedEnemy>()
        {
            LibDdon.Enemy.Create(EnemyId.GiantGeoSaurian, 92, 4200, 0)
                .SetDropsTable(dropsTableGiantGeoSaurian),
            LibDdon.Enemy.Create(EnemyId.GiantGeoSaurian, 92, 4200, 1)
                .SetDropsTable(dropsTableGiantGeoSaurian),
            LibDdon.Enemy.Create(EnemyId.Witch, 92, 21000, 2)
                .SetDropsTable(dropsTableWitch)
                .SetIsBoss(true),
            LibDdon.Enemy.Create(EnemyId.GiantGeoSaurian, 92, 4200, 3)
                .SetDropsTable(dropsTableGiantGeoSaurian),
            LibDdon.Enemy.Create(EnemyId.GiantGeoSaurian, 92, 4200, 4)
                .SetDropsTable(dropsTableGiantGeoSaurian),
        });
    }
}

return new MonsterSpotInfo();
