using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class GameManager : MonoBehaviour
{
    public int totalItemCount;
    public int stage;
    public Text stageCount;
    public Text playerCount;
    public Text stageText;


    private void Awake()
    {
        stageCount.text = "/ " + totalItemCount;
        stageText.text = "Stage "+ stage;
    }

    public void getItem(int count)
    {
        playerCount.text = count.ToString();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            SceneManager.LoadScene(stage);
        }
    }
}
