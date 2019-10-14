using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using TEC_App.Helpers;
using TEC_App.Models.Db;

namespace TEC_App.Services.SessionLocationService
{
    public class SessionLocationServiceTest
    {
        public TecAppContext TecAppContext { get; set; }
        public SessionService.SessionService SessionService { get; set; }
        public LocationService.LocationService LocationService { get; set; }
        public SessionLocationService SessionLocationService { get; set; }
        public Session Session { get; set; }
        public Location Location { get; set; }
        public Session_Location SessionLocation { get; set; }

        public SessionLocationServiceTest()
        {
            TecAppContext = new TecAppContext();
            SessionService = new SessionService.SessionService(TecAppContext);
            LocationService = new LocationService.LocationService(TecAppContext);
            SessionLocationService = new SessionLocationService(TecAppContext);
        }

        [Test]
        public void AddTest()
        {
            var random = new Random();
            Session = SessionService.GetSessionFromId(random.Next(100));
            Location = LocationService.GetLocationFromId(random.Next(100));
            SessionLocation = SessionLocationService.Add(new Session_Location()
            {
                Session = Session,
                SessionId = Session.Id,
                Location = Location,
                LocationId = Location.Id
            });

        }

        [Test]
        public void GetTest()
        {
            var added = SessionLocationService.GetFromIdPair(Session.Id, Location.Id);
            Assert.AreEqual(added.Id, SessionLocation.Id);
        }

        [Test]
        public void RemoveTest()
        {
            SessionLocationService.Remove(Session.Id, Location.Id);
            var removed = SessionLocationService.GetFromIdPair(Session.Id, Location.Id);
            Assert.AreEqual(removed.Id, -1);
        }
    }
}
