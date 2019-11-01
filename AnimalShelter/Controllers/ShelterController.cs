using System;
using System.Collections.Generic;
using System.Linq;
using AnimalShelter.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AnimalShelter.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AnimalsController : ControllerBase
    {
        private AnimalShelterContext _db;

        public AnimalsController(AnimalShelterContext db)
        {
            _db = db;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Animal>> Get(int animalId, string type, string name, int age, string animalList)
        {
            var query = _db.Animals.AsQueryable();
            if (animalId != 0)
            {
                query = query.Where(w => w.AnimalId == animalId);
            }
            if (type != null)
            {
                query = query.Where(w => w.Type == type);
            }
            if (name != null)
            {
                query = query.Where(w => w.Name == name);
            }
            if (age != 0)
            {
                query = query.Where(w => w.Age == age);
            }
            if (animalList != null)
            {
                animalList = animalList.ToLower();
                string[] array = animalList.Split(",");
                List<string> animalsTable = _db.Animals.Select(w => w.Name).ToList();
                // foreach (String animal in array)
                // {
                //     if (!(animalsTable.Contains(animal)))
                //     {
                //         Random rand = new Random();
                //         double randomNumber = rand.Next(1,6);
                //         Animal newAnimal = new Animal{Name= animal, Rating= randomNumber, RatingCount= 0};
                //         _db.Add(newAnimal);
                //         _db.SaveChanges();
                //     }
                // }
                query = query.Where(w => array.Contains(w.Name));
            }
            // if (page != 0)
            // {
            //     int WORDS_PER_PAGE = 30;
            //     int NUMBER_OF_ANIMALS = _db.Animals.ToList().Count;
            //     int MAX_PAGE = (int)Math.Ceiling((double)NUMBER_OF_ANIMALS / (double)ANIMALS_PER_PAGE);
            //     if (page <= MAX_PAGE)
            //     {
            //         int MIN_RANGE = ((page - 1) * ANIMALS_PER_PAGE) + 1;
            //         int RANGE = ANIMALS_PER_PAGE - 1;
            //         if (MIN_RANGE + RANGE > NUMBER_OF_ANIMALS && MIN_RANGE < NUMBER_OF_ANIMALS)
            //         {
            //             RANGE = (NUMBER_OF_ANIMALS - MIN_RANGE) + 1;
            //         }
            //         int[] RANGE_ARRAY = Enumerable.Range(MIN_RANGE, RANGE).ToArray();
            //         query = query.Where(w => RANGE_ARRAY.Contains(w.AnimalId));
            //     }
            // }
            return query.ToList();
        }

        [HttpPost]
        public void Post([FromBody] Animal animal)
        {

            Console.WriteLine("Post");
            List<string> animals = _db.Animals.Select(w => w.Name).ToList();
            if (animals.Contains(animal.Name))
            {
                int animalId = _db.Animals.FirstOrDefault(w => w.Name == animal.Name).AnimalId;
                animal.AnimalId = animalId;
                _db.Entry(animal).State = EntityState.Modified;
                _db.SaveChanges();
            }
            else
            {
                _db.Animals.Add(animal);
                _db.SaveChanges();
            }
        }

        [HttpGet("{id}")]
        public ActionResult<Animal> Get(int id)
        {
            return _db.Animals.FirstOrDefault(entry => entry.AnimalId == id);
        }

        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Animal animal)
        {
            animal.AnimalId = id;
            _db.Entry(animal).State = EntityState.Modified;
            _db.SaveChanges();
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var animalToDelete = _db.Animals.FirstOrDefault(entry => entry.AnimalId == id);
            _db.Animals.Remove(animalToDelete);
            _db.SaveChanges();
        }

    }

}