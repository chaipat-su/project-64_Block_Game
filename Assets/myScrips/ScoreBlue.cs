using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreBlue : MonoBehaviour
{
    public TextMeshProUGUI myText;
    private GameObject[] pieceRed;
    void Start()
    {
        
        pieceRed = GameObject.FindGameObjectsWithTag("PieceRed");
        myText = GameObject.FindWithTag("BlueScore").GetComponent<TextMeshProUGUI>();
        myText.SetText("X 0");
    }
    private void Update(){
        int bluepoint = 0;
        foreach (GameObject red in pieceRed){
            if(red.transform.position == Vector3.zero){
                bluepoint += 1;
            }
        }
        myText.SetText("X " + bluepoint);
    }
}
