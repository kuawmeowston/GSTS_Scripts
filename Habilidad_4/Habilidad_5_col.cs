using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/*
	Script que maneja la destruccion del m&m, pasado un cierto tiempo
	Authors:
	- Marta Fernández Salcedo de la Mela
	 - Guillermo Meléndez Morales
	 - Adrian David Morillas Marco
	 - Zhong Hao Lin Chen
	 - Salvador Nieto Garrido
*/
public class Habilidad_5_col : MonoBehaviour {
	// al detectar colision, se llama a la coroutina, dando igual contra qué choque
	void OnCollisionEnter(Collision col){
		if(col.gameObject.tag == " "){

		}else{
			StartCoroutine("destruccion");
		}
	}
	// espera 3 segundos, y a continuación desactiva el objeto y lo recoloca en la lista
	IEnumerator destruccion (){
		yield return new WaitForSeconds(3f);
		gameObject.SetActive(false);
		Dispara.Q_mms.Enqueue(gameObject);
	}
}
