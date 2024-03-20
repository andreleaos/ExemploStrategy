Exemplo de projeto utilizando o design pattern Strategy aplicado ao contexto de cadastro de filmes

Projeto implemento utilizando o C#, com um projeto de Asp.Net Core Web Api + Projetos complementares de Class library
A arquitetura foi organizada em camadas com as principais estruturas como Api, Infrastructure e Domain

A aplicação web api envia uma requisição para o contexto da app que chama uma strategy que por sua vez faz a solicitação para a camada de serviço
A camada de serviço requisita a camada de repositorio que processará as informações de "banco de dados" (no caso uma lista estática) e retonará as informações
solicitadas

Durante o fluxo de execução da aplicação, um objeto dto é convertido para o tipo entidade por uma classe de conversao que é referida na camada de serviços

Além das camadas de Api, Infra e Domain foram criados as camadas de services e IoC para injeção de dependência

