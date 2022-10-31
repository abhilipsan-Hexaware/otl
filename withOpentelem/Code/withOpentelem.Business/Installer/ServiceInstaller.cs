using withOpentelem.Data.Installer;
using Microsoft.Extensions.DependencyInjection;
using Scrutor;
namespace withOpentelem.Business.Installer
{
    public class ServiceInstaller
    {
        private IServiceCollection _service;
        public ServiceInstaller(IServiceCollection service)
        {
            _service = service;
        }

        public void Install()
        {
            _service.Scan(scan => scan
                                    .FromAssemblyOf<ServiceInstaller>()
                                    .AddClasses()
                                    .AsImplementedInterfaces()
                                    .WithScopedLifetime());
            var dataInstaller = new DataInstaller(_service);
            dataInstaller.Install();
        }
    }
}
