using UnityEngine;

namespace SRP {
    [RequireComponent(typeof(ShipInput))]
    public class ShipEngine : MonoBehaviour {
        [SerializeField]
        private float speed = 5f;
        [SerializeField]
        private float turnSpeed = 5f;

        private ShipInput shipInput;

        void Start () {
            shipInput = GetComponent<ShipInput>();
        }

        void Update () {
            // Move and rotate spaceship
            transform.position += transform.up * (shipInput.Vertical * Time.deltaTime * speed);
            transform.Rotate(-Vector3.forward * (shipInput.Horizontal * Time.deltaTime * turnSpeed));
        }
    }
}
