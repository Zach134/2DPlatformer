using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckpointController : MonoBehaviour
{
    public SpriteRenderer SR;
    public Sprite checkpointON, checkpointOff;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            CheckpointController1.instance.DeactivateCheckpoints();
            SR.sprite = checkpointON;
            CheckpointController1.instance.SetSpawnpoint(transform.position);
        }
    }

    public void ResetCheckpoint()
    {
        SR.sprite = checkpointOff;
    }
}
