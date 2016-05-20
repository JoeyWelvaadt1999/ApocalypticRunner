using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class UIHighscores : UIEndMenu {
	[SerializeField]private GameObject _inner;
	[SerializeField]private Text _scoreText;
	private bool _retrieveScore = true; 


	void Start() {
		FindComponents ();


		_inner.SetActive (false);
	}

	void Update() {
		if (AnimatorDone (_anim, "OpenMenu")) {
			if (_retrieveScore) {
				_saveScore.ScoreText = _scoreText;
				_saveScore.Highscores ();
				_retrieveScore = false;
			}
			_inner.SetActive (true);
		}
	}
}
