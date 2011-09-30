using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DinosaursWithLasers.Model;
using DinosaursWithLasers.Repository;
using NHibernate;
using NHibernate.Criterion;
using NHibernate.Transform;

namespace DinosaursWithLasers.Persistence
{
    public class DinosaurRepository : RepositoryBase, IDinosaurRepository
    {
        public Dinosaur GetDinosaurByName(string dinoName)
        {
            var dino = CurSession.QueryOver<Dinosaur>()
                    .Where(d => d.Name == dinoName)
                    .List().FirstOrDefault();

            return dino;
        }

        public Dinosaur GetDinosaur(int dinoId)
        {
            var dino = CurSession.Get<Dinosaur>(dinoId);
            return dino;
        }

        public void DeleteDinosaur(Dinosaur dino)
        {
            using (var tran = CurSession.BeginTransaction())
            {
                CurSession.Delete(dino);
                tran.Commit();
            }
        }

        public void SaveDinosaur(Dinosaur dino)
        {
            using (var tran = CurSession.BeginTransaction())
            {
                CurSession.SaveOrUpdate(dino);
                tran.Commit();
            }
        }

        public IList<Dinosaur> GetDinosaursByCategory(string catId)
        {
            var dinoList = CurSession.QueryOver<Dinosaur>()
                    .JoinQueryOver<Category>(d => d.Categories)
                    .Where(c => c.CategoryId == catId)
                    .List().ToList();
            return dinoList;
        }

        public IList<Dinosaur> GetAllDinosaurs()
        {
            var dinoList = CurSession.QueryOver<Dinosaur>()
                    .List().ToList();
            return dinoList;
        }

        public IList<Dinosaur> GetDinosaurRiders()
        {
            var dinoList = CurSession.CreateCriteria(typeof (Dinosaur))
                .SetFetchMode("Riders", FetchMode.Eager)
                .SetResultTransformer(new DistinctRootEntityResultTransformer())
                .List<Dinosaur>();
            return dinoList;
        }
    }
}
