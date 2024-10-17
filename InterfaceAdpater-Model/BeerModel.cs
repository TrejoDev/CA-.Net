namespace InterfaceAdpater_Model;
// ! Mi representacion del modelo en base de datos
// ! Puede ser direfentes a mis entities, xq no necesariamente necesitamos tener las mismas propiedades en la base de datos que en las reglas de negocio
public class BeerModel
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Style { get; set; }
    public decimal Alcohol { get; set; }
}
