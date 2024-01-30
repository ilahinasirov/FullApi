using BusinessLayer.Abstract;
using BusinessLayer.Concrete;
using BusinessLayer.Constants;
using Dtos.UserDtos;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        public IActionResult GetAll(Exception ex)
        {
            var result = _userService.GetAll();
            if (result != null)
            {
                return Ok(result);
            }
            return BadRequest(ex.Message);
        }


        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var result = _userService.GetUserById(id);
            if (result != null)
            {
                return Ok(result);
            }
            return BadRequest();
        }


        [HttpGet("role/{roleId}")]
        public IActionResult GetListByRole(int roleId)
        {
            var result = _userService.GetListByRole(roleId);
            if (result != null)
            {
                return Ok(result);
            }
            return BadRequest();
        }


        [HttpPost]
        public IActionResult Add(User user)
        {
            var result = _userService.Add(user);
            if (result != null)
            {
                return Ok(result);
            }
            return BadRequest(Messages.UserCouldNotAdded);
        }



        [HttpPut]
        public IActionResult Update(User user)
        {
            var result = _userService.Update(user);
            if (result != null)
            {
                return Ok(result);
            }
            return BadRequest(new Exception(Messages.UserCouldNotUpdated));
        }


        [HttpDelete]

        public IActionResult Delete(User user)
        {
            var result = _userService.Delete(user);
            if (result != null)
            {
                return Ok(result);
            }
            return BadRequest(new Exception(Messages.UserCouldNotDeleted));


        }

        // I used this methods as examples for dtos
        [HttpGet("GetDto/{id}")]
        public IActionResult GetDto(int id)
        {
            var result = _userService.GetDto(id);
            if (result != null)
            {
                return Ok(result);
            }
            return BadRequest();
        }

        [HttpPut("UpdateDto/{id}")]
        public IActionResult UpdateDto(int id, UserToListDto dto)
        {
            var result = _userService.UpdateDto(id, dto);
            if (result != null)
            {
                return Ok(result);
            }
            return BadRequest(); ;

        }

        [HttpGet("GetListDto")]
        public IActionResult GetListDto()
        {
            var result = _userService.GetListDto();
            if (result != null)
            {
                return Ok(result);
            }
            return BadRequest();
        }


        [HttpPost("AddDto")]
        public IActionResult AddDto(UserToAddDto dto)
        {
            var result = _userService.AddDto(dto);
            if (result != null)
            {
                return Ok(result);
            }
            return BadRequest();
        }

    }
}
