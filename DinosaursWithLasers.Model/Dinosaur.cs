using System;
using System.Collections.Generic;

namespace DinosaursWithLasers.Model
{
    public class Dinosaur
    {
        private IList<Category> _categories;
        private IList<Rider> _riders;
        private IList<string> _weapons;

        public virtual int? DinosaurId { get; set; }
        public virtual string Name { get; set; }
        public virtual string FigImageUrl { get; set; }
        public virtual string BoxImageUrl { get; set; }
        public virtual string ThumbImageUrl { get; set; }
        public virtual string Description { get; set; }
        public virtual IList<Category> Categories 
        {
            get { return _categories ?? (_categories = new List<Category>()); }
            protected set { _categories = value; }
        }
        public virtual IList<Rider> Riders 
        {
            get { return _riders ?? (_riders = new List<Rider>()); }
            protected set { _riders = value; }
        }
        public virtual IList<string> Weapons
        {
            get { return _weapons ?? (_weapons = new List<string>()); }
            protected set { _weapons = value; }
        }

        public virtual string ShortDescription
        {
            get
            {
                if (String.IsNullOrEmpty(Description)) return "(No Description)";;
                var stop = Description.IndexOf('.');
                if (stop <= 0) return Description;
                return Description.Substring(0, stop) + "..";
            }
        }
    }
}