using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class UIMainMenu : MonoBehaviour {
	public void FadeIn(GameObject go) {
		go.SetActive (true);
		StartCoroutine (Fade(go));
	}

	IEnumerator Fade(GameObject go) {
		Image src = GetComponent<Image> ();
		Image sr = go.GetComponent<Image> ();

		Color cc = src.color;
		Color c = sr.color;

		while (c.a < 1 && cc.a > 0) {
			cc.a -= 0.1f;
			c.a += 0.1f;

			sr.color = c;
			src.color = cc;
			Debug.Log (cc.a);
		
			yield return new WaitForSeconds (0.02f);
		}
		src.gameObject.SetActive (false);
	}

	public void PlayGame(int scene) {
		SceneManager.LoadScene (scene);
	}
}
