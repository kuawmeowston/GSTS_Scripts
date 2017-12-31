using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/*
	Script que gestiona la rotacion del menu
	Authors:
	- Marta Fernández Salcedo de la Mela
	 - Guillermo Meléndez Morales
	 - Adrian David Morillas Marco
	 - Zhong Hao Lin Chen
	 - Salvador Nieto Garrido
*/
public class Rotar : MonoBehaviour {
	// Update is called once per frame
	void Update () {
		transform.Rotate (new Vector3 (0f, 30f, 0f) * Time.deltaTime);
	}
}
