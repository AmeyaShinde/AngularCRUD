using AutoMapper;
using BackEndAPI.DTOs;
using BackEndAPI.Models;
using BackEndAPI.Services.Contract;
using BackEndAPI.Utilities;
using Microsoft.AspNetCore.Mvc;

namespace BackEndAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeService _employeeService;
        private readonly IMapper _mapper;

        public EmployeeController(IEmployeeService employeeService, IMapper mapper)
        {
            _employeeService = employeeService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            ResponseAPI<List<EmployeeDTO>> _response;

            try
            {
                List<Employee> employeeList = await _employeeService.GetList();

                if (employeeList.Count > 0)
                {
                    List<EmployeeDTO> dtoList = _mapper.Map<List<EmployeeDTO>>(employeeList);
                    _response = new ResponseAPI<List<EmployeeDTO>> { Status = true, Msg = "Ok", Value = dtoList };
                }
                else
                {
                    _response = new ResponseAPI<List<EmployeeDTO>> { Status = false, Msg = "No data" };
                }

                return StatusCode(StatusCodes.Status200OK, _response);
            }
            catch (Exception ex)
            {
                _response = new ResponseAPI<List<EmployeeDTO>> { Status = false, Msg = ex.Message };
                return StatusCode(StatusCodes.Status500InternalServerError, _response);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Post(EmployeeDTO request)
        {
            ResponseAPI<EmployeeDTO> _response;

            try
            {
                Employee _model = _mapper.Map<Employee>(request);

                Employee _employeeCreated = await _employeeService.Add(_model);

                if (_employeeCreated.Id != 0)
                {
                    _response = new ResponseAPI<EmployeeDTO>
                    {
                        Status = true,
                        Msg = "Ok",
                        Value = _mapper.Map<EmployeeDTO>(_employeeCreated)
                    };
                }
                else
                {
                    _response = new ResponseAPI<EmployeeDTO> { Status = false, Msg = "Could not create" };
                }

                return StatusCode(StatusCodes.Status200OK, _response);
            }
            catch (Exception ex)
            {
                _response = new ResponseAPI<EmployeeDTO> { Status = false, Msg = ex.Message };
                return StatusCode(StatusCodes.Status500InternalServerError, _response);
            }
        }

        [HttpPut]
        public async Task<IActionResult> Put(EmployeeDTO request)
        {
            ResponseAPI<EmployeeDTO> _response;

            try
            {
                Employee _model = _mapper.Map<Employee>(request);
                Employee _employeeEdited = await _employeeService.Update(_model);

                _response = new ResponseAPI<EmployeeDTO>
                {
                    Status = true,
                    Msg = "Ok",
                    Value = _mapper.Map<EmployeeDTO>(_employeeEdited)
                };

                return StatusCode(StatusCodes.Status200OK, _response);
            }
            catch (Exception ex)
            {
                _response = new ResponseAPI<EmployeeDTO> { Status = false, Msg = ex.Message };
                return StatusCode(StatusCodes.Status500InternalServerError, _response);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            ResponseAPI<bool> _response;

            try
            {
                Employee _employeeFound = await _employeeService.Get(id);
                bool deleted = await _employeeService.Delete(_employeeFound);

                if (deleted)
                {
                    _response = new ResponseAPI<bool> { Status = true, Msg = "Ok" };
                }
                else
                {
                    _response = new ResponseAPI<bool> { Status = false, Msg = "Could not delete" };
                }

                return StatusCode(StatusCodes.Status200OK, _response);
            }
            catch (Exception ex)
            {
                _response = new ResponseAPI<bool> { Status = false, Msg = ex.Message };
                return StatusCode(StatusCodes.Status500InternalServerError, _response);
            }
        }
    }
}