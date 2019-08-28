using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Protocols;
using WebsAPIDay3.Models;

namespace WebsAPIDay3.Controllers
{
    public class CatAPIMethods
    {
        
        public static HttpClient GetHttpClient()
        {
            
            var client = new HttpClient(); //4
            client.BaseAddress = new Uri("https://api.thecatapi.com"); //6 GET on Api Website
            var apiKey = ConfigurationManager.AppSettings["CatAPIKey"];
            client.DefaultRequestHeaders.Add("x-api-key", apiKey);//7 Key/Value Pair
            return client; 
            //performs first half of what apis were doing
            //creating http client that connects to server
            //has headers in it key/value
            //sends beginning of request to website with keys and values
            //creates entire package: need headers,base address
        }


        public static async Task<List<CatBreed>> CatBreeds() //5 Task is gonna create this List
                                                             //and return this List
        {
            var client = GetHttpClient(); //4 //we now have client and sending specifcis into this 
            //method
            //talk to client now
            var response = await client.GetAsync("v1/breeds");//8 take last part of url for here
            //taking client and getting end of API Call asking for breeds getting breeds
            //if it starts with v1/ , is returning a list
            //
            client.DefaultRequestHeaders.Add("x-api-key", "CatAPIKey");
            var catBreeds = await response.Content.ReadAsAsync<List<CatBreed>>(); //9.catbreed with all the properties
            //When error when running says it needs to be IList ICollection, make sure you have it as a List
            
            return catBreeds;
        }

        //purpose of this controller is so it can talk to API

        public static async Task<BreedImage> GetBreedImages()
        {

            var client = CatAPIMethods.GetHttpClient(); //4

            var response = await client.GetAsync("v1/images/search?breed_ids=beng");//8 take last part of url for here
            //dont need first slash
            var catImages = await response.Content.ReadAsAsync<List<BreedImage>>(); //9.catbreed with all the properties
            //When error when running says it needs to be IList ICollection, make sure you have it as a List
            return catImages[0];
        }
    }//12 go to specialappsettings.config
}