using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/*
	Script que maneja los atributos de la araña
	Authors:
	- Marta Fernández Salcedo de la Mela
	 - Guillermo Meléndez Morales
	 - Adrian David Morillas Marco
	 - Zhong Hao Lin Chen
	 - Salvador Nieto Garrido
*/
public class Enemy : MonoBehaviour {
	public int vida; // vida de la araña
	int restart; // reinicio de la araña
	private Animator animator; // animator de la araña
	private bool dead = false; //para que la corrutina de morir solo se ejecute una vez
	public int puntos; //puntos que da la araña, poner en el inspector segun el tipo
	private float velOriginal; //velocidad original de la araña
	private Material matOriginal; // material original
	private Material matDamaged; // material de la araña dañada

	// Use this for initialization
	void Start () {
		// guardamos la vida inicial
		restart = vida;
		// inicializamos el animator
		animator = GetComponent<Animator> ();
		//Obtener material original
		matOriginal = transform.GetChild(0).gameObject.GetComponent<Renderer>().material;
		matDamaged = Resources.Load<Material> ("Models/Materials/Materials_araña/Mat_Araña_Damage");
	}
	
	// Update is called once per frame
	void Update () {
		// si la araña no tiene vida se inicializa la animacion de muerte
		if(vida <= 0 && !dead){
			StartCoroutine ("Die");
		}
	}
	// se comprueba cada tipo de colision y su efecto
	 void OnTriggerEnter (Collider col){
        if(col.gameObject.tag == "arandano") {
            vida -= 4;
			StartCoroutine("cambioMaterial");
        }
		if(col.gameObject.tag == "fresa") {
			vida -= 7;
			StartCoroutine("cambioMaterial");
		}
		if(col.gameObject.tag == "oreo") {
			vida -= 10;
			StartCoroutine("cambioMaterial");
			StartCoroutine("ralentizacion");
		}
		//El script del ferrero es el que reduce la vida
		if(col.gameObject.tag == "ferrero") {
			//vida -= 12;
			StartCoroutine("cambioMaterial");
		}
		if(col.gameObject.tag == "mm") {
			vida -= 5;
			StartCoroutine("cambioMaterial");
		}
    }

	IEnumerator Die () {
		Debug.Log ("Morir");
		dead = true;
		//Pasar al estado de morir en el animator
		animator.SetBool("IsDead", true);
		//Esperar unos segundos
		yield return new WaitForSeconds(3.0f);
		//Desactivar
		transform.parent.gameObject.SetActive (false);
		spawn.enemy_q.Enqueue (transform.parent.gameObject);
		vida = restart;
		//Devolver al estado de andar
		animator.SetBool("IsDead", false);
		dead = false;
		//Sumar puntos
		GameController.AddPuntos(puntos);
	}

	// minimiza la velocidad de la araña
	IEnumerator ralentizacion (){
		velOriginal = transform.parent.GetComponent<UnityEngine.AI.NavMeshAgent>().speed;
		transform.parent.GetComponent<UnityEngine.AI.NavMeshAgent>().speed = velOriginal/2;
		yield return new WaitForSeconds(5.0f);
		transform.parent.GetComponent<UnityEngine.AI.NavMeshAgent>().speed = velOriginal;
	}

	// reduce la vida tras la explosion
	public void Vida_Reduc (int decrementacion)	{
		vida -= decrementacion;
	}
	
	// cambia su material si es disparado
	IEnumerator cambioMaterial () {
		transform.GetChild (0).gameObject.GetComponent<Renderer> ().material = matDamaged;
		yield return new WaitForSeconds(2.0f);
		transform.GetChild (0).gameObject.GetComponent<Renderer> ().material = matOriginal;
	}
}
