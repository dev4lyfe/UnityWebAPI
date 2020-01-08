using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using BugReporterUnityWebAPI.Contracts;

namespace Unity3d_Restful_Service.Controllers
{
    public class PlayersController : Controller
    {
        private static List<Player> Players = new List<Player>()
        {
            new Player
            {
                Id = 1,
                FullName = "Guy Bob",
                Score = 111
            },
            new Player
            {
                Id = 2,
                FullName = "Guy Joe",
                Score = 222
            },
            new Player
            {
                Id = 3,
                FullName = "Guy Ren",
                Score = 333
            },
        };

        [HttpGet]
        public JsonResult Get()
        {
            return Json(Players);
        }

        [HttpGet("{id}")]
        public JsonResult Get(int id)
        {
            Player player = Players.Single(p => p.Id == id);
            return Json(player);
        }

        [HttpPost]
        public JsonResult Post([FromBody]Player newPlayer)
        {
            Players.Add(newPlayer);
            return Json(Players);
        }

        [HttpPut("{id}")]
        public JsonResult Put(int id, [FromBody]float newScore)
        {
            Player player = Players.Single(p => p.Id == id);
            player.Score = newScore;
            return Json(player);
        }

        [HttpDelete]
        public void Delete(int id)
        {
            Player player = Players.Single(p => p.Id == id);
            Players.Remove(player);
        }
    }
}

