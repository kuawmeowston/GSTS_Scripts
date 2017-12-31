using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/*
	Script que maneja la rotacion de la camara alrededor de la estatua
	Authors:
	- Marta Fernández Salcedo de la Mela
	 - Guillermo Meléndez Morales
	 - Adrian David Morillas Marco
	 - Zhong Hao Lin Chen
	 - Salvador Nieto Garrido
*/
public class CameraControls : MonoBehaviour {
	// variable que para dispositivos táctiles
	Vector2 touchDeltaPosition;

	void Update () {		
		if (Application.platform == RuntimePlatform.Android){
			if(Input.touchCount < 2){
				// define la rotacion en dispositivos tactiles, comprobando que solo sea en pulsaciones largas
				foreach(Touch touch in Input.touches){
					if(touch.phase == TouchPhase.Moved){
						touchDeltaPosition = Input.GetTouch(0).deltaPosition;
						gameObject.transform.Rotate(0, touchDeltaPosition.x*0.04f, 0);
					}
				}
			}
		}else{
			// comprueba que es un click largo
			if(Dispara.longClick == true){	
				// coge la posicion del raton en el eje horizontal		
				float pointer_y = Input.GetAxis("Mouse X");
				// aplica la rotación cuanto eje y ha rotado
				gameObject.transform.Rotate(0, pointer_y*2, 0);
			}
			// una vez la pulsación larga se ha soltado, deja de calcular
			if(Input.GetMouseButtonUp(0)){
				Dispara.longClick = false;
			}
		}
		
	}
}
