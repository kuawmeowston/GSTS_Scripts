using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/*
	Script que maneja la ruta de la araña
	Authors:
	- Marta Fernández Salcedo de la Mela
	 - Guillermo Meléndez Morales
	 - Adrian David Morillas Marco
	 - Zhong Hao Lin Chen
	 - Salvador Nieto Garrido
*/
public class nav : MonoBehaviour {
	// variables del navmesh
	private UnityEngine.AI.NavMeshAgent agente = null;
	public Transform destination = null;

	// se inicializa el navmesh
	void Awake () {
		agente = GetComponent<UnityEngine.AI.NavMeshAgent> ();
	}

	// se define su destino final
	void Update () {
		agente.SetDestination (destination.position);
	}
}
