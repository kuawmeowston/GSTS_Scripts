using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
	Script que maneja el daño al usuario
	Authors:
	- Marta Fernández Salcedo de la Mela
	 - Guillermo Meléndez Morales
	 - Adrian David Morillas Marco
	 - Zhong Hao Lin Chen
	 - Salvador Nieto Garrido
*/
public class destination : MonoBehaviour {
	// objeto padre
	private GameObject parent;
	// si la araña colisiona, resta cieta porcion de vida al usuario
	void OnTriggerEnter(Collider other) {
		if(other.gameObject.CompareTag("Enemy")) {
			parent = other.gameObject.transform.parent.gameObject;
			//Detener a la araña
			parent.GetComponent<UnityEngine.AI.NavMeshAgent> ().isStopped = true;
			other.gameObject.GetComponent<Animator> ().SetBool ("toAttack", true);
			//Quitar una vida
			GameController.QuitarVida(1.0f);
		}
	}


		
}
