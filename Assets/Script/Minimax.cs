using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Minimax : MonoBehaviour
{
    public Text[] buttonList;
    private string playerSide;
    private GameController gameController;


    void Start()
    {
        gameController = GameObject.FindObjectOfType<GameController>();
        buttonList = gameController.buttonList;
        playerSide = gameController.GetPlayerSide();
        //StartCoroutine(Coroutine1());
        //Coroutine1();
    }
    public void bestMove(){
        // AI to make its turn
        int bestScore = -65535;
        int move = 8;
        for(int i = 0; i < 9; i++){
            if(buttonList[i].text == ""){
               buttonList[i].text = "O";
               int score = minimax(buttonList,0,false);
               buttonList[i].text = "";
               //Debug.Log("score["+i+"]:"+score);
               if (score > bestScore) {
                  bestScore = score;
                  move = i;
               }
            }
        }
        buttonList[move].GetComponentInParent<Button>().interactable = false;
        buttonList[move].text = gameController.GetPlayerSide();
        gameController.EndTurn();
    }
    
    private int scores(string result){
        if(result == "O")
            return 10;
        else if(result == "X")
            return -10;
        else
            return 0;
    }
    public int minimax(Text[] buttonList,int depth,bool isMaximizing){

        //Debug.Log("ButtonList:"+buttonList[0].text);
        string result = gameController.checkWinner(); 
        //Debug.Log("Depth:"+depth);
        if(result != ""){
            return scores(result);
        } 
        ///*
        if(isMaximizing){
           int bestScore = -1000;
            for(int i = 0; i < 9; i++){
                if(buttonList[i].text == ""){
                    buttonList[i].text = "O";
                    int score = minimax(buttonList,(depth+1),false);
                    buttonList[i].text = "";
                    //Debug.Log("isMaximizing Score:"+score);
                    if (score > bestScore) {
                        bestScore = score;
                    }
                }
            }
            return bestScore; 
        }
        //*/
        //return 0;
        ///*
        else{
            int bestScore = 1000;
            for(int i = 0; i < 9; i++){
                if(buttonList[i].text == ""){
                    buttonList[i].text = "X";
                    int score = minimax(buttonList,(depth+1),true);
                    buttonList[i].text = "";
                    //Debug.Log("isNot Score:"+score);
                    if (score < bestScore) {
                        bestScore = score;
                    }
                }
            } 
            return bestScore;
        }    
        //*/
    }
}
