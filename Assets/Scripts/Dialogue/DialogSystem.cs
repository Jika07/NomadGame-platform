using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class DialogSystem : MonoBehaviour
{
    
[System.Serializable]
public struct Speaker
{
    public SpriteRenderer spriteRenderer;
    public Image imageDialog;
    public Text textDialogue;
    public GameObject objectArrow;
}
[System.Serializable]
public struct DialogData 
{
    public int speakerIndex;
    [TextArea(3,10)]
    public string dialogue;
}
    [SerializeField]
    private Speaker[] speakers;
    [SerializeField]
    private DialogData[] dialogs;
    [SerializeField]
    private bool isAutoStart = true;
    public Image StartDialog;
    private bool isFirst = true;
    private int currentDialogIndex = -1;
    private int currentSpeakerIndex = 0;

    private float typingSpeed = 0.1f;
    private bool isTypingEffect = false;

    private void Awake() 
    {
        Setup();
    }
    private void Setup()
    {
        for (int i = 0; i< speakers.Length; ++i)
        {
            SetActiveObjects (speakers[i],false);
            speakers[i].spriteRenderer.gameObject.SetActive(true);
            
        }
    }
    public bool UpdateDialog() 
    {
        if (isFirst == true) 
        {
        StartDialog.enabled = true;
            Setup();
            
            if (isAutoStart)SetNextDialog();
            isFirst = false;
        }
        if (Input.GetMouseButtonDown(0))
        {
            StartDialog.enabled = false;
            if (isTypingEffect == true)
            {
                isTypingEffect = false;
                StopCoroutine ("OnTypingText");
                speakers[currentSpeakerIndex].textDialogue.text = dialogs[currentDialogIndex].dialogue;
                speakers[currentSpeakerIndex].objectArrow.SetActive(false);
                return false;
            }
            if (dialogs.Length > currentDialogIndex + 1)
            {
                SetNextDialog();
            }
            else 
            {
                for ( int i = 0; i < speakers.Length; ++ i)
                {
                    SetActiveObjects(speakers[i], false);
                     
                   gameObject.SetActive(false);
                }
                return true;
            }
        }
        return false;
    }
    private void SetNextDialog()
    {
        SetActiveObjects(speakers[currentSpeakerIndex],false);
        currentDialogIndex ++;
        currentSpeakerIndex = dialogs[currentDialogIndex].speakerIndex;
        SetActiveObjects(speakers[currentSpeakerIndex],true);
        speakers[currentSpeakerIndex].textDialogue.text = dialogs[currentDialogIndex].dialogue;
        StartCoroutine("OnTypingText");
    }
    private void SetActiveObjects(Speaker speaker, bool visible) 
    {
        speaker.imageDialog.gameObject.SetActive(visible);
        speaker.textDialogue.gameObject.SetActive(visible);

        speaker.objectArrow.SetActive(false);

    }
    private IEnumerator OnTypingText()
    {
        int index = 0;
        isTypingEffect = true;
        while (index < dialogs[currentDialogIndex].dialogue.Length)
        {
            speakers[currentSpeakerIndex].textDialogue.text = dialogs[currentDialogIndex].dialogue.Substring(0,index);
            index ++;
            yield return new WaitForSeconds(typingSpeed);
        }
        isTypingEffect = false;
        speakers[currentSpeakerIndex].objectArrow.SetActive(true);
               
    }
}
