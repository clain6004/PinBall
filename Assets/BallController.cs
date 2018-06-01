using UnityEngine;
using System.Collections;
using UnityEngine.UI;


public class BallController : MonoBehaviour {

    private float visiblePosZ = -6.5f;

    private GameObject gameoverText;

    public float smallstar;

    public float largestar;

    public float smallcloud;

    public float largecloud;

    public float score;

    private GameObject scoretext;

	// Use this for initialization
	void Start () {

        this.gameoverText = GameObject.Find("GameOverText");

        this.scoretext = GameObject.Find("scoretext");

	}
	
	// Update is called once per frame
	void Update () {

        this.scoretext.GetComponent<Text>().text =score.ToString();


        if (this.transform.position.z < this.visiblePosZ)
        {

            this.gameoverText.GetComponent<Text>().text = "Game Over";

        }

	}

    private void OnCollisionEnter(Collision other)
    {

        if (other.gameObject.tag == "SmallStarTag")
        {

            score += smallstar;
          
        }
        else if (other.gameObject.tag == "LargeStarTag")
        {

            score += largestar;

        }
        else if (other.gameObject.tag == "SmallCloudTag")
        {

            score += smallcloud;
        }
        else if (other.gameObject.tag == "LargeCloudTag")
        {

            score += largecloud;

        }

    }

    }



