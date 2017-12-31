using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
/*
	Script que maneja la carga de escenas
	Authors:
	- Marta Fernández Salcedo de la Mela
	 - Guillermo Meléndez Morales
	 - Adrian David Morillas Marco
	 - Zhong Hao Lin Chen
	 - Salvador Nieto Garrido
*/
public class ControladorEscenas : MonoBehaviour {
	// carga la escena introducida como string
	public void CargarEscena (string escena) {
		if (escena.Equals ("Nivel1")) {
			GameController.setNumNivel (1);
			GameController.setSound (Musica_Menu.getSound ());
		} else if (escena.Equals ("Nivel2")) {
			GameController.setNumNivel (2);
			GameController.setSound (Musica_Menu.getSound ());
		}		SceneManager.LoadScene (escena);
	}
	// sale del juego
	public void Salir () {
		Application.Quit ();
	}
	// abre la pagina en web
	public void AbrirWeb (string web) {
		Application.OpenURL (web);
	}
}
