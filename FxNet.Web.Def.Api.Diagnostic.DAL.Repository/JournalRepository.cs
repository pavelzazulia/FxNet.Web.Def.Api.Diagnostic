using System.Data.Entity;
using FxNet.Web.Def.Api.Diagnostic.DAL.Db;
using FxNet.Web.Def.Api.Diagnostic.DAL.Db.Tables;
using FxNet.Web.Def.Api.Diagnostic.DAL.Infrastructure.Entity;
using FxNet.Web.Def.Api.Diagnostic.DAL.Infrastructure.Repository;

namespace FxNet.Web.Def.Api.Diagnostic.DAL.Repository
{
    public class JournalRepository : IJournalRepository
    {
        private readonly DataBaseContext dataBaseContext;

        public JournalRepository(DataBaseContext dataBaseContext)
        {
            this.dataBaseContext = dataBaseContext;
        }

        public async Task AddJournalItemAsync(IJournal journal)
        {
            dataBaseContext.Journal.Add(new JournalTable
            {
                EventId = journal.EventId,
                CreatedAt = journal.CreatedAt,
                Path = journal.Path,
                TreeName = journal.TreeName,
                NodeName = journal.NodeName,
                ParentNodeId = journal.ParentNodeId,
                Exception = journal.Exception
            });
            await dataBaseContext.SaveChangesAsync();
        }

        public async Task<IJournal> GetJournalItemAsync(long journalId)
        {
            return dataBaseContext.Journal.SingleOrDefault(j => j.Id == journalId);
        }

        public async Task<(int, IJournal[])> GetJournalItemsAsync(int skip, int take, DateTime? from, DateTime? to, string treeName)
        {
            IQueryable<IJournal> query = dataBaseContext.Journal;

            if (from.HasValue)
                query = query.Where(j => from.Value >= j.CreatedAt);

            if (to.HasValue)
                query = query.Where(j => to.Value <= j.CreatedAt);

            if (!string.IsNullOrEmpty(treeName))
                query = query.Where(j => treeName == j.TreeName);

            var noTrackingQuery = query.AsNoTracking();

            int totalCount = await noTrackingQuery.CountAsync();

            var searchResult = await noTrackingQuery.Skip(skip).Take(take).ToArrayAsync();

            return new (totalCount, searchResult);
        }
    }
}