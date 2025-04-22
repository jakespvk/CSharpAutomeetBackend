namespace AutomeetBackend
{
    public sealed class DbAdapterService
    {
        private DbAdapter _dbAdapter;

        public DbAdapterService(DbAdapter dbAdapter)
        {
            _dbAdapter = dbAdapter;
        }

        public async Task<string> getContactData()
        {
            return await _dbAdapter.getContactData();
        }
    }
}
