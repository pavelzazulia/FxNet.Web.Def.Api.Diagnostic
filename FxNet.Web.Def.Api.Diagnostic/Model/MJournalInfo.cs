using System;
using System.ComponentModel.DataAnnotations;

namespace FxNet.Web.Def.Api.Diagnostic.Model
{
    public class MJournalInfo
    {
        [Required]
        public long Id { get; set; }

        [Required]
        public long EventId { get; set; }

        [Required]
        public DateTime CreatedAt { get; set; }
    }
}
