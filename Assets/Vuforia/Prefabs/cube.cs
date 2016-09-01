using UnityEngine;
using System.Collections;

public class cube : MonoBehaviour {

	// Use this for initialization
	void Start () {
        

    }
	
	// Update is called once per frame
	void Update () {
        //this.transform.Rotate(0.5f, 0.5f, 0.5f);
        this.transform.RotateAround(Vector3.zero, Vector3.up, 70 * Time.deltaTime);

    }
}
