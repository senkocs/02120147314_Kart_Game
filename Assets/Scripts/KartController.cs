using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KartController : MonoBehaviour
{
    public KartController kart;
    public Camera gameCamera;
    public float movingSpeed;
    public Text gameText;
    private float gameTimer;
    public GameObject checkpointContainer;
    private int currentCheckpoint = -1;
    private float bestTime = 999;
    private bool finishedLap;

    // Start is called before the first frame update
    void Start()
    {
        foreach (CheckpointController checkpoint in checkpointContainer.GetComponentsInChildren<CheckpointController>())
        {
            checkpoint.onHitByPlayer = (int checkpointId) => OnReachCheckpoint(checkpointId);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey("a"))
        {
            this.transform.RotateAround(this.transform.position, Vector3.up, -1);

        }
        if (Input.GetKey("d"))
        {
            this.transform.RotateAround(this.transform.position, Vector3.up, 1);

        }
        if (Input.GetKey("w"))
        {
            this.GetComponent<Rigidbody>().velocity = this.transform.forward * movingSpeed;

        }
        gameCamera.transform.position = new Vector3(kart.transform.position.x - kart.transform.forward.x * 5, 3, kart.transform.position.z - kart.transform.forward.z * 5);
        gameCamera.transform.LookAt(kart.transform);
        gameTimer += Time.deltaTime;
        gameText.text = "Time: " + Mathf.Floor(gameTimer);
        if (finishedLap)
            gameText.text += "\nBest Time: " + Mathf.Floor(bestTime);
    }
    void OnReachCheckpoint (int checkpointId)
    {
        if (checkpointId == currentCheckpoint + 1)
        {
            currentCheckpoint++;
        }
        if (checkpointId == 0 && currentCheckpoint == 3) 
        {
            Debug.Log("Lap Finished");
            currentCheckpoint = 0;
            finishedLap = true;
            if (gameTimer < bestTime)
            {
                bestTime = gameTimer;
            }
            gameTimer = 0;
        }
    }
}
