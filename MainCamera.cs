using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCamera : MonoBehaviour
{
    public Transform player;
    
    // Start is called before the first frame update
      
    void Start()
    {
        transform.position = new Vector3(player.position.x, player.position.y, -10f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    
}
