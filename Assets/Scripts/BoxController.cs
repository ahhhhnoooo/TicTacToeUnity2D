using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxController : MonoBehaviour
{
	public int Index;
	public GameObject gameControllerObj;
	public SpriteRenderer spriteRenderer;
	public Sprite spriteX;
	public Sprite spriteO;
	private int clickedPlayer;
	public int ClickedPlayer { get { return clickedPlayer; } }

	void OnMouseDown(){
		// If this tile is already occupied, do nothing
		if(clickedPlayer != 0) return;
		GameController gc = gameControllerObj.GetComponent<GameController>();
		// If the game is over, do nothing
		if(gc.Winner != 0) return;

		clickedPlayer = gc.ToggleTurn(Index);

		if(clickedPlayer == 1){ 
			spriteRenderer.sprite = spriteX;
		} else if(clickedPlayer == 2){
			spriteRenderer.sprite = spriteO;
		}
	}
}
