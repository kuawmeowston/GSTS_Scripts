using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/*
	Script pendiente de optimización, que fragmenta el objeto al colisionar, en varios trozos. Actualmente
	no se encuentra asociado en el juego
	Authors:
	- Marta Fernández Salcedo de la Mela
	 - Guillermo Meléndez Morales
	 - Adrian David Morillas Marco
	 - Zhong Hao Lin Chen
	 - Salvador Nieto Garrido
*/
public class Habilidad_4_colision : MonoBehaviour {
	// se carga el objeto fragmentado
	public Transform BrokenObject;
	public Transform Effect;
	// al colisionar se cambia el modelo actual, por el fragmentado
	void OnCollisionEnter(Collision col){
		if(col.gameObject.tag == " "){

		}else{
			breakDeath();
		}
	}

	void breakDeath (){
		Instantiate (BrokenObject, transform.position, BrokenObject.transform.rotation);
		Destroy(gameObject);
	}
}
