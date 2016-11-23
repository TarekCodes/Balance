using UnityEngine;
using System.Collections;

public class projectileController : MonoBehaviour {

    public float maxStretch = 3.0f;
    public LineRenderer catapultLineFront;
    public LineRenderer catapultLineBack;
    private SpringJoint2D spring;
    private Ray rayToMouse;
    private Ray leftCatapultToProjectile;
    private Transform catapult;
    private Vector2 prevVelocity;
    Rigidbody2D rigid;
    bool clickedOn;


    void Awake()
    {
        spring = GetComponent<SpringJoint2D>();
        rigid = GetComponent<Rigidbody2D>();
        catapult = spring.connectedBody.transform;
    }

	// Use this for initialization
	void Start () {
        LineRendererSetup();
        rayToMouse = new Ray(catapult.position, Vector3.zero);
        leftCatapultToProjectile = new Ray(catapultLineFront.transform.position, Vector3.zero);
	}
	
	// Update is called once per frame
	void Update () {
        if (clickedOn)
            Dragging();
        if (spring != null)
        {
            if(!rigid.isKinematic && prevVelocity.sqrMagnitude > rigid.velocity.sqrMagnitude)
            {
                Destroy(spring);
                rigid.velocity = prevVelocity;
            }
            if (!clickedOn)
                prevVelocity = rigid.velocity;
            LineRendererUpdate();
        }
        else
        {
            catapultLineFront.enabled = false;
            catapultLineBack.enabled = false;
        }
	}

    void LineRendererSetup()
    {
        catapultLineFront.SetPosition(0, catapultLineFront.transform.position);
        catapultLineBack.SetPosition(0, catapultLineBack.transform.position);

        catapultLineFront.sortingLayerName = "foreground";
        catapultLineBack.sortingLayerName = "foreground";

        catapultLineFront.sortingOrder = 3;
        catapultLineBack.sortingOrder = 1;
    }

    void OnMouseDown()
    {
        spring.enabled = false;
        clickedOn = true;
    }

    void OnMouseUp()
    {
        spring.enabled = true;
        rigid.isKinematic = false;
        clickedOn = false;
    }

    void Dragging()
    {
        Vector3 mouseWorldPoint = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 catapultToMouse = mouseWorldPoint - catapult.position;
        if (catapultToMouse.sqrMagnitude > maxStretch * maxStretch)
        {
            rayToMouse.direction = catapultToMouse;
            mouseWorldPoint = rayToMouse.GetPoint(maxStretch);
        }
        mouseWorldPoint.z = 0f;
        //print(mouseWorldPoint);
        transform.position = mouseWorldPoint;
    }
    void LineRendererUpdate()
    {
        Vector2 catapultToProjectile = transform.position - catapultLineFront.transform.position;
        leftCatapultToProjectile.direction = catapultToProjectile;
        Vector3 holdPoint = leftCatapultToProjectile.GetPoint(catapultToProjectile.magnitude + GetComponent<CircleCollider2D>().radius);
        catapultLineBack.SetPosition(1, holdPoint);
        catapultLineFront.SetPosition(1, holdPoint);
    }
}
