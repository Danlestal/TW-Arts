using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TensorFlowLite;
using UnityEngine.UI;
using System.IO;

public class EmotionsSample : MonoBehaviour
{
    [SerializeField, FilePopup("*.tflite")] string fileName = "";
    [SerializeField] RawImage cameraView = null;
    [SerializeField] Text emotionName = null;
    
    WebCamTexture webcamTexture;
    private EmoNet emoNet;

    // Start is called before the first frame update
    void Start()
    {
        string path = Path.Combine(Application.streamingAssetsPath, fileName);
        emoNet = new EmoNet(path);
        initCamera();
    }

    // Update is called once per frame
    void Update()
    {
        emoNet.Invoke(webcamTexture);
        var results = emoNet.GetResults();
        emotionName.text = results[0].ToString();
    }

    private void initCamera(){
        string cameraName = WebCamUtil.FindName();
        webcamTexture = new WebCamTexture(cameraName, 640, 480, 30);
        webcamTexture.Play();
        cameraView.texture = webcamTexture;
    }
}
