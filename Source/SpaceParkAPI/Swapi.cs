using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RestSharp;
using SpaceParkAPI.Models;

namespace SpaceParkAPI
{
    public class Swapi
    {
        private const string basicURL = "http://swapi.dev/api/";

        //Download people from Swapi
        //public static async Task<List<Person>> People(string input)
        //{

        //}

        //Download Starships from Swapi
        //public static async Task<List<Starships>> Starships()
        //{

        //}

        public static async Task<bool> ValidateName(string name)
        {
            var client = new RestClient("https://swapi.dev/api/");
            var request = new RestRequest("people/", DataFormat.Json);

            var peopleResponse = await client.GetAsync<PeopleResponse>(request);

            peopleResponse.Next = "INTE NULL";

            int i = 2;
            while (peopleResponse.Next != null)
            {
                foreach (var p in peopleResponse.Results)
                {
                    if (p.Name.ToLower() == name.ToLower())
                    {
                        return true;
                    }
                }
                request = new RestRequest("people/?page=" + i);
                peopleResponse = await client.GetAsync<PeopleResponse>(request);
                i++;
            }
            return false;
        }

        public static async Task<bool> ValidateSpaceShips(string name)
        {
            var client = new RestClient("https://swapi.dev/api/");
            var request = new RestRequest("starships/", DataFormat.Json);

            var spaceshipResponse = await client.GetAsync<SpaceShips>(request);

            spaceshipResponse.Next = "INTE NULL";

            int i = 2;
            while (spaceshipResponse.Next != null)
            {
                foreach (var p in spaceshipResponse.Results)
                {
                    if (p.Name.ToLower() == name.ToLower())
                    {
                        return true;
                    }
                }
                request = new RestRequest("people/?page=" + i);
                spaceshipResponse = await client.GetAsync<SpaceShips>(request);
                i++;
            }
            return false;
        }
    }
}
