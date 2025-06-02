namespace GS
{
    // Classe base abstrata que representa um usuário do sistema
    public abstract class Usuario
    {
        // Nome do usuário
        public string Nome { get; }

        // Senha do usuário
        public string Senha { get; }

        // Construtor protegido para ser usado apenas por classes derivadas
        protected Usuario(string nome, string senha)
        {
            Nome = nome;
            Senha = senha;
        }

        // Método abstrato que será implementado pelas subclasses
        // Define o menu que o usuário verá ao entrar no sistema
        public abstract void ExibirMenu();

        // Método que verifica se a senha informada corresponde à senha do usuário
        public bool VerificarSenha(string senhaInformada)
        {
            return Senha == senhaInformada;
        }
    }
}
