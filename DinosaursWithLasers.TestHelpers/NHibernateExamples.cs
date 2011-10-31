using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using DinosaursWithLasers.Model;
using DinosaursWithLasers.Persistence;
using NHibernate;
using NHibernate.Cfg;
using NHibernate.Transform;

namespace DinosaursWithLasers.TestHelpers
{
    public class NHibernateExamples
    {
        private NHibernateExamples()
        {
            log4net.Config.XmlConfigurator.Configure();
        }

        private ISession session;
       
        private void Demo_01A_Basics_With_NHibernate()
        {
            Setup();
            //AddingARecord();
            //AddingBatchRecords();
            //FindingAndEditing();
            //
            
           DeletingRecords();
        }

        private void Setup()
        {
            try
            {
                Configuration config = new Configuration().Configure();
                ISessionFactory sessionFactory = config.BuildSessionFactory();

                //Create a Session from the factory - These are a lot lighter weight,
                //best practice is one per web page or one per form (so you get caching and
                //whatnot... but use in whatever way makes sense for your app.

                session = sessionFactory.OpenSession();
            }
            catch (Exception ex)
            {
             
                throw ex;
            }
            //Setting up our connectivity 
            //Make sure you make only ONE of these!

        }

        private void AddingARecord()
        {
            //Let's make us a dinosaur! 
            Dinosaur dino = new Dinosaur
            {
                Name = "AwesomeSaurus Rex",
                Description = "SAMPLE DINO"
            };

            //Persisting is a cakewalk. We'll just need to wrap 
            //this up in a transaction since we're updating the database.  
            using (ITransaction tran = session.BeginTransaction())
            {
                session.SaveOrUpdate(dino);
                tran.Commit();
            }
        }

        private void AddingBatchRecords()
        {
            using (ITransaction tran = session.BeginTransaction())
            {
                for (int i = 0; i < 10; i++) //<--- Holy crap!  TEN dinosaurs!
                {
                    //Let's make us a dinosaur! 
                    Dinosaur dino = new Dinosaur
                    {
                        Name = "BatchaSaurus Rex",
                        Description = "SAMPLE DINO"
                    };

                    session.SaveOrUpdate(dino);
                }
                tran.Commit();
            }
        }
        
        private void FindingAndEditing()
        {
            //Finding records by their primary keys is super easy...
            Category cat = session.Get<Category>("RUL");

            //Finding records by fields other than their primary keys is 
            //pretty easy too... you can use ICriteria, or QueryOver
            //(which is just a wrapper on ICriteria).
            Dinosaur demoDino = session.QueryOver<Dinosaur>()
                .Where(d => d.Name == "AwesomeSaurus Rex")
                .List().FirstOrDefault();

            //Let's add a rider for this dinosaur!  
            Rider rider = new Rider
                              {
                                  DinoBox = demoDino,
                                  FigImageUrl = @"/content/images/InfoPic-Rusty.jpg",
                                  Name = "Rusty"
                              };
            demoDino.Riders.Add(rider);

            //And change some fields...
            demoDino.Categories.Add(cat);
            demoDino.BoxImageUrl = @"/content/images/AwesomeSaurus-Front-Small.png";
            demoDino.FigImageUrl = @"/content/images/InfoPic-Pterodactyl.jpg";
            demoDino.ThumbImageUrl = @"/content/images/NavigationPic-AwesomeSaurus";
            demoDino.Weapons.Add("None");

            //And commit our changes...;
            using (ITransaction tran = session.BeginTransaction())
            {
                session.SaveOrUpdate(demoDino);
                tran.Commit();
            }
        }
        
        private void DeletingRecords()
        {
            //Cleanup time!  Deleting is pretty easy as well.  We'll start
            //by getting a list of dinos we need to delete...
            IList<Dinosaur> dinoDelete = session.QueryOver<Dinosaur>()
                .Where(d => d.Description == "SAMPLE DINO")
                .List();

            using (ITransaction tran = session.BeginTransaction())
            {
                foreach (var dinosaur in dinoDelete)
                {
                    session.Delete(dinosaur);
                }
                //If you need to delete large object graphs, you can use
                //an HQL query (or native SQL) to make things more efficient 
                tran.Commit();
            }
        }

        private void Demo_02_LazyLoading()
        {
            //Now we're taking all of the ceremony stuff we 
            //did by hand in demo 1 and moving it into our repository
            var dRepo = new DinosaurRepository();
            var dino = dRepo.GetDinosaurByName("Tyrannosaurus Rex");
            //dRepo.Dispose();  //<-- Observing a property in the debugger will make it lazy load!
            var rider = dino.Riders.First(); //<-- Touching a property will cause lazy loading
            dRepo.Dispose();  //<-- Observing a property in the debugger will make it lazy load!
        }

        private void Demo_03_N_Plus_One()
        {
            var dRepo = new DinosaurRepository();

            //foreach (var dino in dRepo.GetAllDinosaurs()) //<-- Using Lazy Loading - N+1 Sadness ensues
            foreach (var dino in dRepo.GetDinosaurRiders()) //<- - Using Eager Loading - Unicorns and Sunshine!
            {
                foreach (var rider in dino.Riders)
                {
                    Console.WriteLine("******** {0} - {1}", rider.Name, dino.Name);
                }
            }
        }
    }
}