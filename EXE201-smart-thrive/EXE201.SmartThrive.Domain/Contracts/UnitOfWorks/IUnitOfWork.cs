﻿using EXE201.SmartThrive.Domain.Contracts.Bases;
using EXE201.SmartThrive.Domain.Contracts.Repositories;

namespace EXE201.SmartThrive.Domain.Contracts.UnitOfWorks;

public interface IUnitOfWork : IBaseUnitOfWork
{
    ISubjectRepository SubjectRepository { get; }
    IFeedbackRepository FeedbackRepository { get; }
    ISessionRepository SessionRepository { get; }
    ISessionMeetingRepository SessionMeetingRepository { get; }
    ISessionOfflineRepository SessionOfflineRepository { get; }
    ISessionSelfLearnRepository SessionSelfLearnRepository { get; }
}