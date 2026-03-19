<!DOCTYPE html>
<html lang="fr">
    <head>
        <title>The Eternal Challenger | Download</title>

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
            <section class="dwn">
                <h2 class="dwn__title">Télécharger le jeu</h2>
                <p class="dwn__paragraph" id="dwn__se">Système d'exploitation détecté : </p>
                <div class="dwn__card">
                    <img class="dwn__img" src="./assets/download/windows.webp" alt="Logo de Windows">
                    <h3 class="dwn__subtitle">Windows</h3>
                    <a class="dwn__btn" href="downloads/SetupTheEternalChallenger.exe" download>Télécharger</a>
                    <a class="dwn__btn" href="downloads/md5GameWindows.text" download>md5 setup</a>
                </div>
                <div class="dwn__card">
                    <img class="dwn__img" src="assets/download/linux.webp" alt="Logo de Linux">
                    <h3 class="dwn__subtitle">Linux</h3>
                    <a class="dwn__btn" href="downloads/theEternalChallengerSetup.sh" download>Télécharger</a>
                    <a class="dwn__btn" href="downloads/md5InstallLinux.txt" download>md5 setup</a>
                    <a class="dwn__btn" href="downloads/md5GameLinux.txt" download>md5 game</a>
                </div>
            </section>

            <section class="config --bred">
                <h2 class="config__title">Configuration requise</h2>
                <p>Espace disque : 15 Go d'espace libre</p>
                <div class="config__cols">
                
                <article class="config__col">
                    <h3 class="config__subtitle">Configuration recommandée</h3>
                    <ul class="config__list">
                        <li>Système d'exploitation : Windows 10 / Linux</li>
                        <li>Processeur : Intel Core i3 ou équivalent (AMD Ryzen 3 ou supérieur)</li>
                        <li>Mémoire vive : 8 Go</li>
                        <li>Carte graphique : NVIDIA GeForce GTX 750 ou équivalent (AMD Radeon, ou graphique intégré)</li>
                    </ul>
                </article>
                
                <article class="config__col">
                    <h3 class="config__subtitle">Configuration Gamers</h3>
                    <ul class="config__list">
                        <li>Système d'exploitation : Windows 11 / Linux</li>
                        <li>Processeur : Intel Core i9 ou équivalent (AMD Ryzen 9 ou supérieur)</li>
                        <li>Mémoire vive : 64 Go</li>
                        <li>Carte graphique : NVIDIA GeForce GTX 4090 ou équivalent (AMD Radeon)</li>
                    </ul>
                </article>
                            </div>
            </section>
            
            <section>
                <h2>Instructions d'installation</h2>
                <article class="ins__card">
                    <img class="ins__img" src="./assets/download/windows.webp" alt="Logo de Windows">
                    <h3 class="ins__subtitle">Windows</h3>
                    <ul>
                        <li class="ins__li">Cliquez sur le bouton "Télécharger pour Windows" ci-dessus.</li>
                        <li class="ins__li">Une fois le téléchargement terminé, double-cliquez sur le fichier installateur pour lancer le programme d'installation.</li>
                        <li class="ins__li">Suivez les instructions à l'écran pour installer le jeu.</li>
                    </ul>
                </article>
                <article class="ins__card">
                    <img class="ins__img" src="assets/download/linux.webp" alt="Logo de Linux">
                    <h3 class="ins__subtitle">Linux</h3>
                    <ul>
                        <li class="ins__li">Cliquez sur le bouton "Télécharger pour Linux" ci-dessus.</li>
                        <li class="ins__li">Ouvrez un terminal.</li>
                        <li class="ins__li">Naviguez jusqu'au dossier où vous avez téléchargé le fichier d'installation à l'aide de la commande `cd`. Par exemple, si le fichier est dans votre dossier Téléchargements, tapez `cd Téléchargements`.</li>
                        <li class="ins__li">Rendez le fichier d'installation exécutable en utilisant la commande `chmod +x theEternalChallengerSetup.sh`.</li>
                        <li class="ins__li">Exécutez le fichier d'installation en tapant `./theEternalChallengerSetup.sh`.</li>
                        <li class="ins__li">Suivez les instructions à l'écran pour terminer l'installation.</li>
                    </ul>
                </article>
            </section>
        </main>
        <?php include "./footer.php"; ?>
        <script>
            function detectOS() {
                const userAgent = navigator.userAgent || navigator.vendor || window.opera;
                const platform = navigator.platform;

                let os = "Inconnu";
                if (/windows phone/i.test(userAgent)) {
                    os = "Windows Phone";
                } else if (/win/i.test(platform)) {
                    os = "Windows";
                } else if (/mac/i.test(platform)) {
                    os = "macOS";
                } else if (/android/i.test(userAgent)) {
                    os = "Android";
                } else if (/iphone|ipad|ipod/i.test(userAgent)) {
                    os = "iOS";
                } else if (/linux/i.test(platform)) {
                    os = "Linux";
                }
                const osInfoElement = document.getElementById('dwn__se');
                osInfoElement.textContent = `Système d'exploitation détecté ${os}`;
            }               
            detectOS();
        </script>
    </body>
</html>
