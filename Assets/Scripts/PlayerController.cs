using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("PLAYER VARIABLES")]
    public Transform zAxis, xAxis;
    public float speed;
    public float controlSpeed;
    public float clampMin, clampMax;


    private float _mousePos;

    UiManager UiMan;
    private void Start()
    {
        UiMan = UiManager.Instance;
    }
    void FixedUpdate()
    {
        if (UiMan.isStart)
        {
            zAxis.position += Vector3.forward * speed * Time.fixedDeltaTime;

            if (Input.GetMouseButton(0))
            {
                _mousePos += Input.GetAxis("Mouse X") * controlSpeed * Time.fixedDeltaTime;
            }

            xAxis.position = new Vector3(_mousePos, xAxis.position.y, xAxis.position.z);
        }

        float clampX = Mathf.Clamp(xAxis.position.x, clampMin, clampMax);

        xAxis.position = new Vector3(clampX, xAxis.position.y, xAxis.position.z);
    }

    private void OnTriggerEnter(Collider other)
    {

        if (other.CompareTag("Fuel"))
        {
            UiMan.SetScore(10);
            Destroy(other.gameObject);
            speed++;
        }

        if (other.CompareTag("hole"))
        {
            UiMan.SetScore(-10);
            speed--;

            if (UiMan.Score <= 0)
            {
                UiMan.Score = 0;
                UiMan.scoreTxt.text = "SCORE: " + UiMan.Score;
                UiMan.gameOverPanel.SetActive(true);
                Time.timeScale = 0;
            }
        }
        if (other.CompareTag("Untagged"))
        {
            UiMan.gameOverPanel.SetActive(true);
            Time.timeScale = 0;
        }
    }
}
