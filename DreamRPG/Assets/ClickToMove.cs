using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickToMove : MonoBehaviour {
    public float speed;
    private Vector3 position;
    public UnityEngine.AI.NavMeshAgent navAgent;
	public SpriteRenderer sprite;
	public float time = 0.5f;
	bool refreshTime;
	public Vector3 distanceFromPoint;
   // public CharacterController controller;
	// Use this for initialization
	void Start () {
    //    position = transform.position;
        navAgent = GetComponent<UnityEngine.AI.NavMeshAgent>();
		refreshTime = false;
	}
	
	// Update is called once per frame
	void Update () {
		if (refreshTime) {
			time = 0.4f;
			refreshTime = false;
		}
		time -= Time.deltaTime;
        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Input.GetMouseButtonUp(0))
        {
            if (Physics.Raycast(ray, out hit, 1000))
            {
            //    position = new Vector3(hit.point.x, hit.point.y, hit.point.z);
				navAgent.SetDestination(hit.point);
				distanceFromPoint = hit.point;
            }
        }
		if ((time <= 0.0f) && Vector3.Distance(navAgent.transform.position, distanceFromPoint) > 1.5) {
			sprite.flipX = !sprite.flipX;
			refreshTime = true;
		}

        moveToPosition();    
	}
    void moveToPosition() { 
    
   //     if(Vector3.Distance(transform.position, position) > 1){
            Quaternion newRotation = Quaternion.LookRotation(position - transform.position);
            newRotation.x = 0f;
            newRotation.z = 0f;
            newRotation.y = 0f;
            transform.rotation = Quaternion.Slerp(transform.rotation, newRotation, Time.deltaTime * 50);
         //   controller.SimpleMove(transform.forward * speed);
     //   }
    }
}
