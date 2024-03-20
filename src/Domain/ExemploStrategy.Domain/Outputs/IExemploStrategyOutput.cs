namespace ExemploStrategy.Domain.Outputs;
public interface IExemploStrategyOutput
{
    bool IsSuccess { get; set; }
    string[] Info { get; set; }
    string[] Errors { get; set; }
}
