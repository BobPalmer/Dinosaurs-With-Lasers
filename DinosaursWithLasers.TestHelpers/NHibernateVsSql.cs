using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using DinosaursWithLasers.Model;
using NHibernate;
using NHibernate.Cfg;

namespace DinosaursWithLasers.TestHelpers
{
    public class NHibernateVsSql
    {
        private NHibernateVsSql()
        {
            log4net.Config.XmlConfigurator.Configure();
        }

        public void RunSamples()
        {
            //var dinos = Getting_A_List_Of_Items_Via_Databinding();
            var dinos = Getting_A_List_Of_Items_Via_ADONet();
            //var dinos = Getting_A_List_Of_Items_Via_NHibernate();

            //Show a list of dinosaurs information
            foreach (var dino in dinos)
            {
                Console.WriteLine("{0} - {1}: {2} (Image: {3})", 
                                  dino.DinosaurId, 
                                  dino.Name, 
                                  dino.ShortDescription, 
                                  dino.BoxImageUrl); 
            }
        }

        public IList<Dinosaur> Getting_A_List_Of_Items_Via_Databinding()
        {
            //     \`-"'"-'/    
            //      } X X {       Binding directly to your  
            //     =.  Y  ,=      database is not only a violation
            //   (""-'***`-"")    of separation of concerns, but
            //    `-/     \-'     also kills kittens.        
            //     (  )-(  )==='      
            //
            return null;
        }

        public IList<Dinosaur> Getting_A_List_Of_Items_Via_ADONet()
        {
            IList<Dinosaur> dinoList = new List<Dinosaur>();
            string constr = 
                @"Data Source=.\SQLExpress; Initial Catalog=NHPTest; Trusted_Connection=true;";
            
            using (SqlConnection cnDino = new SqlConnection(constr))
            {
                cnDino.Open();
                SqlCommand cmddino = new SqlCommand("Select * from Dinosaurs", cnDino);
                using (SqlDataReader dino = cmddino.ExecuteReader())
                {
                    while (dino.Read())
                    {
                        var d = new Dinosaur();
                        d.DinosaurId = Int32.Parse(dino["DinosaurID"].ToString());
                        d.Name = dino["Name"].ToString();
                        d.Description = dino["Description"].ToString();
                        d.BoxImageUrl = dino["BoxImageUrl"].ToString();
                        d.FigImageUrl = dino["FigImageUrl"].ToString(); 
                        d.ThumbImageUrl = dino["ThumbImageUrl"].ToString(); 
                        dinoList.Add(d);
                    }
                }
            }


            return dinoList;
        }

        public IList<Dinosaur> Getting_A_List_Of_Items_Via_NHibernate()
        {
            IList<Dinosaur> dinoList = new List<Dinosaur>();
            Configuration config = new Configuration().Configure();
            ISessionFactory sessionFactory = config.BuildSessionFactory();

            using (ISession session = sessionFactory.OpenSession())
            {
                dinoList = session.QueryOver<Dinosaur>().List();
            }
            
            return dinoList;
        }
    }
}