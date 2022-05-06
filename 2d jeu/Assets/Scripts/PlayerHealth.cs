
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    //la vie maximal
    public int maxHealth = 100;
    //la vie courrante du joueur
    public int currentHealth;

    public HealthBar healthBar;
    void Start()
    {
        currentHealth = maxHealth;
        //envoi de la vie a la barre de vie
        healthBar.SetMaxHealth(maxHealth);
    }

    private void Update()//test damage
    {
        if (Input.GetKeyDown(KeyCode.H))
        {
            TakeDamage(20);
        }
    }

    void TakeDamage(int damage) 
    {
        //soustraire les damage de la vie (la vie restante)
        currentHealth -= damage;//currentHealth=  currentHealth - damage;
        healthBar.SetHealth(currentHealth);//envoi de la vie courrant a la barre de vie
    }
}
