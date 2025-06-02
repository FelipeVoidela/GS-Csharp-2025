Este é um sistema de console desenvolvido em C# com o objetivo de simular a gestão de uma rede colaborativa de energia solar. Ele permite o cadastro de geradores solares, registro de falhas, alertas de consumo e geração de relatórios, promovendo um ambiente de monitoramento e colaboração energética entre comunidades.

---

## Funcionalidades

- **Login de usuário (admin ou visitante) com a senha `123`**
- **Cadastro de Geradores Solares**
- **Registro de Falhas nos Geradores**
- **Geração de Alertas de Consumo**
- **Visualização de Logs de Eventos**
- **Relatório de Status dos Geradores**

---

##  Estrutura de Pastas
/GS


- AppSistema.cs - Classe principal que gerencia o sistema
- Gerador.cs - Classe que representa um gerador solar
- LogEvento.cs - Classe que registra eventos e logs do sistema
- Program.cs - Ponto de entrada do sistema
- StatusGerador.cs - Enum que define os estados de um gerador

---

##  Como Executar

### Pré-requisitos

- [.NET 8.0 SDK]

### Passos

1. **Clone este repositório:**
```bash
git clone https://github.com/FelipeVoidela/GS-Csharp-2025
```
2. Abra o projeto no Visual Studio ou no Visual Studio Code.
3. Compile o projeto e execute.
