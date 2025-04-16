# Feedback - Avaliação Geral

## Front End
### Navegação
  * Pontos positivos:
    - O projeto possui views e rotas básicas definidas para as funcionalidades no projeto MVC.

### Design
    - Será avaliado na entrega final

### Funcionalidade
  * Pontos positivos:
    - Implementação básica de CRUD no MVC.

  * Pontos negativos:
    - Faltam implementações essenciais dos casos de uso do documento.
    - Não há separação adequada de responsabilidades, com toda lógica concentrada no projeto MVC.

## Back End
### Arquitetura
  * Pontos positivos:
    - O projeto mantém uma estrutura simples, adequada para CRUD básico.

  * Pontos negativos:
    - Existe apenas um projeto MVC, sem separação em camadas.
    - Não há uma camada centralizadora (Core) para compartilhamento de código de negócio e dados.
    - As entidades estão definidas diretamente no projeto MVC, o que dificultará muito a criação futura da API.
    - Será necessária uma grande refatoração para adequar o projeto à especificação de múltiplas camadas, o que deveria ter sido planejado desde o início de acordo com a especificação

### Funcionalidade
  * Pontos positivos:
    - Implementação básica de CRUD no Entity Framework.

  * Pontos negativos:
    - Não há criação do registro da entidade "Vendedor" no momento da criação do usuário no Identity.
    - Não utiliza SQLite conforme especificado, optando por SQL Server.
    - Faltam várias implementações necessárias do back-end conforme especificação.

### Modelagem
  * Pontos positivos:
    - Modelagem simples e direta das entidades.
    - Uso adequado do contexto do EF Core.

  * Pontos negativos:
    - As entidades estão implementadas diretamente no projeto MVC, sem isolamento em uma camada própria.
    - Faltam implementações necessárias de acordo com a especificação.

## Projeto
### Organização
  * Pontos positivos:
    - Possui pasta `src` na raiz.
    - Arquivo de solução (`.sln`) presente.

  * Pontos negativos:
    - Arquivos binários e (`.vs`) versionados no repositório, o que não é uma boa prática.
    - Falta de organização adequada em projetos separados.
    - Ausência de estrutura em camadas conforme especificação.
    - Arquivos desnecessários na raiz do repositório.

### Documentação
  * Pontos positivos:
    - Possui arquivo `README.md` com informações básicas do projeto.

  * Pontos negativos:
    - Não há arquivo `FEEDBACK.md`.
    - Não há documentação da API via Swagger (pois a API não existe).
    - A documentação existente não reflete a implementação real do projeto.

### Instalação

  * Pontos negativos:
    - Não utiliza SQLite conforme especificado.
    - Ausência de migrations automáticas.
    - Ausência de seed de dados.
    - Dependência exclusiva do SQL Server deixa a aplicação com setup complexo para execução local
