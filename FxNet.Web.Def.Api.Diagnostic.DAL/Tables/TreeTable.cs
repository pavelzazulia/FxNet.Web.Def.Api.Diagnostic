using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using FxNet.Web.Def.Api.Diagnostic.DAL.Infrastructure.Entity;

namespace FxNet.Web.Def.Api.Diagnostic.DAL.Db.Tables
{
    [Table("Tree")]
    public class TreeTable : ITree
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }

        public string Name { get; set; }

        IEnumerable<INode> ITree.Nodes => Nodes;

        public virtual List<NodeTable> Nodes { get; set; }
    }
}
