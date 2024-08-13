using FxNet.Web.Def.Api.Diagnostic.DAL.Infrastructure.Entity;

namespace FxNet.Web.Def.Api.Diagnostic.DAL.Infrastructure.Repository
{
    public interface ITreeRepository
    {
        Task<ITree> GetTreeAsync(string name);
    }
}
