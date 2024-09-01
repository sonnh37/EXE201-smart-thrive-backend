using AutoMapper;
using EXE201.SmartThrive.Domain.Contracts.Repositories;
using EXE201.SmartThrive.Domain.Contracts.Services;
using EXE201.SmartThrive.Domain.Contracts.UnitOfWorks;
using EXE201.SmartThrive.Domain.Entities;
using EXE201.SmartThrive.Domain.Enums;
using EXE201.SmartThrive.Domain.Models.Requests.Commands.Session;
using EXE201.SmartThrive.Services.Base;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;


namespace EXE201.SmartThrive.Services
{
    public class SessionService : BaseService<Session>, ISessionService
    {
        private static ISessionRepository _sessionRepository;
        private static ISessionMeetingRepository _sessionMeetingRepository;
        private static ISessionOfflineRepository _sessionOfflineRepository;
        private static ISessionSelfLearnRepository _sessionSelfLearnRepository;
        private static IUnitOfWork _unitOfWork;
        public SessionService(IMapper mapper, IUnitOfWork unitOfWork) : base(mapper, unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _sessionRepository = _unitOfWork.SessionRepository;
            _sessionMeetingRepository = _unitOfWork.SessionMeetingRepository;
            //_sessionOfflineRepository = _unitOfWork.SessionOfflineRepository;
            //_sessionSelfLearnRepository = _unitOfWork.SessionSelfLearnRepository;
        }

        private static readonly Dictionary<string, System.Type> SessionRegistry = new Dictionary<string, System.Type>();

        public static void RegisterProductType(string type, System.Type classRef)
        {
            SessionRegistry[type] = classRef;
        }


        public async Task<object> CreateSession(string type, SessionCreateCommand payload)
        {
            if (!SessionRegistry.TryGetValue(type, out System.Type sessionClass))
            {
                throw new Exception("Session type not found");
            }
            var session = Activator.CreateInstance(sessionClass, payload) as SessionModel;
            return await session.CreateSession();
        }

        public abstract class SessionModel
        {
            protected Guid? ModuleId { get; set; }

            protected string? Title { get; set; }

            protected string? Document { get; set; }

            protected SessionType SessionType { get; set; }
            protected int SessionNumber { get; set; }

            protected string? Description { get; set; }

            protected object? Detail { get; set; }

            //protected SessionModel(object payload)
            //{
            //    var dict = payload as Dictionary<string, object>;
            //    this.ModuleId = (Guid)dict!["moduleId"];
            //    Title = dict["title"] as string;
            //    Document = dict["document"] as string;
            //    SessionType = (SessionType)dict["sessionType"];
            //    Description = dict["description"] as string;
            //    this.SessionNumber = (int)dict["sessionNumber"];
            //    Detail = dict["detail"];
            //}

            protected SessionModel(SessionCreateCommand payload)
            {
                this.ModuleId = payload.ModuleId;
                Title = payload.Title;
                Document = payload.Document;
                SessionType = payload.SessionType;
                Description = payload.Description;
                this.SessionNumber = payload.SessionNumber;
                Detail = payload.Detail;
            }

            public abstract Task<object> CreateSession();
            public abstract Task<object> UpdateSession(Guid sessionId);

            protected async Task<Session> CreateSessionBase()
            {
                var session = new Session
                {
                    Id = Guid.NewGuid(),
                    ModuleId = this.ModuleId,
                    Title = this.Title,
                    Document = this.Document,
                    SessionType = this.SessionType,
                    Description = this.Description,
                    SessionNumber = this.SessionNumber,
                };
                 _sessionRepository.Add(session);
                return session;
            }

        }

        public class SessionMeetingService : SessionModel
        {
            public SessionMeetingService(SessionCreateCommand payload) : base(payload)
            {

            }
            public override async Task<object> CreateSession()
            {
                JObject converted = JsonConvert.DeserializeObject<JObject>(Detail.ToString());
                Dictionary<string, string> dict = new Dictionary<string, string>();
                foreach (KeyValuePair<string, JToken> keyValuePair in converted)
                {
                    dict.Add(keyValuePair.Key, keyValuePair.Value.ToString());
                }
                var session = await CreateSessionBase();
                if(session == null)
                {
                    throw new Exception("Fail when create session");
                }
                var sessionMeeting = new SessionMeeting
                {
                    Id= Guid.NewGuid(),
                    SessionId = session.Id,
                    Host = dict!["host"] as string,
                    Date = DateTime.Parse(dict!["date"] as string),
                    MeetingUrl = dict["meetingUrl"] as string,
                    MeetingPlatform = dict["meetingPlatform"] as string
                };
                 _sessionMeetingRepository.Add(sessionMeeting);
                _unitOfWork.SaveChanges();

                return session;
            }
            public override Task<object> UpdateSession(Guid sessionId)
            {
                throw new NotImplementedException();
            }
        }

        public class SessionOfflineService: SessionModel
        {
            public SessionOfflineService(SessionCreateCommand payload) : base(payload)
            {

            }

            public override async Task<object> CreateSession()
            {
                JObject converted = JsonConvert.DeserializeObject<JObject>(Detail.ToString());
                Dictionary<string, string> dict = new Dictionary<string, string>();
                foreach (KeyValuePair<string, JToken> keyValuePair in converted)
                {
                    dict.Add(keyValuePair.Key, keyValuePair.Value.ToString());
                }
                var session = await CreateSessionBase();
                if (session == null)
                {
                    throw new Exception("Fail when create session");
                }
                var sessionOffline = new SessionOffline
                {
                    Id = Guid.NewGuid(),
                    SessionId = session.Id,
                    Location = dict["location"] as string,
                    Date = DateTime.Parse(dict["date"]),
                    Duration = int.Parse(dict["duration"]),
                };
                _sessionOfflineRepository.Add(sessionOffline);
                _unitOfWork.SaveChanges();

                return session;
            }
            public override Task<object> UpdateSession(Guid sessionId)
            {
                throw new NotImplementedException();
            }
        }

        public class SessionSelfLearnService : SessionModel
        {
            public override async Task<object> CreateSession()
            {
                JObject converted = JsonConvert.DeserializeObject<JObject>(Detail.ToString());
                Dictionary<string, string> dict = new Dictionary<string, string>();
                foreach (KeyValuePair<string, JToken> keyValuePair in converted)
                {
                    dict.Add(keyValuePair.Key, keyValuePair.Value.ToString());
                }
                var session = await CreateSessionBase();
                if (session == null)
                {
                    throw new Exception("Fail when create session");
                }
                var sessionSelfLearn = new SessionSelfLearn
                {
                    Id = Guid.NewGuid(),
                    SessionId = session.Id,
                    SessionNumber = this.SessionNumber,
                    VideoUrl = dict["videoUrl"],
                    //IsComplete = bool.Parse(dict["isComplete"]),

                };
                _sessionSelfLearnRepository.Add(sessionSelfLearn);
                _unitOfWork.SaveChanges();

                return session;
            }
            public SessionSelfLearnService(SessionCreateCommand payload) : base(payload) { }
            public override Task<object> UpdateSession(Guid sessionId)
            {
                throw new NotImplementedException();
            }
        }
    }
}

