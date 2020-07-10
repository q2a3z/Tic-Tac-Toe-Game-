using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GameController : MonoBehaviour {

    public Text[] buttonList;

    public GameObject gameOverPanel;
    public Text gameOverText;

    private string playerSide;
    private int moveCount;
    public Button Restart;
    private Minimax minimax;
    void Awake ()
    {
        minimax = GameObject.FindObjectOfType<Minimax>();
        SetGameControllerReferenceOnButtons();
        playerSide = "X";
        gameOverPanel.SetActive(false);
        moveCount = 0;
        Button btn = Restart.GetComponent<Button>();
	    btn.onClick.AddListener(RestartGame); 
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

    public string checkWinner(){
        //horizontal
        if (buttonList [0].text == playerSide && buttonList [1].text == playerSide && buttonList [2].text == playerSide)
        {
            //GameOver();
            return playerSide;
        }

        if (buttonList [3].text == playerSide && buttonList [4].text == playerSide && buttonList [5].text == playerSide)
        {
            //GameOver();
            return playerSide;
        }

        if (buttonList [6].text == playerSide && buttonList [7].text == playerSide && buttonList [8].text == playerSide)
        {
            //GameOver();
            return playerSide;
        }
        //vertical
        if (buttonList [0].text == playerSide && buttonList [3].text == playerSide && buttonList [6].text == playerSide)
        {
            //GameOver();
            return playerSide;
        }

        if (buttonList [1].text == playerSide && buttonList [4].text == playerSide && buttonList [7].text == playerSide)
        {
            //GameOver();
            return playerSide;
        }

        if (buttonList [2].text == playerSide && buttonList [5].text == playerSide && buttonList [8].text == playerSide)
        {
            //GameOver();
            return playerSide;
        }
        //diagnol
        if (buttonList [0].text == playerSide && buttonList [4].text == playerSide && buttonList [8].text == playerSide)
        {
            //GameOver();
            return playerSide;
        }

        if (buttonList [2].text == playerSide && buttonList [4].text == playerSide && buttonList [6].text == playerSide)
        {
            //GameOver();
            return playerSide;
        }

        if (moveCount >= 9)
        {
            //GameOver();
            return "T";
            //SetGameOverText ("It's a draw!");
        }
        return "";
    }
    public void EndTurn ()
    {
        moveCount++;
        string result = checkWinner();
        if(result == "X")
            GameOver();
        if(result == "O")
            GameOver();
        if(result == "T")
            SetGameOverText ("It's a draw!");
        ChangeSides();
        if((!gameOverPanel.activeSelf)&&(playerSide == "O"))
            minimax.bestMove();
    }
        
    public void ChangeSides ()
    {
        playerSide = (playerSide == "X") ? "O" : "X";
    }

    void GameOver ()
    {
        for (int i = 0; i < buttonList.Length; i++)
        {
            buttonList[i].GetComponentInParent<Button>().interactable = false;
        }
        SetBoardInteractable(false);
        SetGameOverText(playerSide + " Wins!");
    }
    void SetGameOverText (string value)
    {
        gameOverPanel.SetActive(true);
        gameOverText.text = value;
    }
    public void RestartGame ()
    {
        playerSide = "X";
        moveCount = 0;
        gameOverPanel.SetActive(false);
        SetBoardInteractable(true);

        for (int i = 0; i < buttonList.Length; i++)
        {
            buttonList [i].text = "";
        }
        //if((!gameOverPanel.activeSelf)&&(playerSide == "O"))
        //    minimax.bestMove();
    }
    void SetBoardInteractable (bool toggle)
    {
        for (int i = 0; i < buttonList.Length; i++)
        {
            buttonList[i].GetComponentInParent<Button>().interactable = toggle;
        }
    }
}
