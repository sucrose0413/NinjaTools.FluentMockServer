using System;
using Newtonsoft.Json;
using NinjaTools.FluentMockServer.Domain.Serialization;

namespace NinjaTools.FluentMockServer.Domain.Models.ValueTypes
{
    /// <summary>
    ///     Enumerate the available time unit.
    /// </summary>
    [JsonConverter(typeof(ContractResolver.UpperCaseEnumConverter))]
    [Serializable]
    public enum TimeUnit : int
    {
        /// <summary>
        ///     The nanoseconds.
        /// </summary>
        Nanoseconds = 0,

        /// <summary>
        ///     The Microseconds.
        /// </summary>
        Microseconds= 1,

        /// <summary>
        ///     The Milliseconds.
        /// </summary>
        Milliseconds= 2,

        /// <summary>
        ///     The seconds.
        /// </summary>
        Seconds= 4,

        /// <summary>
        ///     The minutes.
        /// </summary>
        Minutes= 8,

        /// <summary>
        ///     The hours.
        /// </summary>
        Hours= 16,

        /// <summary>
        ///     The days.
        /// </summary>
        Days= 32
    }
}
