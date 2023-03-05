using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameController : MonoBehaviour
{
	public TMP_Text TurnText;
	public TMP_Text ClockX;
	public TMP_Text ClockO;

	// Array tracking status of the board
	private int[] board;

	private int turn;
	// Read-only turn property for the UI to display turn
	public int Turn { get { return turn; } }

	private int winner;
	public int Winner { get { return winner; } }

	private string[] PLAYERS = {"S", "X", "O"};

	void Start() {
		ResetGame();
	}
	public void ResetGame() {
		winner = 0;
		board = new int[10];
		turn = 1;
		TurnText.SetText("Turn: " + PLAYERS[turn]);
	}

	// Toggles to the next player, and returns the previous player
	// Use this to avoid race conditions
	public int ToggleTurn(int index) {
		board[index] = turn;
		CheckWinner();
		int next = 0;
		if( turn == 1 ) {
			turn = 2;
			next = 1;
		} else {
			turn = 1;
			next = 2;
		}
		if( winner != 0 ) {
			TurnText.SetText("Winner: " + PLAYERS[winner]);
		} else {
			TurnText.SetText("Turn: " + PLAYERS[next]);
		}
		return next;
	}
	private void Check(int a, int b, int c){
		if(a != 0 && a == b && b == c){
			winner = a;
		}
	}
	// Just brute force it lol
	private void CheckWinner() {
		// Rows
		Check(board[1], board[2], board[3]); 
		Check(board[4], board[5], board[6]);
		Check(board[7], board[8], board[9]);
		// Columns
		Check(board[1], board[4], board[7]);
		Check(board[2], board[5], board[8]);
		Check(board[3], board[6], board[9]);
		// Diagonals
		Check(board[1], board[5], board[9]);
		Check(board[3], board[5], board[7]);
	}
}
