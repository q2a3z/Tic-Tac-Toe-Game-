using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class GridSpace : MonoBehaviour {

    public Button button;
    public Text buttonText;
    public string playerSide;
    private GameController gameController;

    public void SetGameControllerReference (GameController controller)
    {
        gameController = controller;
    }

    public void SetSpace()
    {
        //buttonText.text = GetComponent<GameController>().GetPlayerSide();
        if(gameController!=null){
                       //gameController.PopUp();
        } else {
            Debug.LogWarning("set Script A!");
        }
        //buttonText.text = playerSide;
        buttonText.text = gameController.GetPlayerSide();
        button.interactable = false;
        gameController.EndTurn();
    }
}
