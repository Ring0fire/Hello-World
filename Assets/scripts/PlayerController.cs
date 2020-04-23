using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
	//allows me to adjust speed and jump height in inspector
	public float moveSpeed;
	public float jumpPwr;
	
	public float jumpTime;
	private float jumpTimeCounter;
	

	
	//this lets me make sure we can't jump unless we're touching the platform
	private bool jumpDismount;
	
	private Rigidbody2D myRigidbody;	
	//ground check, compares a collision box with a "ground" box
	public bool grounded;
	public LayerMask whatIsGround;
	public Transform groundCheck;
	public float groundCheckRadius;
	
	private Animator myAnimator;
	public GameManager theGameManager;
 
    // Start is called before the first frame update
    void Start()
    {//lets me access the Rigidbody2D attatched to whatever game object this script is also attatched
        myRigidbody = GetComponent<Rigidbody2D > ();
	//we will name that Rigidbody2D "myRigidbody"
	
	//allows us to access the Animator attatched to the Player in the same way we got our Rigidbody
		myAnimator = GetComponent<Animator>();
	
	//when we set up the jumpTimeCounter, it will act like a time limit that will decide how high 
	//and long we can jump, and we want to start with a full time limit, so we set it to our jumpTime
		jumpTimeCounter = jumpTime;
	//when we start we want to be on the ground
		jumpDismount = true;
    }

    // Update is called once per frame
    void Update(){
/*  'grounded' and groundCheck notes
this is to detect the ground with elements that are easy to change in the inspector under the 
'Player' game object. we want to create a way to detect collision by connecting a collider to the
bottom of our Player
		
Call Physics to access colliders. create a circle that can create collision 
OverlapCircle needs to know (where see 1,size see 2,what to affect see 3)
1) look for a ground check which is public so it can be set in the inspector
2) size of circle which is public
3) affects a layer that can be changed in the inspector by creating a space that we called
  "whatIsGround" which I'll place the layer "ground" so when we check for whatIsGround we'll see 
  the ground layer
	*/
	grounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, whatIsGround);

/*  Forward movement notes
this moves our Player, but doesn't allow any input. this is automatic

Call on myRigidbody, which we set to contain a Rigidbody2D. through here we access velocity, which we 
will find and change to a new speed using Vector2. We add before jumping so we know how to move forward before
we try jumping. with how this is set up, if we update whether or not we're jumping before we check if we're 
moving forward, then the rules that we only want to apply to our jump will be updated before we run, which
will mean that we can't move unless we're jumping.


Vector2 needs to know (movement on X axis see 1, movement on the Y axis see 2) 
1) our moveSpeed is public to be adjusted in the inspector, what ever number we put in there will move 
  our Player along the x axis. positive values will move right, negative values move left
2) we'll look at how fast myRigidbody which is the name of the Rigidbody2D we attatched to our Player,
  and we'll just set it to itself in this line so it only handles forward movement and won't affect our jump */
  
	myRigidbody.velocity = new Vector2 (moveSpeed,myRigidbody.velocity.y);	
	
//using GetKeyDown for this statement. it will only return true once a button is pressed, and only once per frame
    if(Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0) )
	{
//if our Player's collider is touching something on the 'ground' layer	
		if(grounded)
/* Jump execution notes
  like how we move our Player forward, this will move our Player upward. instead of being automatic, we check
  for specific input that Unity understands by default. so when it detects that input, it executes the following.
  we want to move our Player before we check for input, because if we check for input first, then the conditions
  that apply to jumping will also apply to running. this depends on whether or not we are 'grounded'
  
  Call on myRigidbody to get velocity. Then we set that velocity to a new velocity named Vector2, but this time we
  want to change on the y axis instead of the x, so we focus on the second argument
  Vector2 needs to know (movement on X axis see 1, movement on the Y axis see 2)
  1) we check out myRigidbody for the Rigidbody2D we have connected to our Player. we want to set this to itself
	 because we handled our x movement already so we don't want to get in the way of that
  2) our jumpPwr is public so whatever number we put in the inspector will be read here. a positive value will
	 move us up, negative moves down. 
	 
	 if we are grounded, then we will adjust our position by our 'jumpPwr' along the y axis, and set our jumpDismount to false. 
	 */		
		{
			myRigidbody.velocity = new Vector2 (myRigidbody.velocity.x, jumpPwr);
			jumpDismount = false;	
		}	
	}

	/* using GetKey notes
	we'll use GetKey here because it will continually update as long as the key or button is pressed.
	here we are checking to see if we're holding the jump button AND NOT dismounting from a jump. 
*/
	if((Input.GetKey (KeyCode.Space) || Input.GetMouseButton(0)) && !jumpDismount)
	{	
	//if we have any jumpTime left, we do this
		if (jumpTimeCounter > 0)
		{//do the same thing we did to jump, so just add to it when we can. we can edit 
		 //the floatiness of our Player by adjusting the y argument in our new Vector2 (x,y)
			myRigidbody.velocity = new Vector2 (myRigidbody.velocity.x, jumpPwr);
		 //as long as we have jumpTime, subtract some every frame. this will stop running once we have no more jumpTime	
			jumpTimeCounter -= Time.deltaTime;
		}
	}
	if(Input.GetKeyUp (KeyCode.Space) || Input.GetMouseButtonUp(0))
	{
/*  using GetKeyUp notes
	we'll use GetKeyUp for this statement, which will read when a button is released, so when we release the 
	jump button, we set our counter to 0. once the jump is released, the Player won't be able to control their
	jump until they touch the ground again.
	
	we'll set our jumpDismount to true so we can no longer move upward when the jump button is pressed. 
	*/
		jumpTimeCounter = 0;
		jumpDismount = true;
	}
//this is to reset our
	if(grounded)
	{
		jumpTimeCounter = jumpTime;
	}
	myAnimator.SetFloat ("Speed", myRigidbody.velocity.x);
	myAnimator.SetBool("Grounded", grounded);
	}
	 void OnCollisionEnter2D (Collision2D other)
 {
  if (other.gameObject.tag == "killbox") 
  {
	
	theGameManager.RestartGame(); 
	//movespeed = movespeedStore;
	//speedMilestoneCount = speedMilestoneCountStore;
	//speedIncreaseMilestone = speedIncreaseMilestoneStore;
	//deathSound.Play();
 
		} 
	}
	/*if(other.gameObject.tag == "spring")
	{
		
	}
	if (other.gameObject.tag == "mineshaft")
	{
		
	}*/	
}