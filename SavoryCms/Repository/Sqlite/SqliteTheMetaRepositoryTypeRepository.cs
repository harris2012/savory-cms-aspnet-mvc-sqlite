using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Dapper;

using SavoryCms.Repository.Entity;

namespace SavoryCms.Repository.Sqlite
{
    public class SqliteTheMetaRepositoryTypeRepository : ITheMetaRepositoryTypeRepository
    {

        private SqliteConnectionProvider connectionProvider;

        public SqliteTheMetaRepositoryTypeRepository(SqliteConnectionProvider connectionProvider)
        {
            this.connectionProvider = connectionProvider;
        }

        public TheMetaRepositoryTypeEntity GetById(int id)
        {
            string sql = "select repository_type_id as RepositoryTypeId, repository_type_name as RepositoryTypeName from meta_repository_type where Id = ?";

            using (var sqliteConn = connectionProvider.GetConnection())
            {
                return sqliteConn.QueryFirstOrDefault<TheMetaRepositoryTypeEntity>(sql, new { Id = id });
            }
        }

        public List<TheMetaRepositoryTypeEntity> GetEntityList()
        {
            string sql = "select repository_type_id as RepositoryTypeId, repository_type_name as RepositoryTypeName from meta_repository_type";

            using (var sqliteConn = connectionProvider.GetConnection())
            {
                return sqliteConn.Query<TheMetaRepositoryTypeEntity>(sql).ToList();
            }
        }
    }
}
