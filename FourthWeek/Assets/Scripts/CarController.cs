using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarController : MonoBehaviour
{
    public float speed = 1.0f;
    public float donmeHizi = 50.0f;
    void Start()
    {
        speed = 3f;
        donmeHizi = 50.0f;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 playerInput = new Vector3(Input.GetAxis("Horizontal"), 0.0f, Input.GetAxis("Vertical"));
        Vector3 hizEklentisi = playerInput * Time.deltaTime * speed;
        transform.Translate(hizEklentisi);
        float donmeMiktari = playerInput.x * donmeHizi * Time.deltaTime;
        transform.Rotate(Vector3.up, donmeMiktari);

        RaycastHit hit;
        if (Input.GetMouseButtonDown(0))
        {
            if (Physics.Raycast(Camera.main.transform.position, transform.forward, out hit, Mathf.Infinity))
            {
                if (hit.collider.gameObject.tag == "dusman")
                {
                    Destroy(hit.collider.gameObject);
                }
            }
        }

    }

}

