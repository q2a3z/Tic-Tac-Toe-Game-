using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GameController : MonoBehaviour {

    public Text[] buttonList;

    public GameObject gameOverPanel;
    public Text gameOverText;

    private string playerSide;
    //private int moveCount;
    public Button Restart;
    private Minimax minimax;
    void Awake ()
    {
        minimax = GameObject.FindObjectOfType<Minimax>();
        SetGameControllerReferenceOnButtons();
        playerSide = "X";
        gameOverPanel.SetActive(false);
        //moveCount = 0;
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

    public bool equals3(string a,string b,string c){
        return (a == b && b == c && a !="")?true:false; 
    }
    public string checkWinner(){
        string winner = "";
        //horizontal
        if (equals3(buttonList [0].text , buttonList [1].text , buttonList [2].text))
        {
            //GameOver();
            winner = buttonList [0].text;
        }

        if (equals3(buttonList [3].text , buttonList [4].text , buttonList [5].text))
        {
            //GameOver();
            winner = buttonList [3].text;
        }

        if (equals3(buttonList [6].text , buttonList [7].text , buttonList [8].text))
        {
            //GameOver();
            winner = buttonList [6].text;
        }
        //vertical
        if (equals3(buttonList [0].text , buttonList [3].text , buttonList [6].text))
        {
            //GameOver();
            winner = buttonList [6].text;
        }

        if (equals3(buttonList [1].text , buttonList [4].text , buttonList [7].text))
        {
            //GameOver();
            winner = buttonList [1].text;
        }

        if (equals3(buttonList [2].text , buttonList [5].text , buttonList [8].text))
        {
            //GameOver();
            winner = buttonList [2].text;
        }
        //diagnol
        if (equals3(buttonList [0].text , buttonList [4].text , buttonList [8].text))
        {
            //GameOver();
            winner = buttonList [4].text;
        }

        if (equals3(buttonList [2].text , buttonList [4].text , buttonList [6].text))
        {
            //GameOver();
            winner = buttonList [4].text;
        }
        int moveCount = 0;
        for(int i = 0; i < 9; i++){
            if(buttonList[i].text == ""){
                moveCount++;
            }
        }
        if ((winner == "") && (moveCount == 0)){
            return "T";
        }
        else if((winner != "")){
            return winner;  
        }
        else{
            return "";
        }
        
    }
    public void EndTurn ()
    {
        //moveCount++;
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
        //moveCount = 0;
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
