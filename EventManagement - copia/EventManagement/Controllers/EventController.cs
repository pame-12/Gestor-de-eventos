using EventManagement.Models;
using Microsoft.AspNetCore.Mvc;
using EventManagement.Repositories;
namespace EventManagement.Controllers
{
    [Route("event")]
    public class EventController : Controller
    {
        private readonly EventRepository _eventRepository;

        public EventController(EventRepository eventRepository)
        {
            _eventRepository = eventRepository;
        }

        // GET: /event/list
        [HttpGet("list")]
        public IActionResult GetAllEvents()
        {
            var events = _eventRepository.GetAllEvents();
            return View("GetAllEvents", events);
        }

        // GET: /event/add
        [HttpGet("add")]
        public IActionResult AddEvent()
        {
            return View();
        }

        // POST: /event/add
        [HttpPost("add")]
        public IActionResult AddEvent(Event newEvent)
        {
            if (ModelState.IsValid)
            {
                _eventRepository.AddEvent(newEvent);
                return RedirectToAction("GetAllEvents");
            }
            return View(newEvent);
        }

        // GET: /event/edit/1
        [HttpGet("edit/{id}")]
        public IActionResult EditEvent(int id)
        {
            var eventToEdit = _eventRepository.GetAllEvents().FirstOrDefault(e => e.Id == id);
            if (eventToEdit == null)
            {
                return NotFound();
            }
            return View("EditEvent", eventToEdit);
        }

        // POST: /event/edit/1
        [HttpPost("edit/{id}")]
        public IActionResult EditEvent(Event updatedEvent)
        {
            if (ModelState.IsValid)
            {
                _eventRepository.UpdateEvent(updatedEvent);
                return RedirectToAction("GetAllEvents");
            }
            return View(updatedEvent);
        }

        // POST: /event/delete/1
        [HttpPost("delete/{id}")]
        public IActionResult DeleteEvent(int id)
        {
            _eventRepository.DeleteEvent(id);
            return RedirectToAction("GetAllEvents");
        }
    }

}