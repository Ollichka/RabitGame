using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrystalController : MonoBehaviour {

	public static CrystalController current;

	public UI2DSprite redCrystal, greenCrystal, blueCrystal;
	public Sprite redCrystalSprite, greenCrystalSprite, blueCrystalSprite;

	public HashSet<Crystal.Type> collectedCrystals;

	public void addCrystal(Crystal.Type type) {
		switch (type) {
		case Crystal.Type.BLUE:
			blueCrystal.sprite2D = blueCrystalSprite;
			break;
		case Crystal.Type.RED:
			redCrystal.sprite2D = redCrystalSprite;
			break;
		case Crystal.Type.GREEN:
			greenCrystal.sprite2D = greenCrystalSprite;
			break;
		}

		collectedCrystals.Add (type);
	}

	void Start () {
		LevelStatistic stats = LevelStatistic.load (LevelController.current.level);
		collectedCrystals = new HashSet<Crystal.Type> ();
		foreach (Crystal.Type type in stats.collectedCrystals)
			addCrystal (type);
	}

	void Awake () {
		current = this;
	}

}
