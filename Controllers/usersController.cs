using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using tpcrm.Models;
namespace tpcrm.Controllers;
[Authorize (Roles ="nom")]
[ApiController]
[Route("[controller]")]
[Produces("application/json")]
public class usersController : ControllerBase
{
    
    public readonly CrmContext _context;
    
    public usersController(CrmContext context)
    {
        this._context = context;
        
    }

    [HttpGet]
    public IEnumerable<USers> Get()
    {
        return _context.users.ToList();
    }
     [HttpGet]
    [Route("{id}")]
    public USers Get(int id)
    {
        return _context.users.Find(id);
    }
    [HttpPost]
    [Route("add")]
    public List<USers> post([FromBody] USers user)
    {
       _context.users.Add(user);
       _context.SaveChanges();

        return _context.users.ToList();
    }
    [HttpPut]
    [Route("edit/{id}")]
    public List<USers> put(int id, USers user)
    {
        var us = _context.users.Find(id);
        us.Email=user.Email;
        us.Password=user.Password;
        us.FirstName=user.FirstName;
        us.LastName=user.LastName;
        us.ConfirmesPassword=user.ConfirmesPassword;
        us.Grants=user.Grants;

        _context.SaveChanges();
        return _context.users.ToList();
    }
    [HttpDelete]
    [Route("{id}")]
    public List<USers> deleteProduit(int id)
    {
        var user=_context.users.Find(id);
        _context.users.Remove(user);
        _context.SaveChanges();
        return _context.users.ToList();
    }

}
