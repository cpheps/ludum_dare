using UnityEngine;
using System.Collections;

public class AudioSingleton : MonoBehaviour {
	private static AudioSingleton instance = null;
	private AudioSource gameAudio;

	public static AudioSingleton Instance {
		get { return instance; }
	}

	void Awake() {

		if (instance != null && instance != this) {
			Destroy(this.gameObject);
			return;
		} else {
			instance = this;
		}

		DontDestroyOnLoad(this.gameObject);
	}

	void OnLevelWasLoaded() {
		if (Application.loadedLevelName == "GameScene") {
			AudioSource[] sources = gameObject.GetComponentsInChildren<AudioSource>();

			foreach(AudioSource audio in sources) {
				if(audio.name != "GameMusic") {
					audio.Stop();
				} else {
					gameAudio = audio;
				}
			}

			gameAudio.playOnAwake = true;
			gameAudio.Play();
		}
	}
}
