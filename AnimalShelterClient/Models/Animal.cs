using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace AnimalShelterClient.Models {
    public class Animal {
        public int animalId { get; set; }
        public string type { get; set; }
        public string name { get; set; }
        public int age { get; set; }

        public static List<Animal> GetAnimals () {
            var apiCallTask = ApiHelper.ApiCall ();
            var result = apiCallTask.Result;

            JArray jsonResponse = JsonConvert.DeserializeObject<JArray> (result);
            List<Animal> animalList = JsonConvert.DeserializeObject<List<Animal>>(jsonResponse.ToString());
            return animalList;
        }

        public static Animal PutAnimal(Animal animal)
        {
            var apiCallTask = ApiHelper.ApiCallAnimalList(animal.name);
            var result = apiCallTask.Result;
            JArray jresponse = JsonConvert.DeserializeObject<JArray>(result);
            List<Animal> animalResponse = JsonConvert.DeserializeObject<List<Animal>>(jresponse.ToString());
            Animal targetAnimal = animalResponse[0];
            var apiPutTask = ApiHelper.ApiPut(targetAnimal.animalId, targetAnimal);
            return targetAnimal;
        }
    }
}