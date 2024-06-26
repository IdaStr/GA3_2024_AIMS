using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;


public static class TranslateHelper
{
    public static void LerpTowards(this Transform t1, Transform t2, float t)
    {
        t1.position = Vector3.Lerp(t1.position, t2.position, t);
        t1.rotation = Quaternion.Lerp(t1.rotation, t2.rotation, t);
    }
}


public class DialogueCamera : MonoBehaviour
{

    [Header("Grab A Reference Of DiaCamera")]
    public GameObject playerDiaCamOBJ = null;

    [Header("The Target Position And Rotation (Use Empty)")]
    public GameObject diaTarget = null; // if null it will default to itself.

    [Header("Changes the speed which dialogue camera will lerp to position")]
    [Range(0, 5)] //I've put a "Range" modifier on it for the slider but if you reeeeally want to go beyond 5 you either change the max you change that here :)
    public float transitionSpeed = 1.0f,enableTextOnScreenTreshold=.1f; // 1 being the default speed currently!

    public GameObject player = null;
    GameObject playerCamera = null;
    PlayerController playerController = null;
    public KeyCode triggerKey = KeyCode.F;
    bool isInTrigger;

    bool bInDialogue = false;
    public TMP_Text onScreenText;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("Player"); // store Player ref
        playerCamera = GameObject.FindWithTag("MainCamera"); // store MainCamera ref
        playerController = player.gameObject.GetComponent<PlayerController>(); // For Preventing movement during dialogue..

        if (diaTarget == null)
        {
            diaTarget = this.transform.gameObject; // Default our camera focus to this object unless DiaTarget says otherwise (More flexibility).
        } // I did write this with the intent of having an empty though so keep that in mind ^^.

    }
    // Update is called once per frame
    void Update()
    {

        MoveDiaCam(); // Calls the function allowing us to move smoothly
        if (!Input.GetKeyDown(triggerKey)) { return; }
        if (!isInTrigger) { return; }
     
        if (!bInDialogue) // Temporary methood to get the player out of dialogue mode, you can call this function however you'd like though!
        {
            EnableDialogueCamera();
            Debug.Log("indialouge");
            return;
            
        }
        else
        {
            isInTrigger = false;
            DisableDialogueCamera(); //  <-- Copy this and place it at the end of your dialogue or call it in a different script since its a public function!
        }
    }
        private void EnableDialogueCamera()
    {

        playerDiaCamOBJ.transform.position = playerCamera.transform.position;
        playerDiaCamOBJ.transform.rotation = playerCamera.transform.rotation;

        playerCamera.SetActive(false);
        playerController.enabled = false;
        playerDiaCamOBJ.SetActive(true);
        bInDialogue = true; 
    }
    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(diaTarget.transform.position, enableTextOnScreenTreshold);
    }
    public void DisableDialogueCamera()
    {
        playerDiaCamOBJ.SetActive(false); // disableCamera
        playerDiaCamOBJ.transform.position = new Vector3(0, 0, 0); // reset Camera.
        playerDiaCamOBJ.transform.rotation = new Quaternion(0, 0, 0, 0); // reset Camera.

        playerCamera.SetActive(true);
        playerController.enabled = true;
        onScreenText.enabled = false;
        bInDialogue = false;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            Debug.Log("triggerenter");
            isInTrigger = true;
        }
    }

    private void MoveDiaCam()
    {
        if (bInDialogue)
        {
            if(Vector3.Distance(diaTarget.transform.position, playerDiaCamOBJ.transform.position)<0.1f)onScreenText.enabled=true;
            playerDiaCamOBJ.transform.LerpTowards(diaTarget.transform, transitionSpeed * Time.deltaTime); // Here we use the TranslateHelper in order to much cleanly lerp towards the pos and rot.
        }
    }
}
