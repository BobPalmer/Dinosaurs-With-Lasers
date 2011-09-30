using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DinosaursWithLasers.Model;
using DinosaursWithLasers.Persistence;
using DinosaursWithLasers.Repository;

namespace DinosaursWithLasers.Tasks
{
    public class DinoTasks
    {
        private IDinosaurRepository _dinoRepo;

        public DinoTasks()
        {
            _dinoRepo = new DinosaurRepository();
        }

        public IList<Dinosaur> GetDinosaursByCategory(string catId)
        {
            return _dinoRepo.GetDinosaursByCategory(catId);
        }
    }
}
