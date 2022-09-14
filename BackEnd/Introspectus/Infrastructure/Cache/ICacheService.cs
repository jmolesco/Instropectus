﻿namespace Introspectus.Api.Infrastructure.Cache
{
    public interface ICacheService
    {
        T Get<T>(string key);
        T Set<T>(string key, T value);
        void Remove(string key);
    }
}
