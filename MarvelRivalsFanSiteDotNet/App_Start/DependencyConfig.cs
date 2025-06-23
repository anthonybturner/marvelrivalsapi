// App_Start/DependencyConfig.cs
using MarvelRivalsFanSiteDotNet;
using MarvelRivalsFanSiteDotNet.Services;
using MarvelRivalsFanSiteDotNet.Services.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Configuration;
using System.Linq; // Replace with your actual namespace
using System.Web.Mvc;

public static class DependencyConfig
{
    public static IServiceProvider ConfigureServices()
    {
        var services = new ServiceCollection();

        // Register HttpClient
        services.AddHttpClient<ILeaderboardService, LeaderboardService>(client =>
        {
            client.BaseAddress = new Uri(
                ConfigurationManager.AppSettings["MarvelRivalsApiBaseUrl"]);

            client.DefaultRequestHeaders.Accept.Add(
                new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

            client.DefaultRequestHeaders.Add("x-api-key",
                ConfigurationManager.AppSettings["MarvelRivalsApiKey"]);
        });

        services.AddHttpClient<IHeroesService, HeroesService>(client =>
        {
            client.BaseAddress = new Uri(
                ConfigurationManager.AppSettings["MarvelRivalsApiBaseUrl"]);

            client.DefaultRequestHeaders.Accept.Add(
                new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

            client.DefaultRequestHeaders.Add("x-api-key",
                ConfigurationManager.AppSettings["MarvelRivalsApiKey"]);
        });

        // Register all controllers
        var controllers = typeof(MvcApplication).Assembly.GetExportedTypes()
            .Where(t => !t.IsAbstract && typeof(IController).IsAssignableFrom(t));
        foreach (var controller in controllers)
        {
            services.AddTransient(controller);
        }

        return services.BuildServiceProvider();
    }
}