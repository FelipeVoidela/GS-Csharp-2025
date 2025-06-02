using System;

namespace GS
{
    // Classe para registrar eventos no sistema, como cadastro, falhas, alertas, etc.
    public class LogEvento
    {
        // Data e hora do evento, preenchida automaticamente ao criar o log
        public DateTime Data { get; private set; }

        // Tipo do evento (ex: Cadastro, Falha, Alerta)
        public string Tipo { get; private set; }

        // Mensagem descritiva do evento
        public string Mensagem { get; private set; }

        // Construtor que recebe tipo e mensagem, data preenchida com hora atual
        public LogEvento(string tipo, string mensagem)
        {
            Data = DateTime.Now;
            Tipo = tipo;
            Mensagem = mensagem;
        }

        // Exibe log formatado com data, tipo e mensagem
        public override string ToString()
        {
            return $"[{Data:dd/MM/yyyy HH:mm}] [{Tipo}] {Mensagem}";
        }
    }
}
