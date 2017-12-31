using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/*
	Script que maneja la destruccion del ferrero, pasado un cierto tiempo
	Authors:
	- Marta Fernández Salcedo de la Mela
	 - Guillermo Meléndez Morales
	 - Adrian David Morillas Marco
	 - Zhong Hao Lin Chen
	 - Salvador Nieto Garrido
*/
public class Habilidad_4_col : MonoBehaviour {
	// variable que contiene la explosion de particulas
	public GameObject explosionParticlesPrefab = null;
	// trigger de la esfera
	public SphereCollider colliderChild;
	// sonido de la explosion
	public AudioClip explosion;
	// componente de audio
	private AudioSource source;
	// valor minimo de volumen
	private float volLowRange;
	// valor maximo de volumen
    private float volHighRange;
	// se inicializa el componente
    void Awake () {    
        source = GetComponent<AudioSource>();
    }

	// se inicializa el collider, y los rangos de volumen
	void Start () {
		colliderChild = transform.GetChild (0).gameObject.GetComponent<SphereCollider> ();
		volLowRange = .5f;
		volHighRange = 1.0f;
	}

	// si colisiona se activa la explosion y su sonido correspondiente
	void OnCollisionEnter(Collision col){
		//Activar explosion en cuanto choca con algun objeto (el que sea)
		colliderChild.enabled = true;
		StartCoroutine("destruccion");
	}

	IEnumerator destruccion (){
		//Explosion
		if (explosionParticlesPrefab != null) {
			//Instanciar prefab en la posicion de la bala
			Instantiate (explosionParticlesPrefab, transform.position, transform.rotation);
			// se reporduce el sonido
			float vol = Random.Range (volLowRange, volHighRange);
            source.PlayOneShot(explosion,vol);
		}
		// se espera 500 ms mostrando la explosion
		yield return new WaitForSeconds(0.5f);
		//se desactiva el objeto
		gameObject.SetActive(false);
		colliderChild.enabled = false;
		Dispara.Q_ferreros.Enqueue(gameObject);
	}
}
