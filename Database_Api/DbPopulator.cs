using System;
using System.Collections.Generic;
using System.Linq;

namespace Database_Api
{
    public class DbPopulator
    {
        private CircusContext context;

        public DbPopulator()
        {
            context = new CircusContext();
        }
        
        public List<Tamer> GetAllTamers()
        {
            IEnumerable<Tamer> tamers = context.Tamers.AsEnumerable();
            IEnumerable<SpiritAnimal> spiritAnimals = context.SpiritAnimals.AsEnumerable();
            IEnumerable<KungfuMastery> kungfuMasteries = context.KungfuMasteries.AsEnumerable();

            IEnumerable<Tamer> dataTamers = from t in tamers
                                            join sa in spiritAnimals on t.SpiritAnimal.SpiritAnimalId equals sa.SpiritAnimalId
                                            join km in kungfuMasteries on t.KungfuMastery.KungfuMasteryId equals km.KungfuMasteryId
                                            orderby t.TamerId
                                            select t;
            return dataTamers.ToList();
        }

        public List<SpiritAnimal> GetAllAnimals()
        {
            IEnumerable<SpiritAnimal> animals = context.SpiritAnimals.AsEnumerable();
            
            return animals.ToList();
        }

        public List<KungfuMastery> GetAllKungfuMasteries()
        {
            IEnumerable<KungfuMastery> kungfuMasteries = context.KungfuMasteries.AsEnumerable();

            return kungfuMasteries.ToList();
        }

        public void Populate()
        {
            List<Tamer> tamers = new List<Tamer>();
            
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
            tamers.Add(kungFury);

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
            tamers.Add(hackerMan);

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
            tamers.Add(hitler);

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
            tamers.Add(katana);

            context.AddRange(tamers);
            context.SaveChanges(); 
        }
    }
}
