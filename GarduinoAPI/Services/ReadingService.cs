using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using ServiceStack;
using ServiceStack.OrmLite;

using GarduinoAPI.Types;

namespace GarduinoAPI.Services
{
    [Route("/api/readings", "GET")]
    public class ReadingsQuery : QueryDb<Reading> { }

    [Route("/api/reading", "POST")]
    public class PostReading
    {
      public Reading Reading { get; set; }
    }

    [Route("/api/reading", "DELETE")]
    public class DeleteReading
    {
      public int ReadingId { get; set; }
    }

    public class ReadingService : Service
    {
        public Reading Post(PostReading req)
        {
          if (req.Reading != null)
            Db.Save(req.Reading);

          return req.Reading;
        }

        public int Delete(DeleteReading req)
        {
          return req.ReadingId > 0 ? Db.DeleteById<Reading>(req.ReadingId) : 0;
        }
    }
}
