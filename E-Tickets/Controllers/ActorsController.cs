using E_Tickets.Data;
using E_Tickets.Data.Services;
using E_Tickets.Models;
using Microsoft.AspNetCore.Mvc;

namespace E_Tickets.Controllers
{
    public class ActorsController : Controller
    {
        private readonly IActorsService _Service;

        public ActorsController(IActorsService service )
        {
            _Service = service;
        }
        public async Task<IActionResult> Index()
        {
            var data =await _Service.GetAllAsync();
            return View(data);
        }

        // Get:- Actors/Create
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        //public async Task<IActionResult> Create([Bind("ProfilePictureURL,FullName,Bio")] Actor actor)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        // If the ModelState is not valid (e.g., validation errors), return the same view with the provided actor object
        //        return View(actor);
        //    }

        //    // If ModelState is valid, proceed to add the actor
        //    _Service.Add(actor);

        //    // Redirect to the Index action method to show all actors after successfully adding the new actor
        //    return RedirectToAction(nameof(Index));
        //}

        public async Task<IActionResult> Create(ActorCreateViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                return View(viewModel);
            }

            // Map properties from the view model to the Actor entity
            var actor = new Actor
            {
                ProfilePictureURL = viewModel.ProfilePictureURL,
                FullName = viewModel.FullName,
                Bio = viewModel.Bio
            };

            // Add the actor to the database
           await  _Service.AddAsync(actor);

            return RedirectToAction(nameof(Index));
        }

        //Get:Actors/Details/1
        public async Task<IActionResult>Details(int id)
        {
            var actorDetails = await _Service.GetByIdAsync(id);

            if (actorDetails == null) return View("ohh! Not Found");
            return View(actorDetails);
            
        }

        // For Edit details button

        // Get:- Actors/Create
        public async Task< IActionResult> Edit(int id)
        {
            var actorDetails = await _Service.GetByIdAsync(id);

            if (actorDetails == null) return View("Ohh! Not Found");
            return View(actorDetails);
        }

        [HttpPost]

        //public async Task<IActionResult> Edit(int id, Actor viewModel)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return View(viewModel);
        //    }

        //    // Map properties from the view model to the Actor entity
        //    var actor = new Actor
        //    {
        //        ProfilePictureURL = viewModel.ProfilePictureURL,
        //        FullName = viewModel.FullName,
        //        Bio = viewModel.Bio
        //    };

        //    // Add the actor to the database
        //    await _Service.UpdateAsync(id, actor);

        //    return RedirectToAction(nameof(Index));
        //}

        //public async Task<IActionResult> Edit(int id,[Bind("Id,ProfilePictureURL,FullName,Bio")] Actor actor)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        // If the ModelState is not valid (e.g., validation errors), return the same view with the provided actor object
        //        return View(actor);
        //    }

        //    // If ModelState is valid, proceed to add the actor
        //    await _Service.UpdateAsync(id,actor);

        //    // Redirect to the Index action method to show all actors after successfully adding the new actor
        //    return RedirectToAction(nameof(Index));
        //}
        public async Task<IActionResult> Edit(int id, ActorCreateViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                return View(viewModel);
            }

            // Fetch the existing actor from the database
            var existingActor = await _Service.GetByIdAsync(id);
            if (existingActor == null)
            {
                return View("Ohh! Not Found");
            }

            // Update the properties of the existing actor with the values from the view model
            existingActor.ProfilePictureURL = viewModel.ProfilePictureURL;
            existingActor.FullName = viewModel.FullName;
            existingActor.Bio = viewModel.Bio;

            // Update the actor in the database
            await _Service.UpdateAsync(id, existingActor);

            return RedirectToAction(nameof(Index));
        }


    }
}
