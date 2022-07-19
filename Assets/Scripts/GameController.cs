using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



[System.Serializable]
public class Player {
   public Image panel;
   public Text text;
}

[System.Serializable]
public class PlayerColor {
   public Color panelColor;
   public Color textColor;
}

public class GameController : MonoBehaviour {

   public Text[] buttonList;
   public GameObject gameOverPanel;
   public Text gameOverText;
   public GameObject restartButton;
   public Player playerX;
   public Player playerO;
   public PlayerColor activePlayerColor;
   public PlayerColor inactivePlayerColor;

   private string playerSide;
   private string whoTurn;
   private int moveCount;

   void Awake ()
   {
       SetGameControllerReferenceOnButtons();
       playerSide = "X";
       gameOverPanel.SetActive(false);
       moveCount = 0;
       restartButton.SetActive(false);
       SetPlayerColors(playerX, playerO);
   }

   void SetGameControllerReferenceOnButtons ()
   {
       for (int i = 0; i < buttonList.Length; i++)
       {
           buttonList[i].GetComponentInParent<GridSpace>().SetGameControllerReference(this);
       }
   }

   public string GetPlayerSide ()
   {
       return playerSide;
   }

   public void EndTurn ()
   {
       moveCount++;

       if (buttonList [0].text == playerSide && buttonList [1].text == playerSide && buttonList [2].text == playerSide)
       {
           GameOver(playerSide);
       } 
       else if (buttonList [3].text == playerSide && buttonList [4].text == playerSide && buttonList [5].text == playerSide)
       {
           GameOver(playerSide);
       } 
       else if (buttonList [6].text == playerSide && buttonList [7].text == playerSide && buttonList [8].text == playerSide)
       {
           GameOver(playerSide);
       } 
       else if (buttonList [0].text == playerSide && buttonList [3].text == playerSide && buttonList [6].text == playerSide)
       {
           GameOver(playerSide);
       } 
       else if (buttonList [1].text == playerSide && buttonList [4].text == playerSide && buttonList [7].text == playerSide)
       {
           GameOver(playerSide);
       } 
       else if (buttonList [2].text == playerSide && buttonList [5].text == playerSide && buttonList [8].text == playerSide)
       {
           GameOver(playerSide);
       } 
       else if (buttonList [0].text == playerSide && buttonList [4].text == playerSide && buttonList [8].text == playerSide)
       {
           GameOver(playerSide);
       } 
       else if (buttonList [2].text == playerSide && buttonList [4].text == playerSide && buttonList [6].text == playerSide)
       {
           GameOver(playerSide);
       } 
       else if (moveCount >= 9)
       {
           GameOver("draw");
       } 
       else
       {
           ChangeSides();
       }
   }

   void ChangeSides ()
   {
       playerSide = (playerSide == "X") ? "O" : "X";
       if (playerSide == "X")
       {
           SetPlayerColors(playerX, playerO);
       } 
       else
       {
           SetPlayerColors(playerO, playerX);
       }
   }

   void SetPlayerColors (Player newPlayer, Player oldPlayer)
   {
       newPlayer.panel.color = activePlayerColor.panelColor;
       newPlayer.text.color = activePlayerColor.textColor;
       oldPlayer.panel.color = inactivePlayerColor.panelColor;
       oldPlayer.text.color = inactivePlayerColor.textColor;
   }

   void GameOver (string winningPlayer)
   {  whoTurn = winningPlayer;
       SetBoardInteractable(false);
       if (winningPlayer == "draw")
       {
           SetGameOverText("REMIS!");
	} else
       {
           SetGameOverText(" WYGRYWA " + winningPlayer + "!");
       }
       restartButton.SetActive(true);
   }

   void SetGameOverText (string value)
   {
       gameOverPanel.SetActive(true);
       gameOverText.text = value;
   }

   public void RestartGame ()
   { 
	if (whoTurn == "draw"){
	playerSide = "X";}
else
       playerSide = whoTurn;
       moveCount = 0;
       gameOverPanel.SetActive(false);
       restartButton.SetActive(false);
	if(whoTurn == "O")
{
	SetPlayerColors(playerO, playerX);
} else

       SetPlayerColors(playerX, playerO);
       SetBoardInteractable(true);

       for (int i = 0; i < buttonList.Length; i++)
       {
           buttonList [i].text = "";
       }
   }

   void SetBoardInteractable (bool toggle)
   {
       for (int i = 0; i < buttonList.Length; i++)
       {
           buttonList[i].GetComponentInParent<Button>().interactable = toggle;
       }
   }
}