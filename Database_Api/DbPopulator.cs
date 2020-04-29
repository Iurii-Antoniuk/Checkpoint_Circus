using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Database_Api
{
    public class DbPopulator
    {
        private CircusContext context;

        public DbPopulator()
        {
            context = new CircusContext();
        }
        
        public async Task<List<Tamer>> GetAllTamersAsync()
        {
            IEnumerable<Tamer> tamers = await context.Tamers.ToListAsync();
            IEnumerable<SpiritAnimal> spiritAnimals = await context.SpiritAnimals.ToListAsync();
            IEnumerable<KungfuMastery> kungfuMasteries = await context.KungfuMasteries.ToListAsync();

            IEnumerable<Tamer> dataTamers = from t in tamers
                                            join sa in spiritAnimals on t.SpiritAnimal.SpiritAnimalId equals sa.SpiritAnimalId
                                            join km in kungfuMasteries on t.KungfuMastery.KungfuMasteryId equals km.KungfuMasteryId
                                            orderby t.TamerId
                                            select t;
            return dataTamers.ToList();
        }

        public async Task<List<SpiritAnimal>> GetAllAnimalsAsync()
        {
            return await context.SpiritAnimals.ToListAsync();
        }

        public void SaveFeedback(Feedback feedback)
        {
            context.Add(feedback);
            context.SaveChanges();
        }

        public List<Feedback> GetAllFeedbacks()
        {
            IEnumerable<Feedback> feedbacks = context.Feedbacks.AsEnumerable();

            return feedbacks.ToList();
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
                Image = "/Images/KungFury.jpg",
                Quote = "I'm a cop, and damn good at my job",
                SpiritAnimal = new SpiritAnimal
                {
                    Claws = false,
                    Image = "/Images/Cobra.jpg",
                    Teeth = true,
                    Name = "Mr. Cobra"
                },
                KungfuMastery = new KungfuMastery { Agility = 10, Chosenness = 10, Hacking = 1, KillerInstinct = 10 }
            };
            tamers.Add(kungFury);

            Tamer hackerMan = new Tamer
            {
                Name = "Hackerman",
                Image = "/Images/Hackerman.jpg",
                Quote = "With the right computer algorithms I can hack you back in time",
                SpiritAnimal = new SpiritAnimal
                {
                    Claws = false,
                    Image = "/Images/Triceracop.jpg",
                    Teeth = true,
                    Name = "Triceracop"
                },
                KungfuMastery = new KungfuMastery { Agility = 8, Chosenness = 3, Hacking = 10, KillerInstinct = 1 }
            };
            tamers.Add(hackerMan);

            Tamer hitler = new Tamer
            {
                Name = "Hitler",
                Image = "/Images/Hitler.jpg",
                Quote = "Is this ze police?.. Fuck you!",
                SpiritAnimal = new SpiritAnimal
                {
                    Claws = true,
                    Image = "/Images/Raptor.jpg",
                    Teeth = true,
                    Name = "Nazi Laser Raptor"
                },
                KungfuMastery = new KungfuMastery { Agility = 9, Chosenness = 9, Hacking = 1, KillerInstinct = 10 }
            };
            tamers.Add(hitler);

            Tamer katana = new Tamer
            {
                Name = "Katana",
                Image = "/Images/Katana.jpg",
                Quote = "So...anyway, Thor, um, this is Kung Fury. He's a cop from the future",
                SpiritAnimal = new SpiritAnimal
                {
                    Claws = true,
                    Image = "/Images/Trex.jpg",
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
