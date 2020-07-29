# Contexto

Esse projeto é baseado em um programa de mentoria do canal DevDojo, cujo objetivo é a ampliação dos conhecimentos de tecnologia através de projetos que simulam cenários comuns no mercado de trabalho. Para saber mais, recomendo [esse vídeo](https://www.youtube.com/watch?v=nt7aSfZ1Im8)

# Sobre
Linguagem: C#
Back-end: .NET CORE com ENTITY FRAMEWORK
Front-end: BOOTSTRAP

# Setup
No arquivo appsettings.json, você vai precisar colocar sua string de conexão ao banco de dados. Lembrando que esse projeto foi feito usando o **SQL Server**.
´´´c#
"ConnectionStrings": {
      "FujiwaraCarShopContext": "[INSIRA SUA STRING DE CONEXÃO AQUI]"
  }
´´´
Após isso, você precisará ir no console e criar uma migration do projeto. Não se preocupe, é só digitar o comando abaixo:
´´´
Add-Migration NomeMigration //Sinta-se livre para nomear
´´´


