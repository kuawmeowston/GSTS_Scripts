using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
/*
	Maneja el icono de la Interfaz de Usuario 
	Authors:
	- Marta Fernández Salcedo de la Mela
	 - Guillermo Meléndez Morales
	 - Adrian David Morillas Marco
	 - Zhong Hao Lin Chen
	 - Salvador Nieto Garrido
*/

public class Habilidad_2_UI : MonoBehaviour {
// circulo de progreso
	public Transform LoadingBar;
	// texto que indica el procentaje
	public Transform TextIndicator;
	// cantidad de progreso
	public static float currentAmount;
	// velocidad de progreso
	public float speed;

	// Use this for initialization
	void Start () {
		currentAmount = 0;
	}
	
	// Update is called once per frame
	void Update () {
		// mientras sea inferior a 100%
		if(currentAmount < 100){
			// aumentamos la velocidad
			currentAmount += speed * Time.deltaTime;
			// cambiamos el texto por el nuevo procentaje
			TextIndicator.GetComponent<Text>().text = ((int)currentAmount).ToString() + "%";
		}else{
			// si esta completo lo notificamos
			TextIndicator.GetComponent<Text>().text = "Done";
		}
		// cambiamos la cantidad de progreso del circulo
		LoadingBar.GetComponent<Image>().fillAmount = currentAmount / 100;
	}
}
