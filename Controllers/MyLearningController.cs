using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Text;
using UdemyProject.Models;

namespace loginuser.Controllers;
[ApiController]
[Route("[controller]")]
[Authorize]
public class MyLearningController : ControllerBase
{
    private readonly EducationContext _context;
    public MyLearningController(IConfiguration configuration)
    {
        _context = new EducationContext();
    }

    [HttpGet("GetMyLearningByUserId/{id}")]
    public List<MyLearningVM> GetMtLearningByUserId(int id)
    {
        List<MyLearningVM> myLearnings = _context.Mylearnings.Where(x => x.UserId == id).Select(x => new MyLearningVM { Id = x.Id, CreatedDate = x.CreatedDate,User=_context.Users.FirstOrDefault(y=>y.Id==x.UserId), Lesson = _context.Cards.FirstOrDefault(y => y.Id == x.LessonId) }).ToList();
        return myLearnings;
    }

    [HttpPost("AddToMyLearning")]
    public MyLearning AddToMyLearning([FromBody] MyLearning myLearning)
    {
        myLearning.CreatedDate = DateTime.Now;
        _context.Mylearnings.Add(myLearning);
        _context.SaveChanges();
        return myLearning;

    }
}

