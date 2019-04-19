# SolutionDevChallenge

Clone os fontes do projeto no GitHub

Acessa o github do projeto em: https://github.com/davimorao/SolutionDevChallenge

Abra o terminal e execute git clone https://github.com/davimorao/SolutionDevChallenge.git

Backend com Visual Studio

Abra o projeto no Visual Studio, em seguida compile a solution

Navegue ate o projeto DevChallange.Infra.Data e procure pelo arquivo appsettings.json, altere a connectionString com seus dados de acesso ao SQL Server.

Pressione ALT + T + N + O para abrir o console do Nuget Package, em seguida selecione o projeto DevChallange.Infra.Data

Execute o seguinte comando para criar a base de dados: add-migration criarbanco, apos gerar a migration, execute o seguinte comando update-database.

Pressione F5 para rodar o projeto no Visual Studio

Frontend com Angular e Node

Instale o node, https://nodejs.org/en/.

Abra o CMD (prompt de comando) do Windows e rode o comando npm install -g @angular/cli para instalar o angular cli.

Em seguida, navegue ate a pasta do projeto pelo CMD com o seguinte comando: cd /CaminhoOndeEstaOProjeto/SolutionDevChallenge/DevChallenge.Presentation.Site/ClientApp/

Execute o comando npm install para instalar as dependências do projeto.

Em seguida ng build --prod para compilar o projeto

Por ultimo, para rodar o projeto: ng serve.

Abra o navegador no endereço http://localhost:4200/
