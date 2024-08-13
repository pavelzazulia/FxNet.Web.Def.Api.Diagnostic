namespace FxNet.Web.Def.Api.Diagnostic.DAL.Infrastructure.Entity
{
    public interface IJournalFilter
    {
        DateTime? From { get; set; }

        DateTime? To { get; set; }

        string Search { get; set; }
    }
}
