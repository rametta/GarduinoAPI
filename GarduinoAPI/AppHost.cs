using System;
using Funq;

using ServiceStack;
using ServiceStack.Text;
using ServiceStack.Auth;
using ServiceStack.Data;
using ServiceStack.Admin;
using ServiceStack.Caching;
using ServiceStack.OrmLite;
using ServiceStack.Api.Swagger;

using GarduinoAPI.Models;

namespace GarduinoAPI
{
    internal class AppHost : AppHostBase
    {
        public AppHost() : base("GarduinoAPI", typeof(Services.ReadingService).Assembly) { }

        public override void Configure(Container container)
        {
            var dbFactory = new OrmLiteConnectionFactory(MapProjectPath("GarduinoDB.db"), SqliteDialect.Provider);

            container.Register<IDbConnectionFactory>(c => dbFactory);
            container.Register<ICacheClient>(new MemoryCacheClient());
            // container.Register<IUserAuthRepository>(new InMemoryAuthRepository());
            container.Register<IUserAuthRepository>(c => new OrmLiteAuthRepository(c.Resolve<IDbConnectionFactory>()));

            Plugins.Add(new SwaggerFeature());
            Plugins.Add(new AutoQueryFeature());
            Plugins.Add(new AdminFeature());
            Plugins.Add(new RequestLogsFeature());
            Plugins.Add(new AuthFeature(() => new User(),
                  new IAuthProvider[] {
                new CredentialsAuthProvider()
              }));
            Plugins.Add(new RegistrationFeature());


            ConfigureDb(container);

            var authRepo = (OrmLiteAuthRepository)container.Resolve<IUserAuthRepository>();
            authRepo.InitSchema();

            JsConfig<DateTime>.SerializeFn = time => new DateTime(time.Ticks, DateTimeKind.Local).ToString("O");
            JsConfig.EmitCamelCaseNames = true;
        }

        private void ConfigureDb(Container container)
        {
            using (var db = container.Resolve<IDbConnectionFactory>().Open())
            {
                db.CreateTableIfNotExists<Garden>();
                db.CreateTableIfNotExists<Reading>();
            }
        }
    }
}