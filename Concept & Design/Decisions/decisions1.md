Bonjour à tous, chers camarades, bon j’arrête, je n’aime pas parler comme ça. J’ai réfléchi pour notre projet d’immersion sur quoi nous pouvions partir. J’ai remarqué deux thématiques prédominantes chez vous : manipulation de l’IA et jeux de type combat (Mortal Kombat, Super Smash Bros, etc.).

Je pense dans un premier temps que nous pouvons lier les deux. Donc, en partant du fait que nous sommes d’accord sur les thématiques et que nous allons les lier, nous pouvons nous en servir comme point de départ.

Maintenant, il nous faut choisir entre la 2D et la 3D. Après une petite recherche sur un forum très connu du nom de Reddit, un projet étudiant quelconque en 3D prend 3 à 6 mois pour avoir une v1 correcte (donc mécanique de base, graphismes de base, 2 à 3 personnages, enfin vous m'avez compris).

Alors qu’un jeu en 2D prend entre 15 jours et 1 mois pour avoir une v1, et au bout de 2 mois une v2 bien complète (donc ajout d’éléments importants tels qu'une histoire, des modes supplémentaires, plus de personnages, etc.).

Je pense qu’avec cette brève explication, le choix est vite fait. CE SERA LA 2D !!! Mais il nous reste à choisir entre la 2D pixel et la 2D plus réaliste. Sachez qu’entre les deux, il n’y a pas de complexité supplémentaire pour l’implémentation dans le jeu.

---

**Vote : 2D pixel ou 2D réaliste**

- [x] 2D pixel  
- [ ] 2D réaliste

---

Ensuite, il nous reste le choix d’où récupérer les images, personnages, et tous les éléments graphiques du jeu. Alors sur ce point-là, je vous donne directement ma conclusion : il vaut mieux les faire nous-mêmes.

Pourquoi ? Dans un premier temps, le fait de choisir parmi des graphismes déjà réalisés nous restreint en choix, car nous devrons tout adapter à partir de cela. Dans le cas de demander à un artiste de les faire, sauf si vous connaissez quelqu’un qui le fasse gratuitement et assez rapidement pour nous, alors OK, sinon le prix est beaucoup trop élevé.

De plus, réaliser les graphismes par nous-mêmes nous enlève toutes les questions de droit d’auteur, etc. Et pour finir, à un moment, on est capable de dessiner, que ce soit par IA pour les moins doués, ou à la main pour les autres, je pense qu’on est capable de dessiner 2-3 personnages et décors.

---

**Vote : Comment réalise-t-on les graphismes**

- [ ] J’ai trouvé la perle rare, des graphismes gratuits qui nous conviennent et aucun problème de droit d’auteur  
- [ ] J’ai un pote qui dessine, il peut nous faire ça sous 2-3 semaines  
- [ ] Je suis riche, je paye les graphismes, ne vous inquiétez pas  
- [x] Je suis nul en dessin, mais je vais quand même le faire, ça ne doit pas être si compliqué  
- [x] Je suis pire que nul en dessin, mais je participerai quand même avec ma super IA

---

Maintenant que nous avons notre idée générale sur quel type de jeu nous allons réaliser, dans quelle dimension et comment nous allons réaliser les graphismes, il nous reste la question de « quel langage de programmation choisir pour le jeu ? ».

Mais avant cela, la question de la plateforme s’impose : nous développons notre jeu pour smartphone, PC, ou web ? Je pense dire sans hésitation que cela sera PC, et je ne pense même pas avoir besoin de vous expliquer pourquoi. Bon, passons à la suite.

Tout d’abord, soyons clairs, nous n’allons pas choisir qu’un seul langage. La première raison est que, dans tous les cas, l’IA sera mieux avec du Python, donc nous risquons de prendre Python juste pour ça.

Pour les amateurs de C, tradition depuis 1972, je suis désolé de vous décevoir, mais nous n’allons pas le choisir. Ensuite, il y avait le choix entre Java, C++, C#, mais si nous devons réaliser un jeu, ne réinventons pas la roue, les moteurs de jeu existent.

Pour les connaisseurs, les deux grands sont Unity et Unreal Engine. Pour ma part, je pense que Unity est le meilleur choix car, en plus d’être plus léger qu’Unreal Engine, il peut aussi intégrer d’autres langages que son langage de base, comme Python (url : [https://docs.unity3d.com/Packages/com.unity.scripting.python@2.0/manual/index.html](https://docs.unity3d.com/Packages/com.unity.scripting.python@2.0/manual/index.html)).

Et oui, car pour ceux qui ne le savent pas, Unity est en C#, mais pas d’inquiétude, c’est mieux que le C. Et aussi, pour ceux qui sont en train de se dire « oui mais Unreal Engine fait de meilleurs graphismes et patati et patata », OUI mais NON, nous allons faire un PUTAIN de jeu en 2D.

Avec sûrement nos graphismes, il ne faut pas s’attendre à un truc de ouf, on ne va pas faire GTA V. Mais surtout, le point le plus important, sur le forum Reddit on estime à +60-70% le nombre de tutoriels réalisés sur Unity comparé à Unreal Engine.

Donc, c’est pour dire que normalement ce que l’on va faire, cela a déjà sûrement été fait plusieurs fois. Je pense donc que Unity est parfait pour notre choix.

---

**Vote : Comment allons-nous coder notre jeu**

- [x] En Python et en C dans un terminal Linux  
- [ ] Je pense que GTA V est faisable, GO pour Unreal Engine  
- [x] En vrai, Java c’est bien, alors pourquoi pas  
- [ ] De toute façon, mon PC n’est pas assez puissant, alors je vais coder uniquement en Python  
- [x] Bah Unity, sinon quoi d’autre

---

Nous donnerons à la prof qui a posté quoi sur le Git, donc n’hésitez pas à ajouter et modifier la moindre chose en votre nom. Bon, passons à la suite. Quel sera l’emploi du temps des événements à venir ? Dans quel ordre allons-nous réaliser le jeu ?

Alors, pour répondre à cette question, il faut d’abord savoir quoi faire. Dans un premier temps, en prédisant un minimum les réponses aux questions, je pense que nos versions seront structurées ainsi :  

**v1.0 :**  
- Menu  
- Mécanique des personnages  
- Implémentation d’un combat  
- Graphismes  

**v1.1 :**  
- Réalisation de l’IA  
- Mise en place du son  

**v2.0 :**  
- Mode multijoueur ???  
- Mode histoire ???

Voici un bref aperçu de la construction de notre jeu en fonction des versions, et bien sûr, cela n’est qu’une ébauche. Mais cela va pouvoir nous aider à répondre à notre question. Je pense dans un premier temps que nous devons réaliser les mécaniques de base.

Dans Unity, prendre une plateforme basique (un rectangle), deux personnages de base et réaliser toutes les mécaniques. Une fois réalisé, ce qui suit, c’est bien sûr l’implémentation d’un combat. Une fois mécanique et combat réalisés, nous pouvons enfin mettre en place nos graphismes.

Pour finir sur cette v1, la conception et réalisation du menu nous montrera les premiers débuts de notre jeu. Ici, je pense que notre jeu sera pourri et que nous aurons normalement consacré chacun entre 20 et 45 heures de notre temps.

Une fois la v1.0 réalisée, en fonction du temps que nous aurons passé dessus, nous pourrons adapter nos futures versions.

---

**Vote : Que pensez-vous de ces différentes versions**

- [x] Ça me paraît bien, enfin normal quoi  
- [ ] Je nous trouve bien ambitieux  
- [ ] Je pense que nous devons revoir l’ordre dans lequel procéder, mais l’ensemble est correct

---

Bon, maintenant que nous avons bien avancé sur le projet, nous devons avoir une petite cinématique. De plus,

 nous sommes 5 dans le groupe, je ne pense pas qu’un jeu de combat avec seulement 2 personnages disponibles soit très plaisant pour le joueur.

Je pense donc que nous devons réaliser au minimum un personnage chacun. Et pour qu’il y ait une petite histoire derrière notre jeu, je propose que nous fassions une histoire simple : un héros combat l’anti-héros sombre d’une autre race/nation dans une guerre. Voilà, terminé.

À chacun d’entre vous de faire l’histoire de votre personnage et de lui donner vie. De choisir son arme, sa race, ses attributs, etc.

---

**Vote : Que faisons-nous ?**

- [x] Je vais faire mon personnage, je serai l’anti-héros sombre  
- [x] Moi, je vais devenir le héros qui va tout protéger  
- [ ] Je vais faire un perso random  
- [x] Mon perso va venir d’un autre univers, mais je vais cacher ça pour éviter les droits d’auteur  
- [x] Je ne vais pas faire de perso, je vais davantage travailler sur une partie que j’aime

---

Dans le cas d’une bonne avancée du jeu, le mode histoire pourra peut-être être basé sur les deux héros principaux, ou autres. À voir avec notre avancement.

Bon, maintenant, entrons dans le dernier point que je voulais aborder. D’ailleurs, avant cela, j’avais oublié : dans le cas très probable où nous atteindrions la partie sur l’IA, je pense qu’il serait intéressant d’avoir une IA avec plusieurs niveaux de difficulté.

Elle aurait un mode facile (« Je cours vers le joueur et je le tape ») jusqu’au mode invincible (« Je contre tous les coups du joueur et j’analyse ses points faibles pour le battre le mieux possible »).

---

**Vote : Une IA invincible ?**

- [x] Je pense que l’idée est bonne, je suis pour, mais je me dis que cela risque d’être compliqué  
- [ ] Je suis moyen pour, j’aime pas trop ça  
- [x] Je ne pense pas qu’on pourra faire ça  
- [ ] J’aime pas

---

À partir de cela, j’aimerais vous proposer plusieurs noms pour notre jeu.

---

**Vote : Quel nom choisir ?**

- [x] The Eternal Challenger: A Chronicle of Blades and Will  
- [x] The Undying King’s Tournament: A Legacy Forged in Combat  
- [ ] Rise Against the Machine God: A Journey of Sword and Soul  
- [ ] Chronicles of the Ultimate Duel  
- [ ] The Ascendancy of the Swordmaster  
- [x] Legacy of the Unbeaten  
- [ ] Duel Saga  
- [ ] Combat Chronicles  
- [ ] Eternal Contenders  

---
