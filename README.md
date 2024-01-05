# Computação Gráfica - Pathtracer Simples
## Trabalho Realizado por:  
- David Mendes 22203255  
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
