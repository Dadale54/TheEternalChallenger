#!/bin/bash

# Variables
GAME_URL="https://theternalchallenger.fr/downloads/game/linux/theternalchallenger.zip"
MD5_INSTALL_URL="https://theternalchallenger.fr/downloads/md5InstallLinux.txt"
MD5_GAME_URL="https://theternalchallenger.fr/downloads/md5GameLinux.txt"
INSTALL_DIR="/opt/TheTernalChallenger"
TEMP_DIR=$(mktemp -d)
DESKTOP_FILE="/usr/share/applications/TheTernalChallenger.desktop"
ICON_FILE="$INSTALL_DIR/icon.png"  # Si vous avez une icône à inclure
EXEC_FILE="$INSTALL_DIR/theternalchallenger.x86_64"
PROGRESS=0  # Progression initiale

# Calcul de la largeur du terminal
largeur=$(tput cols)
largeur_barre=$((largeur - 8))
# Caractères pour la barre de progression
plein="#"
vide=" "
# Calcul du nombre de caractères pleins à afficher par seconde
incrementation=$((largeur_barre / 11))

# Fonction pour afficher la barre de progression
show_progress() {
    # Calcul du nombre de caractères pleins à afficher
    nb_plein=$(($1 * incrementation))
    pourcentage=$((nb_plein*100/largeur_barre+2))

    # Affichage de la barre de progression
    echo -ne "\r["
    for j in $(seq 1 $((nb_plein))); do
      echo -ne "$plein"
    done
    for j in $(seq 1 $((largeur_barre - nb_plein))); do
      echo -ne "$vide"
    done
    echo -ne "] $pourcentage %"

    sleep 0.2
}

# Fonction pour détecter le gestionnaire de paquets
detect_package_manager() {
    if command -v apt-get &>/dev/null; then
        echo "apt"
    elif command -v pacman &>/dev/null; then
        echo "pacman"
    elif command -v dnf &>/dev/null; then
        echo "dnf"
    elif command -v zypper &>/dev/null; then
        echo "zypper"
    else
        echo "unknown"
    fi
}

# Fonction pour installer un paquet avec le gestionnaire de paquets détecté
install_package_if_missing() {
    PACKAGE=$1
    PACKAGE_MANAGER=$(detect_package_manager)

    if ! command -v $PACKAGE &> /dev/null; then
        case $PACKAGE_MANAGER in
            apt)
                sudo apt-get install -y $PACKAGE &>/dev/null
                ;;
            pacman)
                sudo pacman -Sy --noconfirm $PACKAGE &>/dev/null
                ;;
            dnf)
                sudo dnf install -y $PACKAGE &>/dev/null
                ;;
            zypper)
                sudo zypper install -y $PACKAGE &>/dev/null
                ;;
            *)
                echo "Erreur : Gestionnaire de paquets non supporté ou introuvable."
                exit 1
                ;;
        esac
    fi
}

# Fonction pour vérifier si le jeu est déjà installé
check_if_installed() {
    if [ -d "$INSTALL_DIR" ] && [ -f "$EXEC_FILE" ]; then
        return 0  # Jeu déjà installé
    else
        return 1  # Jeu non installé
    fi
}

