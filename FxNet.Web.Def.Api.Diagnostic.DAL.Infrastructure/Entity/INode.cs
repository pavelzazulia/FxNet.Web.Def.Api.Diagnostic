namespace FxNet.Web.Def.Api.Diagnostic.DAL.Infrastructure.Entity
{
    public interface INode
    {
        long Id { get; set; }

        long TreeId { get; set; }

        long ParentNodeId { get; set; }

        string Name { get; set; }
    }
}
