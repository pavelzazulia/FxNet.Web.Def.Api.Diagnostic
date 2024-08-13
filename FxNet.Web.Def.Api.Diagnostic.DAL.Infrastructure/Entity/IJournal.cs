namespace FxNet.Web.Def.Api.Diagnostic.DAL.Infrastructure.Entity
{
    public interface IJournal
    {
        long Id { get; set; }

        long EventId { get; set; }

        DateTime CreatedAt { get; set; }

        string Path { get; set; }

        string TreeName { get; set; }

        string NodeName { get; set; }

        long ParentNodeId { get; set; }

        string Exception { get; set; }
    }
}
