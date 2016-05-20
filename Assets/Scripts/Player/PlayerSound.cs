using UnityEngine;
using System.Collections;

public class PlayerSound : MonoBehaviour {
	[SerializeField]private AudioClip _running;
	[SerializeField]private AudioClip _die;
	private Animator _anim;
	private AudioSource _audioSource;

	void Start() {
		_anim = GetComponent<Animator> ();
		_audioSource = GetComponent<AudioSource> ();
	}

	void Update () {
		PlaySounds ();
	}

	void PlaySounds() {
		if (_anim.GetCurrentAnimatorStateInfo (0).IsName ("PlayerRun")) {
			if (!_audioSource.isPlaying) {
				_audioSource.PlayOneShot (_running);
			}
		}

		if (PlayerGlobal.IsDeath) {
			_audioSource.clip = _die;
//			_audioSource.outputAudioMixerGroup = null;
			_audioSource.pitch = 1;

			StartCoroutine (WaitForAudio (_die));
		}
	}

	IEnumerator WaitForAudio(AudioClip clip){
		if (!_audioSource.isPlaying) {
			_audioSource.PlayOneShot(clip);
		}
		yield return new WaitForSeconds(clip.length );
		_audioSource.mute = true;
	}
}
