using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Dapper;

using SavoryCms.Repository.Entity;

namespace SavoryCms.Repository.Sqlite
{
    public class SqliteAppRepository : IAppRepository
    {

        private SqliteConnectionProvider connectionProvider;

        public SqliteAppRepository(SqliteConnectionProvider connectionProvider)
        {
            this.connectionProvider = connectionProvider;
        }

        public void Create(AppEntity entity)
        {
            string sql = "insert into cms_app(app_id, app_type_id, app_name, data_status, description) values (@AppId, @AppTypeId, @AppName, @DataStatus, @Description);";

            using (var sqliteConn = connectionProvider.GetConnection())
            {
                sqliteConn.Execute(sql, new { AppId = entity.AppId, AppTypeId = entity.AppTypeId, AppName = entity.AppName, DataStatus = entity.DataStatus, Description = entity.Description });
            }
        }

        public AppEntity GetById(long id)
        {
            string sql = "select id as Id, app_id as AppId, app_type_id as AppTypeId, app_name as AppName, data_status as DataStatus, description as Description from cms_app where Id = ?";

            using (var sqliteConn = connectionProvider.GetConnection())
            {
                return sqliteConn.QueryFirstOrDefault<AppEntity>(sql, new { Id = id });
            }
        }

        public int GetCount()
        {
            string sql = "select count(1) from cms_app";

            using (var sqliteConn = connectionProvider.GetConnection())
            {
                return sqliteConn.QuerySingle<int>(sql);
            }
        }

        public List<AppEntity> GetEntityList()
        {
            string sql = "select id as Id, app_id as AppId, app_type_id as AppTypeId, app_name as AppName, data_status as DataStatus, description as Description from cms_app";

            using (var sqliteConn = connectionProvider.GetConnection())
            {
                return sqliteConn.Query<AppEntity>(sql).ToList();
            }
        }

        public List<AppEntity> GetEntityList(int pageIndex, int pageSize)
        {
            string sql = "select id as Id, app_id as AppId, app_type_id as AppTypeId, app_name as AppName, data_status as DataStatus, description as Description from cms_app limit @Start, @Count";

            using (var sqliteConn = connectionProvider.GetConnection())
            {
                return sqliteConn.Query<AppEntity>(sql, new { Start = (pageIndex - 1) * pageSize, Count = pageSize }).ToList();
            }
        }

        public void Update(AppEntity entity)
        {
            string sql = "update cms_app set app_id = @AppId, app_type_id = @AppTypeId, app_name = @AppName, data_status = @DataStatus, description = @Description where id = @Id;";

            using (var sqliteConn = connectionProvider.GetConnection())
            {
                sqliteConn.Execute(sql, new { Id = entity.Id, AppId = entity.AppId, AppTypeId = entity.AppTypeId, AppName = entity.AppName, DataStatus = entity.DataStatus, Description = entity.Description });
            }
        }
    }
}
