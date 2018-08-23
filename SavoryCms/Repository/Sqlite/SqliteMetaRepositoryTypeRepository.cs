using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Dapper;

using SavoryCms.Repository.Entity;

namespace SavoryCms.Repository.Sqlite
{
    public class SqliteMetaRepositoryTypeRepository : IMetaRepositoryTypeRepository
    {

        private SqliteConnectionProvider connectionProvider;

        public SqliteMetaRepositoryTypeRepository(SqliteConnectionProvider connectionProvider)
        {
            this.connectionProvider = connectionProvider;
        }

        public void Create(MetaRepositoryTypeEntity entity)
        {
            string sql = "insert into meta_repository_type(repository_type_id, repository_type_name) values (@RepositoryTypeId, @RepositoryTypeName);";

            using (var sqliteConn = connectionProvider.GetConnection())
            {
                sqliteConn.Execute(sql, new { RepositoryTypeId = entity.RepositoryTypeId, RepositoryTypeName = entity.RepositoryTypeName });
            }
        }

        public MetaRepositoryTypeEntity GetById(long id)
        {
            string sql = "select id as Id, repository_type_id as RepositoryTypeId, repository_type_name as RepositoryTypeName from meta_repository_type where Id = ?";

            using (var sqliteConn = connectionProvider.GetConnection())
            {
                return sqliteConn.QueryFirstOrDefault<MetaRepositoryTypeEntity>(sql, new { Id = id });
            }
        }

        public int GetCount()
        {
            string sql = "select count(1) from meta_repository_type";

            using (var sqliteConn = connectionProvider.GetConnection())
            {
                return sqliteConn.QuerySingle<int>(sql);
            }
        }

        public List<MetaRepositoryTypeEntity> GetEntityList()
        {
            string sql = "select id as Id, repository_type_id as RepositoryTypeId, repository_type_name as RepositoryTypeName from meta_repository_type";

            using (var sqliteConn = connectionProvider.GetConnection())
            {
                return sqliteConn.Query<MetaRepositoryTypeEntity>(sql).ToList();
            }
        }

        public List<MetaRepositoryTypeEntity> GetEntityList(int pageIndex, int pageSize)
        {
            string sql = "select id as Id, repository_type_id as RepositoryTypeId, repository_type_name as RepositoryTypeName from meta_repository_type limit @Start, @Count";

            using (var sqliteConn = connectionProvider.GetConnection())
            {
                return sqliteConn.Query<MetaRepositoryTypeEntity>(sql, new { Start = (pageIndex - 1) * pageSize, Count = pageSize }).ToList();
            }
        }

        public void Update(MetaRepositoryTypeEntity entity)
        {
            string sql = "update meta_repository_type set repository_type_id = @RepositoryTypeId, repository_type_name = @RepositoryTypeName where id = @Id;";

            using (var sqliteConn = connectionProvider.GetConnection())
            {
                sqliteConn.Execute(sql, new { Id = entity.Id, RepositoryTypeId = entity.RepositoryTypeId, RepositoryTypeName = entity.RepositoryTypeName });
            }
        }
    }
}
