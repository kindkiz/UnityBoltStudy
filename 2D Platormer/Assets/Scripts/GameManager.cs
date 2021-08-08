using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class GameManager : MonoBehaviour
{
    public int totalPoint;
    public int stagePoint;
    public int stageIndex;
    public int health;
    public PlayerMove player;
    public GameObject[] stages;

    public Image[] UIhealth;
    public Text UIPoint;
    public Text UIStage;
    public GameObject RestartButton;

    void Update()
    {
        UIPoint.text = (totalPoint + stagePoint).ToString();
    }
    public void NextStage()
    {
        //Change Stage
        if (stageIndex < stages.Length-1)
        {
            stages[stageIndex].SetActive(false);
            stageIndex++;
            stages[stageIndex].SetActive(true);
            PlayerReposition();

            UIStage.text = "STAGE " + (stageIndex + 1);
        }
        else
        {
            // Game Clear
            Time.timeScale = 0;
            // Result UI
            Debug.Log("Game Clear");
            // Button UI
            Text btnText = RestartButton.GetComponentInChildren<Text>();
            btnText.text = "Clear!";
            RestartButton.SetActive(true);
        }
        //Calculate point
        totalPoint += stagePoint;
        stagePoint = 0;
    }
    public void HealthDown()
    {
        if (health > 1) { 
            health--;
            UIhealth[health].color = new Color(1, 0, 0, 0.4f);
        }
        else
        {
            //All Health UI Off
            UIhealth[health-1].color = new Color(1, 0, 0, 0.4f);

            // player Die Effect
            player.OnDie();
            // Retry Button UI
            RestartButton.SetActive(true);
        }
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            
            // Player Roposition
            if (health > 1)
                PlayerReposition();
            
            // Health Down
            HealthDown();
        }
    }

    void PlayerReposition()
    {
        player.transform.position = new Vector3(-1.5f, 1f, -1f);
        player.VelocityZero();
    }

    public void Restart()
    {
        Text btnText = RestartButton.GetComponentInChildren<Text>();
        btnText.text = "Retry?";
        RestartButton.SetActive(false);
        SceneManager.LoadScene(0);
        Time.timeScale = 1;
    }
}
