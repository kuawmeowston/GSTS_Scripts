using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
/*
	Script que maneja el tiempo de partida, y su correspondiente imahen
	Authors:
	- Marta Fernández Salcedo de la Mela
	 - Guillermo Meléndez Morales
	 - Adrian David Morillas Marco
	 - Zhong Hao Lin Chen
	 - Salvador Nieto Garrido
*/
public class tiempo : MonoBehaviour {
	// cantidad de progreso (el serialize lo convierte a bytes, por lo que es más veloz su procesamiento)
	public static float currentAmount;
	public float t = 60;
	// disco progresivo
	public Transform LoadingBar;
	// velocidad de progreso
	float speed;

	// inicializa el tiempo
	void Start () {
		currentAmount = 100;
		StartCoroutine("cuenta_atras");
	}

	// queremos 1 minuto de tiempo
	// 100/60 = 1.66
	// 1.66/2 = 0.83
	IEnumerator cuenta_atras (){
		// resta una porcion de queso, cada cierto tiempo
		while(currentAmount > 0){
			currentAmount -= 100/t/2/10;
			LoadingBar.GetComponent<Image>().fillAmount = currentAmount / 100;
			yield return new WaitForSeconds(0.05f);
		}
		//Cuando se acaba el tiempo, el jugador ha ganado
		GameController.setWin(true);
		//Se le bonifica segun la vida que le quede
		GameController.AddPuntos(10*(int)GameController.GetVida());
		//Cargar game over
		SceneManager.LoadScene ("GameOver");
	}
}
