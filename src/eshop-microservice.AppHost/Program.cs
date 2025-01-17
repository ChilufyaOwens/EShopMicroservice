var builder = DistributedApplication.CreateBuilder(args);

builder.AddProject<Projects.Ordering_Api>("ordering-api");

builder.Build().Run();
