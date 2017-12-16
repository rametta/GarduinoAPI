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

using GarduinoAPI.Types;

namespace GarduinoAPI
{
    internal class AppHost : AppHostBase
    {
        public AppHost() : base("GarduinoAPI", typeof(Services.ReadingService).Assembly) { }

        public override void Configure(Container container)
        {
            var dbFactory = new OrmLiteConnectionFactory(MapProjectPath("GarduinoDB.db"), SqliteDialect.Provider);

            container.Register<IDbConnectionFactory>(c => dbFactory);

            SetupDBTables(container);

            Plugins.Add(new SwaggerFeature());
            Plugins.Add(new AutoQueryFeature());
            Plugins.Add(new AdminFeature());

            JsConfig<DateTime>.SerializeFn = time => new DateTime(time.Ticks, DateTimeKind.Local).ToString("O");
        }

        private void SetupDBTables(Container container) {
            using (var db = container.Resolve<IDbConnectionFactory>().Open())
            {
                db.CreateTableIfNotExists<Garden>();
                db.CreateTableIfNotExists<Reading>();
            }
        }
    }
}