using Unity.VisualScripting;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    //Enscaptulation
                       private float Xrange = 26;
   [SerializeField]    private float speed;
                       private float moveDirection = 1f;

   [SerializeField]    private GameObject bone;
   [SerializeField]    private GameObject bone2;

                       private bool isforward = true;
                       private bool isDownward = false;


    private void Update()
    {
        Control();
        OutOfBounds(); 
    }


    private void Control()
    {
        float horizontalInput = Input.GetAxis("Horizontal");

        // Move in the correct direction
        transform.Translate(Vector3.right * Time.deltaTime * speed * horizontalInput * moveDirection);

        if (Input.GetKeyDown(KeyCode.DownArrow)||Input.GetKeyDown(KeyCode.S))
        {
            // Set rotation to 180 degrees
            transform.rotation = Quaternion.Euler(0, 180, 0);
            moveDirection = -1; // Reverse movement
            isDownward= true;
            isforward = false;
        }
        else if (Input.GetKeyDown(KeyCode.UpArrow)||Input.GetKeyDown(KeyCode.W))
        {
            // Set rotation to 0 degrees
            transform.rotation = Quaternion.Euler(0, 0, 0);
            moveDirection = 1; // Reset movement
            isforward= true;
            isDownward= false;
        }


        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (isforward)
            {
                Instantiate(bone, transform.position, transform.rotation);
            }
            if (isDownward)
            {
                Instantiate(bone2 , transform.position, transform.rotation);
            }
        }
    }

    //Example of Abstraction

    /* void OutOfBounds()
     {
         if (transform.position.x >= Xrange)
         {
             Vector3 Pos = new Vector3(Xrange, transform.position.y, transform.position.z);
             transform.position = Pos;
         } if (transform.position.x <= -Xrange)
         {
             Vector3 Pos = new Vector3(-Xrange, transform.position.y, transform.position.z);
             transform.position= Pos;
         }
     }*/

    void OutOfBounds()
    {
        float clampedX = Mathf.Clamp(transform.position.x, -Xrange, Xrange);
        transform.position = new Vector3(clampedX, transform.position.y, transform.position.z);
    }

}

