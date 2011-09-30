using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DinosaursWithLasers.Model;

namespace DinosaursWithLasers.Repository
{
    public interface IDinosaurRepository
    {
        Dinosaur GetDinosaurByName(string dinoName);
        Dinosaur GetDinosaur(int dinoId);
        void DeleteDinosaur(Dinosaur dino);
        void SaveDinosaur(Dinosaur dino);
        IList<Dinosaur> GetDinosaursByCategory(string catId);
        IList<Dinosaur> GetAllDinosaurs();
        IList<Dinosaur> GetDinosaurRiders();
    }
}
