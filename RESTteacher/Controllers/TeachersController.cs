using Microsoft.AspNetCore.Mvc;
using RESTteacher.Managers;
using RESTteacher.Models;

namespace RESTteacher.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TeachersController : ControllerBase
    {
        private readonly TeacherManager manager = new TeacherManager();

        // GET: api/<TeachersController>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IEnumerable<ITeacher> Get(string? name = null, int? minSalary = null, string? orderBy = null)
        {
            return manager.GetAll(name, minSalary, orderBy);
        }

        // GET api/<TeachersController>/5
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<ITeacher> Get(int id)
        {
            ITeacher? teacher = manager.GetById(id);
            if (teacher == null) return NotFound();
            return Ok(teacher);
        }

        // POST api/<TeachersController>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<ITeacher> Post([FromBody] Teacher teacher)
        {
            try
            {
                TeackerValidator.CheckName(teacher.Name);
                TeackerValidator.CheckSalary(teacher.Salary);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

            ITeacher newTeacher = manager.Add(teacher);
            string uri = Url.RouteUrl(RouteData.Values) + "/" + newTeacher.Id;
            return Created(uri, newTeacher);
        }

        /*
        // PUT api/<TeachersController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }
        */

        // DELETE api/<TeachersController>/5
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<ITeacher> Delete(int id)
        {
            ITeacher? teacher = manager.Remove(id);
            if (teacher == null) return NotFound();
            return Ok();
        }
    }
}
