using System;
using System.Collections.Generic;
using System.Text;
using Nancy;
using System.IO;
using System.Linq;
using Newtonsoft.Json;

namespace Database_Api
{
    public class RestModule : NancyModule
    {
        private static CircusContext context = new CircusContext();
        private List<Tamer> tamers = context.Tamers.AsEnumerable().ToList();
        private List<SpiritAnimal> spiritAnimals = context.SpiritAnimals.AsEnumerable().ToList();
        private List<KungfuMastery> kungfuMasteries = context.KungfuMasteries.AsEnumerable().ToList();

        public RestModule()
        {
            Get("/", pars =>
            {
                return "Welcome to the Kung Fu Circus! We're on it";
            });

            Get("/tamers", pars =>
            {
                string output = JsonConvert.SerializeObject(tamers);
                return output;
            });

            Get("/tamers/{id}", pars =>
            {
                bool exists = tamers.Any(t => t.TamerId == pars.id);
                if (exists)
                {
                    Tamer tamer = tamers.First(t => t.TamerId == pars.id);
                    string export = JsonConvert.SerializeObject(tamer);
                    return export;
                }
                else
                {
                    return "Tamer with the requested Id does not exist. Try entering 1 to 4 values instead";
                }
            });

            Get("/animals", pars =>
            {
                string output = JsonConvert.SerializeObject(spiritAnimals);
                return output;
            });

            Get("/animals/{id}", pars =>
            {
                bool exists = spiritAnimals.Any(a => a.SpiritAnimalId == pars.id);
                if (exists)
                {
                    SpiritAnimal animal = spiritAnimals.First(a => a.SpiritAnimalId == pars.id);
                    string export = JsonConvert.SerializeObject(animal);
                    return export;
                }
                else
                {
                    return "Animal with the requested Id does not exist. Try entering 1 to 4 values instead";
                }
            });

        }
    }
}
