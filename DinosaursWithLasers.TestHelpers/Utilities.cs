using System;
using System.Text;
using DinosaursWithLasers.Model;
using DinosaursWithLasers.Persistence;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NHibernate.Cfg;
using NHibernate.Tool.hbm2ddl;

namespace DinosaursWithLasers.TestHelpers
{

    public class Utilities
    {

        #region Setup
        private void GenerateSchema()
        {
            var configuration = new Configuration().Configure();
            var schema = new SchemaExport(configuration);
            schema.Create(true, true);

            CreateDinosaurCatalog();
        }

        private void CreateDinosaurCatalog()
        {
            var dRepo = new DinosaurRepository();
            var cRepo = new CategoryRepository();

            cRepo.SaveCategory(new Category { Name = "Series 1", CategoryId = "S1"});
            cRepo.SaveCategory(new Category { Name = "Series 2", CategoryId = "S2" });
            cRepo.SaveCategory(new Category { Name = "Series 3", CategoryId = "S3" });
            cRepo.SaveCategory(new Category { Name = "Ice Age", CategoryId = "ICE" });
            cRepo.SaveCategory(new Category { Name = "Valorians", CategoryId = "VAL" });
            cRepo.SaveCategory(new Category { Name = "Rulons", CategoryId = "RUL" });

            Dinosaur d;

            d = new Dinosaur();
            d.Name = "Tyrannosaurus Rex";
            d.BoxImageUrl = @"/content/images/Tyrannosaurus-Front-Small.jpg";
            d.Description = "The Tyrannosaurus Rex is arguably the pinnacle of the Dino-Riders toy line.  For its time, this thing was a dinosaur fan’s dream come true.  The set was huge and contained a lot of pieces that took quite some time to put together.  The T-Rex retailed for $50 and although pretty steep for the average kid back in the day, it was definitely worth it.  The  T-Rex was the largest toy in the Dino-Rider line until the 2nd Series release of the Brontosaurus.  The T-Rex also had motorized walking action that was powered by a D battery and assisted with small wheels on its feet.  This feature would later be removed when it was re-released as part of the Smithsonian Institution line.  The T-Rex included three figures, Krulos, Bitor and Cobrus, and the color of their outfits were actually somewhat coordinated.  Despite it large size and awesome artillery, the T-Rex still left something to be desired.  In perhaps the most disappointing use of the “colors may vary” disclaimer, Tyco released the T-Rex in a dark gray and greenish color instead of the advertised bright green and orange.  It was really unfortunate because throughout the entire cartoon series, the T-Rex was always depicted as green and orange.  The pre-production photos that advertised the T-Rex also depicted a green and orange color, which looked infinitely cooler than the final production model.  But anyway, the T-Rex was still the coolest thing out there and still remains an awesome piece to this day.";
            d.FigImageUrl = @"/content/images/InfoPic-TyrannosaurusRex.jpg";
            d.ThumbImageUrl = @"/content/images/NavigationPic-Tyrannosaurus.jpg";
            d.Categories.Add(cRepo.GetCategory("S1"));
            d.Categories.Add(cRepo.GetCategory("Rul"));
            d.Riders.Add(new Rider { DinoBox = d, FigImageUrl = @"/content/images/FigurePic-Krulos.jpg", Name = "Krulos" });
            d.Riders.Add(new Rider { DinoBox = d, FigImageUrl = @"/content/images/FigurePic-Bitor.jpg", Name = "Bitor" });
            d.Riders.Add(new Rider { DinoBox = d, FigImageUrl = @"/content/images/FigurePic-Cobrus.jpg", Name = "Cobrus" });
            d.Weapons.Add("Ladder");
            d.Weapons.Add("Electric Whip");
            d.Weapons.Add("Crossbow");
            d.Weapons.Add("Shield");
            d.Weapons.Add("Binoculars");
            d.Weapons.Add("Bazooka");
            dRepo.SaveDinosaur(d);

            d = new Dinosaur();
            d.Name = "Triceratops";
            d.BoxImageUrl = @"/content/images/Triceratops-Front-Small.jpg";
            d.Description = "As one of the most popular dinosaurs of all time, the Triceratops made a great piece for the Dino-Riders line.  The set included a satellite and two large laser canons on each side of the dinosaur.  Because the Triceratops often appeared in the Dino-Riders cartoon, it was important for Tyco to do a good job with the toy and they did indeed.  The Triceratops also had motorized walking action and its head swayed from side to side as it walked. The motorized walking action would later be removed when it was re-released as part of the Smithsonian Institution line.";
            d.FigImageUrl = @"/content/images/InfoPic-Triceratops.jpg";
            d.ThumbImageUrl = @"/content/images/NavigationPic-Triceratops.jpg";
            d.Categories.Add(cRepo.GetCategory("S1"));
            d.Categories.Add(cRepo.GetCategory("Rul"));
            d.Riders.Add(new Rider { DinoBox = d, FigImageUrl = @"/content/images/FigurePic-Hammerhead.jpg", Name = "Hammerhead" });
            d.Riders.Add(new Rider { DinoBox = d, FigImageUrl = @"/content/images/FigurePic-Sidewinder.jpg", Name = "Sidewinder" });
            d.Weapons.Add("Ladder");
            d.Weapons.Add("Electric Whip");
            d.Weapons.Add("Crossbow");
            d.Weapons.Add("Shield");
            d.Weapons.Add("Binoculars");
            d.Weapons.Add("Bazooka");
            dRepo.SaveDinosaur(d);

            d = new Dinosaur();
            d.Name = "Deinonychus";
            d.BoxImageUrl = @"/content/images/Deinonychus-Front-Small.jpg";
            d.Description = "The Deinonychus had many appearances in the Dino-Riders cartoon and was popular enough to have both a Rulon and Dino-Rider version.  The actual production piece varies slightly from the pre-production photo in that the pre-production photo showed a solid colored light brown dinosaur, whereas the production model had a darker brown color with dark stripes running down its back.  The only difference between the two dinosaurs is that the Rulon version had dark brown stripes and the Dino-Rider version had dark blue stripes.  This difference was less noticeable once the weapons were put on.  The Rulon Deinonychus included Antor and a Rulon trap, which consisted of two long vertical boulders that clasped together and trapped the Deinonychus’ head when a button was pressed.";
            d.FigImageUrl = @"/content/images/InfoPic-Deinonychus.jpg";
            d.ThumbImageUrl = @"/content/images/NavigationPic-Deinonychus.jpg";
            d.Categories.Add(cRepo.GetCategory("S1"));
            d.Categories.Add(cRepo.GetCategory("Rul"));
            d.Riders.Add(new Rider { DinoBox = d, FigImageUrl = @"/content/images/FigurePic-Antor.jpg", Name = "Antor" });
            d.Weapons.Add("Ladder");
            d.Weapons.Add("Electric Whip");
            d.Weapons.Add("Crossbow");
            d.Weapons.Add("Shield");
            d.Weapons.Add("Binoculars");
            d.Weapons.Add("Bazooka");
            dRepo.SaveDinosaur(d);

            d = new Dinosaur();
            d.Name = "Monoclonius";
            d.BoxImageUrl = @"/content/images/Monoclonius-Front-Small.jpg";
            d.Description = "The Monoclonius had an identical body to the Styracosaurus and Chasmosaurus except that it had a different color scheme and a different head sculpt.  The tail and the head were connected in such a way that if you moved the tail in one direction, the head would swing in the other direction.  The Monoclonius included a Rulon trap.  The trap consisted of two vertical logs that would snap together and trap the Monoclonius’ head when a button was pressed.  What was pretty interesting is that this dinosaur is a Rulon but in many of the cartoons, the Monoclonius was used by the Dino-Riders.";
            d.FigImageUrl = @"/content/images/InfoPic-Monoclonius.jpg";
            d.ThumbImageUrl = @"/content/images/NavigationPic-Monoclonius.jpg";
            d.Categories.Add(cRepo.GetCategory("S1"));
            d.Categories.Add(cRepo.GetCategory("Rul"));
            d.Riders.Add(new Rider { DinoBox = d, FigImageUrl = @"/content/images/FigurePic-Mako.jpg", Name = "Mako" });
            d.Weapons.Add("Ladder");
            d.Weapons.Add("Electric Whip");
            d.Weapons.Add("Crossbow");
            d.Weapons.Add("Shield");
            d.Weapons.Add("Binoculars");
            d.Weapons.Add("Bazooka");
            dRepo.SaveDinosaur(d);

            d = new Dinosaur();
            d.Name = "Pteranodon";
            d.BoxImageUrl = @"/content/images/Pteranodon-Front-Small.jpg";
            d.Description = "The Pteranodon was one of the three flying dinosaurs released in the 1st Series.  The Pteranodon had a button over its tail that would cause its wings to flap up and down when pressed.  The Pteranodon included a Rulon trap that consisted of a secret net that would spring up at the press of a button and catch any Pteranodon unfortunate enough to be flying overhead.";
            d.FigImageUrl = @"/content/images/InfoPic-Pteranodon.jpg";
            d.ThumbImageUrl = @"/content/images/NavigationPic-Pteranodon.jpg";
            d.Categories.Add(cRepo.GetCategory("S1"));
            d.Categories.Add(cRepo.GetCategory("Rul"));
            d.Riders.Add(new Rider { DinoBox = d, FigImageUrl = @"/content/images/FigurePic-Rasp.jpg", Name = "Rasp" });
            d.Weapons.Add("Ladder");
            d.Weapons.Add("Electric Whip");
            d.Weapons.Add("Crossbow");
            d.Weapons.Add("Shield");
            d.Weapons.Add("Binoculars");
            d.Weapons.Add("Bazooka");
            dRepo.SaveDinosaur(d);

            d = new Dinosaur();
            d.Name = "Ankylosaurus";
            d.BoxImageUrl = @"/content/images/Ankylosaurus-Front-Small.jpg";
            d.Description = "The Ankylosaurus was one of the smallest pieces in the line.  It had a one-piece attachment that served as both a brain box and a harness that for a giant crossbow rocket.  The Ankylosaurus did not have a seat for its rider, Sting.  The pre-production photo of the Ankylosaurus depicted a dull orange color but the final production piece was actually dark and light gray.  It probably would have looked cooler if the final piece was orange, but the piece was pretty small and ultimately not that cool anyway.  The Ankylosaurus would have its name changed to Euoplocephalus when it was re-released as part of the Smithsonian Institution line.";
            d.FigImageUrl = @"/content/images/InfoPic-Ankylosaurus.jpg";
            d.ThumbImageUrl = @"/content/images/NavigationPic-Ankylosaurus.jpg";
            d.Categories.Add(cRepo.GetCategory("S1"));
            d.Categories.Add(cRepo.GetCategory("Rul"));
            d.Riders.Add(new Rider { DinoBox = d, FigImageUrl = @"/content/images/FigurePic-Sting.jpg", Name = "Sting" });
            d.Weapons.Add("Ladder");
            d.Weapons.Add("Electric Whip");
            d.Weapons.Add("Crossbow");
            d.Weapons.Add("Shield");
            d.Weapons.Add("Binoculars");
            d.Weapons.Add("Bazooka");
            dRepo.SaveDinosaur(d);

            d = new Dinosaur();
            d.Name = "Diplodocus";
            d.BoxImageUrl = @"/content/images/Diplodocus-Front-Small.jpg";
            d.Description = "The Diplodocus was another very large toy in the Dino-Riders line.  It was heavily armored and contained three figures, Questar, Mid-Zei and Aries.  Questar and Mind-Zei sported different outfits than they did in their 1st Series figure assortment appearances.  Questar had a blue and red outfit instead of the black, silver and blue and Mind-Zei had a dark blue outfit instead of silver and light blue.  The Diplodocus had motorized walking action and its neck was attached in such a way that its head would sway from side to side as it walked.  The motorized walking action would later be removed and its name would be changed to Apatosaurus when it was re-released as part of the Smithsonian Institution line. ";
            d.FigImageUrl = @"/content/images/InfoPic-Diplodocus.jpg";
            d.ThumbImageUrl = @"/content/images/NavigationPic-Diplodocus.jpg";
            d.Categories.Add(cRepo.GetCategory("S1"));
            d.Categories.Add(cRepo.GetCategory("Val"));
            d.Riders.Add(new Rider { DinoBox = d, FigImageUrl = @"/content/images/FigurePic-Questar.jpg", Name = "Questar" });
            d.Riders.Add(new Rider { DinoBox = d, FigImageUrl = @"/content/images/FigurePic-Mind-Zei.jpg", Name = "Mind-Zei" });
            d.Riders.Add(new Rider { DinoBox = d, FigImageUrl = @"/content/images/FigurePic-Aries.jpg", Name = "Aries" });
            d.Weapons.Add("Ladder");
            d.Weapons.Add("Water Skin");
            d.Weapons.Add("Handgun");
            d.Weapons.Add("Rifle");
            d.Weapons.Add("Bandolier");
            d.Weapons.Add("AMP");
            dRepo.SaveDinosaur(d);

            d = new Dinosaur();
            d.Name = "Torosaurus";
            d.BoxImageUrl = @"/content/images/Torosaurus-Front-Small.jpg";
            d.Description = "The Torosaurus was the Dino-Riders’ answer to the Rulon Triceratops.  The Torosaurus was apparently released at the tail-end of the 1st Series.  If you notice, the Torosaurus was not included in the back of the small comic book that was included in the 1st Series toys but it did appear on the backs of the 1st, 2nd and Commando figure packs.  The Torosaurus had motorized walking action and its head would sway from side to side as it walked.  The Torosaurus was heavily armored and covered in a shield of individual plates that opened up to ambush unsuspecting foes when a button was pressed.  It also had a clear laser beam that would light up red when a button was pressed.  The Torosaurus had a starring role in one of the cartoon episodes and was packaged with Gunnur and Magnus.  The box art depicted a red and black paint scheme that looked a lot cooler than the brown and green production version.  Ultimately, this difference was minimized by the fact that the toy's color was barely noticeable when fully equipped. ";
            d.FigImageUrl = @"/content/images/InfoPic-Torosaurus.jpg";
            d.ThumbImageUrl = @"/content/images/NavigationPic-Torosaurus.jpg";
            d.Categories.Add(cRepo.GetCategory("S1"));
            d.Categories.Add(cRepo.GetCategory("Val"));
            d.Riders.Add(new Rider { DinoBox = d, FigImageUrl = @"/content/images/FigurePic-Gunnur.jpg", Name = "Gunnur" });
            d.Riders.Add(new Rider { DinoBox = d, FigImageUrl = @"/content/images/FigurePic-Magnus.jpg", Name = "Magnus" });
            d.Weapons.Add("Ladder");
            d.Weapons.Add("Water Skin");
            d.Weapons.Add("Handgun");
            d.Weapons.Add("Rifle");
            d.Weapons.Add("Bandolier");
            d.Weapons.Add("AMP");
            dRepo.SaveDinosaur(d);

            d = new Dinosaur();
            d.Name = "Deinonychus";
            d.BoxImageUrl = @"/content/images/Deinonychus-Front-Small.jpg";
            d.Description = "The Deinonychus had many appearances in the Dino-Riders cartoon and was apparently popular enough to have both a Rulon and Dino-Rider version.  The actual production piece varies slightly from the pre-production photo in that the pre-production photo showed a solid colored light brown dinosaur, whereas the production model had a darker brown color with dark stripes running down its back.  The only difference between this piece and the Rulon Deinonychus is that this piece had dark blue stripes and the Rulon version had dark brown stripes.  This difference was less noticeable once the weapons were put on.  The Dino-Riders Deinonychus came with Yungstar, who had a different outfit that in his Series 1 appearance.";
            d.FigImageUrl = @"/content/images/InfoPic-Deinonychus-DR.jpg";
            d.ThumbImageUrl = @"/content/images/NavigationPic-Deinonychus-DR.jpg";
            d.Categories.Add(cRepo.GetCategory("S1"));
            d.Categories.Add(cRepo.GetCategory("Val"));
            d.Riders.Add(new Rider { DinoBox = d, FigImageUrl = @"/content/images/FigurePic-Sky.jpg", Name = "Sky" });
            d.Weapons.Add("Ladder");
            d.Weapons.Add("Water Skin");
            d.Weapons.Add("Handgun");
            d.Weapons.Add("Rifle");
            d.Weapons.Add("Bandolier");
            d.Weapons.Add("AMP");
            dRepo.SaveDinosaur(d);

            d = new Dinosaur();
            d.Name = "Styracosaurus";
            d.BoxImageUrl = @"/content/images/Styracosaurus-Front-Small.jpg";
            d.Description = "The Styracosaurus had an identical body to the Monoclonius and Chasmosaurus except that it had a different color and a different head sculpt.  The tail and the head were connected in such a way that if you moved the tail in one direction, the head would swing in the other direction.  The Styracosaurus included Turret, a regular character in the cartoon.";
            d.FigImageUrl = @"/content/images/InfoPic-Styracosaurus.jpg";
            d.ThumbImageUrl = @"/content/images/NavigationPic-Styracosaurus.jpg";
            d.Categories.Add(cRepo.GetCategory("S1"));
            d.Categories.Add(cRepo.GetCategory("Val"));
            d.Riders.Add(new Rider { DinoBox = d, FigImageUrl = @"/content/images/FigurePic-Turret.jpg", Name = "Turret" });
            d.Weapons.Add("Ladder");
            d.Weapons.Add("Water Skin");
            d.Weapons.Add("Handgun");
            d.Weapons.Add("Rifle");
            d.Weapons.Add("Bandolier");
            d.Weapons.Add("AMP");
            dRepo.SaveDinosaur(d);

            d = new Dinosaur();
            d.Name = "Quetzalcoatlus";
            d.BoxImageUrl = @"/content/images/Quetzalcoatlus-DR-Front-Small.jpg";
            d.Description = "The Quetzalcoatlus was the Dino-Riders' answer to the Rulon Pteranodon.  Aside from the different head and color, the Quetzalcoatlus was identical to the Pteranodon.  The Quetzalcoatlus had a button over its tail that would flip its wings up and down when pressed.  Although the actual toy had a head crest, the box art depicted it without one.  The Quetzalcoatlus would finally appear without its head crest when it was re-released as part of the the Smithsonian Institution line and it was renamed Pterodactylus.  Finding this piece without the head crest is somewhat difficult and thus potentially more collectible than the standard Dino-Rider version.";
            d.FigImageUrl = @"/content/images/InfoPic-Quetzalcoatlus-DR.jpg";
            d.ThumbImageUrl = @"/content/images/NavigationPic-Quetzalcoatlus-DR.jpg";
            d.Categories.Add(cRepo.GetCategory("S1"));
            d.Categories.Add(cRepo.GetCategory("Val"));
            d.Riders.Add(new Rider { DinoBox = d, FigImageUrl = @"/content/images/FigurePic-Yungstar.jpg", Name = "Yungstar" });
            d.Weapons.Add("Ladder");
            d.Weapons.Add("Water Skin");
            d.Weapons.Add("Handgun");
            d.Weapons.Add("Rifle");
            d.Weapons.Add("Bandolier");
            d.Weapons.Add("AMP");
            dRepo.SaveDinosaur(d);

            d = new Dinosaur();
            d.Name = "Pterodactyl";
            d.BoxImageUrl = @"/content/images/Pterodactyl-Front-Small.jpg";
            d.Description = "The Pterodactyl was one of the smaller pieces in the Dino-Riders line.  It was a very simple piece, including only a small glider mechanism with two small rockets.  The Pterodactyl would later see some variations as the line progressed.  Most notable was the completely re-done paint job that was included in the Dino-Riders fan club package.  Those fortunate enough to send away for the Dino-Riders membership got treated to an all-new brown and orange paint job as opposed to the standard light gray version.  The Pterodactyl would also undergo a name change when it was re-released in the Smithsonian Institution and Cadillacs and Dinosaurs lines.";
            d.FigImageUrl = @"/content/images/InfoPic-Pterodactyl.jpg";
            d.ThumbImageUrl = @"/content/images/NavigationPic-Pterodactyl.jpg";
            d.Categories.Add(cRepo.GetCategory("S1"));
            d.Categories.Add(cRepo.GetCategory("Val"));
            d.Riders.Add(new Rider { DinoBox = d, FigImageUrl = @"/content/images/FigurePic-Llahd.jpg", Name = "Llahd" });
            d.Weapons.Add("Ladder");
            d.Weapons.Add("Water Skin");
            d.Weapons.Add("Handgun");
            d.Weapons.Add("Rifle");
            d.Weapons.Add("Bandolier");
            d.Weapons.Add("AMP");
            dRepo.SaveDinosaur(d);

            d = new Dinosaur();
            d.Name = "Brontosaurus";
            d.BoxImageUrl = @"/content/images/Brontosaurus-Front-Small.jpg";
            d.Description = "The Brontosaurus was by far the biggest Dino-Rider toy made and for that matter, one of the biggest toys ever made, dinosaur.  It retailed for $80 and was about 3 feet long. Despite its huge size, it was highly detailed and well made.  The Brontosaurs included 3 Rhamphorynchus dinosaurs that served as aerial bombers.  It also had a crane with 3 different attachments and a land mine chute.  The head and neck of the Brontosaurus could be moved up and down.  In an effort to keep costs down and make the Brontosaurus (somewhat) affordable, Tyco apparently had to scrap a number of features that it had originally planned, including an entirely different weapons scheme, motorized walking action and 4 figures instead of 3.  Click the 'Variants' button below to find out more about the alternatives that were planned.";
            d.FigImageUrl = @"/content/images/InfoPic-Brontosaurus.jpg";
            d.ThumbImageUrl = @"/content/images/NavigationPic-Brontosaurus.jpg";
            d.Categories.Add(cRepo.GetCategory("S2"));
            d.Categories.Add(cRepo.GetCategory("Val"));
            d.Riders.Add(new Rider { DinoBox = d, FigImageUrl = @"/content/images/FigurePic-Serena.jpg", Name = "Serena" });
            d.Riders.Add(new Rider { DinoBox = d, FigImageUrl = @"/content/images/FigurePic-Ayce.jpg", Name = "Ayce" });
            d.Riders.Add(new Rider { DinoBox = d, FigImageUrl = @"/content/images/FigurePic-Ion.jpg", Name = "Ion" });
            d.Weapons.Add("Psyche Blade");
            d.Weapons.Add("Chest Shield");
            d.Weapons.Add("Double Barrel Rifle");
            d.Weapons.Add("Infrared Night Scope");
            d.Weapons.Add("Rifle Harness");
            d.Weapons.Add("AMP");
            dRepo.SaveDinosaur(d);

            d = new Dinosaur();
            d.Name = "Dimetrodon";
            d.BoxImageUrl = @"/content/images/Dimetrodon-Front-Small.jpg";
            d.Description = "The Dimetrodon was another toy that was highly detailed and excellently sculpted.  The armor was supposed to be designed such that one side of the dinosaur's sail would look like nothing was there but on the other side there would be two hidden lasers that would come down and ambush an unsuspecting foe.  To see what I mean, check out the episode, “Revenge of the Rulons,” a.k.a. “The Adventure Continues.”  Unfortunately, the incognito feature didn’t translate too well for the toy because despite Tyco’s best efforts to hide the artillery, you could still see the brace for it on the bare side of the sail.  The Dimetrodon had a small button on its tail that would open up its mouth when pressed.";
            d.FigImageUrl = @"/content/images/InfoPic-Dimetrodon.jpg";
            d.ThumbImageUrl = @"/content/images/NavigationPic-Dimetrodon.jpg";
            d.Categories.Add(cRepo.GetCategory("S2"));
            d.Categories.Add(cRepo.GetCategory("Val"));
            d.Riders.Add(new Rider { DinoBox = d, FigImageUrl = @"/content/images/FigurePic-Shado.jpg", Name = "Shado" });
            d.Weapons.Add("Psyche Blade");
            d.Weapons.Add("Chest Shield");
            d.Weapons.Add("Double Barrel Rifle");
            d.Weapons.Add("Infrared Night Scope");
            d.Weapons.Add("Rifle Harness");
            d.Weapons.Add("AMP");
            dRepo.SaveDinosaur(d);

            d = new Dinosaur();
            d.Name = "Pachycephalosaurus";
            d.BoxImageUrl = @"/content/images/Pachycephalosaurus-Front-Small.jpg";
            d.Description = "The Pachycephalosaurus had a mechanism that allowed its body to be thrusted from a horizontal position with its tail in the air to a vertical position with its tail on the ground.  The seat could also be adjusted up and down in order to better match the dinosaur's body position.  Except for a somewhat odd-looking tail, which appeared to be a little flattened and wide, the Pachycephalosaurus was highly detailed and excellently sculpted.  The piece also included Tagg, a regular Dino-Rider cartoon character that was forced to make his long overdue toy appearance in the 2nd Series.";
            d.FigImageUrl = @"/content/images/InfoPic-Pachycephalosaurus.jpg";
            d.ThumbImageUrl = @"/content/images/NavigationPic-Pachycephalosaurus.jpg";
            d.Categories.Add(cRepo.GetCategory("S2"));
            d.Categories.Add(cRepo.GetCategory("Val"));
            d.Riders.Add(new Rider { DinoBox = d, FigImageUrl = @"/content/images/FigurePic-Tagg.jpg", Name = "Tagg" });
            d.Weapons.Add("Psyche Blade");
            d.Weapons.Add("Chest Shield");
            d.Weapons.Add("Double Barrel Rifle");
            d.Weapons.Add("Infrared Night Scope");
            d.Weapons.Add("Rifle Harness");
            d.Weapons.Add("AMP");
            dRepo.SaveDinosaur(d);

            d = new Dinosaur();
            d.Name = "Struthiomimus";
            d.BoxImageUrl = @"/content/images/Struthiomimus-Front-Small.jpg";
            d.Description = "The Struthiomimus piece looked more like a statue than an action figure.  The sculpt was excellent and very accurate, but the piece did not move at all.  It was equipped with a small seat and a small carrying pod for holding extra gun tips (anybody who is familiar with the Dino-Riders toys knows you can never have too many gun tips).";
            d.FigImageUrl = @"/content/images/InfoPic-Struthiomimus.jpg";
            d.ThumbImageUrl = @"/content/images/NavigationPic-Struthiomimus.jpg";
            d.Categories.Add(cRepo.GetCategory("S2"));
            d.Categories.Add(cRepo.GetCategory("Val"));
            d.Riders.Add(new Rider { DinoBox = d, FigImageUrl = @"/content/images/FigurePic-Nimbus.jpg", Name = "Nimbus" });
            d.Weapons.Add("Psyche Blade");
            d.Weapons.Add("Chest Shield");
            d.Weapons.Add("Double Barrel Rifle");
            d.Weapons.Add("Infrared Night Scope");
            d.Weapons.Add("Rifle Harness");
            d.Weapons.Add("AMP");
            dRepo.SaveDinosaur(d);

            d = new Dinosaur();
            d.Name = "Protoceratops";
            d.BoxImageUrl = @"/content/images/Protoceratops-Front-Small.jpg";
            d.Description = "Another one of the smallest toys in the line, the Protoceratops was a very cool looking toy that actually.  Unlike the other small toys such as Ankylosaurus and the Placerias, the Protoceratops had a harness for its rider, Kanon.  Equipped with a night vision scope, the Protoceratops served the Dino-Riders force as a moving reconnaissance unit.  The head of the Protoceratops was attached to its body via a ball joint that allowed its head to swivel in various directions.";
            d.FigImageUrl = @"/content/images/InfoPic-Protoceratops.jpg";
            d.ThumbImageUrl = @"/content/images/NavigationPic-Protoceratops.jpg";
            d.Categories.Add(cRepo.GetCategory("S2"));
            d.Categories.Add(cRepo.GetCategory("Val"));
            d.Riders.Add(new Rider { DinoBox = d, FigImageUrl = @"/content/images/FigurePic-Kanon.jpg", Name = "Kanon" });
            d.Weapons.Add("Psyche Blade");
            d.Weapons.Add("Chest Shield");
            d.Weapons.Add("Double Barrel Rifle");
            d.Weapons.Add("Infrared Night Scope");
            d.Weapons.Add("Rifle Harness");
            d.Weapons.Add("AMP");
            dRepo.SaveDinosaur(d);

            d = new Dinosaur();
            d.Name = "Stegosaurus";
            d.BoxImageUrl = @"/content/images/Stegosaurus-Front-Small.jpg";
            d.Description = "As one of the most popular dinosaurs of all time, it is surprising that Tyco waited until the 2nd Series to release the Stegosaurus.  The Stegosaurus was heavily armored and played a starring role in the episode, “Revenge of the Rulons,” a.k.a. “The Adventure Continues.”  The Stegosaurus had motorized walking action, a feature which would later be removed when it was re-released as part of the Smithsonian Institution line.  The Stegosaurus had a red and black color scheme that looked very similar to the paint scheme on the pre-production Torosaurus.";
            d.FigImageUrl = @"/content/images/InfoPic-Stegosaurus.jpg";
            d.ThumbImageUrl = @"/content/images/NavigationPic-Stegosaurus.jpg";
            d.Categories.Add(cRepo.GetCategory("S2"));
            d.Categories.Add(cRepo.GetCategory("Val"));
            d.Riders.Add(new Rider { DinoBox = d, FigImageUrl = @"/content/images/FigurePic-Tark.jpg", Name = "Tark" });
            d.Riders.Add(new Rider { DinoBox = d, FigImageUrl = @"/content/images/FigurePic-Vega.jpg", Name = "Vega" });
            d.Weapons.Add("Psyche Blade");
            d.Weapons.Add("Chest Shield");
            d.Weapons.Add("Double Barrel Rifle");
            d.Weapons.Add("Infrared Night Scope");
            d.Weapons.Add("Rifle Harness");
            d.Weapons.Add("AMP");
            dRepo.SaveDinosaur(d);

            d = new Dinosaur();
            d.Name = "Edmontonia";
            d.BoxImageUrl = @"/content/images/Edmontonia-Front-Small.jpg";
            d.Description = "The Edmontonia was an unusual looking piece, but very cool nonetheless.  The armor was comprised of a large metallic shell that would open up to reveal a propeller-like whip once a button was pressed.  The piece also included a long zip cord in the back of the armor that would make the whip spin around when pulled.";
            d.FigImageUrl = @"/content/images/InfoPic-Edmontonia.jpg";
            d.ThumbImageUrl = @"/content/images/NavigationPic-Edmontonia.jpg";
            d.Categories.Add(cRepo.GetCategory("S2"));
            d.Categories.Add(cRepo.GetCategory("Val"));
            d.Riders.Add(new Rider { DinoBox = d, FigImageUrl = @"/content/images/FigurePic-Axis.jpg", Name = "Axis" });
            d.Weapons.Add("Psyche Blade");
            d.Weapons.Add("Chest Shield");
            d.Weapons.Add("Double Barrel Rifle");
            d.Weapons.Add("Infrared Night Scope");
            d.Weapons.Add("Rifle Harness");
            d.Weapons.Add("AMP");
            dRepo.SaveDinosaur(d);

            d = new Dinosaur();
            d.Name = "Kentrosaurus";
            d.BoxImageUrl = @"/content/images/Kentrosaurus-Front-Small.jpg";
            d.Description = "The Kentrosaurus was another unconventional dinosaur piece because not many people have heard of this dinosaur, aside from dinosaur fans in general.  The Kentrosaurus came with Krok, Krulos’ near second-in-command.  The dinosaur was heavily armored with two rows of artillery on each side.  As an interesting collector's note, the French version of the Kentrosaurus came with a belly band and a separate instruction insert that showed how to equip it on the toy.  The U.S. version did not come with a belly band or an insert.";
            d.FigImageUrl = @"/content/images/InfoPic-Kentrosaurus.jpg";
            d.ThumbImageUrl = @"/content/images/NavigationPic-Kentrosaurus.jpg";
            d.Categories.Add(cRepo.GetCategory("S2"));
            d.Categories.Add(cRepo.GetCategory("Rul"));
            d.Riders.Add(new Rider { DinoBox = d, FigImageUrl = @"/content/images/FigurePic-Krok.jpg", Name = "Krok" });
            d.Weapons.Add("Neck Clip");
            d.Weapons.Add("AMP Detector");
            d.Weapons.Add("Boomerang");
            d.Weapons.Add("Blade Mace");
            d.Weapons.Add("Rifle");
            d.Weapons.Add("Whip");
            dRepo.SaveDinosaur(d);

            d = new Dinosaur();
            d.Name = "Saurolophus";
            d.BoxImageUrl = @"/content/images/Saurolophus-Front-Small.jpg";
            d.Description = "The Saurolophus had a mechanism which allowed it to be thrusted from a horizontal position with its tail in the air to a vertical position with its tail on the ground.  The Saurolophus was excellently sculpted and highly detailed.  The Saurolophus included a hidden rock bunker which housed a Rulon and was used to ambush unsuspecting foes.  When a button was pressed, the top of the bunker opened up and released a laser cannon.  The Saurolophus would later have its name changed to Prosaurolophus when it was re-released as part of the Smithsonian Institution line.";
            d.FigImageUrl = @"/content/images/InfoPic-Saurolophus.jpg";
            d.ThumbImageUrl = @"/content/images/NavigationPic-Saurolophus.jpg";
            d.Categories.Add(cRepo.GetCategory("S2"));
            d.Categories.Add(cRepo.GetCategory("Rul"));
            d.Riders.Add(new Rider { DinoBox = d, FigImageUrl = @"/content/images/FigurePic-Lokus.jpg", Name = "Lokus" });
            d.Weapons.Add("Neck Clip");
            d.Weapons.Add("AMP Detector");
            d.Weapons.Add("Boomerang");
            d.Weapons.Add("Blade Mace");
            d.Weapons.Add("Rifle");
            d.Weapons.Add("Whip");
            dRepo.SaveDinosaur(d);

            d = new Dinosaur();
            d.Name = "Placerias";
            d.BoxImageUrl = @"/content/images/Placerias-Front-Small.jpg";
            d.Description = "The Placerias was one of the smallest toys in the entire line.  Like the Ankylosaurus, the Placerias did not have a seat for its rider, Skate.  The Placerias had a large grappling hook that was supposed to be used for catching other dinosaurs.  The real Placerias is not very popular among non-dinosaur fans but for those in the know, the sculpt was very well done and it was refreshing to see that Tyco was willing to go beyond simply releasing the popular dinosaurs and actually research some of the lesser known ones as well.";
            d.FigImageUrl = @"/content/images/InfoPic-Placerias.jpg";
            d.ThumbImageUrl = @"/content/images/NavigationPic-Placerias.jpg";
            d.Categories.Add(cRepo.GetCategory("S2"));
            d.Categories.Add(cRepo.GetCategory("Rul"));
            d.Riders.Add(new Rider { DinoBox = d, FigImageUrl = @"/content/images/FigurePic-Skate.jpg", Name = "Skate" });
            d.Weapons.Add("Neck Clip");
            d.Weapons.Add("AMP Detector");
            d.Weapons.Add("Boomerang");
            d.Weapons.Add("Blade Mace");
            d.Weapons.Add("Rifle");
            d.Weapons.Add("Whip");
            dRepo.SaveDinosaur(d);

            d = new Dinosaur();
            d.Name = "Pachyrhinosaurus";
            d.BoxImageUrl = @"/content/images/Pachyrhinosaurus-Front-Small.jpg";
            d.Description = "Like the other 3rd Series dinosaurs, the Pachyrhinosaurus is one of the rarest pieces in the entire line, having only a limited production run, predominately in the western United States and Europe.  The Pachyrhinosaurus had the exact same body mold as the Triceratops and Torosaurus but with a different head sculpt and color scheme. The Pachyrhinosaurus also had motorized walking action and its head swayed from side to side as it walked.  Despite its minimal equipment, the Pachyrhinosaurus is a highly sought after toy.";
            d.FigImageUrl = @"/content/images/InfoPic-Pachyrhinosaurus.jpg";
            d.ThumbImageUrl = @"/content/images/NavigationPic-Pachyrhinosaurus.jpg";
            d.Categories.Add(cRepo.GetCategory("S3"));
            d.Categories.Add(cRepo.GetCategory("Val"));
            d.Riders.Add(new Rider { DinoBox = d, FigImageUrl = @"/content/images/FigurePic-Atlas.jpg", Name = "Atlas" });
            d.Weapons.Add("Psyche Blade");
            d.Weapons.Add("Chest Shield");
            d.Weapons.Add("Double Barrel Rifle");
            d.Weapons.Add("Infrared Night Scope");
            d.Weapons.Add("Rifle Harness");
            d.Weapons.Add("AMP");
            dRepo.SaveDinosaur(d);

            d = new Dinosaur();
            d.Name = "Chasmosaurus";
            d.BoxImageUrl = @"/content/images/Chasmosaurus-Front-Small.jpg";
            d.Description = "The Chasmosaurus is one of the rarest of all the Dino-Riders pieces.  Like the other 3rd Series dinosaurs, this piece only had a very limited release, predominately in the western United States and Europe.  The Chasmosaurus uses the exact same body as the Styracosaurus and Monoclonius.  However, the piece had a new head mold and the paint scheme was much more colorful and represented a significant departure from previous paint schemes in the line.  The tail and the head were connected in such a way that if you moved the tail in one direction, the head would swing in the other direction.";
            d.FigImageUrl = @"/content/images/InfoPic-Chasmosaurus.jpg";
            d.ThumbImageUrl = @"/content/images/NavigationPic-Chasmosaurus.jpg";
            d.Categories.Add(cRepo.GetCategory("S3"));
            d.Categories.Add(cRepo.GetCategory("Val"));
            d.Riders.Add(new Rider { DinoBox = d, FigImageUrl = @"/content/images/FigurePic-Llava.jpg", Name = "Llava" });
            d.Weapons.Add("Psyche Blade");
            d.Weapons.Add("Chest Shield");
            d.Weapons.Add("Double Barrel Rifle");
            d.Weapons.Add("Infrared Night Scope");
            d.Weapons.Add("Rifle Harness");
            d.Weapons.Add("AMP");
            dRepo.SaveDinosaur(d);

            d = new Dinosaur();
            d.Name = "Quetzalcoatlus";
            d.BoxImageUrl = @"/content/images/Quetlzalcoatlus-Rulon-Front-Small.jpg";
            d.Description = "The Rulon Quetzalcoatlus is one of the rarest of all the Dino-Riders pieces.  Like the other 3rd Series dinosaurs, this piece only had a very limited release, predominately in the western United States and Europe.  The Quetzalcoatlus had a button over its tail that caused its wings to flap up and down when pressed.  This piece used the exact same mold as the original Quetzalcoatlus, except for the entirely different black & yellow polka dot paint job.";
            d.FigImageUrl = @"/content/images/InfoPic-Quetzalcoatlus-Rulon.jpg";
            d.ThumbImageUrl = @"/content/images/NavigationPic-Quetzalcoatlus-Rulon.jpg";
            d.Categories.Add(cRepo.GetCategory("S3"));
            d.Categories.Add(cRepo.GetCategory("Rul"));
            d.Riders.Add(new Rider { DinoBox = d, FigImageUrl = @"/content/images/FigurePic-Algar.jpg", Name = "Algar" });
            d.Weapons.Add("Neck Clip");
            d.Weapons.Add("AMP Detector");
            d.Weapons.Add("Boomerang");
            d.Weapons.Add("Blade Mace");
            d.Weapons.Add("Rifle");
            d.Weapons.Add("Whip");
            dRepo.SaveDinosaur(d);

            d = new Dinosaur();
            d.Name = "Wooly Mammoth";
            d.BoxImageUrl = @"/content/images/Wooly-Mammoth-Front-Small.jpg";
            d.Description = "The Wooly Mammoth was part of the Dino-Riders Ice Age line.  It was a very large piece that had motorized walking action, a feature that would later be removed when the toy was re-released as part of the Smithsonian Institution line.  The Wooly Mammoth came with the Neanderthal, Grom.  This doesn’t seem to be the same Grom character that appeared in the Ice-Age Adventure cartoon episode because the character looked a lot different and in the cartoon, he was actually a bad guy, so it really wouldn’t make sense for him to be joining the Dino-Riders army.";
            d.FigImageUrl = @"/content/images/InfoPic-WoolyMammoth.jpg";
            d.ThumbImageUrl = @"/content/images/NavigationPic-WoolyMammoth.jpg";
            d.Categories.Add(cRepo.GetCategory("ICE"));
            d.Categories.Add(cRepo.GetCategory("Val"));
            d.Riders.Add(new Rider { DinoBox = d, FigImageUrl = @"/content/images/FigurePic-Grom.jpg", Name = "Grom" });
            d.Weapons.Add("Psyche Blade");
            d.Weapons.Add("Chest Shield");
            d.Weapons.Add("Double Barrel Rifle");
            d.Weapons.Add("Infrared Night Scope");
            d.Weapons.Add("Rifle Harness");
            d.Weapons.Add("AMP");
            dRepo.SaveDinosaur(d);

            d = new Dinosaur();
            d.Name = "Giant Ground Sloth";
            d.BoxImageUrl = @"/content/images/Giant-Ground-Sloth-Front-Small2.jpg";
            d.Description = "The Giant Ground Sloth was part of the Dino-Riders Ice Age line and like the other Ice Age pieces, it was highly detailed and fit right in with the rest of the Dino-Riders line.  The Giant Ground Sloth had a moveable head and its body could be positioned either standing up or on all fours.";
            d.FigImageUrl = @"/content/images/InfoPic-GiantGroundSloth.jpg";
            d.ThumbImageUrl = @"/content/images/NavigationPic-GiantGroundSloth.jpg";
            d.Categories.Add(cRepo.GetCategory("ICE"));
            d.Categories.Add(cRepo.GetCategory("Val"));
            d.Riders.Add(new Rider { DinoBox = d, FigImageUrl = @"/content/images/FigurePic-Ulk.jpg", Name = "Ulk" });
            d.Weapons.Add("Psyche Blade");
            d.Weapons.Add("Chest Shield");
            d.Weapons.Add("Double Barrel Rifle");
            d.Weapons.Add("Infrared Night Scope");
            d.Weapons.Add("Rifle Harness");
            d.Weapons.Add("AMP");
            dRepo.SaveDinosaur(d);

            d = new Dinosaur();
            d.Name = "Killer Wart Hog";
            d.BoxImageUrl = @"/content/images/Killer-Wart-Hog-Front-Small.jpg";
            d.Description = "The Killer Wart Hog was part of the Dino-Riders Ice Age line and like the other Ice Age pieces, the Killer Wart Hog was highly detailed and fit right in with the rest of the line.";
            d.FigImageUrl = @"/content/images/InfoPic-KillerWartHog.jpg";
            d.ThumbImageUrl = @"/content/images/NavigationPic-KillerWartHog.jpg";
            d.Categories.Add(cRepo.GetCategory("ICE"));
            d.Categories.Add(cRepo.GetCategory("Val"));
            d.Riders.Add(new Rider { DinoBox = d, FigImageUrl = @"/content/images/FigurePic-Zar.jpg", Name = "Zar" });
            d.Weapons.Add("Psyche Blade");
            d.Weapons.Add("Chest Shield");
            d.Weapons.Add("Double Barrel Rifle");
            d.Weapons.Add("Infrared Night Scope");
            d.Weapons.Add("Rifle Harness");
            d.Weapons.Add("AMP");
            dRepo.SaveDinosaur(d);

            d = new Dinosaur();
            d.Name = "Sabre Tooth Tiger";
            d.BoxImageUrl = @"/content/images/Sabre-Tooth-Tiger-Front-Small.jpg";
            d.Description = "The Sabre Tooth Tiger was part of the Dino-Riders Ice Age line and it came packaged with Kub, a character that appeared in the Ice Age Adventure cartoon episode.  The cartoon character had long hair and really didn’t look anything like the Neanderthal figures that Tyco released.  In fact, all of the Neanderthal figures that Tyco released all looked pretty much the same and another thing to note is that Tyco made them so that none of them could stand erect.  The Sabre Tooth Tiger is a relatively simple piece but highly detailed nonetheless.";
            d.FigImageUrl = @"/content/images/InfoPic-SabreToothTiger.jpg";
            d.ThumbImageUrl = @"/content/images/NavigationPic-SabreToothTiger.jpg";
            d.Categories.Add(cRepo.GetCategory("ICE"));
            d.Categories.Add(cRepo.GetCategory("Val"));
            d.Riders.Add(new Rider { DinoBox = d, FigImageUrl = @"/content/images/FigurePic-Kub.jpg", Name = "Kub" });
            d.Weapons.Add("Psyche Blade");
            d.Weapons.Add("Chest Shield");
            d.Weapons.Add("Double Barrel Rifle");
            d.Weapons.Add("Infrared Night Scope");
            d.Weapons.Add("Rifle Harness");
            d.Weapons.Add("AMP");
            dRepo.SaveDinosaur(d);
        }

