using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class PlayerBall : MonoBehaviour
{
    public float jumpPower;
    public int itemCount;
    public GameManager manager;
    bool isJump;
    AudioSource audio;
    Rigidbody rigid;

    void Awake()
    {
        isJump = false;
        audio = GetComponent<AudioSource>();
        rigid = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        if (Input.GetButtonDown("Jump") && !isJump)
        {
            isJump = true;
            rigid.AddForce(new Vector3(0, jumpPower, 0), ForceMode.Impulse);
        }
    }
    void FixedUpdate()
    {
        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");
        Vector3 vec = new Vector3(h, 0, v);
        rigid.AddForce(vec, ForceMode.Impulse);
    }

    void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "floor")
        {
            isJump = false;
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Item")
        {
            itemCount++;
            manager.getItem(itemCount);
            audio.Play();
            other.gameObject.SetActive(false);
        }
        else if (other.tag == "finish")
        {
            if (manager.totalItemCount == itemCount)
            {
                // Game Clear!
                if (manager.stage == 5)
                    SceneManager.LoadScene("Example1_0");
                else
                    SceneManager.LoadScene("Example1_" + (manager.stage + 1).ToString());
            }
            else
            {
                // Game Restart...
                SceneManager.LoadScene("Example1_" + manager.stage.ToString());
            }
            itemCount++;
            other.gameObject.SetActive(false);
        }
    }

}
