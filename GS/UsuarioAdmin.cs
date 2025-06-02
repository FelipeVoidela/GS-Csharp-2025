namespace GS
{
    // Classe que representa um usuário do tipo administrador
    public class UsuarioAdmin : Usuario
    {
        // Construtor que chama o construtor da classe base (Usuario)
        public UsuarioAdmin(string nome, string senha) : base(nome, senha) { }

        // Implementação do método ExibirMenu para usuários administradores
        public override void ExibirMenu()
        {
            Console.WriteLine("Você é um administrador. Acesso completo concedido.");
        }
    }
}
