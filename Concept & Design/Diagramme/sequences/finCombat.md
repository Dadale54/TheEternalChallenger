```mermaid
sequenceDiagram
    Participant Utilisateur
    Participant Combat
    Participant MenuPrincipal

    Combat->>Utilisateur: Fin du Combat
    alt Victoire
        Combat->>Utilisateur: AfficherVictoire()
    else Défaite
        Combat->>Utilisateur: AfficherDefaite()
    end
    Utilisateur->>MenuPrincipal: RetourMenuPrincipal()
```
