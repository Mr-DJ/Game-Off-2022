using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformGenerator : MonoBehaviour
{
    public GameObject player;
    public GameObject[] platforms;
    public int maxPlatforms = 4;

    private Vector3 firstPosition, lastPosition;
    private GameObject lastPlatform;
    private int platformCurr;
    private int platformStart;

    void Start()
    {
        GameObject platform = platforms[0];
        lastPlatform = Instantiate(platform, player.transform.position + Vector3.down * 3, Quaternion.identity);
        lastPosition = lastPlatform.transform.GetChild(1).position;
        platformCurr = platformStart = 1;
        lastPlatform.name = "roadey_" + platformCurr;
    }

    void Update()
    {
        float edge = player.transform.position.x + lastPlatform.GetComponent<Collider>().bounds.size.x;

        if (edge > lastPosition.x) {
            GameObject platform = platforms[Random.Range(0, platforms.Length)];

            firstPosition = platform.transform.GetChild(0).position;
            Vector3 position = lastPosition + platform.transform.position - firstPosition;

            lastPlatform = Instantiate(platform, position, Quaternion.identity);
            platformCurr++;
            lastPlatform.name = "roadey_" + platformCurr;
            lastPosition = lastPlatform.transform.GetChild(1).position;

            if(platformCurr - platformStart >= maxPlatforms) {
                GameObject target = GameObject.Find("roadey_" + platformStart);
                Destroy(target);
                platformStart++;
            }
        }
    }
}
