using Microsoft.EntityFrameworkCore;
using FxNet.Web.Def.Api.Diagnostic.DAL.Db;
using FxNet.Web.Def.Api.Diagnostic.DAL.Db.Tables;
using FxNet.Web.Def.Api.Diagnostic.DAL.Infrastructure.Entity;
using FxNet.Web.Def.Api.Diagnostic.DAL.Infrastructure.Repository;

namespace FxNet.Web.Def.Api.Diagnostic.DAL.Repository
{
    public class TreeRepository : ITreeRepository
    {
        private DataBaseContext dataBaseContext;

        public TreeRepository(DataBaseContext dataBaseContext)
        {
            this.dataBaseContext = dataBaseContext;
        }

        public async Task<ITree> GetTreeAsync(string name)
        {
            var tree = dataBaseContext.Tree.Include(t => t.Nodes).SingleOrDefault(t => t.Name == name);

            if (tree == null)
            {
                var t = await dataBaseContext.Tree.AddAsync(new TreeTable { Name = name });
                await dataBaseContext.SaveChangesAsync();

                tree = t.Entity;
            }

            return tree;
        }
    }
}
