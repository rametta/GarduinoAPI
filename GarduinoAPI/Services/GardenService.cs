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

    public class GardenService : Service
    {
        public Garden Post(PostGarden req)
        {
          if (req.Garden != null)
            Db.Save(req.Garden);

          return req.Garden;
        }

        public void Delete(DeleteGarden req)
        {
          if (req.GardenId == 0)
            throw new ArgumentNullException("GardenId");
          Db.DeleteById<Garden>(req.GardenId);
        }
    }
}
