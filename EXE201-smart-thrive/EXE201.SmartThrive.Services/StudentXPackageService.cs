﻿using AutoMapper;
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
    public class StudentXPackageService: BaseService<StudentXPackage>, IStudentXPackageService
    {
        private readonly IStudentXPackageRepository _repository;

        public StudentXPackageService(IMapper mapper, IUnitOfWork unitOfWork) : base(mapper, unitOfWork)
        {
            _repository = unitOfWork.StudentXPackageRepository;
        }
    }
}
