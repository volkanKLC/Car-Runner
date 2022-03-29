using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public Transform zAxis, xAxis;
    public float speed;
    public float controlSpeed;
    public float clampMin, clampMax;
    
    
    private float _mousePos;


    void Start()
    {

    }

    void FixedUpdate()
    {
        if (UI.Instance.isStart)
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

        if (other.gameObject.CompareTag("benzin"))
        {
            UI.Instance.SetScore(10);
            Destroy(other.gameObject);
            speed++;
        }

        
        if (other.gameObject.CompareTag("hole"))
        {

            UI.Instance.SetScore(-10);
           // UI.Instance.gameOverPanel.SetActive(true);
            Time.timeScale = 0;

            speed--;
        }
        if (other.gameObject.CompareTag("Untagged"))
        {
            UI.Instance.gameOverPanel.SetActive(true);
            Time.timeScale = 0;
        }
    }
}
