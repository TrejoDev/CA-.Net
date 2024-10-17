namespace EnterpriseLayer;
// ! Capa enterprise (Entities, reglas de negocio, etc)
// ! 1-Contiene los objetos y conceptos fundamentales del dominio del negocio. 
// ! 2-No deben conocer nada sobre el mundo exterior.
public class Beer
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Style { get; set; }
    public decimal Alcohol { get; set; }
    public bool IsStrogBeer() => Alcohol > 7.5m;
}
