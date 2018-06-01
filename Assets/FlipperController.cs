using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class FlipperController : MonoBehaviour {

    private HingeJoint myHingeJoint;

    private float defaultAngle = 20;

    private float flickAngle = -20;

    public Vector2 startpos;

    public Vector2 direction;

    public float touchpos;

    private int leftFingerId;

    private int rightFingerId;

    // Use this for initialization
    void Start () {

        this.myHingeJoint = GetComponent<HingeJoint>();

        SetAngle(this.defaultAngle);

    }

    // Update is called once per frame
    void Update()
    {

        for (int i = 0; i < Input.touchCount; i++)
        {

            Touch t = Input.GetTouch(i);

            switch (t.phase)
            {

                case TouchPhase.Began:

                    if (t.position.x < Screen.width * 0.5f && tag == "LeftFripperTag")
                    {
                        SetAngle(this.flickAngle);
                        leftFingerId = t.fingerId;
                    }
                    else if (t.position.x > Screen.width * 0.5f && tag == "RightFripperTag")
                    {
                        SetAngle(this.flickAngle);
                        rightFingerId = t.fingerId;
                    }

                    break;

                case TouchPhase.Ended:
                    if (t.fingerId == leftFingerId && tag == "LeftFripperTag")
                    {
                        SetAngle(this.defaultAngle);
                    }
                    else if (t.fingerId == rightFingerId && tag == "RightFripperTag")
                    {
                        SetAngle(this.defaultAngle);
                    }

                    break;
            }
        }

        if (Input.GetKeyDown(KeyCode.LeftArrow) && tag == "LeftFripperTag")
        {

            SetAngle(this.flickAngle);

        }

        if (Input.GetKeyDown(KeyCode.RightArrow) && tag == "RightFripperTag")
        {

            SetAngle(this.flickAngle);

        }

        if (Input.GetKeyUp(KeyCode.LeftArrow) && tag == "LeftFripperTag")
        {

            SetAngle(this.defaultAngle);

        }

        if (Input.GetKeyUp(KeyCode.RightArrow) && tag == "RightFripperTag")
        {

            SetAngle(this.defaultAngle);

        }

    }
        public void SetAngle(float angle)
        {

        JointSpring jointSpr = this.myHingeJoint.spring;

        jointSpr.targetPosition = angle;

        this.myHingeJoint.spring = jointSpr;

        }


	
}
