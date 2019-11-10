using System;
using System.Collections.Generic;
using NinjaTools.FluentMockServer.Models.HttpEntities;
using NinjaTools.FluentMockServer.Models.ValueTypes;


namespace NinjaTools.FluentMockServer.Builders
{
    internal class FluentHttpResponseBuilder : IFluentHttpResponseBuilder, IFluentHeaderBuilder
    {
        private readonly HttpResponse _httpResponse;

        public FluentHttpResponseBuilder()
        {
            _httpResponse = new HttpResponse();
        }

        
        /// <inheritdoc />
        public IFluentHttpResponseBuilder WithDelay(Action<IFluentDelayBuilder> delayFactory)
        {
            var delayBuilder = new FluentDelayBuilder();
            delayFactory(delayBuilder);
            _httpResponse.Delay = delayBuilder.Build();
            return this;
        }

        /// <inheritdoc />
        public IFluentHttpResponseBuilder WithDelay(int value, TimeUnit timeUnit)
        {
            _httpResponse.Delay = new Delay()
            {
                Value = value, TimeUnit = timeUnit
            };
            return this;
        }


        /// <inheritdoc />
        public IFluentHttpResponseBuilder WithHeader(string name, string value)
        {
            _httpResponse.Headers ??= new Dictionary<string, string[]>();
            _httpResponse.Headers.Add(name, new []{value});
            return this;
        }

        /// <inheritdoc />
        public IFluentHttpResponseBuilder WithHeaders(Action<IFluentHeaderBuilder> headerFactory)
        {
            headerFactory(this);
            return this;
        }


        /// <inheritdoc />
        public IFluentHttpResponseBuilder WithConnectionOptions(Action<IFluentConnectionOptionsBuilder> connectionOptionsFactory)
        {
            var builder = new FluentConnectionOptionsBuilder();
            connectionOptionsFactory(builder);
            _httpResponse.ConnectionOptions = builder.Build();
            return this;
        }

        /// <inheritdoc />
        public IFluentHttpResponseBuilder WithByteStreamBody(string base64Bytes, string contentType)
        {
            throw new NotImplementedException();
        }

        /// <inheritdoc />
        public HttpResponse Build() => _httpResponse;
        
        /// <inheritdoc />
        public IFluentHttpResponseBuilder WithBody(Action<IFluentBodyBuilder> bodyFactory)
        {
            var builder = new FluentBodyBuilder();
            bodyFactory(builder);
            _httpResponse.Body = builder.Body;
            return this;
        }

        public IFluentHttpResponseBuilder WithBodyLiteral(string bodyLiteral)
        {
            var builder = new FluentBodyBuilder();
            builder.WithLiteral(bodyLiteral);
            _httpResponse.Body = builder.Build();

            return this;
        }

        /// <inheritdoc />
        public IFluentHeaderBuilder WithHeaders(params (string name, string value)[] headers)
        {
            foreach (var (name, value)in headers)
            {
                AddHeader(name, value);
            }

            return this;
        }

        /// <inheritdoc />
        public IFluentHeaderBuilder AddHeader(string name, string value)
        {
           _httpResponse.Headers.Add(name, new []{value});
           return this;
        }
    }
}
