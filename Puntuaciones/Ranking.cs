using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
/*
	Script que maneja el ranking de putuaciones
	Authors:
	- Marta Fernández Salcedo de la Mela
	 - Guillermo Meléndez Morales
	 - Adrian David Morillas Marco
	 - Zhong Hao Lin Chen
	 - Salvador Nieto Garrido
*/
public class Ranking : MonoBehaviour {
	// nombres de los jugadores en el top
	public Text t_1;
	public Text t_2;
	public Text t_3;
	public Text t_4;
	public Text t_5;
	public Text t_6;
	public Text t_7;
	public Text t_8;
	public Text t_9;
	public Text t_10;
	// puntuaciones de los jugadores en el top
	public Text p_1;
	public Text p_2;
	public Text p_3;
	public Text p_4;
	public Text p_5;
	public Text p_6;
	public Text p_7;
	public Text p_8;
	public Text p_9;
	public Text p_10;
	// botones para cambiar de rankng de nivel
	public Button anterior;
	public Button posterior;
	// boton para volver al menu
	public Button volver;
	// imagen del titulo del nivel
	public Image titulo;
	// variable que gestiona el nivel del que se desea ver el ranking
	public int nivel;
	// nombres de las distintas variables del PlayerPrefs
	private static string[] n1_p_keys = new string[]{"n1_puntuacion_1", "n1_puntuacion_2", "n1_puntuacion_3", "n1_puntuacion_4", "n1_puntuacion_5", "n1_puntuacion_6", "n1_puntuacion_7", "n1_puntuacion_8", "n1_puntuacion_9", "n1_puntuacion_10"};
	private static string[] n2_p_keys = new string[]{"n2_puntuacion_1", "n2_puntuacion_2", "n2_puntuacion_3", "n2_puntuacion_4", "n2_puntuacion_5", "n2_puntuacion_6", "n2_puntuacion_7", "n2_puntuacion_8", "n2_puntuacion_9", "n2_puntuacion_10"};
	private static string[] n1_n_keys = new string[]{"n1_nombre_1", "n1_nombre_2", "n1_nombre_3", "n1_nombre_4", "n1_nombre_5", "n1_nombre_6", "n1_nombre_7", "n1_nombre_8","n1_nombre_9", "n1_nombre_10"};
	private static string[] n2_n_keys = new string[]{"n2_nombre_1", "n2_nombre_2", "n2_nombre_3", "n2_nombre_4", "n2_nombre_5", "n2_nombre_6", "n2_nombre_7", "n2_nombre_8","n2_nombre_9", "n1_nombre_10"};
	
	void Start () {
		// limpieza en caso de que se desee limpiar el ranking
		/*
		for(int i = 0; i < 10; i++){
			PlayerPrefs.SetInt(n1_p_keys[i], 0);
			PlayerPrefs.SetInt(n2_p_keys[i], 0);
			PlayerPrefs.SetString(n1_n_keys[i], "...");
			PlayerPrefs.SetString(n2_n_keys[i], "...");
		}	
		*/
		// se inicializan los botones
		anterior.onClick.AddListener(CambioNivel);
		posterior.onClick.AddListener(CambioNivel);
		volver.onClick.AddListener(CambiarEscena);
	}
	
