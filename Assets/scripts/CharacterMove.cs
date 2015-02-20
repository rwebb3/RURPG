using UnityEngine;
using System.Collections;

public class CharacterMove : MonoBehaviour{
	// Normal Movements Variables
	public float walkSpeed;
	private float horizontalMagnitude;
	private float verticalMagnitude;
	
	private float curSpeed;
	private float maxSpeed;
	
	private Vector3 target;
	
	protected Animator animator;
	
	void Start()
	{
		animator = GetComponent<Animator>();
		target = transform.position;
	}
	void FixedUpdate()
	{
		curSpeed = walkSpeed;
		maxSpeed = curSpeed;

		if(Input.GetMouseButton(0)) {
			target = Camera.main.ScreenToWorldPoint(Input.mousePosition);
			target.z = transform.position.z;
			transform.position = Vector3.MoveTowards(transform.position, target, walkSpeed * Time.deltaTime);

			horizontalMagnitude = target.x - transform.position.x;
			verticalMagnitude = target.y - transform.position.y;

			float clickDistance = Vector3.Distance(transform.position, target);
			//Debug.Log (clickDistance);
			if (clickDistance < 70f){
				walkSpeed = 50;
			}
			else{
				walkSpeed = 100;
			}
			//walkSpeed = 
		}
		else{
			horizontalMagnitude = 0f;
			verticalMagnitude = 0f;
		}

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
		

		//rigidbody2D.velocity = new Vector2(Mathf.Lerp(0, horizontalMagnitude, 0.8f),
		                                   //Mathf.Lerp(0, verticalMagnitude, 0.8f));
	}
}
