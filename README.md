#  UescColcicAPI
﻿
 ## backend-project-bimujudu

Este é o repositório do projeto UescColcicAPI, uma API desenvolvida em .NET para gerenciar projetos, professores, habilidades e estudantes.

 ## Pré-requisitos

- .NET 8.0

 ## Configuração

1. Clone o repositório:
    ```sh
    git clone https://github.com/colcic-uesc/backend-project-bimujudu.git
    ```

2. Restaure as dependências:
    ```sh
    dotnet restore
    ```

3. Execute as migrações do banco de dados:
    ```sh
    dotnet ef database update --project UescColcicAPI.Service
    ```

 ## Executando o Projeto

Para iniciar a API, execute o seguinte comando na raiz do projeto:

```sh
dotnet run --project UescColcicAPI
```

A API estará disponível em http://localhost:5207/swagger/index.html.  

 ## Estrutura de Pastas

UescColcicAPI: Contém a API principal e os controladores.  
UescColcicAPI.Core: Contém as classes de domínio e modelos.  
UescColcicAPI.Service: Contém os serviços e a lógica de negócios.  

 ## Endpoints

 ### Projetos

GET /api/projects: Retorna todos os projetos.  
GET /api/projects/{id}: Retorna um projeto específico por ID.  
POST /api/projects: Cria um novo projeto.  
PUT /api/projects/{id}: Atualiza um projeto existente.  
DELETE /api/projects/{id}: Deleta um projeto.  

 ### Professores

GET /api/professors: Retorna todos os professores.  
GET /api/professors/{id}: Retorna um professor específico por ID.  
POST /api/professors: Cria um novo professor.  
PUT /api/professors/{id}: Atualiza um professor existente.  
DELETE /api/professors/{id}: Deleta um professor.  

 ### Habilidades

GET /api/skills: Retorna todas as habilidades.  
GET /api/skills/{id}: Retorna uma habilidade específica por ID.  
POST /api/skills: Cria uma nova habilidade.  
PUT /api/skills/{id}: Atualiza uma habilidade existente.  
DELETE /api/skills/{id}: Deleta uma habilidade.  

 ### Estudantes

GET /api/students: Retorna todos os estudantes.  
GET /api/students/{id}: Retorna um estudante específico por ID.  
POST /api/students: Cria um novo estudante.  
PUT /api/students/{id}: Atualiza um estudante existente.  
DELETE /api/students/{id}: Deleta um estudante.  

 ## Autores

Beatriz Oliveira  
Eduardo Watanabe  
Júlia Ramos  
Murilo Maia  

 ## Licença

Este projeto está licenciado sob a Licença MIT. Veja o arquivo LICENSE para mais detalhes.

