using AutoMapper;
using EXE201.SmartThrive.Domain.Contracts.Repositories;
using EXE201.SmartThrive.Domain.Contracts.Services;
using EXE201.SmartThrive.Domain.Contracts.UnitOfWorks;
using EXE201.SmartThrive.Domain.Entities;
using EXE201.SmartThrive.Domain.Exceptions;
using EXE201.SmartThrive.Domain.Models;
using EXE201.SmartThrive.Domain.Models.Requests.Commands.Session;
using EXE201.SmartThrive.Domain.Models.Responses;
using EXE201.SmartThrive.Domain.Utilities;
using EXE201.SmartThrive.Services.Base;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace EXE201.SmartThrive.Services;

//arr[0] = value
public class SessionService : BaseService<Session>, ISessionService
{
    private static ISessionRepository _sessionRepository;
    private static ISessionMeetingRepository _sessionMeetingRepository;
    private static ISessionOfflineRepository _sessionOfflineRepository;
    private static ISessionSelfLearnRepository _sessionSelfLearnRepository;
    private static IUnitOfWork _unitOfWork;
    private static readonly Dictionary<string, Type> SessionRegistry = new();
    private readonly IMapper _mapper;

    public SessionService(IMapper mapper, IUnitOfWork unitOfWork) : base(mapper, unitOfWork)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
        _sessionRepository = _unitOfWork.SessionRepository;
        _sessionMeetingRepository = _unitOfWork.SessionMeetingRepository;
        _sessionOfflineRepository = _unitOfWork.SessionOfflineRepository;
        _sessionSelfLearnRepository = _unitOfWork.SessionSelfLearnRepository;
    }


    public async Task<BusinessResult> CreateSession(string type, SessionCreateCommand payload)
    {
        if (!SessionRegistry.TryGetValue(type, out var sessionClass)) throw new Exception("Session type not found");
        var sessionModel = _mapper.Map<SessionModel>(payload);
        var session = Activator.CreateInstance(sessionClass, sessionModel) as SessionBase;
        return new BusinessResult(Const.SUCCESS_CODE , Const.SUCCESS_CREATE_MSG, await session.CreateSession());
    }

    public async Task<BusinessResult> UpdateSession(string type, SessionUpdateCommand payload)
    {
        if (!SessionRegistry.TryGetValue(type, out var sessionClass)) throw new Exception("Session type not found");
        var sessionModel = _mapper.Map<SessionModel>(payload);
        var session = Activator.CreateInstance(sessionClass, sessionModel) as SessionBase;
        return new BusinessResult(Const.SUCCESS_CODE, Const.SUCCESS_UPDATE_MSG, await session.UpdateSession());
    }

    public async Task<BusinessResult> DeleteSession(Guid sessionId)
    {
        var foundSession = await _sessionRepository.GetById(sessionId);
        if (foundSession == null) throw new NotfoundException($"Not found {sessionId}");
        if (!SessionRegistry.TryGetValue(foundSession.SessionType.Value.ToString(), out var sessionClass))
            throw new Exception("Session type not found");
        var sessionModel = _mapper.Map<SessionModel>(foundSession);
        var session = Activator.CreateInstance(sessionClass, sessionModel) as SessionBase;
        await session.DeleteSession();
        return new BusinessResult(Const.SUCCESS_CODE, Const.SUCCESS_DELETE_MSG);
    }
    public async Task<BusinessResult> GetById(Guid sessionId)
    {
        var foundSession = await _sessionRepository.GetById(sessionId);
        if (foundSession == null) throw new NotfoundException($"Not found {sessionId}");
        if (!SessionRegistry.TryGetValue(foundSession.SessionType.Value.ToString(), out var sessionClass))
            throw new Exception("Session type not found");
        var sessionModel = _mapper.Map<SessionModel>(foundSession);
        var session = Activator.CreateInstance(sessionClass, sessionModel) as SessionBase;

        return new BusinessResult(Const.SUCCESS_CODE, Const.SUCCESS_READ_MSG,await session.GetById());
    }

    public static void RegisterProductType(string type, Type classRef)
    {
        SessionRegistry[type] = classRef;
    }

   

    public abstract class SessionBase
    {
        protected SessionBase(SessionModel payload)
        {
            Model = payload;
        }

        protected SessionModel Model { get; set; }

        public abstract Task<Session> CreateSession();
        public abstract Task<Session> UpdateSession();
        public abstract Task DeleteSession();
        public abstract Task<Session> GetById();
        

        protected async Task<Session> CreateSessionBase()
        {
            var session = new Session
            {
                Id = Guid.NewGuid(),
                ModuleId = Model.ModuleId,
                Title = Model.Title,
                Document = Model.Document,
                SessionType = Model.SessionType,
                Description = Model.Description,
                SessionNumber = Model.SessionNumber,
                CreatedDate = DateTime.Now,
                IsDeleted = false
            };
            _sessionRepository.Add(session);
            await _unitOfWork.SaveChanges();
            return session;
        }

        protected async Task<Session> UpdateSessionBase()
        {
            var session = await _sessionRepository.GetById((Guid)Model.Id);
            if (session == null) throw new Exception("Not found exception");
            session.ModuleId = Model.ModuleId;
            session.Title = Model.Title;
            session.Document = Model.Document;
            session.SessionType = Model.SessionType;
            session.Description = Model.Description;
            session.SessionNumber = Model.SessionNumber;
            session.UpdatedDate = DateTime.Now;
            _sessionRepository.Update(session);
            await _unitOfWork.SaveChanges();
            return session;
        }

        protected async Task DeleteSessionBase()
        {
            var session = await _sessionRepository.GetById((Guid)Model.Id);
            if (session == null) throw new Exception("Not found exception");
            _sessionRepository.Delete(session);
            await _unitOfWork.SaveChanges();
        }
    }

    #region Session Meeting Service
    public class SessionMeetingService : SessionBase
    {

        public SessionMeetingService(SessionModel payload) : base(payload)
        {
        }

        public override async Task<Session> CreateSession()
        {
            var converted = JsonConvert.DeserializeObject<JObject>(Model.Detail.ToString());
            var dict = new Dictionary<string, string>();
            foreach (KeyValuePair<string, JToken> keyValuePair in converted)
                dict.Add(keyValuePair.Key, keyValuePair.Value.ToString());
            var session = await CreateSessionBase();
            if (session == null) throw new Exception("Fail when create session");
            var sessionMeeting = new SessionMeeting
            {
                Id = Guid.NewGuid(),
                SessionId = session.Id,
                Host = dict!["host"],
                Date = DateTime.Parse(dict!["date"]),
                MeetingUrl = dict["meetingUrl"],
                MeetingPlatform = dict["meetingPlatform"],
                CreatedDate = DateTime.Now,
                IsDeleted = false
            };
            _sessionMeetingRepository.Add(sessionMeeting);
            await _unitOfWork.SaveChanges();

            return session;
        }

        public override async Task<Session> UpdateSession()
        {
            var session = await UpdateSessionBase();
            if (session == null) throw new Exception("Update session fail");

            var converted = JsonConvert.DeserializeObject<JObject>(Model.Detail.ToString());
            var dict = new Dictionary<string, string>();
            foreach (KeyValuePair<string, JToken> keyValuePair in converted)
                dict.Add(keyValuePair.Key, keyValuePair.Value.ToString());
            var meetingSession = await _sessionMeetingRepository.GetBySessionId(session.Id);
            meetingSession.Host = dict!["host"];
            meetingSession.Date = DateTime.Parse(dict!["date"]);
            meetingSession.MeetingUrl = dict["meetingUrl"];
            meetingSession.MeetingPlatform = dict["meetingPlatform"];

            _sessionMeetingRepository.Update(meetingSession);
            await _unitOfWork.SaveChanges();
            return session;
        }

        public override async Task DeleteSession()
        {
            var meetingSession = await _sessionMeetingRepository.GetBySessionId((Guid)Model.Id);
            if (meetingSession == null) throw new Exception("Not found session");
            _sessionMeetingRepository.Delete(meetingSession);
            await _unitOfWork.SaveChanges();
            await DeleteSessionBase();
        }


        public override async Task<Session> GetById()
        {
            var session = await _sessionRepository.GetById((Guid) Model.Id);
            session.SessionMeeting = await _sessionMeetingRepository.GetBySessionId((Guid)Model.Id);
            return session;
        }
    }
    #endregion
    #region Session Offline Service
    public class SessionOfflineService : SessionBase
    {
        public SessionOfflineService(SessionModel payload) : base(payload)
        {
        }
        public override async Task<Session> GetById()
        {
            var session = await _sessionRepository.GetById((Guid)Model.Id);
            var sessionOffline =   await _sessionOfflineRepository.GetBySessionId((Guid)Model.Id);
            session.SessionOffline = sessionOffline;
            return session;
        }
        public override async Task<Session> CreateSession()
        {
            var converted = JsonConvert.DeserializeObject<JObject>(Model.Detail.ToString());
            var dict = new Dictionary<string, string>();
            foreach (KeyValuePair<string, JToken> keyValuePair in converted)
                dict.Add(keyValuePair.Key, keyValuePair.Value.ToString());
            var session = await CreateSessionBase();
            if (session == null) throw new Exception("Fail when create session");
            var sessionOffline = new SessionOffline
            {
                Id = Guid.NewGuid(),
                SessionId = session.Id,
                Location = dict["location"],
                Date = DateTime.Parse(dict["date"]),
                Duration = int.Parse(dict["duration"])
            };
            _sessionOfflineRepository.Add(sessionOffline);
            await _unitOfWork.SaveChanges();

            return session;
        }

        public override async Task<Session> UpdateSession()
        {
            var session = await UpdateSessionBase();
            if (session == null) throw new Exception("Update session fail");

            var converted = JsonConvert.DeserializeObject<JObject>(Model.Detail.ToString());
            var dict = new Dictionary<string, string>();
            foreach (KeyValuePair<string, JToken> keyValuePair in converted)
                dict.Add(keyValuePair.Key, keyValuePair.Value.ToString());
            var offlineSession = await _sessionOfflineRepository.GetBySessionId(session.Id);
            offlineSession.Location = dict["location"];
            offlineSession.Date = DateTime.Parse(dict["date"]);
            offlineSession.Duration = int.Parse(dict["duration"]);
            _sessionOfflineRepository.Update(offlineSession);
            await _unitOfWork.SaveChanges();
            return session;
        }

        public override async Task DeleteSession()
        {
            var offlineSession = await _sessionOfflineRepository.GetBySessionId((Guid)Model.Id);
            if (offlineSession == null) throw new Exception("Not found session");
            _sessionOfflineRepository.Delete(offlineSession);
            await _unitOfWork.SaveChanges();
            await DeleteSessionBase();
        }
    }
    #endregion
    #region Session Self Learn Service
    public class SessionSelfLearnService : SessionBase
    {
        public SessionSelfLearnService(SessionModel payload) : base(payload)
        {
        }
        public override async Task<Session> GetById()
        {
            var session = await _sessionRepository.GetById((Guid)Model.Id);
            session.SessionSelfLearn = await _sessionSelfLearnRepository.GetBySessionId((Guid)Model.Id);
            return session;
        }
        public override async Task<Session> CreateSession()
        {
            var converted = JsonConvert.DeserializeObject<JObject>(Model.Detail.ToString());
            var dict = new Dictionary<string, string>();
            foreach (KeyValuePair<string, JToken> keyValuePair in converted)
                dict.Add(keyValuePair.Key, keyValuePair.Value.ToString());
            var session = await CreateSessionBase();
            if (session == null) throw new Exception("Fail when create session");
            var sessionSelfLearn = new SessionSelfLearn
            {
                Id = Guid.NewGuid(),
                SessionId = session.Id,
                SessionNumber = Model.SessionNumber,
                VideoUrl = dict["videoUrl"]
                //IsComplete = bool.Parse(dict["isComplete"]),
            };
            _sessionSelfLearnRepository.Add(sessionSelfLearn);
            await _unitOfWork.SaveChanges();

            return session;
        }

        public override async Task<Session> UpdateSession()
        {
            var session = await UpdateSessionBase();
            if (session == null) throw new Exception("Update session fail");

            var converted = JsonConvert.DeserializeObject<JObject>(Model.Detail.ToString());
            var dict = new Dictionary<string, string>();
            foreach (KeyValuePair<string, JToken> keyValuePair in converted)
                dict.Add(keyValuePair.Key, keyValuePair.Value.ToString());

            var selfLearnSession = await _sessionSelfLearnRepository.GetBySessionId(session.Id);
            selfLearnSession.SessionNumber = int.Parse(dict["sessionNumber"]);
            selfLearnSession.VideoUrl = dict["videoUrl"];
            _sessionSelfLearnRepository.Update(selfLearnSession);
            await _unitOfWork.SaveChanges();
            return session;
        }

        public override async Task DeleteSession()
        {
            var selfLearnSession = await _sessionSelfLearnRepository.GetBySessionId((Guid)Model.Id);
            if (selfLearnSession == null) throw new Exception("Not found session");
            _sessionSelfLearnRepository.Delete(selfLearnSession);
            await _unitOfWork.SaveChanges();
            await DeleteSessionBase();
        }
    }
    #endregion
}