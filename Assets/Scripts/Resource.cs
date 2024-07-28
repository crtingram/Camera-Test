using UnityEngine;

public class Resource : MonoBehaviour {

    public int maxHealth = 100;
    public int currentHealth;

    public HealthBar healthBar;

    void Start() {
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
        healthBar.ShowHealthBar(false);
    }

    void Update() {
        if (Input.GetKeyDown(KeyCode.Space)) {
            TakeDamage(20);
        }
    }

    void TakeDamage(int damage) {
        currentHealth -= damage;
        healthBar.SetHealth(currentHealth);
    }

    void OnMouseOver() {
        healthBar.ShowHealthBar(true);
    }

    void OnMouseExit() {
        healthBar.ShowHealthBar(false);
    }

}
