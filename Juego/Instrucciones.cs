using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
/*
	Script que maneja la escena de instrucciones
	Authors:
	- Marta Fernández Salcedo de la Mela
	 - Guillermo Meléndez Morales
	 - Adrian David Morillas Marco
	 - Zhong Hao Lin Chen
	 - Salvador Nieto Garrido
*/
public class Instrucciones : MonoBehaviour {

	public Button btn; //poner en el inspector
	private int nImg;
	private Sprite img;
	// imagenes de la escena
	private RawImage raw1;
	private RawImage raw2;
	private RawImage raw3;

	// Use this for initialization
	void Start () {
		nImg = 1;
		// inicializa las imagenes, y las oculta
		raw1 = GameObject.Find ("RawImage").GetComponent<RawImage> ();
		raw2 = GameObject.Find ("RawImage2").GetComponent<RawImage> ();
		raw3 = GameObject.Find ("RawImage3").GetComponent<RawImage> ();
		raw1.enabled = false;
		raw2.enabled = false;
		raw3.enabled = false;
	}

	//Cambiar imagen
	public void CambiarImg () {
		nImg = (nImg % 3) + 1;
		if (nImg == 1) {
			SceneManager.LoadScene ("MenuPpal");
		} else {
			img = Resources.Load<Sprite> ("Imagenes/Instrucciones/inst_" + nImg.ToString ());
			btn.GetComponent<Image> ().sprite = img;
			if (nImg == 3) {
				raw1.enabled = true;
				raw2.enabled = true;
				raw3.enabled = true;
			}
		}			
	}
}
