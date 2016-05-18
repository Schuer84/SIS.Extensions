namespace SIS.Extensions.TestGenerator.Contracts
{
    public interface ITransform<TIn, TOut>
    {
        TOut Transform(TIn input);
    }
}