using GS;

// Classe que representa um gerador solar
public class Gerador
{
    // Campo estático para gerar IDs únicos automáticos para cada gerador
    private static int proximoId = 0;

    // ID único do gerador 
    public int Id { get; private set; }

    // Nome do gerador
    public string Nome { get; private set; }

    // Capacidade máxima do gerador em kWh 
    public double Capacidade { get; private set; }

    // Status atual do gerador
    public StatusGerador Status { get; set; }

    // Construtor que recebe nome e capacidade e define status inicial como Ativo
    public Gerador(string nome, double capacidade)
    {
        Id = proximoId++;  // Atribui um ID sequencial único
        Nome = nome;
        Capacidade = capacidade;
        Status = StatusGerador.Ativo;
    }

    // Sobrescreve ToString para exibir informações resumidas do gerador
    public override string ToString()
    {
        return $"[ID: {Id}] {Nome} - {Capacidade} kWh - Status: {Status}";
    }
}
