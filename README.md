# iWANT

Aplicação é uma API REST que possui endpoinsts para listagem, cadastro, atualização e deletar registros relacionados a:

* Pedidos (Orders)
	* Categorias (Categories)
* Produtos (Products)
* Usuários (Users) 
	* Clientes (Clients)
	* Funcionários (Employees)
* Segurança 
	Token
	Login

Durante a construção foram implementados conceitos como a `injeção de dependências`, que proporciona a chamada de funcões com uma quantidade menor de parâmetros, contribuindo para a legibilidade do código.

Foi implementada a autenticação JWT, e utilizado Entity Framework como ORM de gerenciamento de tabelas do banco de dados.

Aplicação construida durante o curso **.NET 6 WEB API - Do zero ao avançado**

Link: https://www.udemy.com/course/net-6-web-api-do-zero-ao-avancado

## Screenshots

![Certificado](https://github.com/italosll/iwant-backend/blob/main/src/.github/course-certificate.jpg?raw=true)

## Stack utilizada

**Back-end:** C#, .NET core 6, Entity Framework.

## Rodando localmente

Clone o projeto

```bash
  git clone https://github.com/italosll/iwant-backend.git
```

Abra o projeto no Microsoft Visual Studio, em seguida inicie o projeto.