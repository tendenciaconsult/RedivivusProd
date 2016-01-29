namespace Simir.Infra.Data.Context
{
    public interface IContextManager<TContext>
        where TContext : IDbContext, new()
    {
        IDbContext GetContext();
        void Finish();
    }
}