using AutoMapper;
using EXE201.SmartThrive.Domain.Contracts.Repositories;
using EXE201.SmartThrive.Domain.Contracts.Services;
using EXE201.SmartThrive.Domain.Contracts.UnitOfWorks;
using EXE201.SmartThrive.Domain.Entities;
using EXE201.SmartThrive.Services.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EXE201.SmartThrive.Services
{
    public class SessionService : BaseService<Session>, ISessionService
    {
        private static ISessionRepository _sessionRepository;
        private static ISessionMeetingRepository _sessionMeetingRepository;
        private static ISessionOfflineRepository _sessionOfflineRepository;
        private static ISessionSelfLearnRepository _sessionSelfLearnRepository;
        public SessionService(IMapper mapper, IUnitOfWork unitOfWork) : base(mapper, unitOfWork)
        {
            _sessionRepository = _unitOfWork.SessionRepository;
            _sessionMeetingRepository = _unitOfWork.SessionMeetingRepository;
            _sessionOfflineRepository = _unitOfWork.SessionOfflineRepository;
            _sessionSelfLearnRepository = _unitOfWork.SessionSelfLearnRepository;
        }

        private static readonly Dictionary<string, Type> SessionRegistry = new Dictionary<string, Type>();

        public static void RegisterProductType(string type, Type classRef)
        {
            SessionRegistry[type] = classRef;
        }


        public static async Task<object> CreateSession(string type, object payload)
        {
            if (!SessionRegistry.TryGetValue(type, out Type sessionClass))
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

            protected string? SessionType { get; set; }

            protected string? Description { get; set; }
            protected object? Detail { get; set; }

            protected SessionModel(object payload)
            {
                var dict = payload as Dictionary<string, object>;
                ModuleId = (Guid)dict!["ModuleId"];
                Title = dict["Title"] as string;
                Document = dict["Document"] as string;
                SessionType = dict["SessionType"] as string;
                Description = dict["Description"] as string;
                Detail = dict["Detail"];
            }

            public abstract Task<object> CreateSession();
            public abstract Task<object> UpdateSession(Guid sessionId);

            protected async Task<Session> CreateSessionBase(Guid sessionId)
            {
                var session = new Session
                {
                    Id = sessionId,
                    ModuleId = this.ModuleId,
                    Title = this.Title,
                    Document = this.Document,
                    SessionType = this.SessionType,
                    Description = this.Description,
                };
                 _sessionRepository.Add(session);
                return session;
            }

        }

        //public class SessionMeetingService : SessionModel
        //{
        //    public SessionMeetingService(object payload) : base(payload)
        //    {

        //    }

        //    public override async Task<object> CreateSession()
        //    {
        //        var sessionMeeting = new SessionMeeting
        //        {
        //            Id = Guid.NewGuid(),
        //        };
        //        var newSession = await _sessionMeetingRepository.Add(Detail as Dictionary<string, object>);
        //    }
        //    public override Task<object> UpdateSession(Guid sessionId)
        //    {
        //        throw new NotImplementedException();
        //    }
        //}
    }
    
}
