using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Text;
using UdemyProject.Models;

namespace loginuser.Controllers;
[ApiController]
[Route("[controller]")]
[Authorize]
public class LessonController : ControllerBase
{
    private readonly EducationContext _context;
    public LessonController(IConfiguration configuration)
    {
        _context = new EducationContext();
    }

    [HttpGet]
    public List<Card> Get()
    {
        List<Card> cards = _context.Cards.ToList();
        return cards;
    }
    [HttpGet("{id}")]
    public Card Get(int id)
    {
        Card card = _context.Cards.FirstOrDefault(x => x.Id == id);
        return card;

    }
    //[HttpPost]
    //public void Post(Product product)
    //{
    //    var id = Store.Products.Max(x => x.Id) + 1;
    //    product.Id = id;
    //    Store.Products.Add(product);
    //}
    //[HttpPut]
    //public void Put(Product product)
    //{
    //    var entity = Store.Products.FirstOrDefault(x => x.Id == product.Id);
    //    entity.Name = product.Name;
    //    entity.Description = product.Description;
    //    entity.Price = product.Price;
    //    entity.Image = product.Image;
    //}
    //[HttpDelete]
    //public void Delete(int id)
    //{
    //    var entity = Store.Products.FirstOrDefault(x => x.Id == id);
    //    Store.Products.Remove(entity);
    //}

}

