using SRP;
using UnityEngine;

namespace OCP {
    public class MissileLauncher : MonoBehaviour, ILauncher {
        [SerializeField]
        private Rigidbody2D bulletObject;
        [SerializeField]
        private float fireThrust = 60f;

        void OnEnable () {
            transform.parent.GetComponent<ShipInput>().OnFire += Launch;
        }

        void OnDisable () {
            transform.parent.GetComponent<ShipInput>().OnFire -= Launch;
        }

        public void Launch () {
            Rigidbody2D bulletRigid = Instantiate(bulletObject, transform.position, transform.rotation);
            bulletRigid.AddForce(transform.up * fireThrust);
        }
    }
}
