using System;

namespace Introspectus.Api.Interfaces
{
    public interface IRepository<T> : IDisposable where T : class
    {
    }
}
