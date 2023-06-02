using System;
using System.Collections.Generic;
using UnityEngine;

namespace SRP {
	public class WeaponControl : MonoBehaviour {
		private List<GameObject> children = new List<GameObject>();
		private int index = 0;

		void Start () {
			foreach (Transform child in transform) {
				GameObject obj = child.gameObject;
				obj.SetActive(false);
				children.Add(obj);
			}
			children[index].SetActive(true);
		}

		void OnEnable () {
			GetComponent<ShipInput>().OnChangeWeapon += SelectWeapon;
		}

		void OnDisable () {
			GetComponent<ShipInput>().OnChangeWeapon -= SelectWeapon;
		}

		void SelectWeapon (int value) {
			children[index].SetActive(false);
			index = value;
			children[index].SetActive(true);
		}
	}
}