        private void Deleting_Adding_and_Changing_with_a_Repo()
        {
            log4net.Config.XmlConfigurator.Configure();

            var dRepo = new DinosaurRepository();
            var cRepo = new CategoryRepository();

            Dinosaur d;

            Console.WriteLine("****** DELETE START ********");
            d = dRepo.GetDinosaurByName("AwesomeSaurus Rex");
            if (d != null) dRepo.DeleteDinosaur(d);
            Console.WriteLine("****** DELETE END ********");

            Console.WriteLine("****** ADD START ********");
            d = new Dinosaur();
            d.Name = "AwesomeSaurus Rex";
            d.Categories.Add(cRepo.GetCategory("S3"));
            d.Categories.Add(cRepo.GetCategory("Rul"));
            d.Riders.Add(new Rider { DinoBox = d, FigImageUrl = @"/content/images/InfoPic-Rusty.jpg", Name = "Rusty" });
            dRepo.SaveDinosaur(d);
            Console.WriteLine("****** ADD END ********");


            Console.WriteLine("****** UPDATE START ********");
            var dUp = dRepo.GetDinosaurByName("AwesomeSaurus Rex");
            dUp.Description = "The most awesome dinosaur in the universe!";
            dUp.BoxImageUrl = @"/content/images/AwesomeSaurus-Front-Small.png";
            dUp.FigImageUrl = @"/content/images/InfoPic-Pterodactyl.jpg";
            dUp.ThumbImageUrl = @"/content/images/NavigationPic-AwesomeSaurus";
            d.Weapons.Add("None"); 
            dRepo.SaveDinosaur(dUp);
            Console.WriteLine("****** UPDATE END ********");
            dRepo.Dispose();
        }
        #endregion 

    }
}
