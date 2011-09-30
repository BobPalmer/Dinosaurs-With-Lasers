using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NHibernate;

namespace DinosaursWithLasers.Persistence
{
    public class RepositoryBase : IDisposable
    {
        private ISession _curSession;

        public ISession CurSession
        {
            get { return _curSession ?? (_curSession = NHConfiguration.SessionFactory.OpenSession()); }
        }

        public void Dispose()
        {
            _curSession.Dispose();
        }
    }
}
