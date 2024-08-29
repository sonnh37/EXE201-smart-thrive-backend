using AutoMapper;
using EXE201.SmartThrive.Domain.Contracts.Services;
using EXE201.SmartThrive.Domain.Models.Requests.Commands.Student;
using EXE201.SmartThrive.Domain.Models.Requests.Commands.Subject;
using EXE201.SmartThrive.Domain.Models.Results;
using EXE201.SmartThrive.Services;
using Microsoft.AspNetCore.Mvc;
using System.Runtime.InteropServices;

namespace EXE201.SmartThrive.API.Controllers
{
    public class StudentController : Controller
    {
        private readonly ISubjectService _studentService;
        private readonly IMapper _mapper;

        public StudentController(ISubjectService subjectService, IMapper mapper) {
            _studentService = subjectService;
            _mapper = mapper;

        }

        [HttpGet]
        public async Task<IActionResult> GetAll() {
            try
            {
                var msg = await _studentService.GetAll<StudentResult>();
                return Ok(msg);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{id:guid}")]
        public async Task<IActionResult> Get(Guid id)
        {
            try
            {
                var msg = await _studentService.GetById<StudentResult>(id);
                return Ok(msg);
            }
            catch(Exception ex) 
            {
            return BadRequest(ex.Message);}
        }

        [HttpPost]
        public async Task<IActionResult> Add(StudentCreateCommand request)
        {
            try
            {
                var msg = await _studentService.Create(request);
                return Ok(msg);
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> Delete([FromRoute] Guid id)
        {
            try
            {
                var msg = await _studentService.DeleteById(id);
                return Ok(msg);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        public async Task<IActionResult> Update(StudentUpdateCommand request)
        {
            try
            {
                var msg = await _studentService.Update(request);
                return Ok(msg);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
 