namespace FxNet.Web.Def.Api.Diagnostic.DAL.Infrastructure.Entity
{
    public interface ITree
    {
        long Id { get; set; }

        string Name { get; set; }

        IEnumerable<INode> Nodes { get; }
    }
}
