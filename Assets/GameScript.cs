using UnityEngine;
using System.Collections;
using Pathfinding.Serialization.JsonFx;

public class GameScript : MonoBehaviour
{
    string Info = "HIT detected";
    string description;
    private bool PopUp;
    private Texture2D myGUITexture;
    private Texture2D violinY;
    //private GameObject canvas;
    //MusicalInstrument[] musicalInstruments;
    
    public string _WebsiteURL = "http://test320123456.azurewebsites.net/tables/MusicInstrument/2c616542-fc46-4365-b9b6-d317c994375b?zumo-api-version=2.0.0";

    // Use this for initialization
    void Start()
    {
        
   

        //Reguest.GET can be called passing in your ODATA url as a string in the form:
        //http://{Your Site Name}.azurewebsites.net/tables/{Your Table Name}?zumo-api-version=2.0.0
        //The response produce is a JSON string
        string jsonResponse = Request.GET(_WebsiteURL);

        //Just in case something went wrong with the request we check the reponse and exit if there is no response.
        if (string.IsNullOrEmpty(jsonResponse))
        {
            return;
        }

        Debug.Log(jsonResponse);

        //We can now deserialize into an array of objects - in this case the class we created. The deserializer is smart enough to instantiate all the classes and populate the variables based on column name.
        MusicInstrument cenotaphs = JsonReader.Deserialize<MusicInstrument>(jsonResponse);

        //Debug.Log(cenotaphs.Length);

        //foreach (MusicInstrument musicalInstrument in cenotaphs)
        //{
        // Info = musicalInstrument.Title;
        // description = musicalInstrument.Description;

        //}
        Info = cenotaphs.Title;
        description = cenotaphs.Description;

        myGUITexture = (Texture2D)Resources.Load("black");
        violinY = (Texture2D)Resources.Load("violin");
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
        Rect rectDesc = new Rect(40, 100, (Screen.width - 70), Screen.height);
        Rect close = new Rect((rect.xMax - 110), 5, 100, 100);

        Rect youtube = new Rect(0, (Screen.height / (float)1.5), Screen.width, (Screen.height / 2));
        Rect youtubeBtn = new Rect(0, (Screen.height / (float)1.5), Screen.width, (Screen.height / 2));


        GUIStyle closeButton = new GUIStyle("button");
        closeButton.fontSize = 60;
        closeButton.alignment = TextAnchor.UpperCenter;
        closeButton.wordWrap = true;

        GUIStyle labelButton = new GUIStyle("label");
       labelButton.fontSize = 60;
        labelButton.alignment = TextAnchor.UpperCenter;
        labelButton.wordWrap = true;

        //string description = "Some further infomation and description would go here";
        GUIStyle desc = new GUIStyle("Box");
        desc.fontSize = 30;
        desc.alignment = TextAnchor.UpperLeft;
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
            GUI.Box(youtube, violinY);
            if (GUI.Button(youtubeBtn, " "))
            {
                Application.OpenURL("https://youtu.be/zgaQFLUdUL0?t=140");
            }
        }
    }


    void OnGUI()
    {
        GUI.color = Color.white;
       //GUI.DrawTexture = myGUITexture

        DrawBox();
    }

}