# Fonction pour afficher les conditions d'utilisation point par point
show_eula() {
    clear
    echo "=========================================="
    echo "  Conditions d'utilisation - The Eternal Challenger"
    echo "=========================================="
    echo ""

    text="Conditions d'utilisation de \"The Eternal Challenger\"

1. Acceptation des conditions
    En téléchargeant, installant ou utilisant le jeu \"The Eternal Challenger\" (ci-après dénommé \"le Jeu\"), vous acceptez de vous conformer aux présentes conditions d'utilisation. Si vous n'acceptez pas ces conditions, vous devez immédiatement cesser d'utiliser le Jeu, désinstaller toute copie du Jeu et supprimer tout contenu associé.

2. Licence d'utilisation
    2.1 Octroi de licence :
        La Légion de Muyue vous accorde une licence limitée, non exclusive, non transférable, non sous-licenciable et révocable pour installer et utiliser le Jeu à des fins strictement personnelles et non commerciales.

    2.2 Restrictions :
        Vous n'êtes pas autorisé à :
          - Modifier, traduire, décompiler, désassembler ou effectuer de l'ingénierie inverse sur le Jeu, sauf dans les limites permises par la loi applicable.
          - Louer, vendre, céder, sous-licencier, distribuer ou exploiter le Jeu à des fins commerciales.
          - Utiliser le Jeu de manière frauduleuse, abusive ou contraire aux lois applicables et aux droits de tiers.
          - Extraire ou réutiliser des éléments du Jeu, y compris mais sans s'y limiter, les graphismes, les musiques, les textes et le code source.

    2.3 Révocation de licence :
        Cette licence peut être révoquée à tout moment en cas de violation des présentes conditions.

3. Âge minimum requis
    Le Jeu est réservé aux utilisateurs âgés d’au moins 9 ans. Si vous avez moins de 9 ans, vous devez obtenir l’autorisation explicite d’un parent ou tuteur légal avant de télécharger, installer ou utiliser le Jeu. En acceptant ces conditions, vous déclarez et garantissez avoir l’âge requis ou avoir obtenu ladite autorisation.

4. Propriété intellectuelle
    4.1 Titularité :
        Tous les droits relatifs au Jeu, y compris mais sans s’y limiter, le code source, les graphismes, les musiques, les textes, les concepts, les noms et autres contenus, sont la propriété exclusive de La Légion de Muyue, sauf mention contraire.

    4.2 Utilisation autorisée :
        Vous ne pouvez utiliser les éléments du Jeu que dans le cadre de l’expérience de jeu prévue et conformément à ces conditions. Toute autre utilisation non autorisée est strictement interdite.

    4.3 Contributions tierces :
        Certains éléments du Jeu peuvent inclure des contenus sous licences tierces, y compris des œuvres sous licence \"domaine public\". Ces contributions sont signalées dans les mentions légales du Jeu.

5. Limitation de responsabilité
    5.1 Aucune garantie :
        Le Jeu est fourni \"en l'état\" sans garantie d'aucune sorte, expresse ou implicite. La Légion de Muyue ne garantit pas que le Jeu sera exempt d’erreurs, sécurisé ou compatible avec tous les matériels et logiciels.

    5.2 Responsabilité limitée :
        Dans les limites permises par la loi applicable, La Légion de Muyue décline toute responsabilité pour :
          - Les pertes de données, interruptions de service ou incompatibilités matérielles.
          - Les dommages directs, indirects, spéciaux ou consécutifs résultant de l’utilisation ou de l’impossibilité d’utiliser le Jeu.

    5.3 Indemnisation :
        Vous acceptez d’indemniser et de dégager La Légion de Muyue de toute responsabilité en cas de réclamation, action en justice ou demande découlant de votre violation des présentes conditions ou de votre utilisation abusive du Jeu.

6. Support et mises à jour
    6.1 Support technique :
        Le support technique pour le Jeu est fourni à titre gracieux et n’est pas garanti.

    6.2 Mises à jour :
        La Légion de Muyue peut publier des mises à jour ou correctifs pour le Jeu. Vous acceptez que ces mises à jour puissent être téléchargées et installées automatiquement.

7. Confidentialité et collecte des données
    Aucune donnée personnelle n’est collectée ni stockée par le Jeu.

8. Droit applicable et juridiction compétente
    Les présentes conditions d’utilisation sont régies par le droit français. Tout litige découlant des présentes conditions ou de l’utilisation du Jeu sera soumis à la compétence exclusive des tribunaux français, situés dans le ressort de La Rochelle.

9. Résiliation
    En cas de violation des présentes conditions, La Légion de Muyue se réserve le droit de résilier votre licence et de restreindre ou bloquer votre accès au Jeu sans préavis.

10. Modifications des conditions d’utilisation
    La Légion de Muyue se réserve le droit de modifier ces conditions à tout moment. Les modifications prendront effet dès leur publication sur le site officiel ou leur intégration dans une mise à jour du Jeu. Vous êtes invité à consulter régulièrement ces conditions pour vous tenir informé des éventuelles modifications.

11. Contact
    Pour toute question concernant ces conditions d'utilisation, veuillez contacter La Légion de Muyue à l’adresse suivante : augustin.j.l.roux@gmail.com."

    for ((i=0; i<${#text}; i++)); do
        echo -n "${text:i:1}"
        sleep 0.001
    done

    echo ""
    echo ""
    echo "=========================================="
    echo "Veuillez lire attentivement ces conditions."
    echo "=========================================="

    echo ""
    echo "Acceptez-vous ces conditions d'utilisation ? (y/n)"
    read -p "Votre choix : " choice

    case "$choice" in
        [Yy]*)
            echo "Merci d'avoir accepté les conditions. L'installation continue..."
            ;;
        [Nn]*)
            echo "Vous n'avez pas accepté les conditions. L'installation est annulée."
            exit 1
            ;;
        *)
            echo "Choix invalide. L'installation est annulée."
            exit 1
            ;;
    esac
}

