using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using DinosaursWithLasers.Controllers;
using DinosaursWithLasers.Model;
using DinosaursWithLasers.Persistence;
using DinosaursWithLasers.Utilities;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DinosaursWithLasers.Tests.Controllers
{
    [TestClass]
    public class When_Testing_Dinosaur_Controllers
    {
        [TestMethod]
        public void Should_be_able_to_retrieve_a_single_dinosaur()
        {
            //arrange
            var dRepo = new DinosaurRepository();
            var dino = dRepo.GetDinosaurByName("Brontosaurus");

            var dcon = new DinosaurController(dRepo, new CategoryRepository());

            //act
            var r = dcon.Details(dino.DinosaurId.ToInt()) as ViewResult;

            //assert
            var model = r.ViewData.Model as Dinosaur;
            Assert.IsNotNull(model, "Model should be of type Dinosaur");
        }

        [TestMethod]
        public void Should_be_able_to_retrieve_a_list_of_dinosaurs()
        {
            //arrange
            var dRepo = new DinosaurRepository();
            var dcon = new DinosaurController(dRepo, new CategoryRepository());

            //act
            var r = dcon.List("VAL") as ViewResult;

            //assert
            var model = r.ViewData.Model as IList<Dinosaur>;
            Assert.IsNotNull(model, "Model should be of type IList<Dinosaur>");
        }
    }
}
