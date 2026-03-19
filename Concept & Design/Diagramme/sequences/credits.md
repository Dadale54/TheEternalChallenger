```mermaid
sequenceDiagram
    Participant Utilisateur
    Participant MenuPrincipal
    Participant Credits

    Utilisateur->>MenuPrincipal: Sélectionner "Afficher les Crédits"
    MenuPrincipal->>Credits: AfficherCredits()
    Credits-->>Utilisateur: Afficher les crédits
    Utilisateur->>MenuPrincipal: RetourMenuPrincipal()
```
