using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreRed : MonoBehaviour
{
    public TextMeshProUGUI myText;
    private GameObject[] pieceBlue;
    void Start()
    {
        
        pieceBlue = GameObject.FindGameObjectsWithTag("PieceBlue");
        myText = GameObject.FindWithTag("RedScore").GetComponent<TextMeshProUGUI>();
        myText.SetText("X 0");
    }
    private void Update(){
        int redpoint = 0;
        foreach (GameObject red in pieceBlue){
            if(red.transform.position == Vector3.zero){
                redpoint += 1;
            }
        }
        myText.SetText("X " + redpoint);
    }
}
