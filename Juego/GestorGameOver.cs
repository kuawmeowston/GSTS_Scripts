using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
/*
	Script que maneja la escena de gameover
	Authors:
	- Marta Fernández Salcedo de la Mela
	 - Guillermo Meléndez Morales
	 - Adrian David Morillas Marco
	 - Zhong Hao Lin Chen
	 - Salvador Nieto Garrido
*/
public class GestorGameOver : MonoBehaviour {
	//poner en el inspector
	public Text textoPuntuacion; 
	// puntos finales de la partida
	private int puntosFinales;
	// nivel finalizado
	private int numNivel;
	// como se ha finalizado la partida
	private bool win;
	// titulo de la escena
	public Image img;
	// boton de cambio de nivel
	public Button btnNivel;
	// campo de texto de la escena
	public InputField input;

	// Use this for initialization
	void Start () {
		//Imagen segun win
		win = GameController.getWin ();
		if(win) img.sprite = Resources.Load<Sprite> ("Imagenes/Menus/win"); 
		else img.sprite = Resources.Load<Sprite> ("Imagenes/Menus/lose"); 

		//Obtener la puntuacion
		puntosFinales = GameController.GetPuntos();
		//Mostrarlos en el texto
		textoPuntuacion.text = "Puntuación: "+puntosFinales.ToString();

		//Botones segun nivel actual
		numNivel = GameController.getNumNivel();
		if (numNivel == 1) {
			btnNivel.GetComponent<Image> ().sprite = Resources.Load<Sprite> ("Imagenes/Menus/nivel2");
		} else if (numNivel == 2) {
			btnNivel.GetComponent<Image> ().sprite = Resources.Load<Sprite> ("Imagenes/Menus/nivel1");
		}
	}

	//Funcion para los botones de menu o nivel
	public void CargarEscena (string escena) {
		if(CampoDeTexto.Enviado() == false){
			//Resetear puntos y vida
			GameController.ResetVida();
			GameController.ResetPuntos ();
			GameController.setWin (false);
			// comprueba el nivel
			if (escena.Equals ("Nivel")) {
				GameController.setNumNivel ((numNivel % 2) + 1);
				SceneManager.LoadScene (escena + ((numNivel % 2) + 1));
			} else {
				SceneManager.LoadScene (escena);
			}
		}else{
			// si no se rellena el campo, no te permite volver
			input.text = "Rellene primero";
		}
		
	} 
}
