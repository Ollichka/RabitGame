using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelController : MonoBehaviour {

	public int level;
	public static LevelController current;

	public UILabel coinsLabel;

	public int coins;

	public AudioClip music = null;
	AudioSource musicSource = null;

	Vector3 startingPosition;

	public GameObject losePopUpPrefab;
	public GameObject settingsPrefab;

	void Awake() {
		musicSource = gameObject.AddComponent<AudioSource>();
		musicSource.clip = music;
		musicSource.loop = true;

		if (PlayerPrefs.GetInt("music", 1) == 1){
			musicSource.Play();
		}
		GameStatistics gameStats = GameStatistics.load ();
		coins = gameStats.collectedCoins;
		current = this;
	}

	public void toggleMusic(bool enable) {
		PlayerPrefs.SetInt("music", enable ? 1 : 0);

		if (enable) musicSource.Play();
		else 		musicSource.Stop();
	}

	public void addCoin() { coins++; }

	void Update() {
		coinsLabel.text = coins.ToString("D4");
	}

	public void setStartPosition (Vector3 position) { this.startingPosition = position; }

	public void onRabitDeath (HeroRabit rabit) {
		rabit.beBig (false);
		rabit.transform.position = this.startingPosition;
		LivesController.current.removeLife ();
	}

	public void addCrystal(Crystal crystal) {
		CrystalController.current.addCrystal (crystal.type);
	}

	public void addFruit(int fruitId) { 
		FruitController.current.addFruit (fruitId);
	}

	public void addLife() {
		LivesController.current.addLife ();
	}

	public void lose() {
		Destroy (HeroRabit.lastRabit);
		GameObject parent = UICamera.first.transform.parent.gameObject;
		GameObject obj = NGUITools.AddChild(parent, losePopUpPrefab);
		//LosePopUp loosePopUp = obj.GetComponent<LosePopUp>();
	}

	public LevelStatistic getStats() {
		LevelStatistic stats = new LevelStatistic {
			level = level,
			levelPassed = true,
			collectedFruits = new List<int>(FruitController.current.collectedFruits),
			totalFruits = FruitController.current.totalFruits,
			allFruitsCollected = FruitController.current.collectedFruits.Count >= FruitController.current.totalFruits,
			collectedCrystals = new List<Crystal.Type>(CrystalController.current.collectedCrystals),
			allCrystalsCollected = CrystalController.current.collectedCrystals.Count >= 3,
			collectedCoins = coins
		};

		return stats;
	}

	public void showSettings() {
		GameObject parent = UICamera.first.transform.parent.gameObject;
		GameObject obj = NGUITools.AddChild(parent, settingsPrefab);
		//SettingsPopUp popup = obj.GetComponent<SettingsPopUp>();
	}
}
