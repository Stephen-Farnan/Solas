using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class StoryBookScript : MonoBehaviour
{

    private Image image;
    private Animator anim;
    private AudioSource audioSource;

    public float showPageTime;
    public Sprite[] storyBookImages;
    private int chapterStartPageNumber, chapterEndPageNumber;
    private int currentPageNumber;
    private bool canSkip = false;
    private bool hasBeenSkipped = false;
    private ProgressManager progMan;
    public bool isAutomatic = true;
    private bool goingForward = true;
    public Animator maskAnim;
    private bool maskActive = false;
    private Player_Interaction playInt;
    private bool canInteract = true;

    void Start()
    {
        if (GameObject.FindWithTag("Player") != false)
        {
            playInt = GameObject.FindWithTag("Player").GetComponent<Player_Interaction>();
        }

        image = GetComponent<Image>();
        anim = GetComponent<Animator>();
        progMan = GameObject.FindWithTag("Scene_Manager").GetComponent<ProgressManager>();
        audioSource = GetComponent<AudioSource>();

        Color col = image.color;
        col.a = 0;
        image.color = col;

        //Set chapterStartPageNumber Here
        if (progMan.noOfTemplesCompleted == 0)
        {
            chapterStartPageNumber = 0;
            chapterEndPageNumber = 3;
        }
        if (progMan.noOfTemplesCompleted == 1)
        {
            chapterStartPageNumber = 4;
            chapterEndPageNumber = 6;
        }
        if (progMan.noOfTemplesCompleted == 2)
        {
            chapterStartPageNumber = 7;
            chapterEndPageNumber = 11;
        }
        if (progMan.noOfTemplesCompleted == 3)
        {
            chapterStartPageNumber = 12;
            chapterEndPageNumber = 15;
        }
        if (progMan.noOfTemplesCompleted == 4)
        {
            chapterStartPageNumber = 16;
            chapterEndPageNumber = 18;
        }
        currentPageNumber = chapterStartPageNumber;

        if (!isAutomatic)
        {
            chapterStartPageNumber = 0;
            currentPageNumber = 0;
            canSkip = true;
        }

        //Set the image sprite to the chapterStartPageNumber
        image.sprite = storyBookImages[currentPageNumber];

        if (isAutomatic)
        {
            maskActive = true;
            StartCoroutine(FadeIn());
        }

        //StartCoroutine (CheckVariables());
    }

    void Update()
    {
        if (isAutomatic)
        {
            if (Input.anyKeyDown)
            {
                if (!hasBeenSkipped && canSkip)
                {
                    hasBeenSkipped = true;
                    StartCoroutine(FadeOut());
                }
            }
        }
        else
        {
            if (Input.GetAxis("Horizontal") > 0)
            {
                if (maskActive && canSkip && currentPageNumber < chapterEndPageNumber)
                {
                    goingForward = true;
                    StartCoroutine(FadeOut());
                }
            }
            if (Input.GetAxis("Horizontal") < 0)
            {
                if (maskActive && canSkip && currentPageNumber > chapterStartPageNumber)
                {
                    goingForward = false;
                    StartCoroutine(FadeOut());
                }
            }

            if (Input.GetButtonDown("Interact"))
            {
                if (canSkip && maskActive && canInteract)
                {
                    maskActive = false;
                    StartCoroutine(FadeOut());
                    playInt.local_Object_To_Interact_With = Player_Interaction.Object_To_Interact_With.BOOK;
                }
                else if (playInt.local_Object_To_Interact_With == Player_Interaction.Object_To_Interact_With.BOOK)
                {
                    if (canSkip)
                    {
                        StartCoroutine(FadeIn());
                        playInt.local_Object_To_Interact_With = Player_Interaction.Object_To_Interact_With.NONE;
                    }
                }
            }
        }

        if (playInt != null)
        {
            if (!canInteract)
            {
                playInt.can_Highlight = false;
            }
            else
            {
                playInt.can_Highlight = true;
            }
        }
    }

    IEnumerator CheckVariables()
    {
        while (true)
        {
            Debug.Log("Can Interact: " + canInteract);
            yield return new WaitForSeconds(0.1f);
        }
    }

    IEnumerator FadeIn()
    {
        if (playInt != null)
        {
            canInteract = false;
        }
        canSkip = false;
        if (!maskActive)
        {
            maskAnim.SetTrigger("Fade In");
            maskActive = true;
            yield return new WaitForSeconds(2.1f);
            if (playInt != null)
            {
                canInteract = false;
            }
            yield return new WaitForSeconds(0.4f);
        }
        anim.SetTrigger("Fade In");
        audioSource.pitch = Random.Range(0.6f, 0.8f);
        audioSource.Play();
        yield return new WaitForSeconds(2);
        canSkip = true;
        if (playInt != null)
        {
            canInteract = true;
        }
        if (isAutomatic)
        {
            StartCoroutine(WaitToTurnPage());
        }
    }

    IEnumerator FadeOut()
    {
        if (playInt != null)
        {
            canInteract = false;
        }
        canSkip = false;
        anim.SetTrigger("Fade Out");
        yield return new WaitForSeconds(2);
        if (maskActive)
        {
            if (isAutomatic || goingForward)
            {
                ShowNextPage();
            }
            else
            {
                ShowPreviousPage();
            }
        }
        else
        {
            maskAnim.SetTrigger("Fade Out");
            yield return new WaitForSeconds(2.1f);
            if (playInt != null)
            {
                canInteract = true;
            }
            canSkip = true;
        }
    }

    IEnumerator WaitToTurnPage()
    {
        yield return new WaitForSeconds(showPageTime);
        if (!hasBeenSkipped)
        {
            StartCoroutine(FadeOut());
        }
        else
        {
            hasBeenSkipped = false;
        }
    }

    void ShowNextPage()
    {
        if (currentPageNumber < chapterEndPageNumber)
        {
            currentPageNumber++;
            image.sprite = storyBookImages[currentPageNumber];
            StartCoroutine(FadeIn());
        }
        else
        {
            if (isAutomatic)
            {
                //Load Cabin Scene
                if (progMan.noOfTemplesCompleted == 0)
                {
                    progMan.activateStandingStone = true;
                }
                StartCoroutine(GetComponent<Change_Scene_Trigger>().LoadNewScene());
            }
        }
    }

    void ShowPreviousPage()
    {
        if (currentPageNumber > chapterStartPageNumber)
        {
            currentPageNumber--;
            image.sprite = storyBookImages[currentPageNumber];
            StartCoroutine(FadeIn());
        }
    }
}
