using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enter : MonoBehaviour
{
    public GameObject enterDialog;
    // Start is called before the first frame update

    private void OnTriggerStay2D(Collider2D collision)
    
    {
        if (collision.gameObject.tag == "Players") 
        {
            enterDialog.SetActive(true);
        }
    }
   

    
}
