using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Text;
using UdemyProject.Models;

namespace loginuser.Controllers;
[ApiController]
[Route("[controller]")]
[Authorize]
public class CategoryController : ControllerBase
{
    private readonly EducationContext _context;
    public CategoryController(IConfiguration configuration)
    {
        _context = new EducationContext();
    }

    [HttpGet]
    public List<Category> Get()
    {
        List<Category> categories = _context.Categories.ToList();
        return categories;
    }

    [HttpGet("{id}")]
    public Category Get(int id)
    {
        Category category = _context.Categories.FirstOrDefault(x => x.Id == id);
        return category;

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
