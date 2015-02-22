using UnityEngine;
using System.Collections;

public class RobotPatrol : MonoBehaviour {
	public float walkSpeed;
	private float horizontalMagnitude;
	private float verticalMagnitude;

	private Vector3 startPoint, firstPoint, secondPoint, thirdPoint, currentPoint, nextPoint;
	
	protected Animator animator;
	// Use this for initialization
	void Start () {
		animator = GetComponent<Animator>();

		startPoint = this.transform.position;
		firstPoint = this.transform.Find("firstPoint").transform.position;
		secondPoint = this.transform.Find("secondPoint").transform.position;
		thirdPoint = this.transform.Find ("thirdPoint").transform.position;

		currentPoint = startPoint;
		nextPoint = firstPoint;
	}
	
	// Update is called once per frame
	void Update () {
		//if the robot is not yet at its next point, move it
		if (!this.transform.position.Equals(nextPoint)){
			this.transform.position = Vector3.MoveTowards(transform.position, nextPoint, walkSpeed * Time.deltaTime);

			horizontalMagnitude = nextPoint.x - transform.position.x;
			verticalMagnitude = nextPoint.y - transform.position.y;
		}
		//if it is at its next point, update next and current points.
		else{
			if (nextPoint.Equals(firstPoint)){
				currentPoint = firstPoint;
				nextPoint = secondPoint;
			}
			else if (nextPoint.Equals(secondPoint)){
				currentPoint = secondPoint;
				nextPoint = thirdPoint;
			}
			else if (nextPoint.Equals(thirdPoint)){
				currentPoint = thirdPoint;
				nextPoint = startPoint;
			}
			else if (nextPoint.Equals(startPoint)){
				currentPoint = startPoint;
				nextPoint = firstPoint;
			}
		}

		//set the animation direciton
		if ((horizontalMagnitude == 0) && (verticalMagnitude == 0))
		{
			animator.SetInteger("movementState", 0);
		}
		else if ((horizontalMagnitude > 0) && (Mathf.Abs(horizontalMagnitude) > Mathf.Abs (verticalMagnitude)))
		{
			animator.SetInteger("movementState", 1); //east			
		}
		else if ((horizontalMagnitude < 0) && (Mathf.Abs(horizontalMagnitude) > Mathf.Abs (verticalMagnitude)))
		{
			animator.SetInteger("movementState", 2); //west
		}
		else if ((verticalMagnitude < 0) && (Mathf.Abs(horizontalMagnitude) < Mathf.Abs (verticalMagnitude)))
		{
			animator.SetInteger("movementState", 3); //south
		}
		else if ((verticalMagnitude > 0) && (Mathf.Abs(horizontalMagnitude) < Mathf.Abs (verticalMagnitude)))
		{
			animator.SetInteger("movementState", 4); //north
		}
	}
}
