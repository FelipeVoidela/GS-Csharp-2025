namespace GS
{
    // Classe que representa um usuário do tipo visitante
    public class UsuarioVisitante : Usuario
    {
        // Construtor que chama o construtor da classe base (Usuario)
        public UsuarioVisitante(string nome, string senha) : base(nome, senha) { }

        // Implementação do método ExibirMenu para usuários visitantes
        public override void ExibirMenu()
        {
            Console.WriteLine("Você é um visitante. Acesso limitado concedido.");
        }
    }
}
