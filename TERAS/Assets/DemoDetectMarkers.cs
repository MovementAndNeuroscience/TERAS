using UnityEngine;
using Unity;
using System.Collections;
using UnityEngine.UI;
using OpenCvSharp.Aruco;
using OpenCvSharp;
using UnityEngine.Video;

public class DemoDetectMarkers : MonoBehaviour
{
	public GameObject TobiiVideoPlayer;
	private VideoPlayer videoPlayer; 
	public RenderTexture video; 
	private Texture2D texture;
	private Renderer rend;
	private Point2f[][] corners;
	private int[] ids;
	private Point2f[][] rejectedImgPoints;
	private Dictionary dictionary;
	private DetectorParameters detectorParameters;
	// Start is called before the first frame update
	void Start()
    {
        detectorParameters = DetectorParameters.Create();
        dictionary = CvAruco.GetPredefinedDictionary(PredefinedDictionaryName.Dict4X4_50);
        videoPlayer = TobiiVideoPlayer.GetComponent<VideoPlayer>();
        if (!videoPlayer.isPlaying)
        {
            // Enable new frame Event
            //videoPlayer.sendFrameReadyEvents = true;

            // Subscribe to the new frame Event
            //videoPlayer.frameReady += OnNewFrame;
        }
    }

    // Update is called once per frame
    void Update()
    {

	}
	void OnNewFrame(VideoPlayer source, long frameIdx)
	{
        var time = source.time;

		RenderTexture renderTexture = source.texture as RenderTexture;
        Texture2D videoFrame = new Texture2D(renderTexture.width, renderTexture.height);

        RenderTexture.active = renderTexture;
		videoFrame.ReadPixels(new UnityEngine.Rect(0, 0, renderTexture.width, renderTexture.height), 0, 0);
		videoFrame.Apply();
		RenderTexture.active = null;
        //this.GetComponent<RawImage>().texture = videoFrame;
		Mat mat = OpenCvSharp.Unity.TextureToMat(videoFrame);

        // Convert image to grasyscale
        Mat grayMat = new Mat();
        Cv2.CvtColor(mat, grayMat, ColorConversionCodes.BGR2GRAY);

        // Detect and draw markers
        CvAruco.DetectMarkers(grayMat, dictionary, out corners, out ids, detectorParameters, out rejectedImgPoints);
        CvAruco.DrawDetectedMarkers(mat, corners, ids);

        if(corners.Length != 0 )
        {
            foreach(var corner in corners)
            {
                print("corner : " + corner[0]);
            }
            foreach(var id in ids)
            {
                print("Ids : " + id); 
            }
        }

        // Create Unity output texture with detected markers
        Texture2D grayscaleOutput = OpenCvSharp.Unity.MatToTexture(grayMat);
        Texture2D outputTexture = OpenCvSharp.Unity.MatToTexture(mat);

        // Set texture to see the result
        this.GetComponent<RawImage>().texture = outputTexture;
    }
}
