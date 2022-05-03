using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

public class CircleRotateManager : MonoBehaviour
{
    private GameManager gameManager;
    private string whichResult;
    private void Awake()
    {
        gameManager = Object.FindObjectOfType<GameManager>();
    }
    //Top her temas ettiðinde çember hareket edicek güzel bir animasyon!
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "bullet")
        {
            this.gameObject.transform.DORotate(transform.eulerAngles + Quaternion.AngleAxis(45, Vector3.forward).eulerAngles, 0.5f);

            if (collision.gameObject != null)
            {
                Destroy(collision.gameObject);
            }

            if (gameObject.name == "solDaire")
            {
                whichResult = GameObject.Find("solText").GetComponent<Text>().text;
            }
            else if (gameObject.name == "ortaDaire")
            {
                whichResult = GameObject.Find("ortaText").GetComponent<Text>().text;
            }
            else if (gameObject.name == "sagDaire")
            {
                whichResult = GameObject.Find("sagText").GetComponent<Text>().text;
            }
            gameManager.ResultChecked(int.Parse(whichResult));
        }

    }
}
