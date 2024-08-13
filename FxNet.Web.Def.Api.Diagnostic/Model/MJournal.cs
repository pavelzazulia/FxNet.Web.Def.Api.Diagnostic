using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace FxNet.Web.Def.Api.Diagnostic.Model
{
    public class MJournal : MJournalInfo
    {
        [Required]
        public string Text { get; set; }
    }
}
