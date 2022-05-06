using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Slider slider;

    public Gradient gradient;
    public Image fill;

    public void SetMaxHealth(int health)
    {
        //mettre la vie maximal a  l'initialisation ou la reinitialisation du joueur
        slider.maxValue = health;
        slider.value = health;

        fill.color = gradient.Evaluate(1f);//couleur de base de la barre de vie 
    }

    public void SetHealth(int health)
    {
        //indiquer la vie a la barre de vie
        slider.value = health;
        fill.color = gradient.Evaluate(slider.normalizedValue);
        //recupere la vie dinamicement et transforme la vie avec la normalisation
    }
}
