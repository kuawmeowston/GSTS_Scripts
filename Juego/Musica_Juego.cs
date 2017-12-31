using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/*
	Script que maneja la musica del juego
	Authors:
	- Marta Fernández Salcedo de la Mela
	 - Guillermo Meléndez Morales
	 - Adrian David Morillas Marco
	 - Zhong Hao Lin Chen
	 - Salvador Nieto Garrido
*/
public class Musica_Juego : MonoBehaviour {
	// variables de sonido
	public AudioClip musica;
	private AudioSource source;

	// inicializa el componente de audio
	void Awake() {
		source = GetComponent<AudioSource>();
	}
	// si se permite reproducir sonido, reproduce la musica
	void Start () {
		if(GameController.getSound()) source.PlayOneShot(musica, 0.3f);
	}
}
