# DesafioTargetSistemas

> Repositório com soluções para o desafio técnico da Target Sistemas — contendo dois mini-projetos em C# de gerenciamento de estoque e comissão.

## 📂 Estrutura do Repositório

DesafioTargetSistemas/
│
├── comissaoVendas/ ← Projeto para cálculo de comissão de vendas
│ ├── comissaoVendas.csproj
│ └── Program.cs
│
├── movimentacaoEstoque/ ← Projeto para movimentações de estoque (entrada/saída + juros/multa)
│ ├── movimentacaoEstoque.csproj
│ └── Program.cs
│
└── calcularJuros/ ← Projeto para calcular juros simples (exercício separado)
└── Program.cs

yaml
Copy code

> ✅ Cada pasta representa um projeto C# independente — você roda cada um separadamente com `dotnet run`.

---

## 💡 O Que Cada Projeto Faz

### `comissaoVendas`
- Recebe dados de vendas ou valores (pode ser expandido)  
- Calcula comissão conforme regras definidas (futuro ponto de expansão)  

### `movimentacaoEstoque`
- Lê um JSON interno com itens de “estoque”  
- Permite informar um **código de produto** e uma operação — entrada ou saída  
- Aplica ajuste de estoque e exibe resultado final  
- Exemplo de uso no console  

### `calcularJuros`
- Solicita **valor original** e **data de vencimento** ao usuário  
- Se a data estiver atrasada em relação ao dia atual, aplica **juros a 2,5% ao dia**  
- Exibe **dias de atraso**, **valor dos juros** e **valor final**  

---

## 🚀 Como Rodar Localmente

Para rodar qualquer um dos projetos:

```bash
# Clone o repositório
git clone https://github.com/Theus2005-dev/DesafioTargetSistemas.git
cd DesafioTargetSistemas

# Para o projeto de movimentação de estoque
cd movimentacaoEstoque
dotnet run

# Para o projeto de comissão de vendas
cd ../comissaoVendas
dotnet run

# Para o cálculo de juros simples
cd ../calcularJuros
dotnet run
🔹 Pré-requisito: ter o .NET SDK instalado (versão compatível com os projetos).

🛠 Requisitos & Tecnologias
.NET SDK (≥ .NET 6 ou superior)

C# 10+

Sem dependências externas: tudo se baseia em libs padrão (System, System.Text.Json, System.Linq, etc.)

📈 Possíveis Melhorias / Roadmap
📄 Permitir carregar inventário/estoque via arquivo JSON externo

💾 Salvar histórico de movimentações ou vendas em arquivo ou BD

📊 Gerar relatórios: estoque atual, movimentações, comissões, multas acumuladas

🔄 Criar interface gráfica (console melhorado, WPF, web, etc.)

🧪 Adicionar testes unitários para lógica de cálculo (juros, comissão, estoque)

🤝 Contribuição
Caso queira contribuir ou sugerir melhorias:

Fork esse repositório

Crie uma branch com sua feature (feature/nome-da-feature)

Commit suas alterações e envie um Pull Request

📄 Licença
Este projeto está distribuído sob a licença MIT. Veja o arquivo LICENSE para mais detalhes.

📬 Contato
Desenvolvedor: Theus2005-dev
GitHub: https://github.com/Theus2005-dev
