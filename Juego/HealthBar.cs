using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
/*
	Script que maneja la barra de vida
	Authors:
	- Marta Fernández Salcedo de la Mela
	 - Guillermo Meléndez Morales
	 - Adrian David Morillas Marco
	 - Zhong Hao Lin Chen
	 - Salvador Nieto Garrido
*/
public class HealthBar : MonoBehaviour {
	// cantidad de la barra
	[SerializeField]
	private float fillAmount = 1; 
	[SerializeField]
	// imagen del contenido
	private Image content;
	private static HealthBar hb = null;
	// carga la imagen
	void Awake () {
		hb = this;
	}

	public static void HandleBar (float vidaMax, float vidaActual) {
		//Mapear vida al fillAmount
		hb.fillAmount = vidaActual / vidaMax;
		hb.content.fillAmount = hb.fillAmount;
	}

}
