using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Text;
using UdemyProject.Models;

namespace loginuser.Controllers;
[ApiController]
[Route("[controller]")]
[Authorize]
public class BasketController : ControllerBase
{
    private readonly EducationContext _context;
    public BasketController(IConfiguration configuration)
    {
        _context = new EducationContext();
    }

    [HttpGet("GetBasketByUserId/{id}")]
    public List<BasketVM> GetBasketByUserId(int id)
    {
        List<BasketVM> baskets = _context.Baskets.Where(x => x.UserId == id).Select(x => new BasketVM { Id = x.Id, CreatedDate = x.CreatedDate,User=_context.Users.FirstOrDefault(y=>y.Id==x.UserId), Lesson = _context.Cards.FirstOrDefault(y => y.Id == x.LessonId) }).ToList();
        return baskets;

    }
    [HttpPost("AddToCard")]
    public Basket AddToCard([FromBody] Basket basket)
    {
        basket.CreatedDate = DateTime.Now;
        _context.Baskets.Add(basket);
        _context.SaveChanges();
        return basket;

    }
    [HttpGet("DeleteBasketById/{id}")]
    public Basket? DeleteBasketById(int id)
    {
       Basket? basket =  _context.Baskets.FirstOrDefault(x => x.Id == id);
        if(basket != null)
        {
            _context.Baskets.Remove(basket);
            _context.SaveChanges();
        }
        
        return basket;

    }

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
