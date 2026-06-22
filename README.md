# ApiMyRecipeBook 🍳

Uma API robusta e estruturada desenvolvida em **.NET 10**, seguindo os princípios do **Domain-Driven Design (DDD)**. O projeto foi concebido para gerir um livro de receitas digital, garantindo uma separação clara de responsabilidades, alta manutenibilidade e escalabilidade.

## 📐 Arquitetura e Estrutura do Projeto

A solução está dividida em múltiplos projetos especializados, respeitando as diretrizes do DDD e isolando as regras de negócio das preocupações de infraestrutura e comunicação externa.

```bash
ApiMyRecipeBook/
├── src/
│   ├── ApiMyRecipeBook.API/           # Porta de entrada da aplicação (Controllers)
│   ├── ApiMyRecipeBook.Application/   # Regras de negócio e validações
│   ├── ApiMyRecipeBook.Domain/        # Núcleo do domínio (Entidades, interfaces, linguagem comum)
│   └── ApiMyRecipeBook.Infrastructure/# Implementações externas (BD, e-mails, notificações)
├── src/
│   ├── ApiMyRecipeBook.Exception/     # Gestão centralizada de erros e exceções
│   └── ApiMyRecipeBook.Communication/ # Contratos de Request e Response (DTOs)
└── README.md
```

---

### 🗂️ Responsabilidade dos Projetos (Camadas)

#### 1. 🌐 Projeto API (`ApiMyRecipeBook.API`)

* **Responsabilidade:** É a porta de entrada da aplicação.
* **Funções:** * Receber os *requests* HTTP enviados pelo cliente (front-end/mobile).
* Direcionar o fluxo de execução para as camadas correspondentes (principalmente para a camada de Aplicação).
* Devolver as respostas (*responses*) apropriadas com os respetivos status codes HTTP.



#### 2. ⚡ Application Project (`ApiMyRecipeBook.Application`)

* **Responsabilidade:** Orquestração do fluxo da aplicação e execução das regras de negócio.
* **Funções:**
* Alojar as regras de negócio da API.
* Executar as validações das classes e dados que chegam a partir dos *requests* do projeto de API antes de processar a lógica.



#### 3. 🧩 Domain Project (`ApiMyRecipeBook.Domain`)

* **Responsabilidade:** O coração do ecossistema, isolado de tecnologias externas.
* **Funções:**
* Ajudar a estabelecer e refletir a **Linguagem Ubíqua** (comum a todos os membros da equipa de desenvolvimento e especialistas de negócio).
* Conter as entidades de domínio fundamentais (ex: `Usuarios.cs`, `Receita.cs`).



#### 4. ⚙️ Infrastructure Project (`ApiMyRecipeBook.Infrastructure`)

* **Responsabilidade:** Comunicação com agentes e recursos externos à API.
* **Funções:**
* Implementação real dos mecanismos de persistência de dados (Acesso à Base de Dados).
* Integração com serviços de envio de notificações e e-mails.
* Consumo de APIs externas e outros serviços de infraestrutura.



#### 5. 🚨 Projeto Exception (`ApiMyRecipeBook.Exception`)

* **Responsabilidade:** Gestão e tratamento global de erros da aplicação.
* **Funções:**
* Interromper de forma segura o fluxo de processamento da API quando ocorre uma anomalia.
* Formatar e tratar as mensagens de erro antes de serem retornadas ao front-end, garantindo segurança e clareza para o utilizador.



#### 6. ✉️ Projeto Communication (`ApiMyRecipeBook.Communication`)

* **Responsabilidade:** Definição dos contratos de comunicação de dados.
* **Funções:**
* Alojar todas as classes de **Request** e **Response** (DTOs - Data Transfer Objects).
* Centralizar tudo o que diz respeito à estrutura de dados que transita nas comunicações da API.



---

## 🛠️ Tecnologias e Ferramentas

* **Framework Principal:** .NET 10
* **Linguagem:** C# 14
* **Padrão Arquitetural:** Domain-Driven Design (DDD)

---

## 🚀 Como Executar o Projeto

1. **Clonar o repositório:**
```bash
git clone [https://github.com/gentilpedro/ApiMyRecipeBook.git](https://github.com/gentilpedro/ApiMyRecipeBook.git)
cd ApiMyRecipeBook
```


2. **Restaurar as dependências:**
```bash
dotnet restore
```


3. **Executar a API:**
```bash
dotnet run --project src/ApiMyRecipeBook.API
```