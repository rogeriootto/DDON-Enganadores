using Arrowgene.Buffers;
using Arrowgene.Ddon.Shared.Model.Quest;

namespace Arrowgene.Ddon.Shared.Entity.Structure
{
    public class CDataStageLayoutInfo
    {
        public CDataStageLayoutInfo()
        {
            LayoutId = new CDataStageLayoutId();
        }

        public CDataStageLayoutId LayoutId { get; set; }
        public uint PosId { get; set; }

        public class Serializer : EntitySerializer<CDataStageLayoutInfo>
        {
            public override void Write(IBuffer buffer, CDataStageLayoutInfo obj)
            {
                WriteEntity(buffer, obj.LayoutId);
                WriteUInt32(buffer, obj.PosId);
            }

            public override CDataStageLayoutInfo Read(IBuffer buffer)
            {
                CDataStageLayoutInfo obj = new CDataStageLayoutInfo();
                obj.LayoutId = ReadEntity<CDataStageLayoutId>(buffer);
                obj.PosId = ReadUInt32(buffer);
                return obj;
            }
        }
    }
}
