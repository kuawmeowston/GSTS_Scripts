using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/*
	Script que maneja la creacion de enemigos en el escenario
	Authors:
	- Marta Fernández Salcedo de la Mela
	 - Guillermo Meléndez Morales
	 - Adrian David Morillas Marco
	 - Zhong Hao Lin Chen
	 - Salvador Nieto Garrido
*/
public class spawn : MonoBehaviour {
	// coordenada x del origen
	public int A;
	// coordenada y del origen
	public int B;
	// coordenada aleatoria x
	int random_x;
	// coordenada aleatoria y
	int random_y;
	// valor aleatorio de y
	int signo;
	// objeto a clonar
	private GameObject obj;

	//Numero de tipos de enemigos
	public int tiposEnem = 2;
	//GOs de los enemigos (se ponen en el inspector)
	public GameObject enemy_1;
	public GameObject enemy_2;
	public GameObject enemy_3;
	private int nextEnem;
	// variables del spawner
	private float nextSpawn;
	public float rateOfSpawn = 1;
	// numero de enemigos
	public int n_migos;
	// cola de enemigos almacenados
	public static Queue<GameObject> enemy_q = new Queue<GameObject> ();

	// Use this for initialization
	void Start () {
		nextSpawn = 0;
		aleatorio();
		for (int i = 0; i < n_migos; i++){
			Vector3 position = new Vector3 (random_x, 4, random_y);
			//Elegir aletoriamente el tipo de enemigo que se va a instanciar
			nextEnem = (int) Random.Range (0,tiposEnem); 
			switch (nextEnem) {
			case 0:
				obj = enemy_1;
				break;
			case 1:
				obj = enemy_2;
				break;
			case 2:
				obj = enemy_3;
				break;
			}
			GameObject enemy = Instantiate (obj, position, Quaternion.identity) as GameObject;
			enemy.SetActive(false);
			enemy_q.Enqueue(enemy);
		}
	}
	
	// cada cierto tiempo crea un enemigo aleatoriamente
	void Update () {
		if(Time.time>nextSpawn){
			nextSpawn = Time.time + rateOfSpawn;
			if(enemy_q.Count > 0){		
				GameObject aux = enemy_q.Dequeue();
				aleatorio ();
				Vector3 position = new Vector3 (random_x, 4, random_y);
				aux.transform.position = position;
				aux.SetActive(true);
			}
			
		}
		aleatorio ();
	}
	// define un valor aleatorio en la circunferencia
	void aleatorio (){
		random_x = Random.Range(-310, 520);
		int cuadrado = (random_x - 105);
		float raiz_aux = Mathf.Sqrt(172225 - cuadrado*cuadrado);
		int raiz = (int)raiz_aux;
		random_y = signo_aleatorio() * raiz + 240;
	}
	// define el signo de la ecuacion cuadrática de la circunferecia
	int signo_aleatorio (){
		int num1 = Random.Range(0, 1000);
		if(num1 %2 == 0){
			return 1;
		}else{
			return -1;
		}
	}
}
