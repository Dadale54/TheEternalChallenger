<!DOCTYPE html>
<html lang="fr">
    <head>
        <title>The Eternal Challenger | Accueil</title>

        <meta charset="UTF-8">
        <meta name="viewport" content="width=device-width, initial-scale=1.0">
        <meta name="author" content="Anthony MUDET, Augustin ROUX, Cyprien ROBINAUD, Deryan TREBEAU, Milo GUIARD">
        <meta name="description" content="Plongez dans un monde de combats épiques avec le jeu The Eternal Challenger!">
        <meta name="keywords" content="videogame, 2D, retro">

        <link rel="icon" href="assets/favicon.ico" type="image/x-icon">
        <link rel="stylesheet" href="css/reset.css">
        <link rel="stylesheet" href="css/styles.css">
        <link rel="stylesheet" href="css/responsive.css" media="only screen and (max-width: 768px)">
    </head>
    <body>
        <?php include "./header.php"; ?>
        <main>
            <section class="hero --bred">
                <h2 class="hero__title">Plongez dans un monde de combats épiques !</h2>
                <p class="hero__paragraph text">Maîtrisez l'art du combat dans ce jeu de combat en 2D au style pixel art rétro.</p>
                <a class="hero__btn" href="download.php">Télécharger le jeu</a>
                <img class="hero__img" src="assets/index/hero.webp" alt="Image du jeu"> 
            </section>

            <section class="features">
                <h2 class="features__title">Fonctionnalités principales</h2>
                <ul class="features__elts">
                    <li class="features__elt">Des combats dynamiques en 2D avec des mécaniques inspirées de Mortal Kombat et Super Smash Bros.</li>
                    <li class="features__elt">Un style pixel art rétro qui rend hommage aux classiques du jeu de combat.</li>
                    <li class="features__elt">Des personnages uniques avec leurs propres histoires et attributs.</li>
                    <li class="features__elt">À venir ...</li>
                </ul>
            </section>

            <section class="screens --bred">
                <h2 class="screens__title">Captures d'écran</h2>
                <article class="screens__card">
                    <img class="screens__img" src="assets/index/hero1.webp" alt="Menu principale">
                    <img class="screens__img" src="assets/index/hero2.webp" alt="Combat">
                    <img class="screens__img" src="assets/index/hero3.webp" alt="Combat">
                </article>
            </section>

            <section class="story">
                <h2 class="story__title">L'histoire</h2>
                <p class="story__paragraph">À venir ...</p>
            </section>
        </main>
        <?php include "./footer.php"; ?>
    </body>
</html>