using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using FxNet.Web.Def.Api.Diagnostic.DAL.Infrastructure.Entity;

namespace FxNet.Web.Def.Api.Diagnostic.DAL.Db.Tables
{
    [Table("Node")]
    public class NodeTable : INode
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }

        public long TreeId { get; set; }

        [ForeignKey("TreeId")]
        public virtual TreeTable Tree { get; set; }

        public long ParentNodeId { get; set; }

        public string Name { get; set; }
    }
}
