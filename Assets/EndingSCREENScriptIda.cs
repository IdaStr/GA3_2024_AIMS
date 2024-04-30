using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndingSCREENScriptIda : MonoBehaviour
{


    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")

            Debug.Log("Player entered and left triggerzone");

      

    }


}
