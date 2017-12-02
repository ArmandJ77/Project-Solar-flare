﻿using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Project.Solar.Flare.Test.Api;
using System;
using System.Net.Http;

namespace Project.Solar.Flare.Tests.Unit.Tests.Infrastructure
{
  public class TestContext : IDisposable
  {
    private TestServer _server;
    public HttpClient Client { get; private set; }

    public TestContext()
    {
      SetUpClient();
    }

    private void SetUpClient()
    {
      _server = new TestServer(new WebHostBuilder()
        .UseStartup<Startup>());

      Client = _server.CreateClient();
    }

    public void Dispose()
    {
      _server?.Dispose();
      Client?.Dispose();
    }
  }
}
