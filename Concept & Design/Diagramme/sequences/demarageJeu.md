```mermaid
sequenceDiagram
    Participant Utilisateur
    Participant MenuPrincipal
    Participant ChoixPersonnage
    Participant Combat

    Utilisateur->>MenuPrincipal: Sélectionner "Démarrer le jeu"
    MenuPrincipal->>ChoixPersonnage: AfficherPersonnages()
    ChoixPersonnage-->>Utilisateur: Liste des personnages
    Utilisateur->>ChoixPersonnage: ChoisirPersonnage()
    ChoixPersonnage->>ChoixPersonnage: InitialiserPersonnage()
    ChoixPersonnage->>Utilisateur: Lancement du Combat? (Retour ou Commencer)
    Utilisateur->>Combat: Commencer le Combat
```
