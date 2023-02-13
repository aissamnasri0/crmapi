using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using tpcrm.Models;
namespace tpcrm.Controllers;
[Authorize (Roles ="ad")]
[ApiController]
[Route("[controller]")]
[Produces("application/json")]
public class ClientsController : ControllerBase
{

    public readonly CrmContext _context;

    public ClientsController(CrmContext context)
    {
        this._context = context;

    }
   
    [HttpGet]
    public IEnumerable<Clients> Get()
    {
        return _context.clients.ToList();
    }
    [HttpGet]
    [Route("{id}")]

    public Clients Get(int id)
    {
        return _context.clients.Find(id);
    }
    [HttpPost]
   [Route("add")]
    public List<Clients> post([FromBody] Clients client)
    {
        _context.clients.Add(client);
        _context.SaveChanges();

        return _context.clients.ToList();
    }
    [HttpPut]
    [Route("edit/{id}")]
    public List<Clients> put(int id, Clients client)
    {
        var cli = _context.clients.Find(id);
        cli.Name = client.Name;
        cli.State = client.State;
        cli.Tva = client.Tva;
        cli.TotalCaHt = client.TotalCaHt;
        cli.Comment = client.Comment;
        _context.SaveChanges();
        return _context.clients.ToList();
    }
    [HttpDelete]
    [Route("{id}")]
    public List<Clients> deleteProduit(int id)
    {
        var client = _context.clients.Find(id);
        _context.clients.Remove(client);
        _context.SaveChanges();
        return _context.clients.ToList();
    }

}
