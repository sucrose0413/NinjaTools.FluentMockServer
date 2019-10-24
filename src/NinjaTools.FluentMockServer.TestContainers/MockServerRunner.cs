﻿using System;
using TestContainers.Core.Builders;

namespace NinjaTools.FluentMockServer.TestContainers
{
    using System.Threading.Tasks;
    using Xunit;

    public class MockServerRunner : IAsyncLifetime
    {
        public MockServerContainer Container { get; }
        
        public string MockServerEndpoint => Container.MockServerBaseUrl;
        public int DockerHostMappedPort => Container.GetMappedPort();
        public string DockerHostIP => Container.GetDockerHostIpAddress();
        
        public virtual bool IsRunningInBuildPipeline { get; } = Environment.GetEnvironmentVariable("RUNS_IN_CI") != null;

        public MockServerRunner()
        {
            Container = new GenericContainerBuilder<MockServerContainer>()
                .Begin()
                .WithImage(MockServerContainer.ContainerImage)
                .WithExposedPorts(MockServerContainer.ExposedPort)
                .Build();
        }

        /// <inheritdoc />
        public Task InitializeAsync() => Container.Start();

        /// <inheritdoc />
        public Task DisposeAsync() => Container.Stop();
    }
}