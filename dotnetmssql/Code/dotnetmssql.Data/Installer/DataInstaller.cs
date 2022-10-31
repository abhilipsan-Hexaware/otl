using Microsoft.Extensions.DependencyInjection;

namespace dotnetmssql.Data.Installer
{
    public class DataInstaller
    {
        private IServiceCollection _service;
        public DataInstaller(IServiceCollection service)
        {
            _service = service;
        }

        public void Install()
        {
             _service.Scan(scan => scan
                                    .FromAssemblyOf<DataInstaller>()
                                    .AddClasses()
                                    .AsImplementedInterfaces()
                                    .WithScopedLifetime());
        }
    }
}
