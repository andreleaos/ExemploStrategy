using ExemploStrategy.Domain.Inputs;
using ExemploStrategy.Domain.Interfaces;
using ExemploStrategy.Domain.Outputs;
using ExemploStrategy.Services.Requests;
using ExemploStrategy.Services.Responses;

namespace ExemploStrategy.Services.Strategies;
public class GetAllFilmeStrategy : BaseStrategy<GetAllFilmeResponse>, IExemploStrategy
{
    private readonly IFilmeService _filmeService;

    public GetAllFilmeStrategy(IFilmeService filmeService)
    {
        _filmeService = filmeService;
    }

    public IExemploStrategyOutput Execute(IExemploStrategyInput request)
    {
        try
        {
            if (request == null)
                return WithError($"{nameof(request)} é requerida");

            if (!(request is GetAllFilmeRequest input))
                return WithError($"{nameof(request)} é requerida");

            var result = _filmeService.GetAll();
            var response = new GetAllFilmeResponse() { IsSuccess = true, Filmes = result };
            return response;
        }
        catch (Exception ex)
        {
            var error = ex.Message;
            return WithError(error);
        }
    }
}
