using System.Data.Common;

namespace Arrowgene.Ddon.Database.Sql.Core.Migration
{
    public class Msq32Migration(DatabaseSetting databaseSetting) : IMigrationStrategy
    {
        public uint From => 65;
        public uint To => 66;

        public bool Migrate(IDatabase db, DbConnection conn)
        {
            string adaptedSchema = DdonDatabaseBuilder.GetAdaptedSchema(databaseSetting, "Script/migration_msq_3.2.sql");
            db.Execute(conn, adaptedSchema, true);
            return true;
        }
    }
}
