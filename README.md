# Projeto API

Uma API para gerenciar transações financeiras, com autenticação baseada em API Key, construída com .NET e conectada a um banco de dados PostgreSQL.

## Sumário

* Introdução
* Requisitos
* Autenticação
* Endpoints
* Listar Transações
* Buscar Transação por TxId
* Criar Transação
* Atualizar Transação
* Excluir Transação


## Introdução

A API é uma aplicação para realizar operações de criação, leitura, atualização e exclusão (CRUD) em transações financeiras, garantindo segurança através de autenticação com API Key.

## Requisitos

* .NET 8
* Banco de dados PostgreSQL

## Pacotes Usados

* AutoMapper (13.0.1)
* Entity FrameworkCore (8.0.0)
* Entity FrameworkCore Design (8.0.0)
* Entity FrameworkCore PostgreSQL (8.0.0)
* Swashbuckle AspNetCore (6.6.2)

## Autenticação

A API utiliza API Key para autenticação. Para acessar os endpoints protegidos, inclua um cabeçalho X-API-KEY com sua chave de API válida em todas as requisições.

## Endpoints
### Listar Transações

* Rota: GET /api/transacao
* Descrição: Retorna uma lista de transações.
* Response Body Exemplo:

        {

        "transacaoId": 0,

        "txId": "string",

        "e2eId": "string",

        "pagadorNome": "string",

        "pagadorCpf": "string",

        "pagadorBanco": "string",

        "pagadorAgencia": "string",

        "pagadorConta": "string",

        "recebedorNome": "string",

        "recebedorCpf": "string",

        "recebedorBanco": "string",

        "recebedorAgencia": "string",

        "recebedorConta": "string",

        "valor": 0,

        "dataTransacao": "2024-11-11T12:38:57.264Z"

        }

### Buscar Transação por TxId

* Rota: GET /api/transacao/{txid}
* Descrição: Retorna os detalhes de uma transação específica.
* Parâmetros: txid: Identificador único da transação
* Response Body Exemplo:

        {

        "transacaoId": 0,

        "txId": "string",

        "e2eId": "string",

        "pagadorNome": "string",

        "pagadorCpf": "string",

        "pagadorBanco": "string",

        "pagadorAgencia": "string",

        "pagadorConta": "string",

        "recebedorNome": "string",

        "recebedorCpf": "string",

        "recebedorBanco": "string",

        "recebedorAgencia": "string",

        "recebedorConta": "string",

        "valor": 0,

        "dataTransacao": "2024-11-11T12:39:28.646Z"

         }

### Criar Transação

* Rota: POST /api/transacao
* Descrição: Cria uma nova transação.
* Response Body Exemplo:

        {

        "transacaoId": 0,

        "txId": "string",

        "valor": 0,

        "dataTransacao": "2024-11-11T12:39:40.842Z"

        }

### Atualizar Transação

* Rota: PUT /api/transacao/{txid}
* Descrição: Atualiza os dados de uma transação específica.
* Parâmetros: txid: Identificador da transação a ser atualizada
* Response Body Exemplo:

    
        {

        "pagadorNome": "string",

        "pagadorCpf": "string",

        "pagadorBanco": "string",

        "pagadorAgencia": "string",

        "pagadorConta": "string",

        "recebedorNome": "string",

        "recebedorCpf": "string",

        "recebedorBanco": "string",

        "recebedorAgencia": "string",

        "recebedorConta": "string",

        "valor": 0,

        "dataTransacao": "2024-11-11T12:39:52.605Z"

        }

### Excluir Transação

* Rota: DELETE /api/transacao/{txid}
* Descrição: Remove uma transação.
* Parâmetros: txid: Identificador da transação a ser excluída
* Response Body Exemplo:

        {

        "message": "Transação excluída com sucesso",

        "transacao": {

        "txId": "1d816293937f47da8f2ad264dd561e31000",

        "valor": 10,

        "e2eId": "c887c0b7-66af-4ef9-b436-55d64d352ba6",

        "dataTransacao": "0001-01-01T00:00:00"

        }

### Respostas


🟢200
Resposta bem-sucedida contendo autenticação.

🔴400
Solicitação mal-sucedida se os parâmetros estiverem incorretos ou ausentes.

🔴401
API Key inválida.
