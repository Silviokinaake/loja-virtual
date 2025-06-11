# Feedback - Avaliação Geral

## Front End

### Navegação
  * Pontos positivos:
    - Projeto MVC funcional com rotas e views implementadas para produtos e categorias.

  * Pontos negativos:
    - Ausência de API REST.
    - Não há controle de navegação entre múltiplas camadas.

### Design
  - Interface básica, funcional, suficiente para exibição e cadastro de entidades.

### Funcionalidade
  * Pontos positivos:
    - CRUD de produtos e categorias está implementado no projeto MVC.

  * Pontos negativos:
    - Não há nenhuma implementação de entidade `Vendedor`.
    - Produtos não estão associados ao usuário logado.
    - Não há integração com `IdentityUser` nem associação ao criar produtos.
    - Não há API nem camada `Core` agregadora.
    - Falta de migrations automáticas e seed de dados.
    - Cadastro de vendedores ausente.

## Back End

### Arquitetura
  * Pontos positivos:
    - Projeto MVC bem encapsulado como uma aplicação única.

  * Pontos negativos:
    - Falta de separação de responsabilidades: apenas uma camada está presente.
    - Ausência de API e de camada central de domínio ou repositórios.
    - Lógica de negócio e persistência misturadas no controller.

### Funcionalidade
  * Pontos positivos:
    - Operações de produtos e categorias básicas funcionam.

  * Pontos negativos:
    - Não há autenticação funcional com Identity configurado completamente.
    - Produtos não estão vinculados a usuários.
    - Não há verificação de propriedade para edição ou exclusão.
    - Não há API REST para consumo externo.

### Modelagem
  * Pontos positivos:
    - Entidades `Produto` e `Categoria` bem estruturadas.

  * Pontos negativos:
    - Entidade `Vendedor` está ausente, o que compromete o escopo.
    - Modelagem incompleta frente aos requisitos do projeto.

## Projeto

### Organização
  * Pontos positivos:
    - Estrutura interna do projeto é simples e clara.

  * Pontos negativos:
    - Apenas um projeto no `src`, faltam os demais projetos exigidos (API, Core).
    - Solução (`.sln`) não representa múltiplas camadas.
    - Dependências e arquivos de configuração misturados.

### Documentação
  * Pontos positivos:
    - README.md presente.

  * Pontos negativos:
    - README não apresenta detalhes técnicos nem orientações de execução.

### Instalação
  * Pontos positivos:
    - Projeto executável localmente com estrutura básica.

  * Pontos negativos:
    - Migrations e seed automáticos ausentes.
    - Não utiliza SQLite como requerido.

---

# 📊 Matriz de Avaliação de Projetos

| **Critério**                   | **Peso** | **Nota** | **Resultado Ponderado**                  |
|-------------------------------|----------|----------|------------------------------------------|
| **Funcionalidade**            | 30%      | 5        | 1,5                                      |
| **Qualidade do Código**       | 20%      | 7        | 1,4                                      |
| **Eficiência e Desempenho**   | 20%      | 5        | 1,0                                      |
| **Inovação e Diferenciais**   | 10%      | 5        | 0,5                                      |
| **Documentação e Organização**| 10%      | 8        | 0,8                                      |
| **Resolução de Feedbacks**    | 10%      | 0        | 0,0                                      |
| **Total**                     | 100%     | -        | **5,2**                                  |

## 🎯 **Nota Final: 5,2 / 10**
