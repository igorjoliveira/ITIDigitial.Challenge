# ITIDigitial.Challenge

#### Especificação do desafio
https://github.com/itidigital/backend-challenge

#### Pré Requisitos para compilar e rodar a solução
[Visual Studio Community 2019](https://visualstudio.microsoft.com/pt-br/vs/) </br>
[.Net Core 5.0.201](https://dotnet.microsoft.com/download/dotnet/5.0)


#### Solução Técnica
O desenho da solução foi pensado para atender as necessidades abaixo </br>
  - [x] Baixo Acoplamento
  - [x] Clean Code
  - [x] SOLID
  - [x] Testes de unidade / integração

#### Metodologia Utilizada
Utilizamos o DDD para definir a estrutura e as responsabilidades de cada camada da solução. </br>
Em conjunto aplicamos o TDD em cada componente da solução, assim garantindo o funcionamento isolado de todas as regras.

#### Desenvolvimento 
O primeiro passo foi matererializar o dominio da nossa aplicação, onde nós conseguissemos mapear todas as suas responsabilidades. Desde os seus atributos até as suas ações. </br> 
Após a criação do dominio anemico, partimos para a implementação do nosso TDD. Onde criamos todos os teste unitários que atendiam a todas as regras de negócio. </br>
Feito isso, começamos a implementação do nosso domínio para atender a todos os cenários do teste unitário. </br>
<b>Obs:</b> esse processo se repetiu para as demais camadas da solução

#### Validação de Senha
Para o processo de validação de senha, criamos uma interface com os requisitos minimos para a implementação de uma regra. </br>
Sendo assim, criamos uma implementação especifica para cada regra descrita na especificação. Onde é possível aplicar os testes de forma individual. </br>
Para consolidar todas as regras, criamos uma serviço para o meu dominio, onde todas as regras foram mapeadas e executadas através de um método. </br> 
Dessa forma a minha camada de aplicação recebe o serviço do meu dominio para executar todas as regras. </br>
Esse desenho foi pensado, para garantir o baixo acoplamento e extensibilidade do código.

#### Premissas assumidas
<ol>
  <li>Resultados esperados da API para o endpoit API/Security</li>
  <ol>
    <li>StatusCode 200 - content true</li>
    <li>StatusCode 400 - content false</li>
  </ol>
  <li>Além dos espaços, qualquer caractere fora do alfabeto com exceção aos números e aos caracteres especias, foram tratados como inválidos</li>
  <ol>
    <li>é</li>
    <li>ç</li>
    <li>{</li>
    <li>ó</li>
    <li>ã</li>
  </ol>
</ol>
