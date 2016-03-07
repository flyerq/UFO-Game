using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour {

    private Rigidbody2D rb2d;
    private int count;
    public float speed;
    public Text countText;
    public Text winText;

    void Start() {
        rb2d = GetComponent<Rigidbody2D> ();
        count = 0;
        SetCountText();
        winText.text = "";
    }

	void FixedUpdate () {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");
        Vector2 movement = new Vector2(moveHorizontal, moveVertical);

        rb2d.AddForce(movement * speed);
	}

    void OnTriggerEnter2D(Collider2D other) {
        if ( other.gameObject.CompareTag("PickUp") ) {
            other.gameObject.SetActive(false);
            ++count;
            SetCountText();
        }

        if (count >= 12) {
            winText.text = "恭喜通关！";
        }
    }

    void SetCountText() {
        countText.text = "分数：" + count.ToString();
    }
}
