namespace FxNet.Web.Def.Api.Diagnostic.DAL.Infrastructure.Repository
{
    public interface INodeRepository
    {
        Task AddNodeAsync(string treeName, long parentNodeId, string nodeName);

        Task DeleteNodeAsync(string treeName, long nodeId);

        Task RenameNodeAsync(string treeName, long nodeId, string newNodeName);
    }
}
