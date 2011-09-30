using System;
using System.Collections.Generic;
using DinosaursWithLasers.Model;
using DinosaursWithLasers.Repository;
using NHibernate;

namespace DinosaursWithLasers.Persistence
{
    public class CategoryRepository : RepositoryBase, ICategoryRepository
    {

        public void SaveCategory(Category cat)
        {
            using (var tran = CurSession.BeginTransaction())
            {
                CurSession.SaveOrUpdate(cat);
                tran.Commit();
            }
        }

        public Category GetCategory(string catId)
        {
            Category cat;
            cat = CurSession.Get<Category>(catId);
            return cat;
        }
    }
}