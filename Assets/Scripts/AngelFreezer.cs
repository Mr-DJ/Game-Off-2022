using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AngelFreezer : MonoBehaviour
{
    private FieldOfView fov;
    private HashSet<GameObject> frozenAngels;

    void Awake()
    {
        frozenAngels = new HashSet<GameObject>();
    }

    void Start()
    {
        fov = GetComponent<FieldOfView>();
    }

    void Update()
    {
        frozenAngels.UnionWith(fov.visibleTargets);

        foreach (GameObject current in frozenAngels) 
            if (current.tag == "Angel")
                current.GetComponent<AngelBehaviour>().freeze = fov.visibleTargets.Contains(current);

        frozenAngels.RemoveWhere(obj => !(obj.tag == "Angel" && fov.visibleTargets.Contains(obj)));
    }
}
