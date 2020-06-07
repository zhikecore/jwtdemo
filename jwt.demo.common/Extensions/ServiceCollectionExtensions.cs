using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;
using System.Reflection;
using Microsoft.Extensions.DependencyModel;
using System.IO;

namespace jwt.demo
{
    /// <summary>
    /// ServiceCollection扩展
    /// </summary>
    public static class ServiceCollectionExtensions
    {
        /// <summary>
        /// 扫描程序集自动注册领域服务（包括仓储）
        /// </summary>
        /// <param name="services"></param>
        /// <param name="lifetime"></param>
        public static void AddDomainServicesFromAssembly(this IServiceCollection services, ServiceLifetime lifetime = ServiceLifetime.Scoped)
        {
            var deps = DependencyContext.Default.CompileLibraries.Where(lib => !lib.Name.EndsWith(".Reference") && !lib.Serviceable && lib.Type != "package");//排除所有的系统程序集、Nuget下载包

            var assemblies = deps.Select(lib => Assembly.Load(lib.Name));

            var types = assemblies.SelectMany(n => n.GetTypes()).Where(t => t.GetInterfaces().Any(n => n.Name == "IService" || n.Name == "IRepository") && !t.IsInterface && !t.IsAbstract).ToList();

            foreach (var item in types)
            {
                var interfaceTypes = item.GetInterfaces();

                foreach (var interfaceType in interfaceTypes)
                {
                    switch (lifetime)
                    {
                        case ServiceLifetime.Singleton:
                            services.AddSingleton(interfaceType, item);
                            break;
                        case ServiceLifetime.Scoped:
                            services.AddScoped(interfaceType, item);
                            break;
                        case ServiceLifetime.Transient:
                            services.AddTransient(interfaceType, item);
                            break;
                        default:
                            break;
                    }
                }
            }
        }

        /// <summary>
        /// 注入MebHttpClient
        /// </summary>
        /// <param name="services"></param>
        /// <param name="options"></param>
        //public static void AddMebHttpClient(this IServiceCollection services, Action<MebHttpClientOptions> options = null)
        //{
        //    services.AddHttpClient("mebhttpclient")
        //        .AddTransientHttpErrorPolicy(p => p.RetryAsync(3))
        //        .AddTransientHttpErrorPolicy(p => p.CircuitBreakerAsync(5, TimeSpan.FromSeconds(30)));

        //    services.AddSingleton<MebHttpClient>();

        //    if (options != null) services.Configure(options);
        //}

        //public static IConfiguration AddConsoleDefaultServices(this IServiceCollection services)
        //{
        //    IConfiguration configuration = GetConfiguration();
        //    services.AddSingleton(configuration);

        //    services.AddLogging();

        //    return configuration;
        //}

        //private static IConfiguration GetConfiguration()
        //{
        //    return new ConfigurationBuilder()
        //        .SetBasePath(Directory.GetCurrentDirectory())
        //        .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
        //        .Build();
        //}
    }
}
