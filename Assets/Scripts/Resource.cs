using UnityEngine;
using UnityEngine.Assertions;

class Resource : MonoBehaviour {

    public int maxHealth;
    public int currentHealth;

    public enum ResourceType {
        tree,
        rock,
        gold
    }

    public ResourceType type;

    void Start() {
        currentHealth = maxHealth;
    }

    public void TakeDamage(int damage) {
        currentHealth -= damage;
        if (currentHealth <= 0) {
            Destroy(gameObject);
        }
    }

    public DisplayObject GetDisplayObject() {
        return new DisplayObject("", ToString());
    }

    public override string ToString() {
        return currentHealth + " / " + maxHealth;
    }

}
