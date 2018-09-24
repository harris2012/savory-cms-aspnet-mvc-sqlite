using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Dapper;

using SavoryCms.Repository.Entity;

namespace SavoryCms.Repository.Sqlite
{
    public class SqliteMetaAppTypeRepository : IMetaAppTypeRepository
    {

        private SqliteConnectionProvider connectionProvider;

        public SqliteMetaAppTypeRepository(SqliteConnectionProvider connectionProvider)
        {
            this.connectionProvider = connectionProvider;
        }

        public void Create(MetaAppTypeEntity entity)
        {
            string sql = "insert into meta_app_type(app_type_id, app_type_name) values (@AppTypeId, @AppTypeName);";

            using (var sqliteConn = connectionProvider.GetConnection())
            {
                sqliteConn.Execute(sql, new { AppTypeId = entity.AppTypeId, AppTypeName = entity.AppTypeName });
            }
        }

        public MetaAppTypeEntity GetById(long id)
        {
            string sql = "select id, app_type_id as AppTypeId, app_type_name as AppTypeName from meta_app_type where Id = ?";

            using (var sqliteConn = connectionProvider.GetConnection())
            {
                return sqliteConn.QueryFirstOrDefault<MetaAppTypeEntity>(sql, new { Id = id });
            }
        }

        public int GetCount()
        {
            string sql = "select count(1) from meta_app_type";

            using (var sqliteConn = connectionProvider.GetConnection())
            {
                return sqliteConn.QuerySingle<int>(sql);
            }
        }

        public List<MetaAppTypeEntity> GetEntityList()
        {
            string sql = "select id, app_type_id as AppTypeId, app_type_name as AppTypeName from meta_app_type";

            using (var sqliteConn = connectionProvider.GetConnection())
            {
                return sqliteConn.Query<MetaAppTypeEntity>(sql).ToList();
            }
        }

        public List<MetaAppTypeEntity> GetEntityList(int pageIndex, int pageSize)
        {
            string sql = "select id, app_type_id as AppTypeId, app_type_name as AppTypeName from meta_app_type limit @Start, @Count";

            using (var sqliteConn = connectionProvider.GetConnection())
            {
                return sqliteConn.Query<MetaAppTypeEntity>(sql, new { Start = (pageIndex - 1) * pageSize, Count = pageSize }).ToList();
            }
        }

        public void Update(MetaAppTypeEntity entity)
        {
            string sql = "update meta_app_type set app_type_id = @AppTypeId, app_type_name = @AppTypeName where id = @Id;";

            using (var sqliteConn = connectionProvider.GetConnection())
            {
                sqliteConn.Execute(sql, new { id = entity.Id, AppTypeId = entity.AppTypeId, AppTypeName = entity.AppTypeName });
            }
        }
    }
}
