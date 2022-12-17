# ChronoTrix - CTEDS Projeto Final
**ChronoTrix** é o projeto de conclusão do curso de **Capacitação Tecnológica em Engenharia e Desenvolvimento de Software (CTEDS)**, oferecido pelo **Departamento de Engenharia de Computação e Sistemas Digitais (PCS)** da **Universidade de São Paulo (USP)**. O projeto consiste em uma aplicação Windowns de uma calculadora de multiplas funcionalidades, atualmente o projeto apresenta dois modos de funcionamento: científico e básico. A ideia do projeto é desenvolver uma calculadora completa, prática, responsiva que apresentando diversas funcionalidades úteis.

Autores: [Gabriel Di Vanna Camargo](https://github.com/FastShowDev) e [Matheus Ribeiro Lira](https://github.com/mtlira)

## Funcionalidades
Atualmente estão desenvolvidas as seguintes funcionalidades:
- [x] Calculadora Padrão
- [x] Calculadora Científica
- [x] Sistema de Histórico
- [x] Sistema de Feedback visual
- [x] Permanência do histórico das operações feitas em um banco de dados SQLite.<br/>

**Futuramente** pretende-se implementar outras funcionalidades, por exemplo:<br/>

- Plotagem e visualização de gráficos.
- Conversor de moedas, tempo, ângulo, velocidade, etc.
- Cálculo de Azimutes e coordenadas de levantamento topográfico.
- Cálculo de médias aritméticas, geométricas, ponderadas, etc.
- Cálculo de desvio padrão, moda, mediana, etc.
- Calculadora de matrizes, vetores.
- Calculadora para álgebra linear (produto vetorial, escalar, interno, etc)

Tem alguma sugestão? Envie um email para gabriel_camargo@usp.br

## Funcionalidades
A seguir encontram-se as funcionalidades já implementadas no projeto, uma breve descrição da funcionalidade e um gif mostrando seu funcionamento.

### Calculadora Padrão
O modo de operação padrão possui as quatro operações fundamentais (adição, subtração, multiplicação e divisão), porcentagem, operações de raiz quadrada, elevar ao quadrado e calcular o inverso. Os botões de operação funcionam da seguinte maneira, por exemplo: ao pressionar o botão de raiz quadrada, o que está atualmente inserido no display é calculado e em seguida calcula-se a raiz quadrada do valor obtido. O mesmo ocorre para elevar ao quadrado e calcular o inverso.

<img alt="Gif mostrando o funcionamento da calculadora padrão" src="https://user-images.githubusercontent.com/109106987/208176837-627b798c-25cb-4963-9ec6-a9b3a37b1b3d.gif" width="600px"/>

### Feedback Visual
O sistema de Feedback Visual consiste em uma forma da calculadora avisar para o usuário que a operação realizada é inválida, o sistema identifica uma operação matemáticamente inválida/impossível e automáticamente desativa todos os botões de operadores e operações para evitar possíveis erros.
<img alt="Gif mostrando o feedback da calculadora" src="https://user-images.githubusercontent.com/109106987/208176837-627b798c-25cb-4963-9ec6-a9b3a37b1b3d.gif" width="600px"/>


