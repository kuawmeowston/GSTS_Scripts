using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
/*
	Script que define los controles para disparar, así como para apuntar, y el comportamiento de las balas
	Authors:
	- Marta Fernández Salcedo de la Mela
	 - Guillermo Meléndez Morales
	 - Adrian David Morillas Marco
	 - Zhong Hao Lin Chen
	 - Salvador Nieto Garrido
*/

public class Dispara : MonoBehaviour {	
	// margen de disparo
	public float fireRate = 0.5f;
	// variable auxiliar del margen de disparo
	private float nextFire = 0.0F;
	// velocidad de la bala
	public float speed = 30;
	// indice que define el tipo de bala a disparar
	public int habilidad = 0;
	// variable que contiene el tipo de bala a disparar
	GameObject prefab;
	// variable auxiliar para los controles, el cual define el tiempo de pulsación del click del raton
	float t0;
	// booleano para pulsacion larga
	public static bool longClick;
	// booleano para pulsacion corta
 	public static bool shortClick;
	 // imagenes referentes al canvas
	public Image select_1;
	public Image select_2;
	public Image select_3;
	public Image select_4;
	// botones de las habilidades
	public Button habilidad_1;
	public Button habilidad_2;
	public Button habilidad_3;
	public Button habilidad_4;
	// colas de las balas
	public static Queue<GameObject> Q_arandanos;
	public static Queue<GameObject> Q_fresas;
	public static Queue<GameObject> Q_oreos;
	public static Queue<GameObject> Q_ferreros;
	public static Queue<GameObject> Q_mms;
	// sonidos
	public AudioClip arandano;
	public AudioClip fresa;
	public AudioClip oreo;
	public AudioClip ferrero;
	public AudioClip lacasito;
	private AudioSource source;
	private float volLowRange = .5f;
    private float volHighRange = 1.0f;
	// Gestor tactil
	private int TouchID = -1;

	// carga el sonido
	void Awake () {    
        source = GetComponent<AudioSource>();
    }

