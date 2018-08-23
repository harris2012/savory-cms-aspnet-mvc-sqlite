using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Dapper;

using SavoryCms.Repository.Entity;

namespace SavoryCms.Repository.Sqlite
{
    public class SqliteRepositoryRepository : IRepositoryRepository
    {

        private SqliteConnectionProvider connectionProvider;

        public SqliteRepositoryRepository(SqliteConnectionProvider connectionProvider)
        {
            this.connectionProvider = connectionProvider;
        }

        public void Create(RepositoryEntity entity)
        {
            string sql = "insert into cms_repository(repository_name, repository_type_id, gitlab_project_fullname, data_status, description) values (@RepositoryName, @RepositoryTypeId, @GitlabProjectFullname, @DataStatus, @Description);";

            using (var sqliteConn = connectionProvider.GetConnection())
            {
                sqliteConn.Execute(sql, new { RepositoryName = entity.RepositoryName, RepositoryTypeId = entity.RepositoryTypeId, GitlabProjectFullname = entity.GitlabProjectFullname, DataStatus = entity.DataStatus, Description = entity.Description });
            }
        }

        public RepositoryEntity GetById(long id)
        {
            string sql = "select id as Id, repository_name as RepositoryName, repository_type_id as RepositoryTypeId, gitlab_project_fullname as GitlabProjectFullname, data_status as DataStatus, description as Description from cms_repository where Id = ?";

            using (var sqliteConn = connectionProvider.GetConnection())
            {
                return sqliteConn.QueryFirstOrDefault<RepositoryEntity>(sql, new { Id = id });
            }
        }

        public int GetCount()
        {
            string sql = "select count(1) from cms_repository";

            using (var sqliteConn = connectionProvider.GetConnection())
            {
                return sqliteConn.QuerySingle<int>(sql);
            }
        }

        public List<RepositoryEntity> GetEntityList()
        {
            string sql = "select id as Id, repository_name as RepositoryName, repository_type_id as RepositoryTypeId, gitlab_project_fullname as GitlabProjectFullname, data_status as DataStatus, description as Description from cms_repository";

            using (var sqliteConn = connectionProvider.GetConnection())
            {
                return sqliteConn.Query<RepositoryEntity>(sql).ToList();
            }
        }

        public List<RepositoryEntity> GetEntityList(int pageIndex, int pageSize)
        {
            string sql = "select id as Id, repository_name as RepositoryName, repository_type_id as RepositoryTypeId, gitlab_project_fullname as GitlabProjectFullname, data_status as DataStatus, description as Description from cms_repository limit @Start, @Count";

            using (var sqliteConn = connectionProvider.GetConnection())
            {
                return sqliteConn.Query<RepositoryEntity>(sql, new { Start = (pageIndex - 1) * pageSize, Count = pageSize }).ToList();
            }
        }

        public void Update(RepositoryEntity entity)
        {
            string sql = "update cms_repository set repository_name = @RepositoryName, repository_type_id = @RepositoryTypeId, gitlab_project_fullname = @GitlabProjectFullname, data_status = @DataStatus, description = @Description where id = @Id;";

            using (var sqliteConn = connectionProvider.GetConnection())
            {
                sqliteConn.Execute(sql, new { Id = entity.Id, RepositoryName = entity.RepositoryName, RepositoryTypeId = entity.RepositoryTypeId, GitlabProjectFullname = entity.GitlabProjectFullname, DataStatus = entity.DataStatus, Description = entity.Description });
            }
        }
    }
}
