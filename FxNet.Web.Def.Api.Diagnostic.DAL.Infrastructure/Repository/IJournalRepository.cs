using FxNet.Web.Def.Api.Diagnostic.DAL.Infrastructure.Entity;

namespace FxNet.Web.Def.Api.Diagnostic.DAL.Infrastructure.Repository
{
    public interface IJournalRepository
    {
        Task AddJournalItemAsync(IJournal journal);

        Task<IJournal> GetJournalItemAsync(long journalId);

        Task<(int Count, IJournal[] Items)> GetJournalItemsAsync(int skip, int take, DateTime? from, DateTime? to, string treeName);
    }
}
