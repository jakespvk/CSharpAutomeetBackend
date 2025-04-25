namespace AutomeetBackend
{
    public class DbAdapterService
    {
        private DbAdapter _dbAdapter;

        public DbAdapterService(DbAdapter dbAdapter)
        {
            _dbAdapter = dbAdapter;
        }

        public async Task<List<string>?> getColumns()
        {
            await _dbAdapter.getColumns();
            return _dbAdapter.Columns;
        }

        public async Task<bool> contactDataFound()
        {
            if (string.IsNullOrEmpty(await _dbAdapter.getContactData()))
            {
                return false;
            }
            return true;
        }
    }
}
