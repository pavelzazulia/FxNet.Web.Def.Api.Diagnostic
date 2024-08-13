using Newtonsoft.Json;
using System.Collections.Generic;

namespace FxNet.Web.Def.Api.Diagnostic.Model
{
    public class MNode
    {
        public long Id { get; set; }

        [JsonIgnore]
        public long ParentNodeId { get; set; }

        public string Name { get; set; }

        public IEnumerable<MNode> Children { get; set; }
    }
}
