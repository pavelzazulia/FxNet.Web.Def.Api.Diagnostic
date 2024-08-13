using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using FxNet.Web.Def.Api.Diagnostic.DAL.Infrastructure.Entity;

namespace FxNet.Web.Def.Api.Diagnostic.DAL.Db.Tables
{
    [Table("Journal")]
    public class JournalTable : IJournal
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }

        public long EventId { get; set; }

        public DateTime CreatedAt { get; set; }

        public string Path { get; set; }

        public string TreeName { get; set; }

        public string NodeName { get; set; }

        public long ParentNodeId { get; set; }

        public string Exception { get; set; }
    }
}
