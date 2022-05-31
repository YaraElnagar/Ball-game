using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamScript : MonoBehaviour
{
    public GameObject Player;
    private Vector3 cameraLocation;

    private void Start()
    {
        cameraLocation = this.transform.position;
    }

    private void LateUpdate()
    {
        this.transform.position = Player.transform.position + cameraLocation;
    }
}
