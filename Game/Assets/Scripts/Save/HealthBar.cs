using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    // Référence au composant Slider de l'objet pour afficher la barre de santé.
    public Slider slider;

    // Gradient de couleurs pour visualiser l'état de santé (ex: vert à rouge).
    public Gradient gradient;

    // Référence au composant Image de l'objet pour modifier la couleur de la barre.
    public Image fill;

    public void setMaxHealth(int health)
    {
        // Définit la valeur maximale du Slider.
        slider.maxValue = health;

        // Initialise la valeur actuelle du Slider à la valeur maximale.
        slider.value = health;

        // Définit la couleur initiale de la barre de santé (en utilisant la couleur à 100% du gradient).
        fill.color = gradient.Evaluate(1f);
    }

    public void setHealth(int health)
    {
        // Met à jour la valeur actuelle du Slider.
        slider.value = health;

        // Met à jour la couleur de la barre de santé en fonction du pourcentage de santé restant 
        // (en utilisant la couleur correspondante du gradient).
        fill.color = gradient.Evaluate(slider.normalizedValue);
    }
}