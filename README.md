Desafio para a vaga de Desenvolvedor Backend na toutbox

Deve ser utilizado *dotnet core 3.1+*  para o desenvolvimento.
## O Desafio

O desafio consiste em criar uma api que faça calculo de frete usando o webservice dos correios, listando todos os serviços e preços para a região escolhida.

O candidado deve ser capaz de ler e interpretar a documentação e escrever os métodos apropriados, a api deve ser documentada com swagger ou qualquer outra ferramenta de documentação apis preexistente. 

Os dados da consulta e seu retorno devem ser persistidos em um banco de dados sql server / mysql utilizando o Entity Framework Core.

## Métodos requeridos

* POST /calculaFrete
* GET /ultimasConsultas

## Documentação 

- http://www.correios.com.br/para-voce/correios-de-a-a-z/pdf/calculador-remoto-de-precos-e-prazos/manual-de-implementacao-do-calculo-remoto-de-precos-e-prazos    
- http://ws.correios.com.br/calculador/CalcPrecoPrazo.asmx

## Bônus

* Escrever um metodo que retorne o top 10 dos ceps mais consultados
* Escrever testes para cada metodo da api 

## Diferenciais

* Caching das informações
* Autenticação com JWT
* Agrupamento de consultas por usuario
* Conteinerização do projeto

## O que será avaliado

* A aplicação estava funcional?
* A aplicação cumpre com os requisitos?
* A aplicação está sem bugs?
* A implementação segue as convenções de design de aplicações web?
* A implementação do banco de dados está correta ?
* O código está bem escrito?
* O código está fácil de entender?
* O código está corretamente formatado?
* Foi feito uso correto do git?


O candidato deve dar fork neste repositório e após o termino, realizar um pull request para análise.

Boa sorte!
