```mermaid
sequenceDiagram
    Participant Utilisateur
    Participant MenuPrincipal
    Participant Options

    Utilisateur->>MenuPrincipal: Sélectionner "Options"
    MenuPrincipal->>Options: AfficherOptions()
    Options-->>Utilisateur: Liste des paramètres
    Utilisateur->>Options: ModifierParametres()
    Options->>Utilisateur: Confirmation des changements
    Utilisateur->>MenuPrincipal: RetourMenuPrincipal()
```
