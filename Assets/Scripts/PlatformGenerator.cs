using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformGenerator : MonoBehaviour
{
    public GameObject player;
    public GameObject[] platforms;

    private Vector3 firstPosition, lastPosition;
    private GameObject lastPlatform;

    private float size;

    void Start()
    {
        GameObject platform = platforms[0];
        lastPlatform = Instantiate(platform, player.transform.position + Vector3.down * 3, Quaternion.identity);
        lastPosition = lastPlatform.transform.GetChild(1).position;
    }

    void Update()
    {
        float edge = player.transform.position.x + lastPlatform.GetComponent<Collider>().bounds.size.x;

        if (edge > lastPosition.x) {
            GameObject platform = platforms[Random.Range(0, platforms.Length)];

            firstPosition = platform.transform.GetChild(0).position;
            Vector3 position = lastPosition + platform.transform.position - firstPosition;

            lastPlatform = Instantiate(platform, position, Quaternion.identity);
            lastPosition = lastPlatform.transform.GetChild(1).position;
        }
    }
}
