using Dapper;
using ExemploStrategy.Domain.Entities;
using ExemploStrategy.Domain.Enums;
using ExemploStrategy.Domain.Interfaces;
using ExemploStrategy.Infrastructure.Queries;
using System.Data;

namespace ExemploStrategy.Infrastructure.Repositories;
public class FilmeRepository : IFilmeRepository
{
    private readonly IDbConnection _dbConnection;
    public FilmeRepository(IDbConnection dbConnection)
    {
        _dbConnection = dbConnection;
    }

    public void Create(Filme entity)
    {
        TSqlQueryOption queryType = TSqlQueryOption.CADASTRAR_FILME;
        string sql = SqlManager.GetSql(queryType);
        sql = ReplaceQueryParameters(queryType, entity, sql);
        var result = _dbConnection.Execute(sql);
    }

    public void Delete(int id)
    {
        TSqlQueryOption queryType = TSqlQueryOption.EXCLUIR_FILME;
        string sql = SqlManager.GetSql(queryType);
        sql = ReplaceQueryParameters(queryType, new Filme { Id = id }, sql);
        _dbConnection.Execute(sql);
    }

    public List<Filme> GetAll()
    {
        TSqlQueryOption queryType = TSqlQueryOption.LISTAR_FILME;
        string sql = SqlManager.GetSql(queryType);
        var result = _dbConnection.Query<Filme>(sql).ToList();
        return result;
    }

    public Filme GetById(int id)
    {
        TSqlQueryOption queryType = TSqlQueryOption.PESQUISAR_FILME;
        string sql = SqlManager.GetSql(queryType);
        sql = ReplaceQueryParameters(queryType, new Filme { Id = id }, sql);
        var result = _dbConnection.QueryFirstOrDefault<Filme>(sql);
        return result;
    }

    public void Update(Filme entity)
    {
        TSqlQueryOption queryType = TSqlQueryOption.ATUALIZAR_FILME;
        string sql = SqlManager.GetSql(queryType);
        sql = ReplaceQueryParameters(queryType, entity, sql);
        _dbConnection.Execute(sql);
    }

    private string ReplaceQueryParameters(TSqlQueryOption queryType, Filme entity, string querySql)
    {
        string sql = querySql;

        switch (queryType)
        {
            case TSqlQueryOption.CADASTRAR_FILME:
                sql = sql
                    .Replace("@nome", entity.Nome)
                    .Replace("@genero", entity.Genero)
                    .Replace("@ano", entity.Ano.ToString());
                break;

            case TSqlQueryOption.ATUALIZAR_FILME:
                sql = sql
                    .Replace("@id", entity.Id.ToString())
                    .Replace("@nome", entity.Nome)
                    .Replace("@genero", entity.Genero)
                    .Replace("@ano", entity.Ano.ToString());
                break;

            case TSqlQueryOption.PESQUISAR_FILME:
                sql = sql
                    .Replace("@id", entity.Id.ToString());
                break;

            case TSqlQueryOption.EXCLUIR_FILME:
                sql = sql
                    .Replace("@id", entity.Id.ToString());
                break;
        }

        return sql;
    }
}
