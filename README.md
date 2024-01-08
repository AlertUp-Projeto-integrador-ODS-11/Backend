# AlertUp - Backend :earth_americas::leaves:

![License](https://badgen.net/badge/License/MIT/purple?icon=)
![.NET](https://badgen.net/badge/.NET/v7.0/blue?icon=)
![NuGet](https://badgen.net/badge/icon/Packages/green?icon=nuget&label)
![Docker](https://badgen.net/badge/icon/Available?icon=docker&label)

Este é o repositório do backend do projeto **AlertUp**, uma rede social voltada para denúncias de situações cotidianas relacionadas ao Objetivo de Desenvolvimento Sustentável (ODS) 11 da ONU. Nosso objetivo é criar uma plataforma que permita aos cidadãos denunciar problemas urbanos, promovendo um ambiente urbano mais sustentável e melhorando a qualidade de vida nas cidades.

O backend foi desenvolvido utilizando a tecnologia ASP.NET e é responsável por gerenciar e armazenar os dados do AlertUp.

<br>

![AlertUp](https://imgur.com/xuCzywb.png) 

<br>

## Tecnologias e Ferramentas utilizadas 💻

<div>
    <img align='center' height='50' width='70' title='.NET Core' alt='dotnet' src='https://github.com/devicons/devicon/blob/master/icons/dotnetcore/dotnetcore-original.svg' />
    <img align='center' height='50' width='50' title='Nuget' alt='nuget' src='https://github.com/devicons/devicon/blob/master/icons/nuget/nuget-original.svg' />
    <img align='center' height='62' width='72' title='Swagger' alt='swagger' src='https://github.com/bush1D3v/tsbank_api/assets/133554156/6739401f-d03b-47f8-b01f-88da2a9075d1' />
    <img align='center' height='53' width='55' title='JsonWebToken' alt='jsonwebtoken' src='https://github.com/bush1D3v/solid_rest_api/assets/133554156/d23ffb9d-aedc-4d68-9209-7268d7f41ce6' /> &nbsp;
    <img align='center' height='48' width='48' title='Bcrypt' alt='bcrypt' src='https://bcrypt.online/images/bcrypt-esse-tools-logo-square.svg' /> 
    <img align='center' height='50' width='65' title='PostgreSQL' alt='postgresql' src='https://github.com/devicons/devicon/blob/master/icons/postgresql/postgresql-original.svg' />
    <img align='center' height='50' width='50' title='Microsoft SQL Server' alt='mssql' src='https://i.pinimg.com/originals/00/47/41/004741d0cd8e7face0e44392387ac18c.png' />
    <img align='center' height='49' width='49' title='Microsoft Visual Studio' alt='visual studio' src='https://upload.wikimedia.org/wikipedia/commons/thumb/2/2c/Visual_Studio_Icon_2022.svg/2048px-Visual_Studio_Icon_2022.svg.png' /> &nbsp;&nbsp;
    <img align='center' height='49' width='49' title='Jetbrains Rider' alt='rider' src='https://upload.wikimedia.org/wikipedia/commons/thumb/6/6e/JetBrains_Rider_Icon.svg/1200px-JetBrains_Rider_Icon.svg.png' /> &nbsp;&nbsp;
    <img align='center' height='48' width='48' title='Insomnia' alt='insomnia' src='https://static-00.iconduck.com/assets.00/apps-insomnia-icon-2048x2048-2mq9u7v5.png' /> &nbsp;
    <img align='center' height='63' width='63' title='Docker' alt='docker' src='https://github.com/devicons/devicon/blob/master/icons/docker/docker-original.svg' />
</div>

<br>

## Testando a API :man_scientist:

### Na nuvem ☁️
Para fazer os testes de forma online e sem necessidade de configurações, basta acessar o link do <a target="_blank" href="https://alertup.onrender.com">deploy</a> e começar a utilizar.

<br>

### Localmente (utilizando Docker) :whale:
Para configurar a aplicação para executar em ambiente local, é necessário ter instalado o Docker e o .NET 7 SDK, e assim seguir o passo a passo abaixo:

#### 1. Clone o Projeto

```bash
git clone https://github.com/AlertUp-Projeto-integrador-ODS-11/Backend.git
cd Backend
```

#### 2. Inicialize o contêiner do Docker

```bash
docker compose up
```

#### 3. Configure o appsettings.json

Certifique-se de alterar a variável "Environment":"Start" no arquivo `appsettings.json` do projeto (localizado dentro da pasta BaldursGame). A mesma está com o valor "PROD", que deve ser alterado para "DEV" para ser usado localmente, como representado abaixo:

```json
"Environment": {
    "Start": "DEV"
},
```

#### 4. Execute a aplicação

Volte ao Terminal ou CMD e execute os seguintes comandos:

```bash
cd AlertUp
dotnet run
```

Outra opção é usar uma IDE .NET de sua preferência, como Visual Studio ou Jetbrains Rider. A aplicação estará disponível em [localhost://5000](http://localhost:5000/swagger/index.html), no seu navegador. 

<br>

## Equipe do Projeto:

  | [<img src="https://avatars.githubusercontent.com/u/11530020?v=4" width=115><br><sub>Breno Henrique</sub>](https://github.com/brenonsc) | [<img src="https://media.licdn.com/dms/image/D4D03AQGoIVIx5R9Wpg/profile-displayphoto-shrink_400_400/0/1636665202433?e=1706140800&v=beta&t=38-kZ6p9TuHZj9mBep2KoouzfkFqrrKybbvvSdkQ7kI" width=115><br><sub>Julia Alexandrino</sub>](https://github.com/juhalexandrino) | [<img src="https://avatars.githubusercontent.com/u/102914299?v=4" width=115><br><sub>Matheus Queiroz</sub>](https://github.com/MatheusSQueiroz) | [<img src="https://avatars.githubusercontent.com/u/85324161?v=4" width=115><br><sub>Shomara Quispe</sub>](https://github.com/ShomaraQuispe) | [<img src="https://avatars.githubusercontent.com/u/70173955?v=4" width=115><br><sub>Victor Paliari</sub>](https://github.com/victorpaliari) |
  | :----------------------------------------------------------: | :----------------------------------------------------------: | :----------------------------------------------------------: | :----------------------------------------------------------: | :----------------------------------------------------------: |

<br>

## Projeto Integrador para Conclusão de Curso da Generation Brasil

Este projeto faz parte dos requisitos para a conclusão do programa de treinamento da Generation Brasil. Foi uma oportunidade incrível para colocarmos em prática todas as tecnologias aprendidas durante o curso, além das soft skills relacionadas a trabalho em grupo, orientação ao futuro, entre outras.
