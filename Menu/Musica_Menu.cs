using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
/*
	Script que gestiona la musica del menú
	Authors:
	- Marta Fernández Salcedo de la Mela
	 - Guillermo Meléndez Morales
	 - Adrian David Morillas Marco
	 - Zhong Hao Lin Chen
	 - Salvador Nieto Garrido
*/
public class Musica_Menu : MonoBehaviour {
	// variables del contenido multimedia
	public AudioClip musica;
	private AudioSource source;
	private static bool MusicOn;
	public Button btn; //poner en inspector
	private Sprite img;

	// inicializa el componente de audio del objeto
	void Awake() {
		source = GetComponent<AudioSource>();
	}

	// reproduce la musica del juego
	void Start () {
		source.PlayOneShot(musica,1);
		MusicOn = true;
	}

	// gestiona el ajuste de configuracion de audio
	public void OnOffMusic() {
		//Si estaba encendida, apagar
		if (MusicOn) {
			source.Pause ();
			img = Resources.Load<Sprite> ("Imagenes/Menus/soundoff");
			btn.GetComponent<Image> ().sprite = img;
			MusicOn = false;
		} else {
			source.UnPause ();
			img = Resources.Load<Sprite> ("Imagenes/Menus/sound");
			btn.GetComponent<Image> ().sprite = img;
			MusicOn = true;
		}
	}

	// devuelve si la musica se esta reproduciendo o no
	public static bool getSound () {
		return MusicOn;
	}
}
