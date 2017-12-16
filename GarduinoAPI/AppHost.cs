using System;
using System.IO;
using Funq;

using ServiceStack;
using ServiceStack.Text;
using ServiceStack.OrmLite;
using ServiceStack.OrmLite.Sqlite;
using ServiceStack.Admin;
using ServiceStack.Api.Swagger;
using ServiceStack.Data;

namespace GarduinoAPI
{
    internal class AppHost : AppHostBase
    {
        public AppHost() : base("GarduinoAPI", typeof(Services.ReadingService).GetAssembly()) { }

        public override void Configure(Container container)
        {
            // MS SQLServer DB
            // var connectionString = "Data Source=PCNAME;Integrated Security=true;Initial Catalog=future_bi;Max Pool Size=2000;MultipleActiveResultSets=true;Application Name=SSCoreStarter";
            // var dbFactory = new OrmLiteConnectionFactory(connectionString, SqlServerDialect.Provider);

            // var connectionString = $"Data Source={Directory.GetCurrentDirectory()}\\future_bi.db;Version=3;";

            // SQLite DB
            // var dbFactory = new OrmLiteConnectionFactory(MapProjectPath("future_bi.db"), SqliteDialect.Provider);

            // In Mermory SQLite DB
            var dbFactory = new OrmLiteConnectionFactory(":memory:", SqliteDialect.Provider);

            container.Register<IDbConnectionFactory>(c => dbFactory);

            Plugins.Add(new SwaggerFeature { UseBootstrapTheme = true });
            Plugins.Add(new AutoQueryFeature { MaxLimit = 100 });
            Plugins.Add(new AdminFeature());

            JsConfig<DateTime>.SerializeFn = time => new DateTime(time.Ticks, DateTimeKind.Local).ToString("O");
        }
    }
}