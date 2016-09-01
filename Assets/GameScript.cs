using UnityEngine;
using System.Collections;

public class GameScript : MonoBehaviour
{
    string Info = "HIT detected";
    private bool PopUp;
    private Texture2D myGUITexture;


    // Use this for initialization
    void Start()
    {
        
    myGUITexture = (Texture2D)Resources.Load("black");
        Debug.Log(myGUITexture.ToString());
        

    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetMouseButtonDown(0))
        { // if left button pressed...
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            //Ray touchRay = Camera.main.ScreenPointToRay(Input.GetTouch(0).position);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                if (hit.collider.tag == "clickableCube")
                {
                    GameObject obj = GameObject.FindGameObjectWithTag("clickableCube");
                    //obj.GetComponent<Animation>().Play("cube");
                    Debug.Log("HIT!!");
                    PopUp = true;
                }
            }
        }

    }
    void DrawBox()
    {
        //Rect rect = new Rect(20, 20, 300, 200);
        Rect rect = new Rect(0, 0, Screen.width, Screen.height);
        Rect rectTitle = new Rect(0, 20, Screen.width, Screen.height);
        Rect rectDesc = new Rect(0, 0, Screen.width, Screen.height);
        Rect close = new Rect((rect.xMax - 110), 5, 100, 100);
        GUIStyle closeButton = new GUIStyle("button");
        closeButton.fontSize = 60;
        closeButton.alignment = TextAnchor.UpperCenter;
        closeButton.wordWrap = true;

        GUIStyle labelButton = new GUIStyle("label");
       labelButton.fontSize = 60;
        labelButton.alignment = TextAnchor.UpperCenter;
        labelButton.wordWrap = true;

        string description = "Some further infomation and description would go here";
        GUIStyle desc = new GUIStyle("Box");
        desc.fontSize = 50;
        desc.alignment = TextAnchor.MiddleCenter;
        desc.wordWrap = true;

        if (PopUp)
        {
            GUI.Box(rect, myGUITexture, closeButton);
            if (GUI.Button(close,"X", closeButton))
            {
                PopUp = false;
            }
            GUI.Label(rectTitle, Info, labelButton);
            GUI.Box(rectDesc, description, desc);
        }
    }


    void OnGUI()
    {
        GUI.color = Color.white;
       //GUI.DrawTexture = myGUITexture

        DrawBox();
    }

}

