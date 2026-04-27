using UnityEngine;

public class bridge_game : MonoBehaviour
{
    public GameObject[] states;
    private int current = 0;

    public GameObject pasek; // assign in Inspector
    private Animator pasekAnimator;

    void Start()
    {
        ShowState(0);

        // get animator once
        pasekAnimator = pasek.GetComponent<Animator>();
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Debug.Log("click");

            if (pasekAnimator != null)
            {
                pasekAnimator.speed = 0;
            }

            NextState(); // move to next rock
        }
    }

    void NextState()
    {
        if (current < states.Length - 1)
        {
            current++;
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