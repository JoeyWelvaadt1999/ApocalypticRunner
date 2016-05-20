using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class SaveScore : MonoBehaviour {
	public Text ScoreText { get; set;}
	private string _name;
	private int _score;

	public void Best() {
		_name = PlayerPrefs.GetString ("Name");
		WWWForm form = new WWWForm ();
		form.AddField ("Name", _name);
		WWW www = new WWW ("http://18803.hosts.ma-cloud.nl/ApoRunner/retrieveBest.php", form);
		StartCoroutine (WaitForRequest(www));
	}

	public void Highscores() {
		WWW www = new WWW ("http://18803.hosts.ma-cloud.nl/ApoRunner/retrieve.php");
		StartCoroutine (WaitForRequest(www));
	}

	public void Save() {
		_name = PlayerPrefs.GetString ("Name");
		_score = PlayerPrefs.GetInt ("Score");

		WWWForm form = new WWWForm ();
		form.AddField ("Name", _name);
		form.AddField ("Score", _score);
		WWW www = new WWW ("http://18803.hosts.ma-cloud.nl/ApoRunner/send.php", form);
		StartCoroutine (WaitForRequest(www));
	}

	IEnumerator WaitForRequest(WWW www) {
		yield return www;
		string[] text = www.text.Split ('\n');
		for (int i = 0; i < text.Length; i++) {
			ScoreText.text += text[i] + "M" + '\n';
		}
	}
}
