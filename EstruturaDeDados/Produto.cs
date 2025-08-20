public class Produto
{
    public int Id { get; set; }
    public string Sku { get; set; }
    public string Nome { get; set; }
    public decimal Preco { get; set; }
    public HashSet<string> Tags { get; set; } = new HashSet<string>();
}

public class Pedido
{
    public int Id { get; set; }
    public DateTime DataHora { get; set; }
}
