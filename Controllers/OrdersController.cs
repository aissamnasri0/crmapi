using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using tpcrm.Models;
namespace tpcrm.Controllers;
[Authorize]
[ApiController]
[Route("[controller]")]
[Produces("application/json")]
public class OrdersController : ControllerBase
{

    public readonly CrmContext _context;

    public OrdersController(CrmContext context)
    {
        this._context = context;

    }

    [HttpGet]
    public IEnumerable<Orders> Get()
    {
        return _context.orders.ToList();
    }
    [HttpGet]
    [Route("{id}")]
    public Orders Get(int id)
    {
        return _context.orders.Find(id);
    }
    [HttpPost]
    [Route("add")]
    public List<Orders> post([FromBody] Orders order)
    {
        _context.orders.Add(order);
        _context.SaveChanges();

        return _context.orders.ToList();
    }
    [HttpPut]
    [Route("edit/{id}")]
    public List<Orders> put(int id, Orders order)
    {
        var ord = _context.orders.Find(id);
        ord.TypePresta = order.TypePresta;
        ord.Nameclient = order.Nameclient;
        ord.NbJours = order.NbJours;
        ord.TjmHt = order.TjmHt;
        ord.Tva = order.Tva;
        ord.State = order.State;
        ord.Comment = order.Comment;

        _context.SaveChanges();
        return _context.orders.ToList();
    }
    [HttpDelete]
    [Route("{id}")]
    public List<Orders> deleteProduit(int id)
    {
        var order = _context.orders.Find(id);
        _context.orders.Remove(order);
        _context.SaveChanges();
        return _context.orders.ToList();
    }

}
