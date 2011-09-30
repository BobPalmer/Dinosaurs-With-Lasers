using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using DinosaursWithLasers.Model;
using DinosaursWithLasers.Persistence;
using DinosaursWithLasers.Repository;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DinosaursWithLasers.Utilities;
using NHibernate.Cfg;
using NHibernate.Tool.hbm2ddl;

namespace DinosaursWithLasers.Tests.Persistence
{
    [TestClass]
    public class When_Persisting_Dinosaurs
    {
        private IDinosaurRepository dRepo = new DinosaurRepository();


        public void ClearTestDino()
        {
            var testDino = dRepo.GetDinosaurByName("TestDinosaur");
            if (testDino != null)
            {
                dRepo.DeleteDinosaur(testDino);
            }
        }

        [TestMethod]
        public void Should_be_able_to_get_a_list_of_dinosaurs()
        {
            var expectedSeries2 = 10;
            var expectedValor = 19;

            var actualSeries1 = dRepo.GetDinosaursByCategory("S2").Count;
            var actualValor = dRepo.GetDinosaursByCategory("VAL").Count;

            Assert.AreEqual(expectedSeries2, actualSeries1);
            Assert.AreEqual(expectedValor, actualValor);
        }


        [TestMethod]
        public void Should_be_able_to_create_a_dinosaur()
        {
            var newDino = CreateTestDino();
            var newId = newDino.DinosaurId;
            var repDino = dRepo.GetDinosaur(newId.ToInt());
            ClearTestDino();
            Assert.IsNotNull(newId);
            Assert.AreEqual(newDino.Name, repDino.Name);
        }

        [TestMethod]
        public void Should_be_able_to_change_a_dinosaur()
        {
            var newDino = CreateTestDino();
            var newId = newDino.DinosaurId;
            newDino.Description = "TestDescription";
            dRepo.SaveDinosaur(newDino);
            var repDino = dRepo.GetDinosaur(newId.ToInt());
            ClearTestDino();
            Assert.IsNotNull(repDino.Description);
            Assert.AreEqual(newDino.Description, repDino.Description);
        }

        [TestMethod]
        public void Should_be_able_to_delete_a_dinosaur()
        {
            var newDino = CreateTestDino();
            var newId = newDino.DinosaurId;
            dRepo.DeleteDinosaur(newDino);
            var repDino = dRepo.GetDinosaur(newId.ToInt());
            Assert.IsNotNull(newId);
            Assert.IsNull(repDino);
        }

        [TestMethod]
        public void Should_be_able_to_get_dinosaur_riders()
        {
            var d = dRepo.GetDinosaurByName("Tyrannosaurus Rex");
            var expected = 3;
            var actual = d.Riders.Count();
            Assert.AreEqual(expected,actual);
        }

        private Dinosaur CreateTestDino()
        {
            var dino = new Dinosaur();
            dino.Name = "TestDinosaur";
            dRepo.SaveDinosaur(dino);
            return dino;
        }
    }



}
