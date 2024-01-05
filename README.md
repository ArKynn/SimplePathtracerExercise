# Computação Gráfica - Pathtracer Simples
## Trabalho Realizado por:  
- David Mendes 22203255
## Link para o repositório:  
https://github.com/ArKynn/SimplePathtracerExercise
## Relatório:  

Começei este trabalho com uma pesquisa acerca do que é um PathTracer e como o mesmo funciona.  

https://en.wikipedia.org/wiki/Path_tracing - Começei por dar uma olhada no artigo da wikipedia. Apesar de poder não ser a melhor fonte de informação, ajuda a contextualizar e a pôr diversos termos na cabeça que mais tarde os iria utilizar.  

https://agraphicsguynotes.com/posts/basics_about_path_tracing/ - Durante a minha pesquisa, encontrei este artigo que me apresentou um pouco da matemática por detrás deste processo. Este artigo também mostra exemplos de imagens resultantes de um pathtracer, que me ajudou a visualizar qual o objetivo que pretendo alcançar com o projeto.  

[_Ray Tracing in One Weekend_](https://raytracing.github.io/books/RayTracingInOneWeekend.html) - Após uma recomendação pelo professor, dei uma olhada no primeiro livro desta série. Achei que a informação dada pelo primeiro fora muito bem explicada e fundamentada, e decidi dar uma olhada nos outros dois livros desta série.  
  
[_Ray Tracing: The Next Week_](https://raytracing.github.io/books/RayTracingTheNextWeek.html), [_Ray Tracing: The Rest of Your Life_](https://raytracing.github.io/books/RayTracingTheRestOfYourLife.html) - Estes livros vão ainda em mais detalhe do que o primeiro em como um pathtracer funciona e nos diversos sistemas necessários para este mesmo funcionar. Após a leitura destes livros, decidi guiar-me pelo primeiro para este meu projeto.  
 
 ## O meu projeto:  
 Durante este projeto, decidi guiar-me pelo que me era apresentado no livro mensionado acima.  
 Começei por criar uma simples imagem. Como recomendado pelo livro, utilizei para o projeto todo imagens do formato .ppm.  
   
 ![img-1 01-first-ppm-image](https://github.com/ArKynn/SimplePathtracerExercise/assets/115217596/77057a91-7a8e-4edf-a3a5-9db73adfcb74)  

 Esta imagem serviu apenas para poder por o código que cria o ficheiro pronto a funcionar para o resto do projeto.

 Após isto, introduzi a classe Vec3 e Color. Estas classes irão servir como base para todo este projeto mas, por agora, apenas tinham as funcionalidades mais basicas necessárias ao projeto. Após a sua criação, inseri-as no código, o que produziu a mesma imagem inicial.  

 De seguida, introduzi a classe Ray. Esta classe descreve um raio apartir de um ponto origem e uma direção. Mais tarde, estes raios serão utilizados para calcular a cor dos diversos objetos em que estes embatem. Para isto, preciso de introduzir uma câmara que servirá como ponto inicial para estes raios.  

 Para poder localizar os pixeis da imagem pelo código, tenho de introduzir um Viewport virtual, que contem a grelha de localizações dos pixeis da imagem e dois vetores, u e v. Estes vetores, em conjunto com o centro da câmara, servirão para localizar e identificar o ponto a ser tratado de seguida pelo código.  

 Após o anterior, introduzi o metodo ray_color() á câmara. Este metodo recebe um raio e futuramente irá calcular colisões com objetos e devolverá a cor a ser apresentada. Por agora, apenas cria um gradiente entre azul e branco na imagem.  

Esta é a imagem resultante por agora:  

![img-1 02-blue-to-white](https://github.com/ArKynn/SimplePathtracerExercise/assets/115217596/f6990a22-8e87-49e5-8147-f3317bc02217)  

Para este projeto, apenas utilizei esferas, pela sua simplicidade matemática. Para calcular a sua representação, tenho que calcular a sua interceção com um vetor e recolher o ponto de interceção entre os dois mais perto da câmara. Como já consigo mandar raios para qualquer pixel do ecrâ, quando este raio intercetar a esfera, consigo calcular a interceção entre os dois.  
  
Introduzindo isto no código e adicionando uma esfera simples, conseguimos a seguinte imagem:  

![img-1 03-red-sphere](https://github.com/ArKynn/SimplePathtracerExercise/assets/115217596/0e912622-7bc1-4396-a77a-ac8285073d76)  

Para poder introduzir mais esferas, criei a classe abstrata RayHittable e fiz a classe Sphere filha desta classe base. Isto permitirá criar uma lista com objetos RayHittable para ser mais fácil os calculos quando houver vários objetos. A classe Hittable também introduz o metodo Hit que recebe um raio e apartir daí, a forma geométrica que foi Hit, terá os seus calculos para a interceção com o raio. Neste caso, apenas terei esferas mas, deixei o metodo para ser possivel extender futuramente o projeto para outras formas geométricas.  

Também introduzi a classe Hit_Data, que irá guardar informação sobre o objeto que o raio interceta.

A classe HittableList guarda outros objetos do tipo Hittable e permite verificar se há colisões com todos os objetos que a mesma guarda.  

De seguida, adicionei um simples efeito de antialiasing que verifica os quatro pixeis mais perto do qual estamos a tratar e faz uma média das cores.  
Logo a seguir, adicionei um material difuso simples. Quando um raio colide com uma esfera com este material, perde metade da sua intensidade e reflete para uma outra direção aleatória.  
Atualizei o código e verifiquei o seguinte:  

Esta imagem seria o resultado que, segundo o livro, eu deveria obter:  

![img-1 07-first-diffuse](https://github.com/ArKynn/SimplePathtracerExercise/assets/115217596/428ad366-175e-4232-8b19-7519963e7119)  

Ao invés disto eu obti uma imagem onde os não apresentavam redução na intensidade dos raios quando estes colidiam, o que fez com que as esferas não apresentassem cores diferentes. Como não cheguei a guardar nenhuma imagem, não consigo mostrar o meu resultado.  

Sem conseguir resolver, decidi prosseguir com o livro, já que o problema estava relacionado com o material das esferas.  

De seguida introduzi os materiais Metal e Labertian. Estes materiais apresentam diferentes formas em como os raios refletem na superficie da esfera: O material Metal reflete perfeitamente os raios sem estes atenuarem a sua cor, e o material Lambertian reflete os raios numa direção aleatória e atenua a cor do raio.  

Quando testei o programa, deparei-me com um grande problema: Como tenho estado a seguir o autor que mostra código em c++, tive de o converter em algo semelhante em c#. No metodo scatter dos materiais que introduzi, não consigo reter as mudanças que o metodo faz numa variavel e isto causa que o programa pare de funcionar. Experimentei várias soluções mas nada resolveu. Com isto, não consegui continuar com o trabalho.  

## O que correu mal:  
  
Durante a criação do programa, não guardei o meu progresso, por exemplo, em git. Tive problemas com alterações que fiz e tive perder tempo a voltar atrás no código para resolver estes mesmos.  
  
Durante a criação do programa, fiquei muito colado ao código do autor. Enquanto que isto pode não ser um grande problema, visto que estava a programar numa outra linguagem de programação, fêz com que eu tivesse vários problemas com a minha iteração do renderizador, que me custou muito tempo.  

## O que faltou adicionar ao projeto:  

- A meu ver, faltou adicionar os parâmetros Metalic e Smoothness aos materais e uma equação de calculo de côr e refleção mais universal. Neste momento, os materiais ou são metálicos, ou são difusos. Com uma equação geral e estes parâmetros, permite ao renderizador apresentar mais materiais diversos diferentes dos dois já adicionados.
- A meu ver, faltou adicionar um material Dieletrico. Este material refrata os raios de luz quando estes colidem com o objeto. Para alcançar esta refração, utilizaria a lei de Snell.  
- Adicionalmente, gostaria de adicionar luz e sombras ao projeto. Neste momento, o projeto não toma em consideração a presença de luz. Apesar de este tema não ser abordado neste primeiro livro, acho que o projeto estaria mais completo com luz e sombras.  
- Adicionalmente, mais controlo na câmara. Neste momento, a câmara que o projeto usa não só não permite a modificação de posição e orientação, mas também não permite a mudança de field of view, nem produz depth of field.  

## Conclusões:  

Com este projeto, consegui mergulhar um pouco por dentro de como um pathtracer funciona. Aprendi como representamos o mundo atravéz de código e como traduzimos diversos fenómenos fisicos relacionados à luz em código. Apesar de não incluir no meu projeto, consegui aprender como representamos luz e sombras e diversas metodologias para o fazer. Também aprendi um pouco da importância que um version controller tem em um projeto. 
  
Infelizmente, não consegui obter um produto final funcional mas consegui aproveitar o periodo em que o renderizador fundionava para aprender como representamos raios, reflexões e materiais e como os manipulamos para representar o mundo á nossa volta.  
  
De certeza que irei futuramente voltar a este tema para poder obter um renderizador que representa precisamente os efeitos da luz em um meio fisico.
