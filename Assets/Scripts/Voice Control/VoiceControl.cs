using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.Windows.Speech;
using System;

public class VoiceControl : MonoBehaviour
{
    private KeywordRecognizer kr;
    private Dictionary<string, Action> actions = new Dictionary<string, Action>();
    public GameObject[] colorImages;
    public GameObject webCam;
    public GameObject dataExtract;

    // Start is called before the first frame update
    void Start()
    {
        actions.Add("head", Switch2HeadCam);
        actions.Add("clavicle", Switch2ClavicleCam);
        actions.Add("left", Switch2LeftCam);
        actions.Add("right", Switch2RightCam);
        actions.Add("world", Switch2WorldCam);
        actions.Add("Recording Start", RecordStart);
        actions.Add("Recording Off", RecordOff);
        actions.Add("Camera Switch", WebCamSwitch);

        kr = new KeywordRecognizer(actions.Keys.ToArray());
        kr.OnPhraseRecognized += RecognizedSpeech;
        kr.Start();

    }

    private void RecognizedSpeech(PhraseRecognizedEventArgs speech)
    {
        //Debug.Log(speech.text);
        actions[speech.text].Invoke();
    }


    // Update is called once per frame
    void Update()
    {

     
    }

    private void WebCamSwitch()
    {
        var gb = webCam.GetComponent<WebCamStream>();
        
        // Increment index
        gb.currentIndex = (gb.currentIndex + 1) % gb.deviceNames.Length;
        gb.LoadCamera(gb.currentIndex);
    }
    

    private void RecordStart()
    {
        var gb = dataExtract.GetComponent<DataExtract>();
        gb.startIcon.SetActive(true);
        gb.stopIcon.SetActive(false);
        Debug.Log("Recording On...");
        gb.IsRecording = !gb.IsRecording;
    }

    private void RecordOff()
    {
        var gb = dataExtract.GetComponent<DataExtract>();
        gb.startIcon.SetActive(false);
        gb.stopIcon.SetActive(true);

        Debug.Log("Recording Off...");
        gb.IsRecording = !gb.IsRecording;
        Debug.Log("Saving Data To Excel File!");
        gb.exlpackage.Save();
        Debug.Log("Data has been saved successfully!");
    }

    // To Head Camera
    private void Switch2HeadCam()
    {
        Debug.Log("Word Head detected, now switching to Head Camera ...");
        CameraSwitch(1, colorImages);
    }

    // To Right-hand Camera
    private void Switch2RightCam()
    {
        Debug.Log("Word Right detected, now switching to Right-Hand Camera ...");
        CameraSwitch(2, colorImages);
    }

    // To Clavicle Camera
    private void Switch2ClavicleCam()
    {
        Debug.Log("Word Clavicle detected, now switching to Clavicle Camera ...");
        CameraSwitch(3, colorImages);
    }

    // To Left-hand Camera
    private void Switch2LeftCam()
    {
        Debug.Log("Word Left detected, now switching to Left-Hand Camera ...");
        CameraSwitch(4, colorImages);
    }

    // To World Camera
    private void Switch2WorldCam()
    {
        Debug.Log("Word World detected, now switching to World Camera ...");
        CameraSwitch(5, colorImages);
    }

    // Switch Cameras
    private void CameraSwitch(int index, GameObject[] gbList)
    {
        for(int i = 0; i < gbList.Length; i++)
        {
            if (i == index - 1)
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


