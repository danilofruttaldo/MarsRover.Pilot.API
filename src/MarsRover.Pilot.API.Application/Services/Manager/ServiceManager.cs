using MarsRover.Pilot.API.Application.Interfaces;
using MarsRover.Pilot.API.Application.Interfaces.Manager;
using MarsRover.Pilot.API.Core.Integrations.Manager;
using MarsRover.Pilot.API.Core.Repositories.Manager;
using System.Reflection;

namespace MarsRover.Pilot.API.Application.Services.Manager
{
    public class ServiceManager : IServiceManager
    {
        private readonly Lazy<IDriverService> _lazyDriverService;
        private readonly Lazy<IPositionService> _lazyPositionService;

        public IDriverService DriverService => _lazyDriverService.Value;
        public IPositionService PositionService => _lazyPositionService.Value;

        public ServiceManager(IRepositoryManager repositoryManager, IIntegrationManager integrationManager)
        {
            _lazyDriverService = new Lazy<IDriverService>(() => new DriverService(repositoryManager, integrationManager));
            _lazyPositionService = new Lazy<IPositionService>(() => new PositionService(repositoryManager, integrationManager));
        }

        public TService GetService<TService>()
        {
            PropertyInfo? property = GetType().GetProperty(typeof(TService).Name);
            if (property == null)
                throw new ArgumentNullException(nameof(TService));

            object? result = property.GetValue(this, null);
            if (result is TService repository)
                return repository;

            try
            {
                return (TService)Convert.ChangeType(result, typeof(TService));
            }
            catch (InvalidCastException)
            {
                return default;
            }
        }
    }
}
