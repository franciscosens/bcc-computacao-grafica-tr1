# Computação Gráfica - Trabalho 01 

[Slides](assets/slides.pdf)

## Questão 01 - Explorar o uso da primitiva gráfica ponto no SRU

Implemente uma aplicação para desenhar um círculo no centro do Sistema de Referência do Universo (SRU), com raio de valor 100. Utilize 72 pontos simetricamente distribuídos sobre o perímetro do círculo e defina as dimensões da janela do espaço gráfico com valores entre -300 a 300, de forma que o resultado final seja o mais parecido com a figura a baixo.

![Questão 01](assets/questão&#32;01.png)

Observações:
* desenhe somente os eixos positivos x e y, cada um com comprimento igual a 200;
* experimente mudar a cor de fundo da tela para cinza e a cor de desenho dos pontos para amarelo;
* utilize as funções sin(ang) e cos(ang) da Classe Matematica fornecida;
* não é permitido usar o comando circle do OpenGL e nem outra implementação que não use as funções da classe Matematica.

## Questão 02 - Funções de Pan e Zoom

Crie uma nova aplicação (ver vídeo abaixo) usando como base o exercício anterior (neste caso o fundo de cor branca e desenho preto) para implementar as funções de Pan e Zoom. Para isso, implemente uma função de callback de teclado que leia as teclas e os parâmetros necessários para a função Ortho. Tais parâmetros deverão ser armazenados em uma classe Camera. 
Observações:

- tecla Pan (deslocar para esquerda): E;
- tecla Pan (deslocar para direita): D;
- tecla Pan (deslocar para cima): C;
- tecla Pan (deslocar para baixo): B;
- tecla Zoom in (aproximar): I;
- tecla Zoom out (afastar): O.

Não esqueça de “tratar” os limites de zoom mínimo e máximo senão poderá ocorrer erros de execução, ou até a inversão horizontal/vertical do desenho na tela. Geralmente estes “problemas” ocorrem devido ao tipo de variável declarada para armazenar o “passo” do zoom atual.


![Questão 02](assets/questão&#32;02.gif)


## Questão 03 - Desenhando objetos gráficos iguais

Crie uma outra aplicação para fazer o desenho da imagem abaixo. Os círculos tem raio com valor 100.

![Questão 03](assets/questão&#32;03.png)

## Questão 04 - Primitivas Geométricas

Nesta aplicação a idéia é explorar a utilização das “primitivas geométricas”. As dimensões da janela do espaço gráfico deve ter valores entre -400 a 400. Já os pontos são valores de 200 negativo e positivo de forma que o resultado final seja o mais parecido com o vídeo a baixo.

No caso a interação deve ser:
- para alternar entre as “primitivas geométricas” use a tecla de “barra de espaço”;
- as “primitivas geométricas” que devem ser utilizadas são: GL_POINTS, GL_LINES,  GL_LINE_LOOP,  GL_LINE_STRIP,  GL_TRIANGLES,  GL_TRIANGLE_STRIP, GL_TRIANGLE_FAN,  GL_QUADS, GL_QUAD_STRIP e GL_POLYGON.

**Atenção:** só deve aparecer em todo o código UM ÚNICO “glBegin” e “glEnd” para informar as primitivas geométricas. As imagens abaixo são meramente ilustrativas de só algumas das “primitivas”, e não precisam aparecer na mesma sequência.

![Questão 04](assets/questão&#32;04.gif)

## Questão 05 - Sr. Palito, dando seus primeiros passos

Agora, crie uma nova aplicação com o objetivo de poder mover um Segmento de Reta (SR), aqui conhecido com Sr. "Palito", lateralmente usando as teclas Q (esquerda) e W (Direita). Ao iniciar a aplicação um dos pontos do Sr. Palito está na origem. O segundo ponto do Sr. Palito será definido com raio de valor 100 e ângulo 45º. Ainda é possível usar as teclas A (diminuir) e S (aumentar) para mudar  o tamanho (raio), e as teclas Z (diminuir) e X (aumentar) para girar (ângulo) do Sr. Palito. Olhe o exemplo no vídeo a baixo.

![Questão 05](assets/questão&#32;05.gif)

## Questão 06 - Spline

Já esta aplicação o seu objetivo é poder desenhar uma spline (curva polinomial) que permita alterar a posição (x,y) dos pontos de controle dinamicamente utilizando o teclado. As dimensões da janela com valores (xMin: -400, xMax: 400, yMin: -400, yMax: 400) e os pontos são valores de 100 negativo e positivo de forma que o resultado final seja o mais parecido com o vídeo a baixo.

No caso a interação deve ser:
- para mudar entre o ponto de controle selecionado (em cor vermelha) usar as teclas “1, 2, 3 e 4”;
- para mover o ponto selecionado (um dos pontos de controle) usar as teclas C (cima), B (baixo), E (esquerda) e D (direita);
- as teclas do sinal de mais (+) e menos (-) podem aumentar e diminui a quantidade de pontos calculados na spline;
- ao pressionar a tecla R os pontos de controle devem voltar aos valores iniciais;
- a spline deve ser desenha usando linhas de cor amarela;
- o poliedro de controle deve ser desenhado usando uma linha de cor ciano.
ATENÇÃO: não é permitido usar o comando spline do OpenGL, sendo só permitido usar UMA das formas de splines “demonstradas em aula”. Ao mover um dos pontos de controle, o poliedro e a spline deve se ajustar aos novos valores deste ponto.
Veja o exemplo no vídeo a baixo.

![Questão 06](assets/questão&#32;06.gif)

## Questão 07 - BBox dos círculos

E por fim, esta aplicação tem o objetivo de fazer um joystick virtual. Basicamente deve-se desenhar dois círculos (um menor e outro maior) e poder usar o mouse para mover o círculo menor, mas sem deixar ele (o centro do círculo menor) sair dos limites do círculo maior.

Para controlar o movimento do centro do círculo menor deve ser usado:
- um teste inicial pela BBox interna do círculo maior;
- seguido do cálculo da distância (euclidiana, sem raiz).
Exemplo, vídeo a baixo.

![Questão 07](assets/questão&#32;07.gif)