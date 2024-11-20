using HMSystem.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net.Http.Json;
using System.Text.Json.Serialization;

namespace HMSystem.Controllers
{
    public class RoomModelController : Controller
    {
        private readonly HttpClient _client;

        public RoomModelController(HttpClient httpClient)
        {
            _client = httpClient;
            _client.BaseAddress = new Uri("https://localhost:7048");
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            try
            {
                var response = await _client.GetAsync("/api/RoomModel/GetRoom");

                if (response.IsSuccessStatusCode)
                {
                    var data = await response.Content.ReadAsStringAsync();
                    var roomList = JsonConvert.DeserializeObject<List<RoomModel>>(data);
                    return View(roomList);
                }
                else
                {
                    // Handle non-success status codes
                    ViewBag.ErrorMessage = $"Error: {response.StatusCode}";
                    return View(new List<RoomModel>());
                }
            }
            catch (Exception ex)
            {
                ViewBag.ErrorMessage = $"An error occurred: {ex.Message}";
                return View(new List<RoomModel>());
            }
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View(); 
        }

        [HttpPost]
        public async Task<IActionResult> Create(RoomModel roomModel)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    // Make POST request to the API
                    var response = await _client.PostAsJsonAsync("/api/RoomModel/create", roomModel);

                    if (response.IsSuccessStatusCode)
                    {
                        return RedirectToAction("Index"); 
                    }
                    else
                    {
              
                        ModelState.AddModelError("", $"Error: {response.StatusCode} - {response.ReasonPhrase}");
                    }
                }
                catch (Exception ex)
                {
                
                    ModelState.AddModelError("", "An unexpected error occurred while creating the room.");
                }
            }

            // Return the Create view with validation errors
            return View("Create", roomModel);
        }
        [HttpGet]
        public async Task<IActionResult> Edite(string id)
        {
            var result = await _client.GetAsync("/api/RoomModel/Getdata/{id}");
            if (result.IsSuccessStatusCode)
            {
                var data = await result.Content.ReadAsStringAsync();
                var room = JsonConvert.DeserializeObject<RoomModel>(data);
                return View(room);

            }
            else
            {
                return View("Index");
            }

        }
        [HttpPost]
        public async Task<IActionResult> Edite(RoomModel roomModel)
        {
            try
            {
                var result = await _client.PostAsJsonAsync("/api/RoomModel/UpdateRoom/{roomModel.RoomID}", roomModel);
                if (result.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index");
                }
                else
                {

                    ModelState.AddModelError("", $"Error: {result.StatusCode} - {result.ReasonPhrase}");
                }
            }
            catch (Exception ex)
            {

                ModelState.AddModelError("", "An unexpected error occurred while creating the room.");
            }

            // Return the Create view with validation errors
            return View("Edite", roomModel);
        }

    }

}

