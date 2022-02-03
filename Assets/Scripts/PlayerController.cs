using UnityEngine;
using System.Collections;
using UnityEngine.UI;




public class PlayerController : MonoBehaviour
{
    private Rigidbody rb;
    private int count;

    public float Speed;
    public Text countText;
    public Text winText;


    void Start ()
    {
        rb = GetComponent<Rigidbody>();
        count = 0;
        SetCountText();
        winText.text = "";
    }



    void FixedUpdate ()
    {
        float MoveHorizontal = Input.GetAxis("Horizontal");
        float MoveVertical = Input.GetAxis("Vertical");
        Vector3 Movement = new Vector3(MoveHorizontal, 0.0f, MoveVertical);
        rb.AddForce(Movement * Speed);
    }


    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Pick Up"))
        {
            other.gameObject.SetActive(false);
            count++;
            SetCountText();
        }
    }



    void SetCountText()
    {
        countText.text = "Count:" + count.ToString ();
        if (count >= 12)
        {
            winText.text = "Win !! :D";
        }
    }
}
