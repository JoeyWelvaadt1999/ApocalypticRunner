using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Story : MonoBehaviour {
	[SerializeField]private Dialog[] _dialogs;
	[SerializeField]private Text _text;
	[SerializeField]private int _dialogNumber;

	public void Start () {
		StartCoroutine (TypeAll());
	}

	IEnumerator TypeAll() {

		for (int j = 0; j < _dialogs [_dialogNumber]._lines.Length; j++) {
			for (int k = 0; k < _dialogs [_dialogNumber]._lines [j].text.ToCharArray ().Length; k++) {
				_text.text = _dialogs [_dialogNumber]._lines [j].user + ": " + _dialogs [_dialogNumber]._lines [j].text.Substring (0, k + 1);

				FindObjectOfType<PlayerMovement> ().enabled = false;
				FindObjectOfType<PlayerJump> ().enabled = false;
				FindObjectOfType<PlayerScore> ().enabled = false;
				PlayerGlobal.PlayerSpeed = 0;

				if (Input.GetMouseButtonDown (0)) {
//					if (j < _dialogs [_dialogNumber]._lines.Length - 1) {
						k++;
//					}
				}

				yield return new WaitForSeconds (0.05f);
			}

			while (!Input.GetMouseButtonDown (0)) {
				yield return new WaitForSeconds (0.01f);
			}
		}
		yield return new WaitForSeconds (1);
		FindObjectOfType<PlayerMovement> ().enabled = true;
		FindObjectOfType<PlayerJump> ().enabled = true;
		FindObjectOfType<PlayerScore> ().enabled = true;
		PlayerGlobal.PlayerSpeed = 3.0f;
		yield return 0;
	}
}

[System.Serializable]
class Dialog {
	public StoryLine[] _lines;
}
