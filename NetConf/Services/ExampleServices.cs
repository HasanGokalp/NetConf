using Microsoft.Extensions.Options;
using NetConf.ConfClasses;

namespace NetConf.Services
{
    public class ExampleServices
    {
        private readonly ExampleConf _exampleConf;
        public ExampleServices(IOptions<ExampleConf> options)
        {
            _exampleConf = options.Value;
        }

        public string GetHasan()
        {
            return _exampleConf.DenemeHasan;
        }
    }
}
