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
    public class DepartmentController : ControllerBase
    {
        private readonly IDeparmentService _deparmentService;
        private readonly IMapper _mapper;

        public DepartmentController(IDeparmentService deparmentService, IMapper mapper)
        {
            _deparmentService = deparmentService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            ResponseAPI<List<DepartmentDTO>> _response;

            try
            {
                List<Department> departmentList = await _deparmentService.GetList();
                if (departmentList.Count > 0)
                {
                    List<DepartmentDTO> dtoList = _mapper.Map<List<DepartmentDTO>>(departmentList);
                    _response = new ResponseAPI<List<DepartmentDTO>> { Status = true, Msg = "Ok", Value = dtoList };
                }
                else
                {
                    _response = new ResponseAPI<List<DepartmentDTO>> { Status = false, Msg = "No data" };
                }

                return StatusCode(StatusCodes.Status200OK, _response);
            }
            catch (Exception ex)
            {
                _response = new ResponseAPI<List<DepartmentDTO>> { Status = false, Msg = ex.Message };
                return StatusCode(StatusCodes.Status500InternalServerError, _response);
            }
        }
    }
}