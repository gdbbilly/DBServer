# DBServer - Teste

•	O que vale destacar no código implementado?
- Busquei fazer uma implentação por camadas e orientada a objetos.
- Implementei um serviço(WCF) para ser utilizado tanto pela parte Web quanto pela Desktop.
- Acesso do banco é feito pelo EntityFramework.
- Utilizei a integração de ferramentas/componentes externos como bootstrap, gráficos do google.


•	O que poderia ser feito para melhorar o sistema?

- Deixar todo sistema online.
- Poderia ser utilizado um tamplate para melhorar visualmente a aplicação.
- Criar o cadastro online para os restaurantes.
- Fazer uma integração com o AD, para validação dos usuários que utilizam o sistema.
- Fazer um job que encerre a votação automaticamente em determinado horário, sem precisar ter um administrador para fazer isso.
- Poder reabrir a votação, para que os usuários que não votaram possam votar.


•	Algo a mais que você tenha a dizer ?

- No Projeto dbtest.Map tem o script(ModelBD.edmx.sql) para criar as tabelas no banco
- Alterar todas as connectionStrings para conectar na base que for feito o teste da aplicação
- Classe de teste principal é a TestStories
- No Sistema ele pede usuário e senha para entrar, pode ser utilizado qualquer usuário
- A parte web pode ser publicada em um servidor IIS e todos os usuários podem acessar para verificar a votação
- O código está no GIT na url https://github.com/gdbbilly/DBServer

•	Processo de como o fluxo da aplicação funciona

1 - Abrir o Sistema de Votação, escolher o restaurante e votar. (Desktop)

2 - O Administrador deve encerrar a votação na parte Web, logar com o usuário: admin, senha: admin (Web)

3 - Todos usuários podem acompanhar a votação e depois que a votação for encerrada podem verificar qual o restaurante vencedor (Web).
