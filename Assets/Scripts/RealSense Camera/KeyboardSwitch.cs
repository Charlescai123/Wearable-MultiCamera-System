using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyboardSwitch : MonoBehaviour
{
    //private int count = 0;
    private int camera_num;


    // Images 1-5 are head, right hand, clavicle, left hand and world cameras (3rd camera), respectively 
    public GameObject[] colorImages;
    private int temp;
    private GameObject gb;

    List<GameObject> gbList = new List<GameObject>();

    public void Start()
    {
        // Find The Camera GameObjects 
        foreach(var i in colorImages)
        {
            gbList.Add(i);
        }

        camera_num = colorImages.Length;

    }

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.H))
        {
            Debug.Log("Keyboard H has been pressed, switching to Head Camera ...");
            for (int i = 0; i < camera_num; i++)
            {
                if (i == 0)
                {
                    gbList[i].SetActive(true);
                }
                else
                {
                    gbList[i].SetActive(false);
                }
            }
        }

        else if (Input.GetKeyDown(KeyCode.R))
        {
            Debug.Log("Keyboard R has been pressed, switching to Right-Hand Camera ...");
            for (int i = 0; i < camera_num; i++)
            {
                if (i == 1)
                {
                    gbList[i].SetActive(true);
                }
                else
                {
                    gbList[i].SetActive(false);
                }
            }
        }

        else if (Input.GetKeyDown(KeyCode.C))
        {
            Debug.Log("Keyboard C has been pressed, switching to Clavicle Camera ...");
            for (int i = 0; i < camera_num; i++)
            {
                if (i == 2)
                {
                    gbList[i].SetActive(true);
                }
                else
                {
                    gbList[i].SetActive(false);
                }
            }
        }

        else if (Input.GetKeyDown(KeyCode.L))
        {
            Debug.Log("Keyboard L has been pressed, switching to Left-Hand Camera ...");
            for (int i = 0; i < camera_num; i++)
            {
                if (i == 3)
                {
                    gbList[i].SetActive(true);
                }
                else
                {
                    gbList[i].SetActive(false);
                }
            }
        }

        else if (Input.GetKeyDown(KeyCode.W))
        {
            Debug.Log("Keyboard W has been pressed, switching to World Camera (3rd Personal View Camera) ...");
            for (int i = 0; i < camera_num; i++)
            {
                if (i == 4)
                {
                    gbList[i].SetActive(true);
                }
                else
                {
                    gbList[i].SetActive(false);
                }
            }
        }

    }
}
