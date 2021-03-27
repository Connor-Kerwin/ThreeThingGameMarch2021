using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class SpawnDemoCollectables : MonoBehaviour
{
    public GameObject goldenChickPrefab;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.F) && NetworkServer.active)
        {
            GameObject inst = GameObject.Instantiate<GameObject>(goldenChickPrefab);
            NetworkServer.Spawn(inst);
        }
    }
}
