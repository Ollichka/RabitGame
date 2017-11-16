using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SettingsPopUp : MonoBehaviour {

	public Sprite soundOnSprite, soundOffSprite, musicOnSprite, musicOffSprite;
	public GameObject soundButton, musicButton;

	bool soundEnabled, musicEnabled;

	// Use this for initialization
	void Start () {
		soundEnabled = PlayerPrefs.GetInt("sound", 1) == 1;
		SoundManager.Instance.setSoundOn(soundEnabled);
		musicEnabled = PlayerPrefs.GetInt("music", 1) == 1;

		UI2DSprite spriteSound = soundButton.GetComponent<UI2DSprite>();
		spriteSound.sprite2D = soundEnabled ? soundOnSprite : soundOffSprite;
		UI2DSprite spriteMusic = musicButton.GetComponent<UI2DSprite>();
		spriteMusic.sprite2D = musicEnabled ? musicOnSprite : musicOffSprite;
	}

	// Update is called once per frame
	void Update () {
		UI2DSprite spriteSound = soundButton.GetComponent<UI2DSprite>();
		spriteSound.sprite2D = soundEnabled ? soundOnSprite : soundOffSprite;
		UI2DSprite spriteMusic = musicButton.GetComponent<UI2DSprite>();
		spriteMusic.sprite2D = musicEnabled ? musicOnSprite : musicOffSprite;
	}

	public void onCloseClick() {
		Destroy(this.gameObject);
	}

	public void onSoundClick() {
		soundEnabled = !soundEnabled;
		SoundManager.Instance.setSoundOn(soundEnabled);
		UI2DSprite sprite = soundButton.GetComponent<UI2DSprite>();
		sprite.sprite2D = soundEnabled? soundOnSprite:soundOffSprite;
	}

	public void onMusicClick() {
		musicEnabled = !musicEnabled;
		LevelController.current.toggleMusic(musicEnabled);
		UI2DSprite sprite = musicButton.GetComponent<UI2DSprite>();
		sprite.sprite2D = musicEnabled ? musicOnSprite : musicOffSprite;
	}

}
