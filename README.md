# Integrantes
| RM       | Nome                          |
| :------- | :---------------------------- |
| `554012` | `Gabriel Pescarolli Galiza`   |
| `554258` | `Guilherme Gambarão Baptista` |
| `553640` | `Marcelo Vieira Junior`       |

## Objetivo proposto pela OdontoPrev

Os alunos serão desafiados a criar soluções inovadoras focadas na 
redução de sinistros no setor odontológico. Especificamente, o desafio 
envolve o uso de análise preditiva para antecipar e mitigar situações de 
sinistro relacionadas aos atendimentos odontológicos.
O objetivo central é criar soluções que utilizem análise preditiva para 
reduzir sinistros.


## Escopo
A ideia é uma aplicação de software de triagem de dados da consulta antes de realizar a marcação, onde é feito um relatório através da descrição do paciente e a descrição da consulta realizada, e então realizar uma análise, que indica a porcentagem de veracidade de uma consulta odontológica, dessa forma previnimos possíveis fraudes. 
Vale ressaltar que essa porcentagem não substitui a análise de um profissional da OdontoPrev, a ideia é que os profissionais da OdontoPrev irão priorizar e analisar os casos com maior porcentagem de veracidade do problema.


## Sumário
- [Passos para rodar a Aplicação](#1-como-rodar-a-aplicação)
- [Definição e Implementação da Arquitetura](#2-definição-e-implementação-da-arquitetura-da-api)
- [Requisitos](#21-requisitos)
- [Domínio](#23-domínio)
- [Classes](#24-classes-implementadas)
- [Banco de Dados Oracle](#27-banco-de-dados-oracle)
- [Configuração CORS](#28-configuração-cors)
- [Instruções de Instalação e Configuração](#3-instruções-de-instalação-e-configuração)
- [API Endpoints](#4-api-endpoints)

---
## 1. Como rodar a aplicação

1. **Acesse o diretorio do projeto**
    ```bash
    cd Challenge_DAS_dotNet/ChallengerSprint3ABDWN/
    ```

2. **Restaure dependências do projeto**
    ```bash
    dotnet restore
    ```

3. **Rode o projeto**
    ```bash
    dotnet run
    ```

---
## 2. Definição e Implementação da Arquitetura da API

A escolha entre monolítica ou microserviços depende muito do contexto do projeto, na arquitetura monolítica, toda
a aplicação é construída como um único bloco coeso, ou seja, todos os componentes e funcionalidades estão em um 
único projeto e são interligados, já a arquitetura de microserviços, divide a aplicação em pequenos serviços
independentes, cada um responsável por um parte específica da funcionalidade, cada serviço é autônomo.

Para o nosso projeto optamos por uma abordagem monolítica, por conta de ser um sistema menor a abordagem 
monolítica era mais vantajosa para facilidade de implementação e de manutenção, e trazendo um melhor desempenho 
atendendo os requisitos do projeto de forma eficaz. A abordagem de microserviços seria mais vantajosa para 
sistemas maiores, com requisitos de escabilidade e resiliência mais complexos.


### 2.1 Requisitos

#### Requisitos Funcionais
> cadastro, atualização de dados, listagem dos clientes e a remoção de clientes.
>
> cadastro, login, atualização de dados, listagem de clinicas.
>
> cadastro, atualização de dados e listagem dos relatórios.

#### Requisitos Não Funcionais
> A aplicação deve ser responsiva e fácil de usar. 
> 
> Garantir a segurança de dados dos usuários.


### 2.2 Clean Architecture
O projeto considera a utilização de uma arquitetura limpa para separar responsabilidades, facilitando a manutenção
e o teste do código. A camada models contém as entidades necessárias para o projeto e suas regras de negócio, a 
camada DTOs contém as classes DTOs necessárias para isolar a camada models, garantindo assim que não ocorra a 
exposição direta das entidades e manter o controle sobre quais dados são transmitidos, a camada repositories 
apresenta os repositorios que conversam com o banco de dados e suas respectivas interfaces com cada um dos seus
métodos, permitindo que a camada que conversa com o banco não se relacione diretamente com a controller e sim sua
interface faça esse relacionamento e a camada controller apresenta os métodos HTTPs com suas operações estabelecidas
para cada uma das entidades.


### 2.3 Domínio 
As principais entidades do domínio incluem:

- **Clinica** representa as clínicas ondontológicas e seus atributos necessários.
- **Cliente** representa os pacientes e seus atributos necessários.
- **Relatorio** contém os detalhes sobre as consultas realizadas.
- **Endereco** armazena informações de endereços relacionadas as clinicas e aos clientes.


### 2.4 Classes Implementadas
- **Clinica** contém os dados necessários da clínica, já sendo definido qual é [Required] e qual não é preciso ser
e apresenta as regras de negócio necessárias, sendo a que valida o cnpj através da função que considera apenas os 
números e verifica se o tamanho é o adequado, e a que valida o formato do email através do [EmailAddress]


- **Cliente** contém os dados do cliente, já definindo os que serão [Required] e valida o cpf considerando apenas
os números e verificando se tem o tamanho adequado.


- **Relatorio** Detalha as informações sobre a consulta.


- **Endereco** Gerencia os dados dos endereços, além disso, é feita a validação do cep, onde apenas os números são
considerados e é verificado se o tamanho está adequado ao padrão.


- **Controllers** as controllers para cada classe segue cada uma com suas operações CRUD e seus métodos HTTP, as
funções estabelecidas para essas operações e métodos foram estabelecidas no requisito funcional do projeto, vale
ressaltar o uso de DTOs nas controllers de cliente e clinica com o intuito de preservas certas informações da 
classe e seguir a ideia para cada DTO criada, nas operações de inserir novos clientes e clinicas é usada a classe
models para que todos os dados sejam inseridos no banco, além disso, cada um dos endpoints e seus modelos de dados
foram documentados.

### 2.5 DTOs
- **LoginDTO** essa classe foi criada para efetuar o login da clínica sem precisar manipular a entidade e todos seus
atributos.


- **ClienteDTO** criada para atualizar os dados dos cliente, e como tem dados que não podem ser alterados esse DTO
é para manipular apenas os dados necessários.


- **ClinicaDTO** criada para a listagem da clínica, esse DTO é usado para a segurança de dados, evitando manipular
a entidade e proteger dados como cnpj e senha.


### 2.6 REPOSITORIES
- **ClienteRepository** criada para conversar com a tabela cliente no banco de dados, tornando possível as operações
CRUD.


- **ClinicaRepository** criada para conversar com a tabela das clinicas no banco de dados, possibilitando as operações
estabelecidas para essa classe.


- **RelatorioRepository** segue o mesmo padrão das outras repositories, foi criada para conversar com o banco permitindo
as operações CRUD.


- **InterfacesRepositories** as interfaces repository criada para cada classe repository tem o intuito de trazer mais segurança ao código, pois dessa forma a pasta controller não conversa diretamente com as classes que chamam o banco de dados, é necessário passar a informação ao program.cs para que toda vez que a classe interface for  chamada a repository relacionada aos seus métodos é acionada.

> OBS: Optamos por fazer essa ação direta no program.cs ao invés de criar uma parta extension por conta de não haver muitas classes repositorys no código.

### 2.7 Banco de Dados Oracle

A aplicação utiliza o banco de dados Oracle para persistência dos dados. A string de conexão deve ser configurada no arquivo `appsettings.json` na chave `"OracleFIAPDbContext"`. Certifique-se de que o banco esteja acessível e as credenciais estejam corretas para o funcionamento da aplicação.

### 2.8 Configuração CORS

Foi configurada uma política CORS chamada `"PermitirTudo"` que permite requisições de qualquer origem, método e cabeçalho. Essa configuração facilita o desenvolvimento e testes, permitindo que clientes externos acessem a API sem restrições de origem.

### 2.9 Uso de DTOs e Repository Pattern

O projeto utiliza Data Transfer Objects (DTOs) para isolar a camada de domínio da camada de apresentação, garantindo que apenas os dados necessários sejam expostos ou recebidos pelas APIs. As operações de inserção geralmente utilizam as entidades do domínio diretamente, enquanto atualizações e listagens utilizam DTOs para maior controle e segurança.

O padrão Repository é utilizado para abstrair o acesso ao banco de dados, facilitando a manutenção e testes. Cada entidade possui sua interface e implementação de repositório, que são injetadas nas controllers via Dependency Injection configurada no `Program.cs`.

---
## 3. Instruções de Instalação e Configuração

> No entregável constará tanto o link do repositório no github com o projeto como o arquivo do projeto, caso opte pelo link do github, clone o repositório.

> Configurar a string de conexão do seu banco de dados Oracle no arquivo appsettings.json.

> Restaurar as dependências do projeto, através do comando 'dotnet restore' na aba do terminal.

> Execute o comando para aplicar as migrations, dessa forma você criará ou atualizará suas tabelas no banco de dados oracle conforme foi estabelecido no projeto.

---
## 4. API Endpoints

A aplicação expõe os seguintes endpoints da api:

| Entidade | Método HTTP | Rota                  | Descrição                         |
|----------|-------------|-----------------------|-----------------------------------|
| Cliente  | GET         | /api/cliente          | Lista todos os clientes           |
| Cliente  | GET         | /api/cliente/{id}     | Busca cliente por ID              |
| Cliente  | POST        | /api/cliente          | Insere novo cliente               |
| Cliente  | PUT         | /api/cliente/{id}     | Atualiza cliente por ID           |
| Cliente  | DELETE      | /api/cliente/{id}     | Remove cliente por ID             |
| Clinica  | GET         | /api/clinica          | Lista todas as clínicas           |
| Clinica  | GET         | /api/clinica/{id}     | Busca clínica por ID              |
| Clinica  | POST        | /api/clinica          | Insere nova clínica               |
| Clinica  | PUT         | /api/clinica/{id}     | Atualiza clínica por ID           |
| Clinica  | POST        | /api/clinica/login    | Login da clínica                  |
| Clinica  | DELETE      | /api/clinica/{id}     | Remove clínica por ID             |
| Relatorio| GET         | /api/relatorio        | Lista todos os relatórios         |
| Relatorio| GET         | /api/relatorio/{id}   | Busca relatório por ID            |
| Relatorio| POST        | /api/relatorio        | Insere novo relatório             |
| Relatorio| PUT         | /api/relatorio/{id}   | Atualiza relatório por ID         |
| Relatorio| DELETE      | /api/relatorio/{id}   | Remove relatório por ID           |
