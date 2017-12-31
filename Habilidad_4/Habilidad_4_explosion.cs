using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/*
	Maneja la explosion del ferrero
	Authors:
	- Marta Fernández Salcedo de la Mela
	 - Guillermo Meléndez Morales
	 - Adrian David Morillas Marco
	 - Zhong Hao Lin Chen
	 - Salvador Nieto Garrido
*/
public class Habilidad_4_explosion : MonoBehaviour {
	// radio de la explosion
	public static int radio;
	// collider del ferrero
	private SphereCollider myCollider;

	// Use this for initialization
	void Start () {
		// se inicializa la colision
		myCollider = transform.GetComponent<SphereCollider>();
		// se inicializa el radio
		myCollider.radius = 0.112f;
	}

	public void Boom (GameObject enemy){
		//Utiliza la funcion del enemigo para restarle vida
		if (enemy.CompareTag("Enemy")) {
			enemy.GetComponent<Enemy> ().Vida_Reduc (12);
		}
	}

	//Este collider solo se activa una vez que el objeto choca contra algo
	void OnTriggerEnter(Collider other) {		
		//Para todos los objetos que entren en el trigger, llama a boom
		Boom(other.gameObject);
	}
}
