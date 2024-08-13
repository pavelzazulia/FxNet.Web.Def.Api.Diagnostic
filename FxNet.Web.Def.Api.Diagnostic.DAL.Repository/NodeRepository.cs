using Microsoft.EntityFrameworkCore;
using FxNet.Web.Def.Api.Diagnostic.DAL.Db;
using FxNet.Web.Def.Api.Diagnostic.DAL.Db.Tables;
using FxNet.Web.Def.Api.Diagnostic.DAL.Infrastructure.Repository;

namespace FxNet.Web.Def.Api.Diagnostic.DAL.Repository
{
    public class NodeRepository : INodeRepository
    {
        private readonly DataBaseContext dataBaseContext;

        public NodeRepository(DataBaseContext dataBaseContext)
        {
            this.dataBaseContext = dataBaseContext;
        }

        public async Task AddNodeAsync(string treeName, long parentNodeId, string nodeName)
        {
            var tree = dataBaseContext.Tree.SingleOrDefault(t => t.Name == treeName);
            dataBaseContext.Node.Add(new NodeTable { TreeId = tree.Id, ParentNodeId = parentNodeId, Name = nodeName });
            await dataBaseContext.SaveChangesAsync();
        }

        public async Task DeleteNodeAsync(string treeName, long nodeId)
        {
            var node = dataBaseContext.Node.SingleOrDefault(t => t.Tree.Name == treeName && t.Id == nodeId);
            dataBaseContext.Node.Remove(node);
            await dataBaseContext.SaveChangesAsync();
        }

        public async Task RenameNodeAsync(string treeName, long nodeId, string newNodeName)
        {
            var node = dataBaseContext.Node.SingleOrDefault(t => t.Tree.Name == treeName && t.Id == nodeId);
            node.Name = newNodeName;
            dataBaseContext.Entry(node).State = EntityState.Modified;
            await dataBaseContext.SaveChangesAsync();
        }
    }
}
