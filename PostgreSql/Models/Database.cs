namespace PostgreSql.Models
{
    internal class BaseEntity
    {
        public Nullable<DateTime> RecordCreated { get; set; }
        public Nullable<DateTime> RecordUpdated { get; set; }
    }
    internal partial class GuildModel : BaseEntity
    {
        public long GuildID { get; set; }
        public string? GuildName { get; set; }
        public DateTime CreationDate { get; set; }
        public virtual List<AuditLogsHistory>? AuditLogs { set; get; }
    }
    internal partial class AuditLogsHistory : BaseEntity
    {
        public long AuditLogID { get; set; }
        public long GuildID { get; set; }
        public DateTime CreationDate { get; set; }
        public string? ActionType { get; set; }
        public string? Reason { get; set; }
        public virtual GuildModel? Guild { set; get; }
    }
}