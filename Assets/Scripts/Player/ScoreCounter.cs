using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreCounter : MonoBehaviour
{
    public static ScoreCounter instance;    
    //SCORE
    public Text counterText;
    public int scoreValue = 0;
    //WIN
    public GameObject winCanvas;
    public AudioClip winClip;
    public bool isOver;

    private void Awake()
    {
        instance = this;
        winCanvas.SetActive(false);
    }

    // Start is called before the first frame update
    void Start()
    {
       counterText.text = "Score: " + scoreValue.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        if (scoreValue == 27 && isOver==false)
        {
            winCanvas.SetActive(true);
            isOver = true;
            musicPlays();

        }
        else
        {
            counterText.text = "Score: " + scoreValue.ToString();
        }

    }
    public void PointAddition()
    {
        scoreValue += 1;
        counterText.text = "Score: " + scoreValue.ToString();
        Debug.Log("Add a point");
    }
    void musicPlays()
    {
        StartCoroutine(musicPlaying());
    }
    IEnumerator musicPlaying()
    {
        if (isOver == true)
        {
            AudioSource.PlayClipAtPoint(winClip, Vector2.zero);
            yield return new WaitForSeconds(1.0f);
        }

    }

}
