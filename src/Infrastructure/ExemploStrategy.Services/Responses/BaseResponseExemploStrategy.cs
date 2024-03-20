using ExemploStrategy.Domain.Outputs;

namespace ExemploStrategy.Services.Responses;
public class BaseResponseExemploStrategy : IExemploStrategyOutput
{
    public virtual bool IsSuccess { get; set; }
    public virtual string[] Info { get; set; }
    public virtual string[] Errors { get; set; }
}
