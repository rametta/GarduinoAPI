using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using ServiceStack;

using GarduinoAPI.Types;

namespace GarduinoAPI.Services
{
    [Route("/api/starter", "GET")]
    public class GetStarterReq { }

    public class ReadingService : Service
    {
        public Starter Get(GetStarterReq req)
        {
            return new Starter { Hello = "World" };
        }
    }
}
