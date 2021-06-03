using FamilyOrgaBack.Models;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Linq;

namespace FamilyOrgaBack.Services 
{
    public class CalendarEntryServcie
    {
        private readonly IMongoCollection<CalendarEntry> _carlendarEntry;
        public CalendarEntryServcie(IFamilyOrgaDBSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);

            _carlendarEntry = database.GetCollection<CalendarEntry>(settings.CalendarCollectionName);
        }

        public List<CalendarEntry> Get() => 
            _carlendarEntry.Find(CalendarEntry => true).ToList();
        
        public CalendarEntry Get(string id) =>
            _carlendarEntry.Find(calendarEntry => calendarEntry.Id == id).FirstOrDefault();

        public CalendarEntry Create(CalendarEntry calendarEntry)
        {
            _carlendarEntry.InsertOne(calendarEntry);
            return calendarEntry;
        }
        public void Update(string id, CalendarEntry calendarEntryIn) =>
        _carlendarEntry.ReplaceOne(calendarEntry => calendarEntry.Id == id, calendarEntryIn);

        public void Remove(CalendarEntry calendarEntryIn) =>
        _carlendarEntry.DeleteOne(calendarEntry => calendarEntry.Id == calendarEntryIn.Id);

        public void Remove(string id)=>
        _carlendarEntry.DeleteOne(calendarEntry => calendarEntry.Id == id);
    }
}