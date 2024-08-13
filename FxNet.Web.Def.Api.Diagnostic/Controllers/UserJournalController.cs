using System.Linq;
using System.ComponentModel;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using FxNet.Web.Def.Api.Diagnostic.Model;
using System.ComponentModel.DataAnnotations;
using FxNet.Web.Def.Api.Diagnostic.DAL.Infrastructure.Repository;

namespace FxNet.Web.Def.Api.Diagnostic.Controllers
{
    [DisplayName("user.journal")]
    [ApiController]
    public class UserJournalController : ControllerBase
    {
        private readonly IJournalRepository journalRepository;

        public UserJournalController(IJournalRepository journalRepository)
        {
            this.journalRepository = journalRepository;
        }

        [HttpPost("api.user.journal.getRange")]
        public async Task<MRangeMJournal> GetRange([Required] int skip, [Required] int take, [FromBody, Required] VJournalFilter filter)
        {
            var result = await journalRepository.GetJournalItemsAsync(skip, take, filter.From, filter.To, filter.Search);

            return new MRangeMJournal { Skip = skip, Count = result.Count, Items = result.Items.Select(i => new MJournalInfo { Id = i.Id, CreatedAt = i.CreatedAt, EventId = i.EventId } ) };
        }

        [HttpPost("api.user.journal.getSingle")]
        public async Task<MJournal> GetSingle([Required] int id)
        {
            var result = await journalRepository.GetJournalItemAsync(id);

            return new MJournal { Id = result.Id, EventId = result.EventId, CreatedAt = result.CreatedAt, Text = result.Exception };
        }
    }
}
