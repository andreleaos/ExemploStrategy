using ExemploStrategy.Domain.Inputs;
using ExemploStrategy.Domain.Interfaces;
using ExemploStrategy.Domain.Outputs;
using ExemploStrategy.Services.Requests;
using ExemploStrategy.Services.Responses;

namespace ExemploStrategy.Services.Strategies;

public class GetFilmeByIdStrategy : BaseStrategy<GetFilmeByIdResponse>, IExemploStrategy
{
    private readonly IFilmeService _filmeService;

    public GetFilmeByIdStrategy(IFilmeService filmeService)
    {
        _filmeService = filmeService;
    }


    public IExemploStrategyOutput Execute(IExemploStrategyInput request)
    {
        try
        {
            if (request == null)
                return WithError($"{nameof(request)} é requerida");

            if (!(request is GetFilmeByIdRequest input))
                return WithError($"{nameof(request)} é requerida");

            var result = _filmeService.GetById(input.Id);
            var response = new GetFilmeByIdResponse() { IsSuccess = true, Filme = result };
            return response;
        }
        catch (Exception ex)
        {
            var error = ex.Message;
            return WithError(error);
        }
    }
}
