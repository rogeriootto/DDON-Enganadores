using Arrowgene.Buffers;
using Arrowgene.Ddon.Shared.Network;

namespace Arrowgene.Ddon.Shared.Entity.PacketStructure
{
    public class C2SChainDungeonEndChainNtc : IPacketStructure
    {
        public PacketId Id => PacketId.C2S_CHAIN_DUNGEON_END_CHAIN_NTC;

        public C2SChainDungeonEndChainNtc()
        {
        }

        public class Serializer : PacketEntitySerializer<C2SChainDungeonEndChainNtc>
        {
            public override void Write(IBuffer buffer, C2SChainDungeonEndChainNtc obj)
            {
            }

            public override C2SChainDungeonEndChainNtc Read(IBuffer buffer)
            {
                C2SChainDungeonEndChainNtc obj = new C2SChainDungeonEndChainNtc();
                return obj;
            }
        }
    }
}
