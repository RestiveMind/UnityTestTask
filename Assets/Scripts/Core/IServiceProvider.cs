using System;

namespace Core
{
    public interface IServiceProvider
    {
        T GetService<T>() where T : IService;

        IService GetService(Type serviceType);
    }   
}