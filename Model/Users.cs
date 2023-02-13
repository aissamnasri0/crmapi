namespace tpcrm.Models;
public class USers{
    public int Id{ get; set; }
    public string Email{ get; set; }
    public string Password{ get; set; }
    public string LastName{ get; set; }
    public string FirstName{ get; set; }
    public string ConfirmesPassword{ get; set; }
    public string Grants { get; set; }

    public USers(){
    
    }
}