using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Domain.Entities;
using Domain.Abstract;
namespace MyWeb.Controllers
{
    public class GameController : Controller
    {
        // GET: Game
        private IGameRepository repository;
        public GameController (IGameRepository repo)
        {
            repository = repo;
        }
        public ViewResult List()
        {
            return View(repository.Games);
        }
    }
}