	// dependiendo del nivel, se imprime un ranking u otro, cogiendo los valores del PlayerPrefs
	void Update () {
		if(nivel == 1){
			titulo.sprite = Resources.Load<Sprite>("Imagenes/Menus/nivel1");
			t_1.text = "1.- " + PlayerPrefs.GetString(n1_n_keys[0]);
			t_2.text = "2.- " + PlayerPrefs.GetString(n1_n_keys[1]);
			t_3.text = "3.- " + PlayerPrefs.GetString(n1_n_keys[2]);
			t_4.text = "4.- " + PlayerPrefs.GetString(n1_n_keys[3]);
			t_5.text = "5.- " + PlayerPrefs.GetString(n1_n_keys[4]);
			t_6.text = "6.- " + PlayerPrefs.GetString(n1_n_keys[5]);
			t_7.text = "7.- " + PlayerPrefs.GetString(n1_n_keys[6]);
			t_8.text = "8.- " + PlayerPrefs.GetString(n1_n_keys[7]);
			t_9.text = "9.- " + PlayerPrefs.GetString(n1_n_keys[8]);
			t_10.text = "10.- " + PlayerPrefs.GetString(n1_n_keys[9]);
			p_1.text = " ............ " + PlayerPrefs.GetInt(n1_p_keys[0]);
			p_2.text = " ............ " + PlayerPrefs.GetInt(n1_p_keys[1]);
			p_3.text = " ............ " + PlayerPrefs.GetInt(n1_p_keys[2]);
			p_4.text = " ............ " + PlayerPrefs.GetInt(n1_p_keys[3]);
			p_5.text = " ............ " + PlayerPrefs.GetInt(n1_p_keys[4]);
			p_6.text = " ............ " + PlayerPrefs.GetInt(n1_p_keys[5]);
			p_7.text = " ............ " + PlayerPrefs.GetInt(n1_p_keys[6]);
			p_8.text = " ............ " + PlayerPrefs.GetInt(n1_p_keys[7]);
			p_9.text = " ............ " + PlayerPrefs.GetInt(n1_p_keys[8]);
			p_10.text = " ............ " + PlayerPrefs.GetInt(n1_p_keys[9]);
		}else if(nivel == 2){
			titulo.sprite = Resources.Load<Sprite>("Imagenes/Menus/nivel2");
			t_1.text = "1.- " + PlayerPrefs.GetString(n2_n_keys[0]);
			t_2.text = "2.- " + PlayerPrefs.GetString(n2_n_keys[1]);
			t_3.text = "3.- " + PlayerPrefs.GetString(n2_n_keys[2]);
			t_4.text = "4.- " + PlayerPrefs.GetString(n2_n_keys[3]);
			t_5.text = "5.- " + PlayerPrefs.GetString(n2_n_keys[4]);
			t_6.text = "6.- " + PlayerPrefs.GetString(n2_n_keys[5]);
			t_7.text = "7.- " + PlayerPrefs.GetString(n2_n_keys[6]);
			t_8.text = "8.- " + PlayerPrefs.GetString(n2_n_keys[7]);
			t_9.text = "9.- " + PlayerPrefs.GetString(n2_n_keys[8]);
			t_10.text = "10.- " + PlayerPrefs.GetString(n2_n_keys[9]);
			p_1.text = " ............ " + PlayerPrefs.GetInt(n2_p_keys[0]);
			p_2.text = " ............ " + PlayerPrefs.GetInt(n2_p_keys[1]);
			p_3.text = " ............ " + PlayerPrefs.GetInt(n2_p_keys[2]);
			p_4.text = " ............ " + PlayerPrefs.GetInt(n2_p_keys[3]);
			p_5.text = " ............ " + PlayerPrefs.GetInt(n2_p_keys[4]);
			p_6.text = " ............ " + PlayerPrefs.GetInt(n2_p_keys[5]);
			p_7.text = " ............ " + PlayerPrefs.GetInt(n2_p_keys[6]);
			p_8.text = " ............ " + PlayerPrefs.GetInt(n2_p_keys[7]);
			p_9.text = " ............ " + PlayerPrefs.GetInt(n2_p_keys[8]);
			p_10.text = " ............ " + PlayerPrefs.GetInt(n2_p_keys[9]);
		}
	}

	// gestiona el cambio de ranking
	void CambioNivel (){
		if(nivel == 1){
			nivel = 2;
		}else if(nivel == 2){
			nivel = 1;
		}
	}

	// retorna al menu principal
	void CambiarEscena (){
		SceneManager.LoadScene ("MenuPpal");
	}
}
