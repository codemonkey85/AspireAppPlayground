var builder = DistributedApplication.CreateBuilder(args);

var apiService = builder
  .AddProject<Projects.AspireAppPlayground_ApiService>("apiservice");

builder
  .AddProject<Projects.AspireAppPlayground_Web>("webfrontend")
  .WithExternalHttpEndpoints()
  .WithReference(apiService);

builder.Build().Run();
