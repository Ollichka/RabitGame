using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LivesController : MonoBehaviour {
	public static LivesController current;

	public List<UI2DSprite> lifeIcons;
	public Sprite emptyHeart, fullHeart;

	int lives;

	public void removeLife() {
		if (lives <= 0) {
			LevelController.current.lose ();
			return;
		}

		lives--;
		lifeIcons.FindLast (isFullHeart).sprite2D = emptyHeart;
	}

	public void addLife() {
		if (lives != 3) {
			lives++;
			lifeIcons.Find (isEmptyHeart).sprite2D = fullHeart;
		}
	}

	// Use this for initialization
	void Awake () {
		current = this;
		lives = 3;
	}

	private bool isEmptyHeart(UI2DSprite heart) {
		return heart.sprite2D == emptyHeart;
	}

	private bool isFullHeart(UI2DSprite heart) {
		return heart.sprite2D == fullHeart;
	}
}
