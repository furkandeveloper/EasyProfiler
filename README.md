<p align="center">
  <img src="https://user-images.githubusercontent.com/47147484/97106329-e885f080-16d1-11eb-9278-e266673cdc67.png" />
</p>

[![CodeFactor](https://www.codefactor.io/repository/github/furkandeveloper/easyprofiler/badge)](https://www.codefactor.io/repository/github/furkandeveloper/easyprofiler)
<a href="https://gitmoji.carloscuesta.me">
  <img src="https://img.shields.io/badge/gitmoji-%20😜%20😍-FFDD67.svg?style=flat-square" alt="Gitmoji">
</a>
![.NET Core](https://github.com/furkandeveloper/EasyProfiler/workflows/.NET%20Core/badge.svg?branch=develop)
![Nuget](https://img.shields.io/nuget/dt/EasyProfiler.SQLServer?label=SQLServer%20Downloads)
![Nuget](https://img.shields.io/nuget/v/EasyProfiler.SQLServer?label=SQLServer)
![Nuget](https://img.shields.io/nuget/dt/EasyProfiler.MariaDb?label=MariaDb%20Downloads)
![Nuget](https://img.shields.io/nuget/v/EasyProfiler.MariaDb?label=MariaDb)
[![Maintainability](https://api.codeclimate.com/v1/badges/7da8a3efef94f523f2c1/maintainability)](https://codeclimate.com/github/furkandeveloper/EasyProfiler/maintainability)

## Easy Profiler
Welcome EasyProfiler documentation.

### Purpose
This repo, provides query profiler for EF Core.

### Getting started with EasyProfiler

Easy Profiler uses `Interceptor` to measure the performance of your queries.

It uses the `ProfilerDbContext` object to store the results.

### Supported Databases

* [x] SQL Server
* [ ] PostgreSQL
* [x] MariaDb
* [ ] MySQL
* [ ] MongoDB

### Sample for SQL Server
Install `EasyProfiler.SQLServer` from [Nuget Package](https://www.nuget.org/packages/EasyProfiler.SQLServer/)

Initilaze `EasyProfilerDbContext` in `Startup.cs` to save the results.
#### Sample
```csharp
services.AddEasyProfilerDbContext(options =>
{
    options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"));
});
```

and `EasyProfilerInterceptor` extensions add for own `DbContext`.

#### Sample
```csharp
services.AddDbContext<SampleDbContext>(options =>
{
    options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"))
    .AddEasyProfiler(services);
});
```

### Migrations
Use the `ApplyEasyProfilerSQLServer` extension method for pending migrations.

#### Sample

```csharp
public void Configure(IApplicationBuilder app, IWebHostEnvironment env, ProfilerDbContext profilerDbContext)
{
    app.ApplyEasyProfilerSQLServer(profilerDbContext);
}
```

<hr/>

Run your application and check your db. Must be created `Profiler` entity.

### Sample for MariaDb
Install `EasyProfiler.MariaDb` from [Nuget Package](https://www.nuget.org/packages/EasyProfiler.MariaDb/)

Initilaze `EasyProfilerDbContext` in `Startup.cs` to save the results.
#### Sample
```csharp
services.AddEasyProfilerDbContext(options =>
{
    options.UseMySql(Configuration.GetConnectionString("DefaultConnection"));
});
```

and `EasyProfilerInterceptor` extensions add for own `DbContext`.

#### Sample
```csharp
services.AddDbContext<SampleDbContext>(options =>
{
    options.UseMySql(Configuration.GetConnectionString("DefaultConnection"))
    .AddEasyProfiler(services);
});
```

### Migrations
Use the `ApplyEasyProfilerMariaDb` extension method for pending migrations.

#### Sample

```csharp
public void Configure(IApplicationBuilder app, IWebHostEnvironment env, ProfilerDbContext profilerDbContext)
{
    app.ApplyEasyProfilerMariaDb(profilerDbContext);
}
```

<hr/>

Run your application and check your db. Must be created `Profiler` entity.

## Watch Queries with AdvancedFilter

#### Usage
Get `IEasyProfilerBaseService<ProfilerDbContext>` From Dependency Injection.

```csharp
var queryProfilers = await easyProfilerService.AdvancedFilterAsync(new AdvancedFilterModel()
{
    CombineWith = CombineType.Or,
    Duration = new Range<TimeSpan> { Max = TimeSpan.MaxValue, Min = TimeSpan.MinValue},
    Page = 1,
    PerPage = 15,
    Query = "Select", // <---- Contains
    SortBy = Sorting.Descending, // <---  Default value Sorting.Descending,
    Sort = "Duration" // <--- Default value "Duration"
});
```

#### Response

```json
[
  {
    "query": "SELECT [c].[CustomerId], [c].[CreateDate], [c].[Name], [c].[Surname]\r\nFROM [Customers] AS [c]",
    "duration": {
      "ticks": 8737783,
      "days": 0,
      "hours": 0,
      "milliseconds": 873,
      "minutes": 0,
      "seconds": 0,
      "totalDays": 0.000010113174768518518,
      "totalHours": 0.00024271619444444446,
      "totalMilliseconds": 873.7783,
      "totalMinutes": 0.014562971666666667,
      "totalSeconds": 0.8737783
    },
    "id": "c06cae66-3dd1-4e34-810c-498c979a5c6a"
  }
]
```

## RoadMap

* [ ] PostgreSQL support.
* [ ] MySQL support.
* [x] MariaDB support.
* [x] SQLServer support.
* [ ] MongoDB support.
* [ ] QueryType. (For Example : `Select`,`Insert`,`Update`,`Delete`)
* [ ] Request Path. (For Example : "customer/getCustomer?fullname=sample")
