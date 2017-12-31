using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;
using System.Collections.Generic;
/*
	Script que maneja los botones del menu principal
	Authors:
	- Marta Fernández Salcedo de la Mela
	 - Guillermo Meléndez Morales
	 - Adrian David Morillas Marco
	 - Zhong Hao Lin Chen
	 - Salvador Nieto Garrido
*/
public class PanelManager : MonoBehaviour {
	// animator de la escena
	public Animator initiallyOpen;
	// parametros del menu
	private int m_OpenParameterId;
	private Animator m_Open;
	private GameObject m_PreviouslySelected;
	// transicion del menu
	const string k_OpenTransitionName = "Open";
	const string k_ClosedStateName = "Closed";

	public void OnEnable(){
		// inicializa el animator
		m_OpenParameterId = Animator.StringToHash (k_OpenTransitionName);
		// comprueba si se ha abierto
		if (initiallyOpen == null)
			return;
		OpenPanel(initiallyOpen);
	}

	// define la animacion del menu
	public void OpenPanel (Animator anim){
		if (m_Open == anim)
			return;
		anim.gameObject.SetActive(true);
		var newPreviouslySelected = EventSystem.current.currentSelectedGameObject;
		anim.transform.SetAsLastSibling();
		CloseCurrent();
		m_PreviouslySelected = newPreviouslySelected;
		m_Open = anim;
		m_Open.SetBool(m_OpenParameterId, true);
		GameObject go = FindFirstEnabledSelectable(anim.gameObject);
		SetSelected(go);
	}

	// selecciona el boton del menu
	static GameObject FindFirstEnabledSelectable (GameObject gameObject) {
		GameObject go = null;
		var selectables = gameObject.GetComponentsInChildren<Selectable> (true);
		foreach (var selectable in selectables) {
			if (selectable.IsActive () && selectable.IsInteractable ()) {
				go = selectable.gameObject;
				break;
			}
		}
		return go;
	}

	// cierra el selector
	public void CloseCurrent() {
		if (m_Open == null)
			return;
		m_Open.SetBool(m_OpenParameterId, false);
		SetSelected(m_PreviouslySelected);
		StartCoroutine(DisablePanelDeleyed(m_Open));
		m_Open = null;
	}

	// desactiva el panel del menu
	IEnumerator DisablePanelDeleyed(Animator anim) {
		bool closedStateReached = false;
		bool wantToClose = true;
		while (!closedStateReached && wantToClose) {
			if (!anim.IsInTransition(0))
				closedStateReached = anim.GetCurrentAnimatorStateInfo(0).IsName(k_ClosedStateName);
			wantToClose = !anim.GetBool(m_OpenParameterId);
			yield return new WaitForEndOfFrame();
		}
		if (wantToClose)
			anim.gameObject.SetActive(false);
	}

	// define al objeto como seleccionado
	private void SetSelected(GameObject go) {
		EventSystem.current.SetSelectedGameObject(go);
	}
}
