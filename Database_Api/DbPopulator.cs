using System;
using System.Collections.Generic;
using System.Text;

namespace Database_Api
{
    public class DbPopulator
    {
        public static List<Tamer> Tamers = new List<Tamer>();

        public static void Populate()
        {
            using (var context = new CircusContext())
            {
                context.Database.EnsureDeleted();
                context.Database.EnsureCreated();

                Tamer kungFury = new Tamer
                {
                    Name = "Kung Fury",
                    Image = "https://vignette.wikia.nocookie.net/vsbattles/images/e/e8/Kf.jpg/revision/latest/scale-to-width-down/340?cb=20161027063513",
                    Quote = "I'm a cop, and damn good at my job",
                    SpiritAnimal = new SpiritAnimal
                    {
                        Claws = false,
                        Image = "https://i.pinimg.com/236x/56/ce/18/56ce18eca0c119b2ff5674af715b1a57--kung-fury-wilde.jpg",
                        Teeth = true,
                        Name = "Mr. Cobra"
                    },
                    KungfuMastery = new KungfuMastery { Agility = 10, Chosenness = 10, Hacking = 1, KillerInstinct = 10 }
                };
                Tamers.Add(kungFury);

                Tamer hackerMan = new Tamer
                {
                    Name = "Hackerman",
                    Image = "https://i.pinimg.com/originals/d7/48/d6/d748d627ab913303b42224d91980ace3.jpg",
                    Quote = "With the right computer algorithms I can hack you back in time",
                    SpiritAnimal = new SpiritAnimal
                    {
                        Claws = false,
                        Image = "https://pm1.narvii.com/6514/866c29584784cf94263eff9c95574de7b2cf10db_00.jpg",
                        Teeth = true,
                        Name = "Triceracop"
                    },
                    KungfuMastery = new KungfuMastery { Agility = 8, Chosenness = 3, Hacking = 10, KillerInstinct = 1 }
                };
                Tamers.Add(hackerMan);

                Tamer hitler = new Tamer
                {
                    Name = "Hitler",
                    Image = "https://cdn-www.konbini.com/fr/files/2015/05/Kung-Fury.jpg",
                    Quote = "Is this ze police?.. Fuck you!",
                    SpiritAnimal = new SpiritAnimal
                    {
                        Claws = true,
                        Image = "http://4.bp.blogspot.com/-cor5EnU3ipo/VY7sDxYVU7I/AAAAAAAAXcY/Ph7bsXGyXRI/s640/flying%2Bnazi%2Bphoenix-b.png",
                        Teeth = false,
                        Name = "Flying Nazi Phoenix"
                    },
                    KungfuMastery = new KungfuMastery { Agility = 9, Chosenness = 9, Hacking = 1, KillerInstinct = 10 }
                };
                Tamers.Add(hitler);

                Tamer katana = new Tamer
                {
                    Name = "Katana",
                    Image = "https://i.pinimg.com/originals/66/9f/95/669f957543b3e680e8f0e98756f7b9c1.jpg",
                    Quote = "So...anyway, Thor, um, this is Kung Fury. He's a cop from the future",
                    SpiritAnimal = new SpiritAnimal
                    {
                        Claws = true,
                        Image = "https://i.ytimg.com/vi/y5ibJ9UOGPA/maxresdefault.jpg",
                        Teeth = true,
                        Name = "Tyrannosaur"
                    },
                    KungfuMastery = new KungfuMastery { Agility = 7, Chosenness = 4, Hacking = 1, KillerInstinct = 8 }
                };
                Tamers.Add(katana);

                context.AddRange(Tamers);
                context.SaveChanges();
            }
        }
    }
}