# Appel de la fonction pour afficher les conditions d'utilisation
show_eula

# Vérification si le jeu est déjà installé
if check_if_installed; then
    read -p "Le jeu est déjà installé. Voulez-vous le réinstaller ? (y/n) " choice
    case "$choice" in
        [Yy]*)
            sudo rm -rf "$INSTALL_DIR" "$DESKTOP_FILE"
            ;;
        [Nn]*)
            echo "Quitter l'installation."
            exit 0
            ;;
        *)
            echo "Choix invalide. L'installation est interrompue."
            exit 1
            ;;
    esac
fi

echo ""

show_progress $PROGRESS

# Téléchargement des md5
wget -q $MD5_INSTALL_URL -O $TEMP_DIR/md5InstallLinux.txt
wget -q $MD5_GAME_URL -O $TEMP_DIR/md5GameLinux.txt
PROGRESS=$((PROGRESS+1))
show_progress $PROGRESS

# Somme de contrôle MD5 attendue
MD5_ATTENDU_INSTALL=$(cat $TEMP_DIR/md5InstallLinux.txt)

# Calculer la somme de contrôle MD5 du fichier téléchargé
MD5_CALCUL_INSTALL=$(md5sum "./theEternalChallengerSetup.sh" | awk '{print $1}')

# Vérifier l'intégrité du fichier
if [[ "$MD5_CALCUL" != "$MD5_ATTENDU" ]]; then
  echo ""
  echo "Erreur: le téléchargement de l'installateur est corrompu."
  rm "./theEternalChallengerSetup.sh"
  exit 1
fi
PROGRESS=$((PROGRESS+1))
show_progress $PROGRESS

# Vérification et installation des dépendances
install_package_if_missing "wget"
install_package_if_missing "curl"
install_package_if_missing "unzip"
PROGRESS=$((PROGRESS+1))
show_progress $PROGRESS

# Téléchargement du jeu avec une barre de progression
wget -q $GAME_URL -O $TEMP_DIR/theternalchallenger.zip
PROGRESS=$((PROGRESS+1))
show_progress $PROGRESS

# Somme de contrôle MD5 attendue
MD5_ATTENDU=$(cat $TEMP_DIR/md5GameLinux.txt)

# Calculer la somme de contrôle MD5 du fichier téléchargé
MD5_CALCUL=$(md5sum "$TEMP_DIR/theternalchallenger.zip" | awk '{print $1}')

# Vérifier l'intégrité du fichier
if [[ "$MD5_CALCUL" != "$MD5_ATTENDU" ]]; then
  echo ""
  echo "Erreur: le téléchargement est corrompu."
  rm "$TEMP_DIR/theternalchallenger.zip"
  exit 1
fi
PROGRESS=$((PROGRESS+1))
show_progress $PROGRESS

# Créer le répertoire d'installation
sudo mkdir -p "$INSTALL_DIR"
PROGRESS=$((PROGRESS+1))
show_progress $PROGRESS

# Extraction de l'archive avec une barre de progression
sudo unzip -q "$TEMP_DIR/theternalchallenger.zip" -d "$INSTALL_DIR"
PROGRESS=$((PROGRESS+1))
show_progress $PROGRESS

# Donner les permissions nécessaires
sudo chmod +x "$INSTALL_DIR/theternalchallenger.x86_64"
PROGRESS=$((PROGRESS+1))
show_progress $PROGRESS

# Nettoyer le répertoire temporaire
rm -rf "$TEMP_DIR"
PROGRESS=$((PROGRESS+1))
show_progress $PROGRESS

# Créer le raccourci dans le répertoire global des applications
sudo bash -c "cat <<EOF > $DESKTOP_FILE
[Desktop Entry]
Version=1.0
Name=The Eternal Challenger
Comment=Jeu graphique The Eternal Challenger
Exec=$(printf "%q" "$EXEC_FILE")
Icon=$(printf "%q" "$ICON_FILE")
Terminal=false
Type=Application
Categories=Game;
EOF"
PROGRESS=$((PROGRESS+1))
show_progress $PROGRESS

# Rendre le raccourci exécutable
sudo chmod +x "$DESKTOP_FILE"
PROGRESS=$((PROGRESS+1))
show_progress $PROGRESS

echo ""

# Message de succès
echo -e "\nInstallation terminée avec succès ! 🎉"
