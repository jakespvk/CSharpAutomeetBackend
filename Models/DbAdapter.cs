namespace AutomeetBackend
{
    public abstract class DbAdapter
    {
        [System.ComponentModel.DataAnnotations.Key]
        public abstract Guid UserId { get; set; }
        public abstract List<string>? Columns { get; set; }
        public abstract List<string>? ActiveColumns { get; set; }

        public abstract Task getColumns();
        public abstract Task<string> getContactData();
    }
}
