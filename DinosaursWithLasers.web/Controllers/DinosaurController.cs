using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DinosaursWithLasers.Persistence;
using DinosaursWithLasers.Repository;

namespace DinosaursWithLasers.Controllers
{
    public class DinosaurController : Controller
    {
        private IDinosaurRepository _dinoRepo;
        private ICategoryRepository _catRepo;
        
        public DinosaurController() : this(new DinosaurRepository(), new CategoryRepository())
        {
        }

        public DinosaurController(IDinosaurRepository dinoRepo, ICategoryRepository catRepo)
        {
            _dinoRepo = dinoRepo;
            _catRepo = catRepo;
        }

        public ActionResult List(string catId)
        {
            var dinoList = _dinoRepo.GetDinosaursByCategory(catId);
            ViewBag.CategoryName = _catRepo.GetCategory(catId).Name;
            return View(dinoList);
        }

        public ActionResult Details(int id)
        {
            var dino = _dinoRepo.GetDinosaur(id);
            return View(dino);
        }
    }
}
