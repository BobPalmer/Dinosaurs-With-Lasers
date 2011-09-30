using System.Collections.Generic;

namespace DinosaursWithLasers.Model
{
    public class Category
    {
        private IList<Dinosaur> _dinosaurs;

        public virtual string CategoryId { get; set; }
        public virtual string Name { get; set; }
        public virtual IList<Dinosaur> Dinosaurs
        {
            get { return _dinosaurs ?? (_dinosaurs = new List<Dinosaur>()); }
            protected set { _dinosaurs = value; }
        }
    }
}