using System;
using UnityEngine;

namespace SRP {
    public class ShipHealth : MonoBehaviour {
        private readonly int maxHealth = 100;
        private int health;
        public event Action OnDie;

        void Start () {
            health = maxHealth;
        }

        void OnCollisionEnter2D (Collision2D collision) {
            if (collision.gameObject.CompareTag("Enemy")) {
                health -= 5;
                if (health <= 0) {
                    OnDie?.Invoke();
                    Destroy(gameObject);
                }
            }
        }
    }
}
