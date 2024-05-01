using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

using TMPro;




public class EndingSCREENScriptIda : MonoBehaviour
{
    public Canvas EndCredits;


    private void OnTriggerEnter(Collider other)
    {
        { if (other.tag == "Player")

                Debug.Log("Player entered triggerzone");
        

        }

        {
            if (other.tag == "Player")
            {
                Debug.Log("Canvas should activate if youre not an idiot Ida");
                EndCredits.enabled = false;

            }
            


        }

    }  


}
