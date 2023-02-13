namespace tpcrm.Models;
public class Orders{
    public int Id { get; set; }
    public string TypePresta { get; set; }
    public int NbJours { get; set; }
    public double TjmHt { get; set; }
    public int Tva { get; set; }
    public string State { get; set; }
    public string Comment { get; set; }
    public string Nameclient { get; set; }
    public int ClientId { get; set; }
   [System.Text.Json.Serialization.JsonIgnore]
    public virtual Clients? Clients { get; set; }

    public Orders(){
    
    }
}