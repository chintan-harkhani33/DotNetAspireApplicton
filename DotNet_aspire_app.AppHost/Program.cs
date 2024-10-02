var builder = DistributedApplication.CreateBuilder(args);


var apiService = builder.AddProject<Projects.DotNet_aspire_app_ApiService>("apiservice");

builder.AddProject<Projects.DotNet_aspire_app_Web>("webfrontend")
    .WithExternalHttpEndpoints()
    .WithReference(apiService);

builder.Build().Run();
