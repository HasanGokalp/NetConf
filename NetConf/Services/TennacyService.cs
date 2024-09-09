using Microsoft.Extensions.Options;
using NetConf.ConfClasses;

namespace NetConf.Services
{
    public class TennacyService
    {
        private readonly DbSettings _dbSettings;
        public TennacyService(IOptions<DbSettings> options) 
        {
            _dbSettings = options.Value;
        }

        public string GetConnectionString()
        {
            return _dbSettings.ConnectionString;
        }
    }
}
