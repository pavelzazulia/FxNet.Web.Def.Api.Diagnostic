using System.Linq;
using System.Collections.Generic;
using FxNet.Web.Def.Api.Diagnostic.Model;
using FxNet.Web.Def.Api.Diagnostic.DAL.Infrastructure.Entity;

namespace FxNet.Web.Def.Api.Diagnostic
{
    public static class ModelHelper
    {
        public static IEnumerable<MNode> BuildNodeModel(this IEnumerable<INode> nodes)
        {
            if (nodes == null)
                return new List<MNode>();

            var tempNodeCollection = nodes.Select(n => new MNode { Id = n.Id, ParentNodeId = n.ParentNodeId, Name = n.Name }).ToArray();

            var rootNodes = tempNodeCollection.Where(node => node.ParentNodeId == 0).ToArray();

            var childNodes = tempNodeCollection.Where(node => node.ParentNodeId > 0).ToArray();

            foreach (var rootNode in rootNodes)
                rootNode.Children = childNodes.BuildNode(rootNode.Id);

            return rootNodes;
        }

        private static IEnumerable<MNode> BuildNode(this IEnumerable<MNode> nodes, long parentNodeId)
        {
            var childNodes = nodes.Where(n => n.ParentNodeId == parentNodeId).ToArray();

            foreach (var node in childNodes)
            {
                var nodeChilds = nodes.Where(n => n.ParentNodeId == node.Id).ToArray();

                node.Children = nodeChilds.BuildNode(node.Id);
            }

            return childNodes;
        }
    }
}
