# Uniftec - Projetos Web - COVID19
Temos como objetivo capturar informações diretamente do GPS de um dispositivo móvel e comparar com uma base de dados de casos positivos para COVID e com
um cálculo de Geolocalização apontar os locais que ofereceram maior risco para o usuário e quais os locais que deveriam ser evitados.

O aplicativo Mobile irá enviar as coordenadas (latitude e longitude) para uma API, que será construída, utilizando C# e iremos inserir em um banco de dados PostgreSQL.
Esta API também será responsável por importar a base de dados pública, onde constam os dados necessários para que possamos realizar um Geocode. Após o Geocode poderemos calcular a distância em que os casos positivos de COVID19 residem e o percurso realizado pelos nossos usuários.

Em posse desta análise, iremos montar um dashboard exibindo um mapa de calor, dos locais mais perigosos para se frequentar.

## Características do Sensor
O sensor de GPS dos dispositivos móveis comuns conseguem enviar uma posição a cada 1 segundo e para que a comunicação seja possível será necessário que alguma interface de rede esteja ativa. Sendo ela conexão móvel (3g, 4g, etc) ou WIFI.

## Aplicativo Mobile
Iremos criar um aplicativo bem simples, visto que este não é o foco da disciplina, para apenas realizar uma comunicação com a API enviando o par de coordenadas.

## API
A API será construída ASP.net MVC. Temos como objetivo utilizar o .net core para que seja possível executa-la em ambientes Unix.
