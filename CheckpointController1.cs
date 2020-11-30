using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckpointController1 : MonoBehaviour
{
    public static CheckpointController1 instance;

    private CheckpointController[] checkpoints;

    public Vector3 spawnpoint;

    private void Awake()
    {
        instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        checkpoints = FindObjectsOfType<CheckpointController>();

        spawnpoint = PlayerController.instance.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void DeactivateCheckpoints()
    {
        for(int i = 0; i < checkpoints.Length; i++)
        {
            checkpoints[i].ResetCheckpoint();
        }
    }

    public void SetSpawnpoint(Vector3 newSpawnpoint)
    {
        spawnpoint = newSpawnpoint;
    }
}
