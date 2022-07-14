// Track 2 Outscal LP Clan 5 - Ram (jinja)

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    public Rigidbody2D rb;
    public float speed;
    public GameObject gameWonPanel;
    public GameObject gameLostPanel;
    private bool _takeRest = false;
    private bool _isGameOver = false;


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)) // Disable movement when Space key is pressed till pressed again..
        {
            _takeRest = (_takeRest != true);
        }
    }

    // This function is called every fixed framerate frame, if the MonoBehaviour is enabled.
    protected void FixedUpdate()
    {
        if (!_isGameOver)
            if (_takeRest == false)
            {
                if (Input.GetAxis("Horizontal") > 0)
                {
                    rb.AddForce(transform.right * (speed * rb.mass)); // Accelerate with time
                }

                else if (Input.GetAxis("Horizontal") < 0)
                {
                    rb.AddForce(-transform.right * (speed * rb.mass));
                }

                else if (Input.GetAxis("Vertical") > 0)
                {
                    rb.AddForce(transform.up * (speed * rb.mass));
                }

                else if (Input.GetAxis("Vertical") < 0)
                {
                    rb.AddForce(-transform.up * (speed * rb.mass));
                }

                else if (Input.GetAxis("Horizontal") == 0 && Input.GetAxis("Vertical") == 0)
                {
                    rb.velocity = Vector2.zero;
                }
            }
    }

    protected void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Door"))
        {
            Debug.Log("Level Complete!");
            gameWonPanel.SetActive(true);
            _isGameOver = true;
        }
        
        else if (other.CompareTag("Enemy"))
        {
            Debug.Log("Level Not Complete!");
            gameLostPanel.SetActive(true);
            _isGameOver = true;
        }
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}