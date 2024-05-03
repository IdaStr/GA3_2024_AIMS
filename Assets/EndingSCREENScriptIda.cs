using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

using TMPro;




public class EndingSCREENScriptIda : MonoBehaviour
{
    public GameObject EndCredits;


    private void OnTriggerEnter(Collider other)
    {
        { if (other.tag == "Player")

                Debug.Log("Player entered triggerzone");
        

        }

        {
            EndCredits.SetActive (true);
            


        }

    }  


}
