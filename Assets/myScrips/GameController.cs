using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    private GameObject selectedPiece;
    private Vector3 selectedPosition;
    private GameObject[] boardSquares,
        pieceBlue,
        pieceRed;
    private float moveSpeed = 30f;
    private Color[] originalColors;
    
    public bool redTurn = false;
    public bool blueTurn = true;



    private void Start()
    {
        boardSquares = GameObject.FindGameObjectsWithTag("Board");
        pieceBlue = GameObject.FindGameObjectsWithTag("PieceBlue");
        pieceRed = GameObject.FindGameObjectsWithTag("PieceRed");
        
        // set origin bord's color
        originalColors = new Color[boardSquares.Length];
        for (int i = 0; i < boardSquares.Length; i++)
        {
            originalColors[i] = boardSquares[i].GetComponent<Renderer>().material.color;
        }
        
        
         // set boxcllider 
        foreach (GameObject board in boardSquares)
        {  foreach (GameObject blue in pieceBlue){
            foreach (GameObject red in pieceRed){
                if(board.transform.position == blue.transform.position || board.transform.position == red.transform.position){
                    board.GetComponent<BoxCollider2D>().enabled = false;
                }
            }
        }
           
        }
    }

    private void Update()
    {   
        
        
        if (Input.GetMouseButtonDown(0) )
        {   Collider col = GetComponent<Collider>();
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(ray.origin, ray.direction);

            if ((hit.collider.tag == "PieceBlue") && blueTurn)
            {   
                for (int i = 0; i < boardSquares.Length; i++)
                {
                    boardSquares[i].GetComponent<Renderer>().material.color = originalColors[i];
                }

                selectedPiece = hit.collider.gameObject;
                selectedPosition = selectedPiece.transform.position;

                for (int i = 0; i < boardSquares.Length; i++)
                {
                    if (
                        Mathf.Approximately(
                            boardSquares[i].transform.position.x,
                            selectedPosition.x
                        )
                        || Mathf.Approximately(
                            boardSquares[i].transform.position.y,
                            selectedPosition.y
                        )
                    )
                    {   bool dontBlock = true;
                        foreach (GameObject obj1 in pieceBlue){
                            foreach (GameObject obj2 in pieceRed)
                            {   if(obj1.transform.position == boardSquares[i].transform.position || obj2.transform.position == boardSquares[i].transform.position){
                                   dontBlock = false;
                                   break;
                                }
                                
                                    if((
                                            obj1.transform.position.x < boardSquares[i].transform.position.x
                                            && obj1.transform.position.x > selectedPosition.x
                                            && Mathf.Approximately(boardSquares[i].transform.position.y, obj1.transform.position.y)
                                        )
                                        || (
                                            obj1.transform.position.x > boardSquares[i].transform.position.x
                                            && obj1.transform.position.x < selectedPosition.x
                                            && Mathf.Approximately(boardSquares[i].transform.position.y, obj1.transform.position.y)
                                        )
                                        || (
                                            obj1.transform.position.y < boardSquares[i].transform.position.y
                                            && obj1.transform.position.y > selectedPosition.y
                                            && Mathf.Approximately(boardSquares[i].transform.position.x, obj1.transform.position.x)
                                        )
                                        || (
                                            obj1.transform.position.y > boardSquares[i].transform.position.y
                                            && obj1.transform.position.y < selectedPosition.y
                                            && Mathf.Approximately(boardSquares[i].transform.position.x, obj1.transform.position.x)
                                        )
                                        || (
                                            obj2.transform.position.x < boardSquares[i].transform.position.x
                                            && obj2.transform.position.x > selectedPosition.x
                                            && Mathf.Approximately(boardSquares[i].transform.position.y, obj2.transform.position.y)
                                        )
                                        || (
                                            obj2.transform.position.x > boardSquares[i].transform.position.x
                                            && obj2.transform.position.x < selectedPosition.x
                                            && Mathf.Approximately(boardSquares[i].transform.position.y, obj2.transform.position.y)
                                        )
                                        || (
                                            obj2.transform.position.y < boardSquares[i].transform.position.y
                                            && obj2.transform.position.y > selectedPosition.y
                                            && Mathf.Approximately(boardSquares[i].transform.position.x, obj2.transform.position.x)
                                        )
                                        || (
                                            obj2.transform.position.y >boardSquares[i].transform.position.y
                                            && obj2.transform.position.y < selectedPosition.y
                                            && Mathf.Approximately(boardSquares[i].transform.position.x, obj2.transform.position.x)
                                        )){
                                        dontBlock = false;
                                }
                                
                                
                            }
                            }
                        if(dontBlock){
                            boardSquares[i].GetComponent<Renderer>().material.color = Color.Lerp(originalColors[i], Color.yellow, 0.5f);
                        }
                        
                    }
                }
            }
            if (hit.collider.tag == "PieceRed" && redTurn)
            {
                
                for (int i = 0; i < boardSquares.Length; i++)
                {
                    boardSquares[i].GetComponent<Renderer>().material.color = originalColors[i];
                }
                selectedPiece = hit.collider.gameObject;
                selectedPosition = selectedPiece.transform.position;

                for (int i = 0; i < boardSquares.Length; i++)
                {
                    if (
                        Mathf.Approximately(
                            boardSquares[i].transform.position.x,
                            selectedPosition.x
                        )
                        || Mathf.Approximately(
                            boardSquares[i].transform.position.y,
                            selectedPosition.y
                        )
                    )
                    {   bool dontBlock = true;
                        foreach (GameObject obj1 in pieceBlue){
                            foreach (GameObject obj2 in pieceRed)
                            {   if(obj1.transform.position == boardSquares[i].transform.position || obj2.transform.position == boardSquares[i].transform.position){
                                   dontBlock = false;
                                   break;
                                }
                                
                                    if((
                                            obj1.transform.position.x < boardSquares[i].transform.position.x
                                            && obj1.transform.position.x > selectedPosition.x
                                            && Mathf.Approximately(boardSquares[i].transform.position.y, obj1.transform.position.y)
                                        )
                                        || (
                                            obj1.transform.position.x > boardSquares[i].transform.position.x
                                            && obj1.transform.position.x < selectedPosition.x
                                            && Mathf.Approximately(boardSquares[i].transform.position.y, obj1.transform.position.y)
                                        )
                                        || (
                                            obj1.transform.position.y < boardSquares[i].transform.position.y
                                            && obj1.transform.position.y > selectedPosition.y
                                            && Mathf.Approximately(boardSquares[i].transform.position.x, obj1.transform.position.x)
                                        )
                                        || (
                                            obj1.transform.position.y > boardSquares[i].transform.position.y
                                            && obj1.transform.position.y < selectedPosition.y
                                            && Mathf.Approximately(boardSquares[i].transform.position.x, obj1.transform.position.x)
                                        )
                                        || (
                                            obj2.transform.position.x < boardSquares[i].transform.position.x
                                            && obj2.transform.position.x > selectedPosition.x
                                            && Mathf.Approximately(boardSquares[i].transform.position.y, obj2.transform.position.y)
                                        )
                                        || (
                                            obj2.transform.position.x > boardSquares[i].transform.position.x
                                            && obj2.transform.position.x < selectedPosition.x
                                            && Mathf.Approximately(boardSquares[i].transform.position.y, obj2.transform.position.y)
                                        )
                                        || (
                                            obj2.transform.position.y < boardSquares[i].transform.position.y
                                            && obj2.transform.position.y > selectedPosition.y
                                            && Mathf.Approximately(boardSquares[i].transform.position.x, obj2.transform.position.x)
                                        )
                                        || (
                                            obj2.transform.position.y >boardSquares[i].transform.position.y
                                            && obj2.transform.position.y < selectedPosition.y
                                            && Mathf.Approximately(boardSquares[i].transform.position.x, obj2.transform.position.x)
                                        )){
                                        dontBlock = false;
                                }
                                
                                
                            }
                            }
                        if(dontBlock){
                            boardSquares[i].GetComponent<Renderer>().material.color = Color.Lerp(originalColors[i], Color.yellow, 0.5f);
                        }
                    }
                }
            }
        }

        if (Input.GetMouseButtonDown(0) && selectedPiece != null )
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(ray.origin, ray.direction);

            if (hit.collider != null && hit.collider.tag == "Board")
            {
                Vector3 destination = hit.collider.transform.position;
                StartCoroutine(MovePiece(selectedPiece, selectedPosition, destination));
            }
        }
    }



    private IEnumerator MovePiece(GameObject piece, Vector3 currentPosition, Vector3 destination)
    {
        int eatedNum = 0;
        GameObject[] eatedArray = new GameObject[64];
        for (int i = 0; i < pieceBlue.Length; i++)
        {
            if (
                (
                    pieceBlue[i].transform.position.x < currentPosition.x
                    && pieceBlue[i].transform.position.x > destination.x
                    && Mathf.Approximately(currentPosition.y, pieceBlue[i].transform.position.y)
                )
                || (
                    pieceBlue[i].transform.position.x > currentPosition.x
                    && pieceBlue[i].transform.position.x < destination.x
                    && Mathf.Approximately(currentPosition.y, pieceBlue[i].transform.position.y)
                )
                || (
                    pieceBlue[i].transform.position.y < currentPosition.y
                    && pieceBlue[i].transform.position.y > destination.y
                    && Mathf.Approximately(currentPosition.x, pieceBlue[i].transform.position.x)
                )
                || (
                    pieceBlue[i].transform.position.y > currentPosition.y
                    && pieceBlue[i].transform.position.y < destination.y
                    && Mathf.Approximately(currentPosition.x, pieceBlue[i].transform.position.x)
                )
                || (
                    pieceRed[i].transform.position.x < currentPosition.x
                    && pieceRed[i].transform.position.x > destination.x
                    && Mathf.Approximately(currentPosition.y, pieceRed[i].transform.position.y)
                )
                || (
                    pieceRed[i].transform.position.x > currentPosition.x
                    && pieceRed[i].transform.position.x < destination.x
                    && Mathf.Approximately(currentPosition.y, pieceRed[i].transform.position.y)
                )
                || (
                    pieceRed[i].transform.position.y < currentPosition.y
                    && pieceRed[i].transform.position.y > destination.y
                    && Mathf.Approximately(currentPosition.x, pieceRed[i].transform.position.x)
                )
                || (
                    pieceRed[i].transform.position.y > currentPosition.y
                    && pieceRed[i].transform.position.y < destination.y
                    && Mathf.Approximately(currentPosition.x, pieceRed[i].transform.position.x)
                )
                || destination == pieceRed[i].transform.position
                || destination == pieceBlue[i].transform.position
            )
            {
                yield break;
            }
        }

        float distance = Vector3.Distance(currentPosition, destination);

        float time = distance / moveSpeed;

        bool isOnSameRow = Mathf.Approximately(currentPosition.y, destination.y);
        bool isOnSameColumn = Mathf.Approximately(currentPosition.x, destination.x);

        if (!isOnSameRow && !isOnSameColumn)
        {
            yield break;
        }

        for (int i = 0; i < boardSquares.Length; i++)
        {
            boardSquares[i].GetComponent<Renderer>().material.color = originalColors[i];
        }

        float elapsedTime = 0;
        while (elapsedTime < time)
        {
            piece.transform.position = Vector3.Lerp(
                currentPosition,
                destination,
                (elapsedTime / time)
            );
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        piece.transform.position = destination;
        selectedPiece = null;

// eat piece
        foreach (GameObject obj1 in pieceBlue)
{   int pointcol = 0;
    int pointraw = 0;
    GameObject[] destroy1 = new GameObject[2];
    GameObject[] destroy2 = new GameObject[2];
  
    foreach (GameObject obj2 in pieceRed)
    {
        float distanceX = Mathf.Abs(obj1.transform.position.x - obj2.transform.position.x);
        float distanceY = Mathf.Abs(obj1.transform.position.y - obj2.transform.position.y);
        
        if(distanceX == 1 && distanceY == 0){
                   if(blueTurn){destroy1[pointcol] = obj2;}
                    else
                    {
                       destroy1[pointcol] = obj1;
                    }
                    pointcol += 1;
                }
                if(distanceX == 0 && distanceY == 1){
                    if(blueTurn){destroy2[pointraw] = obj2;}
                    else
                    {
                       destroy2[pointraw] = obj1;
                    }
                    pointraw += 1;
                }
                if(pointcol >= 2){
                    foreach (GameObject dest1 in destroy1){
                        eatedArray[eatedNum] = dest1;
                        eatedNum += 1;
                    }
                }
                if(pointraw >= 2){
                    foreach (GameObject dest2 in destroy2){
                        eatedArray[eatedNum] = dest2;
                        eatedNum += 1;
                    } 
                }
    }
}




    foreach (GameObject obj1 in pieceRed)
{   int pointcol = 0;
    int pointraw = 0;
    GameObject[] destroy1 = new GameObject[2];
    GameObject[] destroy2 = new GameObject[2];
    // Loop over each game object in the second tag
    foreach (GameObject obj2 in pieceBlue)
    {
        // Calculate the distance between the game objects in x and y
        float distanceX = Mathf.Abs(obj1.transform.position.x - obj2.transform.position.x);
        float distanceY = Mathf.Abs(obj1.transform.position.y - obj2.transform.position.y);
        
        if(distanceX == 1 && distanceY == 0){
                    if(blueTurn){destroy1[pointcol] = obj1;}
                    else
                    {
                       destroy1[pointcol] = obj2;
                    }
                    pointcol += 1;
                }
                if(distanceX == 0 && distanceY == 1){
                    if(blueTurn){destroy2[pointraw] = obj1;}
                    else
                    {
                       destroy2[pointraw] = obj2;
                    }
                    pointraw += 1;
                }
                if(pointcol >= 2){
                    foreach (GameObject dest1 in destroy1){
                        eatedArray[eatedNum] = dest1;
                        eatedNum += 1;
                    }
                }
                if(pointraw >= 2){
                    foreach (GameObject dest2 in destroy2){
                        eatedArray[eatedNum] = dest2;
                        eatedNum += 1;
                    }
                }
    }

}

        foreach (GameObject obj1 in pieceBlue){
            int cornerPoint = 0;
            foreach(GameObject obj2 in pieceRed){
                float distanceX = Mathf.Abs(obj1.transform.position.x - obj2.transform.position.x);
                float distanceY = Mathf.Abs(obj1.transform.position.y - obj2.transform.position.y);   
                if(( obj1.transform.position.x == 3.5f && obj1.transform.position.y == 3.5f )||
                (obj1.transform.position.x == -3.5f && obj1.transform.position.y == 3.5f) ||
                (obj1.transform.position.x == 3.5f && obj1.transform.position.y == -3.5f )||
                (obj1.transform.position.x == -3.5f && obj1.transform.position.y == -3.5f) ){
                    if(distanceX == 1 && distanceY == 0 || distanceX == 0 && distanceY == 1){
                        cornerPoint += 1;
                    }
                }
            }
            if(cornerPoint >= 2){
                eatedArray[eatedNum] = obj1;
                        eatedNum += 1;
            }
        }

        foreach (GameObject obj1 in pieceRed){
            int cornerPoint = 0;
            foreach(GameObject obj2 in pieceBlue){
                float distanceX = Mathf.Abs(obj1.transform.position.x - obj2.transform.position.x);
                float distanceY = Mathf.Abs(obj1.transform.position.y - obj2.transform.position.y);   
                if(( obj1.transform.position.x == 3.5f && obj1.transform.position.y == 3.5f )||
                (obj1.transform.position.x == -3.5f && obj1.transform.position.y == 3.5f) ||
                (obj1.transform.position.x == 3.5f && obj1.transform.position.y == -3.5f )||
                (obj1.transform.position.x == -3.5f && obj1.transform.position.y == -3.5f) ){
                    if(distanceX == 1 && distanceY == 0 || distanceX == 0 && distanceY == 1){
                        cornerPoint += 1;
                    }
                }
            }
            if(cornerPoint >= 2){
                eatedArray[eatedNum] = obj1;
                        eatedNum += 1;
            }
        }
        if(redTurn){
            foreach (GameObject pice1 in pieceRed){
                GameObject[] pieceBluex = new GameObject[6];
                GameObject[] pieceBluey = new GameObject[6];
                float xmin;
                float ymin;
                int xnum = 0;
                int ynum = 0;
                foreach (GameObject pice2 in pieceBlue){
                    if(pice1.transform.position.y - pice2.transform.position.y == 0){
                        if(pice1.transform.position.x - pice2.transform.position.x == 1){
                            pieceBluex[xnum] = pice2;
                            xnum += 1;
                            xmin = pice2.transform.position.x;
                            for (int i = 0; i < 6; i++){
                                foreach (GameObject pice3 in pieceBlue){
                                  if(pice1.transform.position.y - pice3.transform.position.y == 0){
                                    if(xmin - pice3.transform.position.x == 1){
                                        pieceBluex[xnum] = pice3;
                                        xnum += 1;
                                        xmin = pice3.transform.position.x;}
                                    }
                                }
                            }
                            foreach (GameObject pice4 in pieceRed){
                              if(pice1.transform.position.y - pice4.transform.position.y == 0)
                                {if(xmin - pice4.transform.position.x == 1){
                                    foreach (GameObject pice in pieceBluex){
                                        eatedArray[eatedNum] = pice;
                                        eatedNum += 1;
                                    }
                                }}
                            }
                        }
                    }

                    if(pice1.transform.position.x - pice2.transform.position.x == 0){
                        if(pice1.transform.position.y - pice2.transform.position.y == 1){
                            pieceBluey[ynum] = pice2;
                            ynum += 1;
                            ymin = pice2.transform.position.y;
                            for (int i = 0; i < 6; i++){
                                foreach (GameObject pice3 in pieceBlue){
                                  if(pice1.transform.position.x - pice3.transform.position.x == 0){
                                    if(ymin - pice3.transform.position.y == 1){
                                        pieceBluey[ynum] = pice3;
                                        ynum += 1;
                                        ymin = pice3.transform.position.y;
                                    }}
                                }
                            }
                            foreach (GameObject pice4 in pieceRed){
                              if(pice1.transform.position.x - pice4.transform.position.x == 0)
                                {if(ymin - pice4.transform.position.y == 1){
                                    foreach (GameObject pice in pieceBluey){
                                        eatedArray[eatedNum] = pice;
                                        eatedNum += 1;
                                    }
                                }}
                            }
                        }
                    }
                }
            }
        }

        if(blueTurn){
            foreach (GameObject pice1 in pieceBlue){
                GameObject[] pieceRedx = new GameObject[6];
                GameObject[] pieceRedy = new GameObject[6];
                float xmin;
                float ymin;
                int xnum = 0;
                int ynum = 0;
                foreach (GameObject pice2 in pieceRed){
                    if(pice1.transform.position.y - pice2.transform.position.y == 0){
                        if(pice1.transform.position.x - pice2.transform.position.x == 1){
                            pieceRedx[xnum] = pice2;
                            xnum += 1;
                            xmin = pice2.transform.position.x;
                            for (int i = 0; i < 6; i++){
                                foreach (GameObject pice3 in pieceRed){
                                  if(pice1.transform.position.y - pice3.transform.position.y == 0)
                                    {if(xmin - pice3.transform.position.x == 1){
                                        pieceRedx[xnum] = pice3;
                                        xnum += 1;
                                        xmin = pice3.transform.position.x;
                                    }}
                                }
                            }
                            foreach (GameObject pice4 in pieceBlue){
                              if(pice1.transform.position.y - pice4.transform.position.y == 0)
                                {if(xmin - pice4.transform.position.x == 1){
                                    foreach (GameObject pice in pieceRedx){
                                        eatedArray[eatedNum] = pice;
                                        eatedNum += 1;
                                    }
                                }}
                            }
                        }
                    }

                    if(pice1.transform.position.x - pice2.transform.position.x == 0){
                        if(pice1.transform.position.y - pice2.transform.position.y == 1){
                            pieceRedy[ynum] = pice2;
                            ynum += 1;
                            ymin = pice2.transform.position.y;
                            for (int i = 0; i < 6; i++){
                                foreach (GameObject pice3 in pieceRed){
                                  if(pice1.transform.position.x - pice3.transform.position.x == 0)
                                    {if(ymin - pice3.transform.position.y == 1){
                                        pieceRedy[ynum] = pice3;
                                        ynum += 1;
                                        ymin = pice3.transform.position.y;
                                    }}
                                }
                            }
                            foreach (GameObject pice4 in pieceBlue){
                              if(pice1.transform.position.x - pice4.transform.position.x == 0)
                                {if(ymin - pice4.transform.position.y == 1){
                                    foreach (GameObject pice in pieceRedy){
                                        eatedArray[eatedNum] = pice;
                                        eatedNum += 1;
                                    }
                                }}
                            }
                        }
                    }
                }
            }
        }
   
        foreach (GameObject eated in eatedArray){
                        if(eated != null)
                       { eated.SetActive(false); // disable the game object
                        Renderer renderer = eated.GetComponent<Renderer>();
                        renderer.enabled = false;
                        eated.transform.position = Vector3.zero; 
                        }
                    } 


        foreach (GameObject board in boardSquares){
            board.GetComponent<BoxCollider2D>().enabled = true;
        } 
        // set boxcllider 
        foreach (GameObject board in boardSquares)
        {  foreach (GameObject blue in pieceBlue){
            foreach (GameObject red in pieceRed){
                if(board.transform.position == blue.transform.position || board.transform.position == red.transform.position){
                    board.GetComponent<BoxCollider2D>().enabled = false;
                }
            }
        }
           
        }
       
       
       
        // check win
        int redpoint = 0;
        int bluepoint = 0;
        foreach (GameObject blue in pieceBlue){
            if(blue.transform.position == Vector3.zero){
                redpoint += 1;
            }
        }
        foreach (GameObject red in pieceRed){
            if(red.transform.position == Vector3.zero){
                bluepoint += 1;
            }
        }
        if(bluepoint == 8){
            //blue win
            SceneManager.LoadScene(10);
        }
        if(redpoint == 8){
            //redwin
            SceneManager.LoadScene(11);
        }


        // change turn
        redTurn = !redTurn;
        blueTurn = !blueTurn;
    }
}
