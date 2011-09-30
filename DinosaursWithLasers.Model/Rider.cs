using System;
using System.Linq;
using System.Text;

namespace DinosaursWithLasers.Model
{
    public class Rider
    {
        public virtual int? RiderId { get; set; }
        public virtual string Name { get; set; }
        public virtual string FigImageUrl { get; set; }
        public virtual Dinosaur DinoBox { get; set; }
    }
}
