using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DodgeRoll : MonoBehaviour
{
    private Movement2D move;
    bool roll = false;
    public int cooldowntime = 3;
    [SerializeField] float boost = 30f;

    // Start is called before the first frame update
    void Start()
    {
        move = GetComponent<Movement2D>();
        //using move will now allow us to call objects and other data from Movement2D
    }

    // Update is called once per frame
    void Update()
    {
        //detects if the right mouse button has been pressed down
        if (Input.GetKeyDown(KeyCode.Mouse1))
        {
            Debug.Log("rightclick");
            //checks if roll is currently false
            if (!roll)
            {
                Debug.Log("we can roll");
                roll = true;
                Dodge();

                //if roll if false then set to true and activate dodge method
            }
        }
    }
    
    /// <summary>
    /// this method sends boost float to move the player faster
    /// </summary>
    void Dodge()
    {
        //Dodger is a method that accepts a float
        move.Dodger(boost);
        StartCoroutine(Cooldown());  //Coroutine, a special method that can pause and resume execution
        //doesn't block the main thread - they let toher code keep running
 
    }

    ///<summary>
    ///this method is reset moveSpeed and set roll to false after timers
    ///stop : this returns the player back to normal speed and allows them to dodge again
    ///<summary>
   
    IEnumerator Cooldown()
    {
        yield return new WaitForSeconds(.25f);
        //waits for .25 sec before continuing, this gives just enough time for the boost to occur
        //but short enough to reset player speed before it can be abused

        float sD = boost - (boost * 2);
        // allows us to subtract our added boost without actually altering the boost float
        move.Dodger(sD);
        Debug.Log("Coroutine started");

        yield return new WaitForSeconds(cooldowntime);
        //waits for x seconds before reseting roll to false allowing to dodge again. x == to cooldowntime integer
        roll = false;
    }
}
