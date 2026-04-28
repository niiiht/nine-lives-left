using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class bridge_game : MonoBehaviour
{
    public RectTransform pasek;
    public RectTransform greenZone;

    // public Image myImage;
    // public Sprite[] jumpSprites ;

    public GameObject[] states;
  
    public GameObject yellow_pasek;
    private int current = 0;

    private Animator pasekAnimator;

    private bool isPaused = false;
    private Image jumpBar;
    private GameObject greenBar1;
    private Sprite barChange1;
    private Sprite barChange2;
    private GameObject secondBar;




    void Start()
    {
        pasekAnimator = yellow_pasek.GetComponent<Animator>();
        jumpBar = GameObject.Find("jump_bar").GetComponent<Image>();
        greenBar1 = GameObject.Find("pasek_zielony1");
        barChange1 = Resources.Load<Sprite>("pasek2");
       

    }

    void Update()
    {
        if (isPaused) return;

        if (Input.GetMouseButtonDown(0))
        {
            if (IsInGreen())
            {
                Debug.Log("SUCCESS");
                // for(int i = 0 ; i< jumpSprites.Length; i++)
                // {
                //     myImage.sprite = jumpSprites[i];
                    
                // }
                // //   myImage.sprite = newSprite;
                // StartCoroutine(PauseAndContinue());
                 NextState();
            }
            else
            {
                Debug.Log("FAIL");
            }
        }
    }

    bool IsInGreen()
    {
        Vector3[] corners = new Vector3[4];
        greenZone.GetWorldCorners(corners);

        float left = corners[0].x;
        float right = corners[3].x;

        float yellowX = pasek.position.x;

        return yellowX >= left && yellowX <= right;
    }

    // IEnumerator PauseAndContinue()
    // {
    //     isPaused = true;

    //     // stop animation
    //     pasekAnimator.speed = 0;

    //     // wait 2 seconds (real time)
    //     yield return new WaitForSeconds(0.1f);

    //     NextState();

    //     // resume animation
    //     pasekAnimator.speed = 1;

    //     isPaused = false;
    // }

    void NextState()
    {
        if (current < states.Length - 1)
        {
            current++;
            if(current == 1)
            {
                  jumpBar.sprite = barChange1;
                  greenBar1.SetActive(false);
                  

               
            
            }else if(current == 2){
                
                
            }
          
            ShowState(current);
        }
    }

    void ShowState(int index)
    {
        for (int i = 0; i < states.Length; i++)
        {
    
            states[i].SetActive(i == index);
        }
    }
}