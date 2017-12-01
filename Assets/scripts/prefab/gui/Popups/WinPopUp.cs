using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WinPopUp : MonoBehaviour {

	public GameObject fruitLabel;
	UILabel labelFruit;

	public UI2DSprite redCrystal, greenCrystal, blueCrystal;

	public GameObject crystalParent;

	public void setStats(LevelStatistic stats) {
		labelFruit = fruitLabel.GetComponent<UILabel>();
		labelFruit.text = stats.collectedFruits.Count + "/" + stats.totalFruits;

		List<Crystal.Type> crystalColors = stats.collectedCrystals;
		for (int i = 0; i < crystalColors.Count; i++) {
			switch (crystalColors[i])
			{
			case Crystal.Type.BLUE:
				blueCrystal.sprite2D = CrystalController.current.blueCrystalSprite;
				break;
			case Crystal.Type.RED:
				redCrystal.sprite2D = CrystalController.current.redCrystalSprite;
				break;
			case Crystal.Type.GREEN:
				greenCrystal.sprite2D = CrystalController.current.greenCrystalSprite;
				break;
			}
		}
	}

	public void onRestartClick() {
		Destroy(this.gameObject);
		SceneManager.LoadScene(SceneManager.GetActiveScene().name);
	}

	public void OnNextClick() {
		Destroy(this.gameObject);
		SceneManager.LoadScene("Levels");
	}

}
