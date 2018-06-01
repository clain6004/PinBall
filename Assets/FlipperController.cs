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

	// Use this for initialization
	void Start () {

        this.myHingeJoint = GetComponent<HingeJoint>();

        SetAngle(this.defaultAngle);

    }

    // Update is called once per frame
    void Update()
    {

        if (Input.touchCount > 0) {

            Touch t = Input.GetTouch(0);

            touchpos = Input.GetTouch(0).position.x;

            switch (t.phase)
            {

                case TouchPhase.Began:
                   if(touchpos<Screen.width*0.5f)
                    {
                        if (Input.GetKeyDown(KeyCode.LeftArrow) && tag == "LeftFripperTag")
                        {
                            SetAngle(this.flickAngle);
                        }
                    }
                    else
                    {
                        if (Input.GetKeyDown(KeyCode.RightArrow) && tag == "RightFripperTag")
                        {

                            SetAngle(this.flickAngle);

                        }

                    }
                    break;

                case TouchPhase.Ended:

                    SetAngle(this.defaultAngle);

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
