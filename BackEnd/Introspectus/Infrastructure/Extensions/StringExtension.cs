﻿namespace Introspectus.Api.Infrastructure.Extensions
{
    public static class StringExtension
    {
        /// <summary>
        /// Check if string has value
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static bool HasValue(this string value)
        {
            return !string.IsNullOrWhiteSpace(value);
        }
    }
}
