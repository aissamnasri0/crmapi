namespace tpcrm.Models;
public class Clients{
public int Id { get; set; }
public string Name { get; set; }
public string State { get; set; }
public int Tva { get; set; }
public double TotalCaHt { get; set; }
public string Comment { get; set; }
public int? idOrder { get; set; }
[System.Text.Json.Serialization.JsonIgnore]
public virtual ICollection<Clients>? Orders { get; set; }
    public Clients(){
    
    }
}