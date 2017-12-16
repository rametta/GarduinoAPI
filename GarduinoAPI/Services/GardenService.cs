using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using ServiceStack;
using ServiceStack.OrmLite;

using GarduinoAPI.Models;

namespace GarduinoAPI.Services
{
    [Route("/api/gardens", "GET")]
    public class GardensQuery : QueryDb<Garden> { }

    [Route("/api/garden", "POST")]
    public class PostGarden
    {
      public Garden Garden { get; set; }
    }

    [Route("/api/garden", "DELETE")]
    public class DeleteGarden
    {
      public int GardenId { get; set; }
    }

    [Authenticate()]
    public class GardenService : Service
    {
        public Garden Post(PostGarden req)
        {
          if (req.Garden != null)
            Db.Save(req.Garden);

          return req.Garden;
        }

        public int Delete(DeleteGarden req)
        {
          return req.GardenId > 0 ? Db.DeleteById<Garden>(req.GardenId) : 0;
        }
    }
}
