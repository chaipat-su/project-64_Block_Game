using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    private GameObject selectedPiece;
    private Vector3 selectedPosition;
    private GameObject[] boardSquares,
        pieceBlue,
        pieceRed;
    private float moveSpeed = 30f;
    private Color[] originalColors;
    private static int pointraw;
    private static int pointcol;
    public bool redTurn = false;

    public bool blueTurn = true;

    private void Start()
    {
        boardSquares = GameObject.FindGameObjectsWithTag("Board");
        pieceBlue = GameObject.FindGameObjectsWithTag("PieceBlue");
        pieceRed = GameObject.FindGameObjectsWithTag("PieceRed");

        originalColors = new Color[boardSquares.Length];
        for (int i = 0; i < boardSquares.Length; i++)
        {
            originalColors[i] = boardSquares[i].GetComponent<Renderer>().material.color;
        }


        

        Debug.Log("Number of board squares: " + pieceBlue.Length + pieceRed.Length);
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
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
                    {
                        boardSquares[i].GetComponent<Renderer>().material.color = Color.yellow;
                    }
                }

                Debug.Log("Selected piece: " + selectedPiece.name);
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
                    {
                        boardSquares[i].GetComponent<Renderer>().material.color = Color.yellow;
                    }
                }

                Debug.Log(
                    "Selected piece: "
                        + selectedPiece.name
                        + (pieceBlue[0].transform.position.x - pieceRed[0].transform.position.x)
                );
            }
        }

        if (Input.GetMouseButtonDown(0) && selectedPiece != null)
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
                Debug.LogWarning("Cannot cross mak");
                yield break;
            }
        }

        float distance = Vector3.Distance(currentPosition, destination);

        float time = distance / moveSpeed;

        bool isOnSameRow = Mathf.Approximately(currentPosition.y, destination.y);
        bool isOnSameColumn = Mathf.Approximately(currentPosition.x, destination.x);

        if (!isOnSameRow && !isOnSameColumn)
        {
            Debug.LogWarning("Cannot move diagonally. Please choose a valid square to move to.");
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


/// eat p
        Debug.Log("Moved piece to: " + destination.ToString());

        foreach (GameObject obj1 in pieceBlue)
{   int pointcol = 0;
    int pointraw = 0;
    GameObject[] destroy1 = new GameObject[2];
    GameObject[] destroy2 = new GameObject[2];
    // Loop over each game object in the second tag
    foreach (GameObject obj2 in pieceRed)
    {
        // Calculate the distance between the game objects in x and y
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
                        dest1.SetActive(false); // disable the game object
                        Renderer renderer = dest1.GetComponent<Renderer>();
renderer.enabled = false;
dest1.transform.position = Vector3.zero; 
                    }
                }
                if(pointraw >= 2){
                    foreach (GameObject dest2 in destroy2){
                        dest2.SetActive(false); // disable the game object
                        Renderer renderer = dest2.GetComponent<Renderer>();
renderer.enabled = false;
dest2.transform.position = Vector3.zero; 
                    }
                }
        // Print the distances to the console
        Debug.Log("Distance between " + obj1.name + " and " + obj2.name + ": " + distanceX + ", " + distanceY);
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
                        dest1.SetActive(false); // disable the game object
                        Renderer renderer = dest1.GetComponent<Renderer>();
renderer.enabled = false;
dest1.transform.position = Vector3.zero; 
                    }
                }
                if(pointraw >= 2){
                    foreach (GameObject dest2 in destroy2){
                        dest2.SetActive(false); // disable the game object
                        Renderer renderer = dest2.GetComponent<Renderer>();
renderer.enabled = false;
dest2.transform.position = Vector3.zero; 
                    }
                }
        // Print the distances to the console
        Debug.Log("Distance between " + obj1.name + " and " + obj2.name + ": " + distanceX + ", " + distanceY);
    }
}

           

           

        redTurn = !redTurn;
        blueTurn = !blueTurn;
    }
}
