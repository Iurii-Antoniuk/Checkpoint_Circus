using System;
using System.Collections.Generic;
using System.Text;
using Nancy;
using System.IO;
using System.Linq;
using Newtonsoft.Json;
using System.Threading.Tasks;

namespace Database_Api
{
    public class RestModule : NancyModule
    {
        private static readonly DbPopulator db = new DbPopulator();
        
        public RestModule()
        {
            Get("/", pars =>
            {
                return "Welcome to the Kung Fu Circus! We're on it";
            });

            Get("/tamers", async pars =>
            {
                IEnumerable<Tamer> tamers = await db.GetAllTamersAsync();
                string output = JsonConvert.SerializeObject(tamers);
                return output;
            });

            Get("/tamers/{id}", async pars =>
            {
                IEnumerable<Tamer> tamers = await db.GetAllTamersAsync();
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

            Get("/tamers/{id}/spirit-animal", async pars =>
            {
                IEnumerable<Tamer> tamers = await db.GetAllTamersAsync();
                bool exists = tamers.Any(t => t.TamerId == pars.id);
                if (exists)
                {
                    SpiritAnimal animal = tamers.First(t => t.TamerId == pars.id).SpiritAnimal;
                    string export = JsonConvert.SerializeObject(animal);
                    return export;
                }
                else
                {
                    return "Ooups, the requested Id does not exist. Try entering 1 to 4 id values instead";
                }
            });

            Get("/tamers/{id}/skills", async pars =>
            {
                IEnumerable<Tamer> tamers = await db.GetAllTamersAsync();
                bool exists = tamers.Any(t => t.TamerId == pars.id);
                if (exists)
                {
                    KungfuMastery skills = tamers.First(t => t.TamerId == pars.id).KungfuMastery;
                    string export = JsonConvert.SerializeObject(skills);
                    return export;
                }
                else
                {
                    return "Ooups, the requested tamer Id does not exist. Try entering 1 to 4 id values instead";
                }
            });

            Get("/animals", async pars =>
            {
                IEnumerable<SpiritAnimal> animals = await db.GetAllAnimalsAsync();
                string output = JsonConvert.SerializeObject(animals);
                return output;
            });

            Get("/animals/{id}", async pars =>
            {
                IEnumerable<SpiritAnimal> animals = await db.GetAllAnimalsAsync();
                bool exists = animals.Any(a => a.SpiritAnimalId == pars.id);
                if (exists)
                {
                    SpiritAnimal animal = animals.First(a => a.SpiritAnimalId == pars.id);
                    string export = JsonConvert.SerializeObject(animal);
                    return export;
                }
                else
                {
                    return "Animal with the requested Id does not exist. Try entering 1 to 4 values instead";
                }
            });

            Get("/feedbacks", pars =>
            {
                IEnumerable<Feedback> feedbacks = db.GetAllFeedbacks();
                string output = JsonConvert.SerializeObject(feedbacks);
                return output;
            });

            Get("/feedbacks/{name}", pars =>
            {
                IEnumerable<Feedback> feedbacks = db.GetAllFeedbacks();
                Feedback feedback = feedbacks.SingleOrDefault(f => f.Name == pars.name);
                if (feedback != null)
                {
                    string export = JsonConvert.SerializeObject(feedback);
                    return export;
                }
                else
                {
                    return "Ouups, we don't have any feedbacks from users with the requested Name";
                }
            });

        }
    }
}
