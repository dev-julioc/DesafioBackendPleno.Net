# Desafio Locadora de DVD

## Descrição do Projeto

O desafio consiste em desenvolver uma API para gerenciar um CRUD de DVDs utilizando o .NET 8 ou superior. A arquitetura do projeto será baseada nos princípios da **Clean Architecture**, **CQRS** (Command Query Responsibility Segregation) e **Arquitetura Orientada a Eventos**. A aplicação integrará várias ferramentas modernas para garantir eficiência e escalabilidade.

## Ferramentas Utilizadas

- **Framework**: .NET 8 ou superior.
- **Banco de Dados**:
  - 🗄️ **Relacional**: PostgreSQL para operações de escrita.
  - 📚 **Não Relacional**: MongoDB para operações de leitura.
- **Cache**:
  - 🗄️ **Redis** para cache das operações de leitura.
- **Mensageria**: 
  - 📦 **RabbitMQ** para comunicação entre componentes.
- **Comunicação**: 
  - **Mediator** para comunicação entre componentes dentro da aplicação.
  - **MassTransit** para comunicação entre serviços.
- **Contêineres**:
  - 🐳 **Docker** para facilitar a configuração e implantação do ambiente de desenvolvimento.
- **IDE**: 
  - 💻 **Visual Studio** como ambiente de desenvolvimento.

## Objetivo

O objetivo do projeto é desenvolver uma API que permita as seguintes operações CRUD para DVDs, seguindo o padrão CQRS:

### Fluxos de Operação

1. **Create (Criar)**:
   - ➕ Inserir um DVD no banco de dados de escrita (PostgreSQL).
   - 📬 Publicar uma mensagem em uma fila do RabbitMQ.
   - 📥 Consumir essa fila e atualizar o banco de leitura (MongoDB).

2. **Read (Ler)**:
   - 🔍 Consultar o DVD no cache (Redis).
   - ❓ Se não encontrar no cache, consultar o DVD no banco de dados de leitura (MongoDB).
   - 🔄 Atualizar o cache com os dados encontrados e retornar o DVD.

3. **Update (Atualizar)**:
   - ✏️ Atualizar um DVD no banco de dados de escrita (PostgreSQL).
   - 📬 Publicar uma mensagem em uma fila do RabbitMQ.
   - 📥 Consumir essa fila e atualizar o banco de leitura (MongoDB).

4. **Delete (Deletar)**:
   - ❌ Deletar um DVD do banco de dados de escrita (PostgreSQL).
   - 📬 Publicar uma mensagem em uma fila do RabbitMQ.
   - 📥 Consumir essa fila e atualizar o banco de leitura (MongoDB).
   - **Observação**: A exclusão não requer a remoção do DVD do banco de dados.

## Estrutura do Projeto

A organização do projeto é baseada na Arquitetura Limpa e CQRS, onde as responsabilidades são divididas em diferentes camadas. Isso facilita a manutenção e a escalabilidade da aplicação. As principais camadas incluem:

- **Api**: Exposição da API REST.
- **Application**: Implementação da lógica de negócios e serviços.
- **Domain**: Definição das entidades do domínio.
- **Infrastructure**: Implementação de bancos de dados, cache e comunicação.

## Conclusão

Esse projeto visa proporcionar uma experiência completa de gerenciamento de DVDs, integrando tecnologias modernas e melhores práticas de desenvolvimento. 