	void Start () {
		//Crear colas
		Q_arandanos = new Queue<GameObject> ();
     	Q_fresas = new Queue<GameObject> ();
     	Q_oreos = new Queue<GameObject> ();
		Q_mms = new Queue<GameObject> ();
		Q_ferreros = new Queue<GameObject> ();

		// inicializamos el tiempo de pulsacion
		t0 = 0;
		// inicializamos los booleanos a false
     	longClick = false;
     	shortClick = false;
		 // inicializamos los redondeles de seleccion
		prefab = new GameObject();
		select_1.enabled = false;
		select_2.enabled = false;
		select_3.enabled = false;
		select_4.enabled = false;
		// inicializamos los botones de las habilidades
		habilidad_1.interactable = false;
		habilidad_2.interactable = false;
		habilidad_3.interactable = false;
		habilidad_4.interactable = false;
		// se le aporta a los botones sus respectivas funciones
		habilidad_1.onClick.AddListener(Disparo_1);
		habilidad_2.onClick.AddListener(Disparo_2);
		habilidad_3.onClick.AddListener(Disparo_3);
		habilidad_4.onClick.AddListener(Disparo_4);
		// inicializamos las listas
		prefab = Resources.Load("Prefabs/Escenario/Habilidad_1") as GameObject;
		for(int i = 0; i < 25; i++){
			GameObject go = Instantiate(prefab, transform.position, Quaternion.identity) as GameObject;
			go.SetActive(false);
			Q_arandanos.Enqueue(go);
		}
		prefab = Resources.Load("Prefabs/Escenario/Habilidad_2") as GameObject;
		for(int i = 0; i < 5; i++){
			GameObject go = Instantiate(prefab, transform.position, Quaternion.identity) as GameObject;
			Q_fresas.Enqueue(go);
			go.SetActive(false);
		}
		prefab = Resources.Load("Prefabs/Escenario/Habilidad_3") as GameObject;
		for(int i = 0; i < 4; i++){
			GameObject go = Instantiate(prefab, transform.position, Quaternion.identity) as GameObject;
			Q_oreos.Enqueue(go);
			go.SetActive(false);
		}
		prefab = Resources.Load("Prefabs/Escenario/Habilidad_4") as GameObject;
		for(int i = 0; i < 2; i++){
			GameObject go = Instantiate(prefab, transform.position, Quaternion.identity) as GameObject;
			Q_ferreros.Enqueue(go);
			go.SetActive(false);
		}
		prefab = Resources.Load("Prefabs/Escenario/Habilidad_5") as GameObject;
		for(int i = 0; i < 20; i++){
			GameObject go = Instantiate(prefab, transform.position, Quaternion.identity) as GameObject;
			Q_mms.Enqueue(go);
			go.SetActive(false);
		}
		prefab = Resources.Load("Prefabs/Escenario/Habilidad_1") as GameObject;
	}
	void Update () {
		// comprobamos que no haya ninguna habilidad activa
		if(HabilidadActiva()){
			// si es dispositivo movil, se activan los botones
			if (Application.platform == RuntimePlatform.Android){
				habilidad_1.interactable = true;
				habilidad_2.interactable = true;
				habilidad_3.interactable = true;
				habilidad_4.interactable = true;
				// controles para seleccionar una de las habilidaes
			}else{
				// tecla 1
				if(Input.GetKey(KeyCode.Alpha1)){
					// si la habilidad esta cargada lanza la habilidad
					Disparo_1();	
				}
				// tecla 2
				if(Input.GetKey(KeyCode.Alpha2)){
					// si la habilidad esta cargada lanza la habilidad
					Disparo_2();
				}
				// tecla 3
				if(Input.GetKey(KeyCode.Alpha3)){
					// si la habilidad esta cargada lanza la habilidad
					Disparo_3();
				}
				// tecla 4
				if(Input.GetKey(KeyCode.Alpha4)){
					// si la habilidad esta cargada lanza la habilidad
					Disparo_4();
				}
			}			
		}else{
			habilidad_1.interactable = false;
			habilidad_2.interactable = false;
			habilidad_3.interactable = false;
			habilidad_4.interactable = false;	
		}
		// si es dispositivo movil diferenciamos la pulsacion larga de la corta
		if (Application.platform == RuntimePlatform.Android){
			foreach(Touch touch in Input.touches){
				if(touch.phase == TouchPhase.Began){
					TouchID = touch.fingerId;
					if(touch.phase != TouchPhase.Ended && touch.fingerId == TouchID) {
						// bloqueamos la parte superior de la pantalla
						if(touch.position.y > 3*Screen.height/4) {

						}else{
							Disparar();
						}
					}
					if(touch.phase == TouchPhase.Ended) {
						TouchID = -1;
					}
					
				}
			}
		}else{				
			// compronamos el tiempo de pulsacion
			if (Input.GetMouseButtonDown(0)){
				t0 = Time.time ;
			}
			// si se ha soltado el click en un periodo breve, se identifica como corto
			if (Input.GetMouseButtonUp(0) && (Time.time - t0) < 0.25){
				shortClick = true;
			}else if (Input.GetMouseButtonDown(0)){
				longClick = true;
			}

			// en caso de un click corto lanzamos una bala
			if(shortClick&&(Time.time > nextFire)){
				// redefinimos el booleano al valor por defecto
				shortClick = false;
				// disparamos la bala
				Disparar();
			}
		}	
	}
	// activa la habilidad y la prepara para disparar
	void Disparo_1(){
		if(Habilidad_1_UI.currentAmount > 100){
			select_1.enabled = true;
			habilidad = 1;
		}
	}
	void Disparo_2(){
		if(Habilidad_2_UI.currentAmount > 100){
			select_2.enabled = true;
			habilidad = 2;
		}
	}
	void Disparo_3(){
		if(Habilidad_3_UI.currentAmount > 100){
			select_3.enabled = true;
			habilidad = 3;
		}		
	}
	void Disparo_4(){
		if(Habilidad_4_UI.currentAmount > 100){
			select_4.enabled = true;
			habilidad = 4;
		}	
	}
	// devuelve false si alguna habilidad esta ya seleccionada
	public bool HabilidadActiva (){
		for(int i = 1; i < 5; i++){
			if(habilidad == i){
				return false;
			}
		}
		return true;
	}
	// dispara la bala
	public void Disparar (){
		Fire();
		// si se ha lanzado una habilidad, redefinimos la siguiente bala a la que hay por defecto
		// fresa
		if(habilidad == 1){
			select_1.enabled = false;
			Habilidad_1_UI.currentAmount = 0;
			habilidad = 0;
		}
		// galleta
		if(habilidad == 2){
			select_2.enabled = false;
			Habilidad_2_UI.currentAmount = 0;
			habilidad = 0;
		}
		// chicle
		if(habilidad == 3){
			select_3.enabled = false;
			Habilidad_3_UI.currentAmount = 0;
			habilidad = 0;
		}
		// undefined
		if(habilidad == 4){
			select_4.enabled = false;
			Habilidad_4_UI.currentAmount = 0;
			habilidad = 0; 
		}
	}
	public void Fire() {	
		// defino el tiempo entre disparos
		nextFire = Time.time + fireRate;
		// defino la distancia de desplazamiento
		float distance = 10.0f;
		// defino la posicion de salida
		Vector3 position = new Vector3(Input.mousePosition.x, Input.mousePosition.y, distance);
		position = Camera.main.ScreenToWorldPoint(position);
		GameObject go = null;
		if(habilidad == 0){
			if(Q_arandanos.Count > 0){
				go = Q_arandanos.Dequeue();
				go.SetActive(true);
				// la posiciono mirando hacia el frente
				go.transform.position = transform.position;
				go.transform.rotation = Quaternion.identity;
				go.transform.LookAt(position);     
				// le aporto velocidad a la bala
				Rigidbody rb = go.GetComponent<Rigidbody>();
				rb.velocity = go.transform.forward * speed;	
				float vol = Random.Range (volLowRange, volHighRange);
				source.PlayOneShot(arandano,vol);
			}
		}
		if(habilidad == 1){
			if(Q_fresas.Count > 0){
				go = Q_fresas.Dequeue();
				go.SetActive(true);
				// la posiciono mirando hacia el frente
				go.transform.position = transform.position;
				go.transform.rotation = Quaternion.identity;
				go.transform.LookAt(position);     
				// le aporto velocidad a la bala
				Rigidbody rb = go.GetComponent<Rigidbody>();
				rb.velocity = go.transform.forward * speed;	
				float vol = Random.Range (volLowRange, volHighRange);
            	source.PlayOneShot(fresa,vol);
			}
		}
		if(habilidad == 2){
			if(Q_oreos.Count > 0){
				go = Q_oreos.Dequeue();
				go.SetActive(true);
				// la posiciono mirando hacia el frente
				go.transform.position = transform.position;
				go.transform.rotation = Quaternion.identity;
				go.transform.LookAt(position);     
				// le aporto velocidad a la bala
				Rigidbody rb = go.GetComponent<Rigidbody>();
				rb.velocity = go.transform.forward * speed;	
				float vol = Random.Range (volLowRange, volHighRange);
            	source.PlayOneShot(oreo,vol);
			}
		}
		if(habilidad == 3){
			if(Q_ferreros.Count > 0){
				go = Q_ferreros.Dequeue();
				go.SetActive(true);
				// la posiciono mirando hacia el frente
				go.transform.position = transform.position;
				go.transform.rotation = Quaternion.identity;
				go.transform.LookAt(position);     
				// le aporto velocidad a la bala
				Rigidbody rb = go.GetComponent<Rigidbody>();
				rb.velocity = go.transform.forward * speed;	
				float vol = Random.Range (volLowRange, volHighRange);
            	source.PlayOneShot(ferrero,vol);
			}
		}
		// defino una rafaga de disparos
		if(habilidad == 4){
			if(Q_mms.Count > 0){
				StartCoroutine("metralleta");
			}
		}	
	}
	// animacion de rafaga de disparos
	IEnumerator metralleta (){
		int i = 0;		
		bool sonido = true;
		while (i < 7){
			float distance = 10.0f;
			// defino la posicion de salida
			Vector3 position = new Vector3(Input.mousePosition.x, Input.mousePosition.y, distance);
			position = Camera.main.ScreenToWorldPoint(position);
			GameObject go = null;
			go = Q_mms.Dequeue();
			go.SetActive(true);
			// la posiciono mirando hacia el frente
			go.transform.position = transform.position;
			go.transform.rotation = Quaternion.identity;
			go.transform.LookAt(position);     
			// le aporto velocidad a la bala
			Rigidbody rb = go.GetComponent<Rigidbody>();
			rb.velocity = go.transform.forward * speed;	
			if(sonido){
				sonido = false;
				float vol = Random.Range (volLowRange, volHighRange);
            	source.PlayOneShot(lacasito,vol);
			}
			i++;
			yield return new WaitForSeconds(0.1f);
		}
	}
}
