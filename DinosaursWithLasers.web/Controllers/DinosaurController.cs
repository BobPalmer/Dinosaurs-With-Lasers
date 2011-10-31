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

        public ActionResult List(string id)
        {
            var dinoList = _dinoRepo.GetDinosaursByCategory(id);
            ViewBag.CategoryName = _catRepo.GetCategory(id).Name;
            return View(dinoList);
        }

        public ActionResult Details(int id)
        {
            var dino = _dinoRepo.GetDinosaur(id);
            return View(dino);
        }

        public JsonResult GetSimilarDinosaurs(int id)
        {
            var dino = _dinoRepo.GetDinosaur(id);
            var dinoList = new List<string>();
            foreach (var cat in dino.Categories)
            {
                var simDin = _dinoRepo.GetDinosaursByCategory(cat.CategoryId);
                foreach (var d in simDin)
                {
                    if (!dinoList.Contains(d.Name))
                    dinoList.Add(d.Name);
                }
            }
            dinoList.Remove(dino.Name);
            return Json(string.Join(", ",dinoList.ToArray()), JsonRequestBehavior.AllowGet);
        }
    }
}
