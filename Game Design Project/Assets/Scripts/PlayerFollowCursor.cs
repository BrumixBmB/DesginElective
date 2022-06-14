using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFollowCursor : MonoBehaviour
{
    Vector3 mousePos;
    Camera camera;
    Rigidbody2D rid;


    // Start is called before the first frame update
    void Start()
    {
        rid = this.GetComponent<Rigidbody2D>();
        camera = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        rotateCamera();
    }

    void rotateCamera()
    {
        mousePos = camera.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, Input.mousePosition.z));
        rid.transform.eulerAngles = new Vector3(0, 0, Mathf.Atan2((mousePos.y - transform.position.y),(mousePos.x - transform.position.x)) * Mathf.Rad2Deg);
    }
}
