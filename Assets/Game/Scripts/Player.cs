using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] Material mat;
    [SerializeField] private float speed;
    [SerializeField] private float jumpForce;

    private string state = "IDLE";
    private Material defaultMat;
    private Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody>();
        defaultMat = gameObject.GetComponent<MeshRenderer>().material;
        StartCoroutine(ChangeActive());
    }

    IEnumerator ChangeIdle()
    {
        yield return new WaitForSeconds(0.5f);
        state = "IDLE";
        gameObject.GetComponent<MeshRenderer>().material = defaultMat;
        StartCoroutine(ChangeActive());
    }

    IEnumerator Jump()
    {
        yield return new WaitForSeconds(0.1f);
        if (state == "IDLE")
        {
            rb.AddForce(0, jumpForce, 0);
            yield return new WaitForSeconds(0.3f);
            rb.AddForce(0, -jumpForce, 0);
        }
    }

    IEnumerator ChangeActive()
    {
        yield return new WaitForSeconds(1.5f);
        state = "ACTIVE";
        gameObject.GetComponent<MeshRenderer>().material = mat;
        StartCoroutine(ChangeIdle());
    }
    // Update is called once per frame
    void Update()
    {
        if(GameManager.instance.state == "PLAY")
        {
            if (state == "IDLE")
            {
                rb.velocity = Vector2.zero;
                StartCoroutine(Jump());
            }
            if (Input.GetMouseButton(0))
            {
                if (state == "ACTIVE")
                {
                    rb.velocity = new Vector3(0, 0, speed);
                }
            }

            if (transform.position.z > 0)
            {
                GameManager.instance.Ending(true);
            }
        }
    }

    //private void OnMouseDrag()
    //{
    //    if (state == "IDLE") return;
    //    Vector3 screenPos = new Vector3(Input.mousePosition.x, Input.mousePosition.y, Camera.main.WorldToScreenPoint(transform.position).z);
    //    Vector3 worldPos = Camera.main.ScreenToWorldPoint(screenPos);
    //    transform.position = new Vector3(worldPos.x, -7.085f, worldPos.y);
    //}


}
