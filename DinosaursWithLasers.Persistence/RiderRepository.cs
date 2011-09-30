using System;
using System.Linq;
using DinosaursWithLasers.Model;
using DinosaursWithLasers.Repository;

namespace DinosaursWithLasers.Persistence
{
    public class RiderRepository : RepositoryBase, IRiderRepository
    {

        public Rider GetRiderByName(string riderName)
        {
            var r = CurSession.QueryOver<Rider>()
                .Where(d => d.Name == riderName)
                .List().FirstOrDefault();
            return r;
        }


        public void SaveRiderInfo(Rider rider)
        {
            using (var tran = CurSession.BeginTransaction())
            {
                CurSession.SaveOrUpdate(rider);
                tran.Commit();
            }
        }
    }
}