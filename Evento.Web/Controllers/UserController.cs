using AutoMapper;
using Evento.Web.Http;
using Evento.Web.Models.User;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Evento.Web.Controllers
{
    public class UserController : Controller
    {
        private readonly IApiClient<UserViewModel> _apiClient;
        private readonly IMapper _mapper;
        private readonly string baseUrl;

        public UserController(IApiClient<UserViewModel> apiClient,
            IConfiguration configuration,
            IMapper mapper)
        {
            _apiClient = apiClient
                ?? throw new ArgumentNullException(nameof(apiClient));
            baseUrl = configuration["BaseUrl"]
                ?? throw new ArgumentNullException($"configuration {nameof(configuration)}");
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        // GET: UserController
        public async Task<ActionResult> Index()
        {
            var users = await _apiClient.GetListAsync($"{baseUrl}/users");
            return View(users);
        }

        // GET: UserController/Details/5
        public async Task<ActionResult> Details(int id)
        {
            var user = await _apiClient.GetAsync($"{baseUrl}/users/{id}");
            return View(user);
        }

        // GET: UserController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: UserController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(UserCreateViewModel user)
        {
            try
            {
                
                HttpResponseMessage response = await _apiClient.PostAsync($"{baseUrl}/users", user);
                if (!response.IsSuccessStatusCode)
                {
                    throw new Exception($"Failed to create item: {response.StatusCode}");
                }
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: UserController/Edit/5
        public async Task<ActionResult> Edit(int id)
        {
            var user = await _apiClient.GetAsync($"{baseUrl}/users/{id}");
            return View(_mapper.Map<UserUpdateViewModel>(user));
        }

        // POST: UserController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(int id, UserUpdateViewModel user)
        {
            try
            {
                var response = await _apiClient.PutAsync($"{baseUrl}/users/{id}", user);
                if (!response.IsSuccessStatusCode)
                {
                    throw new Exception($"Failed to create item: {response.StatusCode}");
                }
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: UserController/Delete/5
        public async Task<ActionResult> Delete(int id)
        {
            var user = await _apiClient.GetAsync($"{baseUrl}/users/{id}");
            return View(user);
        }

        // POST: UserController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Delete(int id, IFormCollection collection)
        {
            try
            {
                var response = await _apiClient.DeleteAsync($"{baseUrl}/users/{id}");
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
