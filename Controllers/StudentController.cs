using ApiWithDbms.DbManagement;
using ApiWithDbms.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace ApiWithDbms.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly StudentDbManagement _context;

        public StudentController(StudentDbManagement context)
        {
            _context = context;
        }


        [HttpGet]
        public IActionResult Get()
        {
            var result = _context.Student.ToList();

            return Ok(result);
        }


        [HttpGet("Id")]
        public IActionResult Get(int id)
        {
            var student = _context.Student.FirstOrDefault(x => x.Id == id);
            return Ok(student);
        }


        [HttpPost]
        public IActionResult Post(Students model)
        {
            try
            {
                var create = _context.Add(model);
                _context.SaveChanges();
                 return Ok("Created Successfully");
            }
            catch (Exception e)
            {
                 return BadRequest(e.Message);
              
            }
        }


        [HttpPut]
        public IActionResult Put(Students model)
        {
            var update = _context.Student.Find(model.Id);

            if(update == null)
            {           
             return NotFound("Not found");
            }
            update.Name = model.Name;
            update.Address = model.Address;
            update.RollNo = model.RollNo;
            _context.SaveChanges();
            return Ok("Student updated");
        

        }

        [HttpDelete]

        public IActionResult Delete(int id)
        {
            var result = _context.Student.FirstOrDefault(e=> e.Id == id);
            if (result != null)
            {
              _context.Student.Remove(result);
                _context.SaveChanges();
                
            }
            return Ok("Done");
        }


    }
}
