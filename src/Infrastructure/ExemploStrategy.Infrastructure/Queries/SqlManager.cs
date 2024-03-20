using ExemploStrategy.Domain.Enums;

namespace ExemploStrategy.Infrastructure.Queries;
public static class SqlManager
{
    public static string GetSql(TSqlQueryOption sqlQueryOption)
    {
        string sql = "";

        switch (sqlQueryOption)
        {
            case TSqlQueryOption.CADASTRAR_FILME:
                sql = "insert into filme (nome, genero, ano) values ('@nome', '@genero', '@ano');";
                break;

            case TSqlQueryOption.ATUALIZAR_FILME:
                sql = "update filme set nome = '@nome', genero = '@genero', ano = '@ano' where id = @id";
                break;

            case TSqlQueryOption.EXCLUIR_FILME:
                sql = "delete from filme where id = @id";
                break;

            case TSqlQueryOption.LISTAR_FILME:
                sql = "select id, nome, genero, ano from filme order by nome;";
                break;

            case TSqlQueryOption.PESQUISAR_FILME:
                sql = "select id, nome, genero, ano from filme where id = @id;";
                break;
        }

        return sql;
    }
}
