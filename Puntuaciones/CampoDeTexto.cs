using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
/*
	Script que gestiona en la pantalla de gameover el registro en el ranking de puntuaciones
	Authors:
	- Marta Fernández Salcedo de la Mela
	 - Guillermo Meléndez Morales
	 - Adrian David Morillas Marco
	 - Zhong Hao Lin Chen
	 - Salvador Nieto Garrido
*/
public class CampoDeTexto : MonoBehaviour {
	// campo de texto para el nombre
	public InputField input;
	// variable que bloquea el boton de enviar, una vez se ha enviado con exito
	public static bool enviado;

	// Use this for initialization
	void Start () {
		// se inicializa el boton
		Button btn = gameObject.GetComponent<Button>();
		btn.onClick.AddListener(Enviar);
		enviado = true;
	}

	// se comprueba que el campo esté correctamente relleno, y se manda al gamecontroller el nombre y la puntuacion del usuario
	void Enviar (){
		if(enviado){			
			if (input.text.Length > 0){
				enviado = false;
				if(GameController.getNumNivel() == 1){
					GameController.n1_setRanking(GameController.GetPuntos(), input.text);
					input.text = input.text + " Almacenado!";
				}
				if(GameController.getNumNivel() == 2){
					GameController.n2_setRanking(input.text, GameController.GetPuntos());
					input.text = input.text + " Almacenado!";
				}
			}else if (input.text.Length == 0){
				input.text = "Nombre incorrecto";
			}
		}
	}

	// comprueba que se ha enviado con exito
	public static bool Enviado (){
		return enviado;
	}
}
