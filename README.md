# Desafio Locadora de DVD

## Descrição do Projeto

O desafio consiste em desenvolver uma API para gerenciar um CRUD de DVDs utilizando o .NET 8 ou superior. A arquitetura do projeto deve incluir dois bancos de dados: um não relacional (MongoDB) para leitura e um relacional (PostgreSQL) para escrita. Além disso, a aplicação deve integrar um sistema de mensagens com RabbitMQ e utilizar o Redis como cache, implementando um padrão RESTful.

## Requisitos

- **Framework**: O projeto deve ser desenvolvido com .NET 8 ou superior.
- **Bancos de Dados**:
  - 🗄️ **Relacional**: PostgreSQL para operações de escrita.
  - 📚 **Não Relacional**: MongoDB para operações de leitura.
- **Cache**: 
  - 🗄️ **Redis** para cache das operações de leitura.
- **Mensageria**: Implementar um Publisher e um Consumer utilizando RabbitMQ.
- **API**: A API deve seguir o padrão REST.

## Objetivo

O objetivo do projeto é desenvolver uma API que permita as seguintes operações CRUD para DVDs:

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

## Conclusão

Esse projeto visa proporcionar uma experiência completa de gerenciamento de DVDs, integrando tecnologias modernas e melhores práticas de desenvolvimento. Se você tiver alguma dúvida ou sugestão, fique à vontade para contribuir!
