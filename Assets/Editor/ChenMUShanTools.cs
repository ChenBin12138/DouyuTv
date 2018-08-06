using UnityEditor;
using UnityEngine;
using System.IO;
using UnityEngine.UI;


public class ChenMUShanTools :EditorWindow {

    [MenuItem("陈木杉/初始化项目目录")]
    public static void CreatNewProectDir() {
        Debug.Log("Creat Dir !");

        string datapath = Application.dataPath + "/";

        if (!Directory.Exists(datapath + "Scripts"))
            Directory.CreateDirectory(datapath + "Scripts");

        if (!Directory.Exists(datapath + "Sprites"))
            Directory.CreateDirectory(datapath + "Sprites");

        if (!Directory.Exists(datapath + "Materials"))
            Directory.CreateDirectory(datapath + "Materials");

        if (!Directory.Exists(datapath + "Texutres"))
            Directory.CreateDirectory(datapath + "Texutres");

        if (!Directory.Exists(datapath + "Scenes"))
            Directory.CreateDirectory(datapath + "Scenes");

        if (!Directory.Exists(datapath + "Parfabs"))
            Directory.CreateDirectory(datapath + "Parfabs");

        if (!Directory.Exists(datapath + "Tts"))
            Directory.CreateDirectory(datapath + "Tts");

        if (!Directory.Exists(datapath + "Plugins"))
            Directory.CreateDirectory(datapath + "Plugins");

        if (!Directory.Exists(datapath + "Animations"))
            Directory.CreateDirectory(datapath + "Animations");

        if (!Directory.Exists(datapath + "Animators"))
            Directory.CreateDirectory(datapath + "Animators");

        if (!File.Exists(Application.dataPath + "/记得每日备份"))
            File.Create(Application.dataPath + "/记得每日备份");

        if (!Directory.Exists(Application.streamingAssetsPath))
            Directory.CreateDirectory(Application.streamingAssetsPath);

        Debug.Log("Creat Dir Over");
    }

    [MenuItem("陈木杉/testbtn")]
    public static void testfun() {
        GameObject[] objs = Selection.gameObjects;

        foreach (var item in objs)
        {

            for (int i = 0; i < item.transform.childCount; i++)
            {
                item.transform.GetChild(i).name = i.ToString();
                //item.transform.Find("Text").GetComponent<Text>().text = "";
            }
        }
    }



    [MenuItem("陈木杉/mywinodws")]
    public static void ShowWindows() {
        ChenMUShanTools windows = (ChenMUShanTools)EditorWindow.GetWindow(typeof(ChenMUShanTools));
       

        uIContentarr = new GUIContent[10];

        for (int i = 0; i < 10; i++)
        {
            uIContentarr[i] = new GUIContent(i.ToString());
        }
        windows.Show();

    }

    bool is_open;
    static GUIContent[] uIContentarr;
    int index = 0;

    void OnGUI() {


        //EditorGUIUtility.b
        GUILayout.Label("bbb !");


        is_open = EditorGUILayout.BeginToggleGroup("ahhaha", is_open);

        
        index = EditorGUILayout.Popup(index, uIContentarr);


        switch (index)
        {
            case 0:
                GUILayout.Label("0~");
                GUILayout.HorizontalSlider(5, 0, 5);
                break;
            case 1:
                GUILayout.Label("1~");
                GUILayout.HorizontalSlider(6, -6, 0);
                break;
            case 2:
                GUILayout.Label("2~");
                GUILayout.HorizontalSlider(90, -45, 45);
                break;
            case 3:
                GUILayout.Label("3~");
                GUILayout.HorizontalSlider(52, 0, 5);
                break;
            case 4:  break;
            case 5:  break;
        }


        if (is_open)
        {
            GUILayout.Label("hahhah !");
        }
      

       EditorGUILayout.EndToggleGroup();



        EditorGUI.BeginChangeCheck();


    }


}
