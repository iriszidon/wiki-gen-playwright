# Welcome to the Wiki-Playwright demo test project :)

## Install using the terminal

`dotnet --version `

- initialize a new projecat named GenWikiTests using MS tests

- `dotnet new mstest - n GenWikiTests`
- `cd GenWikiTests`
- `dotnet add package Microsoft.Playwright.MSTest`
- `playwright install`
- `dotnet add package DotNetEnv`
- `dotnet add package Allure.Commons`

## Add .env file

- Create a .env file directly under the root folder wiki-gen-playwrite
- Copy all the fileds from .env.example file into .env file
- The automation assums that an .env file is supplied.

## Run tests by

### Run all tests

`dotnet test`

### Run the sample test to make sure Playwright is up and runnig

`dotnet test --filter "ClassName=GenWikiTests.SampleTests" `

### Run all tests in class ExampleTest

`dotnet test --filter "ClassName=GenWikiTests.Tests.ExampleTest"`

### Run all tests with test category "WordCount"

`dotnet test --filter "TestCategory=WordCount" `

### Run with more visible output

`dotnet test --filter "TestCategory=WordCount" --logger "console;verbosity=detailed" `

### To output result to trx

`dotnet test --filter "TestCategory=Wikitext" --logger "trx;LogFileName=test_results.trx;verbosity=detailed" `

### Run with LinkValidation categoty

`dotnet test --filter "TestCategory=LinkValidation" --logger "trx;LogFileName=test_results.trx;verbosity=detailed"`

### Run with DarkModeValidation categoty

`dotnet test --filter "TestCategory=DarkModeValidation" --logger "trx;LogFileName=test_results.trx;verbosity=detailed"`

## Add reports by

- `allure generate TestResults/ --clean`
- `allure open`

## Assumptions

- env file is supplied
- .env file path is <Any path>\wiki-gen-playwright\.env
