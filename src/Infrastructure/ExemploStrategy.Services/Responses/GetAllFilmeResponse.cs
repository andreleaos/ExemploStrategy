using ExemploStrategy.Domain.Dtos;

namespace ExemploStrategy.Services.Responses;

public class GetAllFilmeResponse : BaseResponseExemploStrategy
{
    public List<FilmeDto> Filmes { get; set; }
}
