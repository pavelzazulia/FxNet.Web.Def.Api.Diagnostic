using System.ComponentModel;
using System.Collections.Generic;

namespace FxNet.Web.Def.Api.Diagnostic.Model
{
    public class MRangeMJournal
    {
        public int Skip { get; set; }

        public int Count { get; set; }

        public IEnumerable<MJournalInfo> Items { get; set; }
    }
}
