using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class UIEndMenu : MonoBehaviour {
	[SerializeField]private GameObject _menu;
	protected SaveScore _saveScore;
	protected Animator _anim;

	void Start() {
		FindComponents ();
		_menu.SetActive (false);
		this.gameObject.SetActive (false);
	}

	protected void FindComponents () {
		_saveScore = FindObjectOfType<SaveScore> ();
		_anim = GetComponent<Animator> ();
	}

	private void Update() {
		if (AnimatorDone (_anim, "OpenMenu")) {
			if (_menu != null) {
				_menu.SetActive (true);
			}
		}

	}

	protected bool AnimatorDone(Animator anim, string animName) {
		if (anim.GetCurrentAnimatorStateInfo (0).IsName (animName)) {
			return false;
		} else {
			return true;
		}
	}

	public void ShowMenu(GameObject go) {
		

		gameObject.SetActive (false);

		_menu.SetActive (false);
//		_menu = null;
//		_menu = go.transform.FindChild ("MenuInner").gameObject;
		go.SetActive (true);
		FindComponents ();
	}

	public void ChangeMenu(GameObject go ) {
//		_menu = go;

	} 

	public void OpenScene(string scene) {
		SceneManager.LoadScene (scene);	
	}
}
