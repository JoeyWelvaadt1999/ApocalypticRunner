using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlayerScore : MonoBehaviour {
	[SerializeField]private Text _scoreText;
	[SerializeField]private Text _bestText;
	private SaveScore _saveScore;
	private float _score;
	private bool _save = true;

	void Start() {
		_saveScore = FindObjectOfType<SaveScore> ();
		PlayerPrefs.SetString ("Name", "Joey");
		CheckScore ();
	}

	void Update() {
		if (!PlayerGlobal.IsDeath) {
			
			_score += 0.1f;
			_scoreText.text = Mathf.RoundToInt(_score).ToString () + "M";
		} else {
			if (_save) {
				PlayerPrefs.SetInt ("Score", (int)_score);
				_saveScore.Save ();
				_save = false;
			}
		}
	}

	private void CheckScore() {
		_saveScore.ScoreText = _bestText;
		_saveScore.Best ();
	}
}
