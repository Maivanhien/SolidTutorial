using System;
using UnityEngine;

namespace SRP {
    public class ShipInput : MonoBehaviour
    {
        public float Horizontal { get; private set; }
        public float Vertical { get; private set; }
        public event Action OnFire;
        public event Action<int> OnChangeWeapon;
        [SerializeField]
        private float fireResetTime = 1f;
        private float nextFireTime;

        void Update () {
            Horizontal = Input.GetAxis("Horizontal");
            Vertical = Input.GetAxis("Vertical");
            if (CanFire() && Input.GetButtonDown("Fire1")) {
                OnFire?.Invoke();
                nextFireTime = Time.time + fireResetTime;
            }
            if (Input.GetKeyDown(KeyCode.Alpha1)) {
                OnChangeWeapon?.Invoke(0);
            } else if(Input.GetKeyDown(KeyCode.Alpha2)) {
                OnChangeWeapon?.Invoke(1);
            }
        }

        private bool CanFire () {
            return Time.time >= nextFireTime;
        }
    }
}
