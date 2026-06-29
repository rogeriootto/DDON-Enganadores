using Arrowgene.Buffers;
using Arrowgene.Ddon.Shared.Entity.Structure;
using Arrowgene.Ddon.Shared.Network;
using System.Collections.Generic;

namespace Arrowgene.Ddon.Shared.Entity.PacketStructure
{
    public class S2CChainDungeonRewardChestAppearNtc : ServerResponse
    {
        public override PacketId Id => PacketId.S2C_CHAIN_DUNGEON_REWARD_CHEST_APPEAR_NTC;

        public S2CChainDungeonRewardChestAppearNtc()
        {
            RewardChestList = new List<CDataStageLayoutInfo>();
        }

        public List<CDataStageLayoutInfo> RewardChestList { get; set; }

        public class Serializer : PacketEntitySerializer<S2CChainDungeonRewardChestAppearNtc>
        {
            public override void Write(IBuffer buffer, S2CChainDungeonRewardChestAppearNtc obj)
            {
                WriteEntityList(buffer, obj.RewardChestList);
            }

            public override S2CChainDungeonRewardChestAppearNtc Read(IBuffer buffer)
            {
                S2CChainDungeonRewardChestAppearNtc obj = new S2CChainDungeonRewardChestAppearNtc();
                obj.RewardChestList = ReadEntityList<CDataStageLayoutInfo>(buffer);
                return obj;
            }
        }
    }
}
