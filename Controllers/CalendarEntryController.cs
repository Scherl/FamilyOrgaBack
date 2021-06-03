using FamilyOrgaBack.Models;
using FamilyOrgaBack.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace FamilyOrgaBack.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CalendarEntryController : ControllerBase{
        private readonly CalendarEntryServcie _calendarEntryService;

        public CalendarEntryController(CalendarEntryServcie calendarEntryService)
        {
            _calendarEntryService = calendarEntryService;
        }

        [HttpGet]
        public ActionResult<List<CalendarEntry>> Get() =>
            _calendarEntryService.Get();

        [HttpGet("{id:length(24)}", Name ="GetCalendarEntry")]
        public ActionResult<CalendarEntry> GetActionResult(string id)
        {
            var calendarEntry = _calendarEntryService.Get(id);

            if (calendarEntry == null)
            {
                return NotFound();
            }
            return calendarEntry;
        }

        [HttpPost]
        public ActionResult<CalendarEntry> Create (CalendarEntry calendarEntry)
        {
            _calendarEntryService.Create(calendarEntry);
            return CreatedAtRoute("GetCalendarEntry", new {id = calendarEntry.Id.ToString()}, calendarEntry);
        }
        [HttpPut("{id:length(24)}")]
        public IActionResult Update(string id, CalendarEntry calendarEntryIn)
        {
            var calendarEntry = _calendarEntryService.Get(id);
            if(calendarEntry == null)
            {
                return NotFound();
            }
            _calendarEntryService.Update(id, calendarEntryIn);
            return NoContent();
        }

        [HttpDelete("{id:length(24)}")]
        public ActionResult<List<CalendarEntry>> Delete(string id)
        {
            var calendarEntry = _calendarEntryService.Get(id);
            if(calendarEntry == null)
            {
                return NotFound();
            }
            _calendarEntryService.Remove(calendarEntry.Id);
            
            List<CalendarEntry> CalendarEntryList = new List<CalendarEntry>();
            
            CalendarEntryList = _calendarEntryService.Get();

            return CalendarEntryList;
        }

    }
}