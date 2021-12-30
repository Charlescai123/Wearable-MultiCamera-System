using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
//using System.Management;
using System;
using System.Text;
using System.IO;
//using Microsoft.MixedReality.WebRTC;
using OfficeOpenXml;
using ExperimentDataRecord;

public class WebCamStream : MonoBehaviour
{
    public RawImage rawImage;
    public bool usePredefinedCameras;
    public string[] deviceNames;
    public string[] deviceIDs;
    

    private WebCamDevice[] devices;
    private WebCamTexture webcamTexture;
    public int currentIndex = 0;
    private int cam_num = 0;

    List<string> deviceList;


void Start()
    {
        deviceList = new List<string>();

        // Predefined names
        deviceNames = new string[]
        {
            "Intel(R) RealSense(TM) Depth Camera 435 with RGB Module RGB",
            "Intel(R) RealSense(TM) Depth Camera 435 with RGB Module RGB 1"
        };

        // Get all connected devices
        devices = WebCamTexture.devices;

        for (int i = 0; i < devices.Length; i++)
        {
            // Only Add Intel Realsense RGB Cameras 
            if(!devices[i].name.Contains("Intel(R) RealSense(TM) Depth Camera 435 with RGB Module RGB")&&!devices[i].name.Contains("Intel(R) RealSense(TM) Depth Camera 435i RGB")&&!devices[i].name.Contains("Intel(R) RealSense(TM) 435 with RGB Module RGB"))
            {

            }
            else
            {
                deviceList.Add(devices[i].name);
            }
        }

        // Render to texture
        webcamTexture = new WebCamTexture();
        rawImage.texture = webcamTexture;
        rawImage.material.mainTexture = webcamTexture;

        // Initialization
        if (devices.Length > 0)
        {
            // If no predefined names are given
            if (!usePredefinedCameras)
            {   
                deviceNames = deviceList.ToArray();
            }
            LoadCamera(0);
        }
    }

    void Update()
    {

        //AddLocalVideoTrackAsync();
        //GetVideoCaptureDevicesAsync();
        //Open();
        if (devices.Length == 0)
            return;

        // Switch cameras
        /*if (Input.GetKeyDown(KeyCode.Q))
        {
            LoadCamera(0);
        }
        if (Input.GetKeyDown(KeyCode.W))
        {
            LoadCamera(1);
        }
        if (Input.GetKeyDown(KeyCode.E))
        {
            LoadCamera(2);
        }
        if (Input.GetKeyDown(KeyCode.R))
        {
            LoadCamera(3);
        }*/

        // Increment index
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            currentIndex = (currentIndex + 1) % deviceNames.Length;
            LoadCamera(currentIndex);
        }
    }

    public void LoadCamera(int index)
    {
        if (index < deviceNames.Length)
        {
            currentIndex = index;
            // change texture
            webcamTexture.Stop();
            webcamTexture.deviceName = deviceNames[currentIndex];
            webcamTexture.Play();

            Debug.Log("Current camera name: " + deviceNames[currentIndex]);
        }
    }


    public void Open(string arguments = null)
    {
        System.Diagnostics.Process p = new System.Diagnostics.Process();
        //设置.net的程序路径
        var Path = "C:\\Users\\Charlescai\\Desktop";
        p.StartInfo.FileName = Path + "\\ConsoleApp1.exe";
        p.StartInfo.Arguments = arguments;
        p.StartInfo.CreateNoWindow = true;
        p.StartInfo.UseShellExecute = false;
        p.StartInfo.StandardOutputEncoding = Encoding.Default;
        p.StartInfo.RedirectStandardOutput = true;
        p.StartInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
        p.Start();
        StreamReader s = p.StandardOutput;
        p.WaitForExit();
        Manager(s.ReadToEnd());
        s.Close();
    }
    private void Manager(string content)
    {
        //处理接收到的内容

        for (int i = 0; i < deviceIDs.Length; i++)
        {
            if (content.IndexOf(deviceIDs[i]) == -1)
            {
                Debug.Log("No!!!");
            }
            else
            {
                Debug.Log("Yes!!!");
            }
        }
        Debug.Log(content);
    }

    //static List<USBDeviceInfo> GetUSBDevices()
    //{
    //    List<USBDeviceInfo> devices = new List<USBDeviceInfo>();

    //    ManagementObjectCollection collection;
    //    using (var searcher = new ManagementObjectSearcher(@"Select * From Win32_USBHub"))
    //        collection = searcher.Get();

    //    foreach (var device in collection)
    //    {
    //        devices.Add(new USBDeviceInfo(
    //        (string)device.GetPropertyValue("DeviceID"),
    //        (string)device.GetPropertyValue("PNPDeviceID"),
    //        (string)device.GetPropertyValue("Description")
    //        ));
    //    }

    //    collection.Dispose();
    //    return devices;
    //}
}

class USBDeviceInfo
{
    public USBDeviceInfo(string deviceID, string pnpDeviceID, string description)
    {
        this.DeviceID = deviceID;
        this.PnpDeviceID = pnpDeviceID;
        this.Description = description;
    }
    public string DeviceID { get; private set; }
    public string PnpDeviceID { get; private set; }
    public string Description { get; private set; }
}


