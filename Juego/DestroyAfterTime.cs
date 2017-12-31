//Para destruir las particulas
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/*
	Script que maneja destruye el objeto despues de un tiempo definido
	Authors:
	- Marta Fernández Salcedo de la Mela
	 - Guillermo Meléndez Morales
	 - Adrian David Morillas Marco
	 - Zhong Hao Lin Chen
	 - Salvador Nieto Garrido
*/
public class DestroyAfterTime : MonoBehaviour {
	// tiempo de destruccion
	public float destroyTime = 2.0f;

	void Start () {
		//Despues del tiempo establecido, ejecuta el metodo die
		Invoke ("Die", destroyTime);
	}

	//Destruye el propio objeto
	void Die () {
		Destroy (gameObject);
	}
}
