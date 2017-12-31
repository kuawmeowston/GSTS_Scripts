using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
/*
	Script que gestiona las variables compartidas entre escenas
	Authors:
	- Marta Fernández Salcedo de la Mela
	 - Guillermo Meléndez Morales
	 - Adrian David Morillas Marco
	 - Zhong Hao Lin Chen
	 - Salvador Nieto Garrido
*/
public class GameController : MonoBehaviour {
	// vida maxima del jugador
	public float vidaMax = 10.0f;
	// vida actual del jugador
	private float vidaActual;
	// puntuacion del jugador
	private int puntos;
	// propio GameController
	private static GameController gc = null;
	// define si ha ganado o perdido
	private bool win = false;
	// indice que define el nivel en el que se encuentra el jugador
	private static int numNivel;
	// define en que estado se encuentra el sonido
	private static bool sound;
	// variables de la puntuacion
	private static int [] n1_puntuaciones;
	private static string [] n1_nombres;
	private static int [] n2_puntuaciones;
	private static string [] n2_nombres;
	// variables del PayerPrefs
	private static string[] n1_p_keys = new string[]{"n1_puntuacion_1", "n1_puntuacion_2", "n1_puntuacion_3", "n1_puntuacion_4", "n1_puntuacion_5", "n1_puntuacion_6", "n1_puntuacion_7", "n1_puntuacion_8", "n1_puntuacion_9", "n1_puntuacion_10"};
	private static string[] n2_p_keys = new string[]{"n2_puntuacion_1", "n2_puntuacion_2", "n2_puntuacion_3", "n2_puntuacion_4", "n2_puntuacion_5", "n2_puntuacion_6", "n2_puntuacion_7", "n2_puntuacion_8", "n2_puntuacion_9", "n2_puntuacion_10"};
	private static string[] n1_n_keys = new string[]{"n1_nombre_1", "n1_nombre_2", "n1_nombre_3", "n1_nombre_4", "n1_nombre_5", "n1_nombre_6", "n1_nombre_7", "n1_nombre_8","n1_nombre_9", "n1_nombre_10"};
	private static string[] n2_n_keys = new string[]{"n2_nombre_1", "n2_nombre_2", "n2_nombre_3", "n2_nombre_4", "n2_nombre_5", "n2_nombre_6", "n2_nombre_7", "n2_nombre_8","n2_nombre_9", "n1_nombre_10"};
	// Use this for initialization
	void Start () {		
		// inicializa el array de puntuaciones
		n1_puntuaciones = new int [10];
		n1_nombres = new string [10];
		n2_puntuaciones = new int [10];
		n2_nombres = new string [10];
		// adquiere la puntuacion del PlayerPrefs
		for(int i = 0; i < 10; i++){
			n1_puntuaciones[i] = PlayerPrefs.GetInt(n1_p_keys[i]);
			n2_puntuaciones[i] = PlayerPrefs.GetInt(n2_p_keys[i]);
			n1_nombres[i] = PlayerPrefs.GetString(n1_n_keys[i]);
			n2_nombres[i] = PlayerPrefs.GetString(n2_n_keys[i]);
		}			
		// define su no destruccion e inicializa la vida y los puntos		
		DontDestroyOnLoad(this);
		vidaActual = vidaMax;
		puntos = 0;
		gc = this;
	}

	// devuelve la vida actual
	public static float GetVida () {
		return gc.vidaActual;
	}

	// devuelve la puntuacion actual
	public static int GetPuntos () {
		return gc.puntos;
	}

	// añade puntuacion al usuario
	public static void AddPuntos (int p) {
		gc.puntos += p;
	}
	// quita vida al usuario
	public static void QuitarVida (float v) {
		gc.vidaActual -= v;
		//Actualizar healthbar
		HealthBar.HandleBar(gc.vidaMax, gc.vidaActual);
		if (gc.vidaActual <= 0.0f) {			
			SceneManager.LoadScene ("GameOver");
		}
	}

	// reinicia la vida del usuario
	public static void ResetVida () {
		gc.vidaActual = gc.vidaMax;
	}

	// reinicia la puntuacion del usuario
	public static void ResetPuntos () {
		gc.puntos = 0;
	}

	// Define en que estado ha terminado la partida
	public static void setWin (bool b) {
		gc.win = b;
	}

	// devuelve el estado de la partida
	public static bool getWin () {
		return gc.win;
	}

	// define el nivel de la partida
	public static void setNumNivel (int n) {
		numNivel = n;
	}

	// devuelve el nivel de la partida
	public static int getNumNivel () {
		return numNivel;
	}

	// define el estado del sonido
	public static void setSound (bool s) {
		sound = s;
	}

	// devuelve el estado del sonido
	public static bool getSound () {
		return sound;
	}

	// define una nueva puntuacion de la partida, de cara al ranking del nivel 1
	public static void n1_setRanking (int points, string name){
		for(int i = 0; i < 10; i++){
			if(points > n1_puntuaciones[i]){
				for (int j = 9; j > i; j--){
					n1_nombres[j] = n1_nombres[j-1];
					n1_puntuaciones [j] = n1_puntuaciones [j-1];
				}
				n1_nombres[i] = name;
				n1_puntuaciones[i] = points;
				break;
			}
		}
		for(int i = 0; i < 10; i++){
			PlayerPrefs.SetInt(n1_p_keys[i], n1_puntuaciones[i]);
			PlayerPrefs.SetInt(n2_p_keys[i], n2_puntuaciones[i]);
			PlayerPrefs.SetString(n1_n_keys[i], n1_nombres[i]);
			PlayerPrefs.SetString(n2_n_keys[i], n2_nombres[i]);
		}	
	}
	// define una nueva puntuacion de la partida, de cara al ranking del nivel 2
	public static void n2_setRanking (string name, int points){
		for(int i = 0; i < 10; i++){
			if(points > n2_puntuaciones[i]){
				for (int j = 10; j > i; j--){
					n2_nombres[j] = n2_nombres[j-1];
					n2_puntuaciones [j] = n2_puntuaciones [j-1];
				}
				n2_nombres[i] = name;
				n2_puntuaciones[i] = points;
			}
			break;
		}
		for(int i = 0; i < 10; i++){
			PlayerPrefs.SetInt(n1_p_keys[i], n1_puntuaciones[i]);
			PlayerPrefs.SetInt(n2_p_keys[i], n2_puntuaciones[i]);
			PlayerPrefs.SetString(n1_n_keys[i], n1_nombres[i]);
			PlayerPrefs.SetString(n2_n_keys[i], n2_nombres[i]);
		}	
	}
}
