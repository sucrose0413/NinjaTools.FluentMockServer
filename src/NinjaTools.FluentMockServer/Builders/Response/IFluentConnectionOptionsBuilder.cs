using System.ComponentModel;
using NinjaTools.FluentMockServer.FluentInterfaces;
using NinjaTools.FluentMockServer.Models.ValueTypes;

namespace NinjaTools.FluentMockServer.Builders.Response
{
    /// <summary>
    /// 
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public interface IFluentConnectionOptionsBuilder : IFluentBuilder<ConnectionOptions>
    {
        ConnectionOptions Build();
    }
}
