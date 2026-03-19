**Ce fichier liste les différentes tâches du projet.**

Ce fichier est essentiel au bon fonctionnement du projet. Il n'y a pas d'obligation sur qui fait quoi, la seule règle ici c'est : je mets mon nom devant le ou les points que je vais réaliser, puis je le fais. Bien sûr, plusieurs personnes peuvent réaliser la même chose, il suffit de le dire entre vous avant toute continuation pour éviter les conflits.
Et bien sûr, si j'ai oublié des points, vous pouvez les rajouter.

**I. Gameplay (~50 parties)**

* **Mécaniques de base (~20 parties)**
    1.  Mouvement du personnage (droite, gauche)
    2.  Saut du personnage
    3.  Accroupissement du personnage
    4.  Attaque faible (face)
    5.  Attaque faible (haut)
    6.  Attaque faible (bas)
    7.  Attaque forte (face)
    8.  Attaque forte (haut)
    9.  Attaque forte (bas)
    10. Défense face aux attaques faibles (face)
    11. Défense face aux attaques faibles (haut)
    12. Défense face aux attaques faibles (bas)
    13. Défense face aux attaques fortes (face)
    14. Défense face aux attaques fortes (haut)
    15. Défense face aux attaques fortes (bas)
    16. Sprint du personnage
    17. Esquive du personnage
    18. Collision avec l'environnement
    19. Collision entre les personnages
    20. Gestion des dégâts

* **Système de combat (~15 parties)**
    1.  Initialisation du combat
    2.  Détection des coups
    3.  Calcul des dégâts
    4.  Mise à jour de la vie des personnages
    5.  Conditions de fin de combat
    6.  Affichage du gagnant
    7.  Retour au menu principal
    8.  Gestion des animations d'attaque
    9. Gestion des animations de défense
    10. Gestion des animations de déplacement
    11. Synchronisation des animations avec les actions
    12. Effets visuels lors des coups
    13. Effets sonores lors des coups
    14. Transitions entre les phases de combat

* **Personnages (~5 parties)**
    1.  Création des sprites des personnages (~1 par personne)
    2.  Animation des personnages (marche, saut, attaque, etc.) (~1 par personne)
    3.  Implémentation des mouvements spéciaux (~1 par personne)

**II. Intelligence Artificielle (~30 parties)**

* **Niveaux de difficulté (~15 parties)**
    1.  IA facile (mouvements aléatoires)
    2.  IA moyenne (réagit aux actions du joueur)
    3.  IA difficile (anticipe les actions du joueur)
    4.  IA très difficile (utilise des combos)
    5.  IA invincible (contre-attaque parfaitement)
    6.  Adaptation de l'IA au personnage choisi
    7.  Apprentissage des habitudes du joueur par l'IA
    8.  Exploitation des faiblesses du joueur par l'IA
    9.  Variation des comportements de l'IA
    10. Équilibrage de la difficulté des différents niveaux
    11. Tests et ajustements de l'IA
    12.  Détection des patterns du joueur
    13.  Analyse du timing des actions du joueur
    14.  Prise de décision en fonction de la situation
    15.  Gestion de la mémoire de l'IA

* **Comportements spécifiques (~15 parties)**
    1.  Poursuite du joueur
    2.  Fuite du joueur
    3.  Attaque à distance
    4.  Défense active
    5.  Utilisation d'objets
    6.  Changement de stratégie en cours de combat
    7.  Adaptation à l'environnement
    8.  Coopération entre plusieurs IA (si mode multijoueur)
    9.  Comportements uniques pour chaque personnage IA
    10. Animation des personnages IA
    11.  Synchronisation des actions de l'IA avec les animations
    12.  Effets visuels pour les actions de l'IA
    13.  Effets sonores pour les actions de l'IA
    14.  Déclenchement d'événements spéciaux par l'IA
    15.  Interaction de l'IA avec l'environnement

**III. Interface Utilisateur (~20 parties)**

* **Menu principal (~5 parties)**
    1.  Création du menu principal
    2.  Bouton "Jouer"
    3.  Bouton "Options"
    4.  Bouton "Crédits"
    5.  Bouton "Quitter"

* **Menu des options (~5 parties)**
    1.  Réglage du volume sonore
    2.  Réglage de la résolution d'écran
    3.  Choix de la langue
    4.  Commandes du jeu
    5.  Retour au menu principal

* **Écran de sélection des personnages (~5 parties)**
    1.  Affichage des personnages disponibles
    2.  Sélection du personnage
    3.  Affichage des informations du personnage
    4.  Confirmation du choix
    5.  Retour au menu principal

* **Affichage du jeu (HUD) (~5 parties)**
    1.  Barre de vie des personnages
    2.  Nom des personnages
    3.  Affichage du score
    4.  Messages d'information
    5.  Timer (si nécessaire)

**IV. Graphismes (~20 parties)**

* **Environnement (~10 parties)**
    1.  Création des décors (au moins 3)
    2.  Animation des éléments du décor (si nécessaire)
    3.  Effets de lumière
    4.  Effets de particules
    5.  Arrière-plan
    6.  Éléments interactifs dans le décor
    7.  Ambiance visuelle
    8.  Palette de couleurs
    9.  Optimisation des graphismes
    10.  Adaptation des graphismes à différentes résolutions

* **Effets visuels (~10 parties)**
    1.  Effets d'attaque
    2.  Effets de défense
    3.  Effets de mouvement spécial
    4.  Effets de transition
    5.  Effets de particules
    6.  Effets de lumière
    7.  Effets sonores associés aux effets visuels
    8.  Animations des effets visuels
    9.  Optimisation des effets visuels
    10.  Intégration des effets visuels dans le jeu

**V. Son (~10 parties)**

* **Musique (~5 parties)**
    1.  Musique du menu principal
    2.  Musique de combat
    3.  Musique de victoire
    4.  Musique de défaite
    5.  Ambiance sonore

* **Effets sonores (~5 parties)**
    1.  Effets sonores des coups
    2.  Effets sonores des mouvements
    3.  Effets sonores de l'interface utilisateur
    4.  Effets sonores de l'environnement
    5.  Voix des personnages (si nécessaire)

**VI. Divers (~10 parties)**

* **Tests et débogage (~5 parties)**
    1.  Tests unitaires
    2.  Tests d'intégration
    3.  Tests système
    4.  Correction des bugs
    5.  Optimisation du code

* **Documentation (~5 parties)**
    1.  Documentation du code
    2.  Manuel utilisateur
    3.  README
    4.  Crédits
    5.  Licence
