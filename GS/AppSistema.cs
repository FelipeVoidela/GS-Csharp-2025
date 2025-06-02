using System;
using System.Collections.Generic;

namespace GS
{
    // Classe principal que gerencia o sistema de Rede Colaborativa de Energia
    public class AppSistema
    {
        // Lista que armazena todos os geradores cadastrados
        private List<Gerador> geradores = new();

        // Lista que armazena os logs de eventos do sistema
        private List<LogEvento> logs = new();

        // Dicionário com instâncias de usuário
        private Dictionary<string, Usuario> usuarios = new()
        {
            { "admin", new UsuarioAdmin("admin", "123") },
            { "visitante", new UsuarioVisitante("visitante", "123") }
        };

        // Armazena o usuário logado
        private Usuario usuarioLogado;

        // Método principal que inicia o sistema e gerencia o menu
        public void Iniciar()
        {
            Console.WriteLine("Bem-vindo à Rede Colaborativa de Energia");

            // Realiza o login do usuário; se falhar, encerra o sistema
            if (!Login())
            {
                Console.WriteLine("Encerrando o sistema...");
                return;
            }

            // Loop principal do menu de opções
            while (true)
            {
                Console.WriteLine("\nMenu Principal:");
                Console.WriteLine("1. Cadastrar Gerador Solar");
                Console.WriteLine("2. Registrar Falha");
                Console.WriteLine("3. Gerar Alerta de Consumo");
                Console.WriteLine("4. Exibir Logs de Eventos");
                Console.WriteLine("5. Relatório de Status dos Geradores");
                Console.WriteLine("0. Sair");
                Console.Write("Escolha uma opção: ");

                try
                {
                    // Tenta ler e converter a opção do usuário
                    int opcao = int.Parse(Console.ReadLine());
                    switch (opcao)
                    {
                        case 1:
                            CadastrarGerador();
                            break;
                        case 2:
                            RegistrarFalha();
                            break;
                        case 3:
                            GerarAlerta();
                            break;
                        case 4:
                            ExibirLogs();
                            break;
                        case 5:
                            RelatorioStatus();
                            break;
                        case 0:
                            return; // Encerra o programa
                        default:
                            Console.WriteLine("Opção inválida.");
                            break;
                    }
                }
                catch (Exception ex)
                {
                    // Captura erros inesperados na entrada do usuário e exibe mensagem
                    Console.WriteLine($"Erro: {ex.Message}");
                }
            }
        }

        // Login do usuário com validação
        private bool Login()
        {
            Console.Write("Usuário: ");
            string nomeUsuario = Console.ReadLine();

            Console.Write("Senha: ");
            string senha = Console.ReadLine();

            if (usuarios.TryGetValue(nomeUsuario, out Usuario usuario) && usuario.VerificarSenha(senha))
            {
                usuarioLogado = usuario;
                Console.WriteLine($"Login bem-sucedido! Bem-vindo, {usuario.Nome}.");
                usuario.ExibirMenu();
                return true;
            }

            Console.WriteLine("Usuário ou senha inválidos.");
            return false;
        }

        // Função para cadastrar um novo gerador solar
        private void CadastrarGerador()
        {
            Console.Write("Nome do Gerador: ");
            string nome = Console.ReadLine();

            // Validação da capacidade inserida: deve ser um número positivo
            Console.Write("Capacidade (kWh): ");
            if (!double.TryParse(Console.ReadLine(), out double capacidade) || capacidade <= 0)
            {
                Console.WriteLine("Valor inválido para capacidade.");
                return;
            }

            // Cria o gerador e adiciona na lista
            geradores.Add(new Gerador(nome, capacidade));

            // Registra evento de cadastro no log
            logs.Add(new LogEvento("Cadastro", $"Gerador '{nome}' cadastrado com capacidade de {capacidade} kWh."));

            Console.WriteLine("Gerador cadastrado com sucesso.");
        }

        // Método para registrar uma falha em um gerador já cadastrado
        private void RegistrarFalha()
        {
            Console.Write("ID do Gerador: ");

            // Valida se o ID é válido (índice dentro da lista)
            if (!int.TryParse(Console.ReadLine(), out int id) || id < 0 || id >= geradores.Count)
            {
                Console.WriteLine("ID inválido.");
                return;
            }

            // Altera o status do gerador para Falha
            geradores[id].Status = StatusGerador.Falha;

            // Adiciona log da falha
            logs.Add(new LogEvento("Falha", $"Falha registrada no gerador '{geradores[id].Nome}'."));

            Console.WriteLine("Falha registrada com sucesso.");
        }

        // Método para gerar alerta baseado no consumo informado
        private void GerarAlerta()
        {
            Console.Write("Consumo atual (kWh): ");

            // Valida se o consumo informado é um número válido e positivo
            if (!double.TryParse(Console.ReadLine(), out double consumo) || consumo < 0)
            {
                Console.WriteLine("Consumo inválido.");
                return;
            }

            // Condição simples: consumo acima de 100 kWh gera alerta
            if (consumo > 100)
            {
                logs.Add(new LogEvento("Alerta", "Consumo elevado detectado."));
                Console.WriteLine("Alerta: Consumo elevado!");
            }
            else
            {
                Console.WriteLine("Consumo dentro dos limites.");
            }
        }

        // Exibe todos os logs de eventos registrados
        private void ExibirLogs()
        {
            Console.WriteLine("\n=== Logs de Eventos ===");
            foreach (var log in logs)
            {
                Console.WriteLine(log);
            }
        }

        // Exibe um relatório do status atual de todos os geradores cadastrados
        private void RelatorioStatus()
        {
            Console.WriteLine("\n=== Relatório de Geradores ===");
            for (int i = 0; i < geradores.Count; i++)
            {
                Console.WriteLine($"[{i}] {geradores[i]}");
            }
        }
    }
}
