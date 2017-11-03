using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickToMove : MonoBehaviour {
    public float speed;
    private Vector3 position;
    public UnityEngine.AI.NavMeshAgent navAgent;
	public SpriteRenderer sprite;
	float time;
	bool refreshTime;
   // public CharacterController controller;
	// Use this for initialization
	void Start () {
    //    position = transform.position;
        navAgent = GetComponent<UnityEngine.AI.NavMeshAgent>();
		time = Time.deltaTime;
		refreshTime = false;
	}
	
	// Update is called once per frame
	void Update () {
		if (refreshTime) {
			time = Time.deltaTime;
			refreshTime = false;
		}
        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Input.GetMouseButtonUp(0))
        {
            if (Physics.Raycast(ray, out hit, 1000))
            {
            //    position = new Vector3(hit.point.x, hit.point.y, hit.point.z);
                navAgent.SetDestination(hit.point);
				if (time * 1000 <= 1) {
					sprite.flipX = true;

				} else if(time*1000 >= 2) {
					sprite.flipX = false;
					refreshTime = true;
				}
            }
        }
        moveToPosition();    
	}
    void moveToPosition() { 
    
   //     if(Vector3.Distance(transform.position, position) > 1){
            Quaternion newRotation = Quaternion.LookRotation(position - transform.position);
            Debug.Log("rotation x: " + newRotation.x);
            Debug.Log("rotation Y: " + newRotation.y);
            Debug.Log("rotation z: " + newRotation.z);
            newRotation.x = 0f;
            newRotation.z = 0f;
            newRotation.y = 0f;
            transform.rotation = Quaternion.Slerp(transform.rotation, newRotation, Time.deltaTime * 10);
         //   controller.SimpleMove(transform.forward * speed);
     //   }
    }
}
