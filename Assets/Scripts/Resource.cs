using UnityEngine;
using UnityEngine.Assertions;

class Resource : MonoBehaviour {

    public int maxHealth = 100;
    public int currentHealth;

    public HealthBar healthBar;

    public enum ResourceType {
        tree,
        rock,
        gold
    }

    public ResourceType type;

    void Start() {
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
        healthBar.ShowHealthBar(false);
    }

    void OnMouseOver() {
        healthBar.ShowHealthBar(true);
    }

    void OnMouseExit() {
        healthBar.ShowHealthBar(false);
    }

    public void TakeDamage(int damage) {
        currentHealth -= damage;
        healthBar.SetHealth(currentHealth);
        if (currentHealth <= 0) {
            Destroy(gameObject);
        }
    }

}
