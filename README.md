<h2>Documentação completa: <a href="http://doc-devchallenge.azurewebsites.net/" targe="blank">http://doc-devchallenge.azurewebsites.net/</a></h2>

<h2>Instalação</h2>

<ol>
                                        <li>
                                            <p><b>Clone os fontes do projeto no GitHub</b></p>
                                            <p>Acessa o github do projeto em: <a href="https://github.com/davimorao/SolutionDevChallenge">https://github.com/davimorao/SolutionDevChallenge</a></p>
                                            <p>Abra o terminal e execute <code>git clone https://github.com/davimorao/SolutionDevChallenge.git</code></p>
                                        </li>
                                        <li>
                                            <p><b>Backend com Visual Studio</b></p>
                                            <p>Abra o projeto no Visual Studio, em seguida compile a solution</p>
                                            <p>Navegue ate o projeto <code>DevChallange.Infra.Data</code> e procure pelo arquivo appsettings.json, altere a connectionString com seus dados de acesso ao SQL Server.</p>
                                            <p>Pressione <code>ALT + T + N + O</code> para abrir o console do Nuget Package, em seguida selecione o projeto <code>DevChallange.Infra.Data</code></p>
                                            <p>Execute o seguinte comando para criar a base de dados: <code>add-migration criarbanco</code>, apos gerar a migration, execute o seguinte comando <code>update-database</code>. </p>
                                            <p>Pressione <code>F5</code> para rodar o projeto no Visual Studio</p>
                                        </li>
                                        <li>
                                            <p><b>Frontend com Angular e Node</b></p>
                                            <p>Instale o node, <a href="https://nodejs.org/en/">https://nodejs.org/en/</a>.</p>
                                            <p>Abra o CMD (prompt de comando) do Windows e rode o comando <code>npm install -g @angular/cli</code> para instalar o angular cli.</p>
                                            <p>Em seguida, navegue ate a pasta do projeto pelo CMD com o seguinte comando: <code>cd /CaminhoOndeEstaOProjeto/SolutionDevChallenge/DevChallenge.Presentation.Site/ClientApp/</code></p>
                                            <p>Execute o comando <code>npm install</code> para instalar as dependências do projeto.</p>
                                            <p>Em seguida <code>ng build --prod</code> para compilar o projeto</p>
                                            <p>Por ultimo, para rodar o projeto: <code>ng serve</code>.</p>
                                            <p>Abra o navegador no endereço <a href="http://localhost:4200/">http://localhost:4200/</a></p>
                                        </li>
                                    </ol>
