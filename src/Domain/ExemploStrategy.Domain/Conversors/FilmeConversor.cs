using ExemploStrategy.Domain.Dtos;
using ExemploStrategy.Domain.Entities;

namespace ExemploStrategy.Domain.Conversors;
public static class FilmeConversor
{
    public static FilmeDto ConvertToDto(Filme filme)
    {
        if (filme == null)
            return null;

        var dto = new FilmeDto()
        {
            Id = filme.Id,
            Nome = filme.Nome,
            Genero = filme.Genero,
            Ano = filme.Ano
        };

        return dto;
    }
    public static List<FilmeDto> ConvertCollectionToDto(List<Filme> filmes)
    {
        var result = new List<FilmeDto>();

        foreach(var item in filmes)
        {
            var convertedItem = ConvertToDto(item);
            result.Add(convertedItem);
        }

        return result;
    }
    public static Filme ConvertToEntity(FilmeDto dto)
    {
        if (dto == null)
            return null;

        Filme entity = new Filme()
        {
            Id = dto.Id,
            Nome = dto.Nome,
            Genero = dto.Genero,
            Ano = dto.Ano
        };

        return entity;
    }
    public static List<Filme> ConvertCollectionToDto(List<FilmeDto> filmes)
    {
        var result = new List<Filme>();

        foreach (var item in filmes)
        {
            var convertedItem = ConvertToEntity(item);
            result.Add(convertedItem);
        }

        return result;
    }

}
