using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using FxNet.Web.Def.Api.Diagnostic.Model;
using System.ComponentModel.DataAnnotations;
using FxNet.Web.Def.Api.Diagnostic.DAL.Infrastructure.Repository;

namespace FxNet.Web.Def.Api.Diagnostic.Controllers
{
    [ApiController]
    public class UserTreeController : ControllerBase
    {
        private readonly ITreeRepository treeRepository;

        public UserTreeController(ITreeRepository treeRepository)
        {
            this.treeRepository = treeRepository;
        }

        [HttpPost("api.user.tree.get")]
        public async Task<MNode> GetTree([Required] string treeName)
        {
            var result = await treeRepository.GetTreeAsync(treeName);

            return new MNode { Id = result.Id, Name = result.Name, Children = result.Nodes.BuildNodeModel() };
        }
    }
}
