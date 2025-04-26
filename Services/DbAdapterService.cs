namespace AutomeetBackend
{
    public class DbAdapterService
    {
        private DbAdapter _dbAdapter;

        public DbAdapterService(DbAdapter dbAdapter)
        {
            _dbAdapter = dbAdapter;
        }

        // this code is confusing
        // telling me that you're getting columns
        // populating columns? setting up columns?
        // morphing the entity you're working with
        // in the same method, for me looks like magic
        // then return dbAdapter.Columns
        // maybe naming issue? prob impl issue?
        public async Task<List<string>?> getColumns()
        {
            await _dbAdapter.getColumns();
            return _dbAdapter.Columns;
        }

        // unnecessary I think
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
