using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Dapper;

using SavoryCms.Repository.Entity;

namespace SavoryCms.Repository.Sqlite
{
    public class SqliteTheMetaAppTypeRepository : ITheMetaAppTypeRepository
    {

        private SqliteConnectionProvider connectionProvider;

        public SqliteTheMetaAppTypeRepository(SqliteConnectionProvider connectionProvider)
        {
            this.connectionProvider = connectionProvider;
        }

        public TheMetaAppTypeEntity GetById(int id)
        {
            string sql = "select app_type_id as AppTypeId, app_type_name as AppTypeName from meta_app_type where Id = ?";

            using (var sqliteConn = connectionProvider.GetConnection())
            {
                return sqliteConn.QueryFirstOrDefault<TheMetaAppTypeEntity>(sql, new { Id = id });
            }
        }

        public List<TheMetaAppTypeEntity> GetEntityList()
        {
            string sql = "select app_type_id as AppTypeId, app_type_name as AppTypeName from meta_app_type";

            using (var sqliteConn = connectionProvider.GetConnection())
            {
                return sqliteConn.Query<TheMetaAppTypeEntity>(sql).ToList();
            }
        }
    }
}
