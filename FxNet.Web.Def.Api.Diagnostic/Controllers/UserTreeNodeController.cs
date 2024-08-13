using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using FxNet.Web.Def.Api.Diagnostic.DAL.Infrastructure.Repository;

namespace FxNet.Web.Def.Api.Diagnostic.Controllers
{
    [ApiController]
    public class UserTreeNodeController : ControllerBase
    {
        private readonly INodeRepository nodeRepository;

        public UserTreeNodeController(INodeRepository nodeRepository)
        {
            this.nodeRepository = nodeRepository;
        }

        [HttpPost("api.user.tree.node.create")]
        public async Task CreateNode([Required] string treeName, [Required] long parentNodeId, [Required] string nodeName)
        {
            await nodeRepository.AddNodeAsync(treeName, parentNodeId, nodeName);
        }

        [HttpPost("api.user.tree.node.delete")]
        public async Task DeleteNode([Required] string treeName, [Required] long nodeId)
        {
            await nodeRepository.DeleteNodeAsync(treeName, nodeId);
        }

        [HttpPost("api.user.tree.node.rename")]
        public async Task RenameNode([Required] string treeName, [Required] long nodeId, [Required] string newNodeName)
        {
            await nodeRepository.RenameNodeAsync(treeName, nodeId, newNodeName);
        }
    }
}
