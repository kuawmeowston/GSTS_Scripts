using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/*
	Script que maneja la rotacion de la araña a la hora de caminar
	Authors:
	- Marta Fernández Salcedo de la Mela
	 - Guillermo Meléndez Morales
	 - Adrian David Morillas Marco
	 - Zhong Hao Lin Chen
	 - Salvador Nieto Garrido
*/
public class rotacion : MonoBehaviour {
	public LayerMask mask;
	// Update is called once per frame
	void Update () {
		// se coge la alineacion y se le aplica a la araña		
		GetAlignment ();
	}

	void GetAlignment () {
		RaycastHit hit;
		Physics.Raycast (transform.position, -transform.up, out hit, 1.5f, mask);
		Vector3 newUp = hit.normal;
		transform.up = newUp;
		transform.Rotate(0, 720, 0);
		
	}
}
