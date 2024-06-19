using UnityEngine;
using UnityEngine.U2D;

public class PPCManager : MonoBehaviour
{
    private void Start()
    {
        PixelPerfectCamera ppc = Camera.main.GetComponent<PixelPerfectCamera>();
        if (ppc == null)
        {
            ppc = Camera.main.gameObject.AddComponent<PixelPerfectCamera>();
        }
        
        ppc.assetsPPU = 64;
        ppc.refResolutionX = 1920;
        ppc.refResolutionY = 1080;
        ppc.upscaleRT = true;
        ppc.pixelSnapping = true;
        ppc.cropFrameX = PixelPerfectCamera.CropFrame.X;
        ppc.cropFrameY = PixelPerfectCamera.CropFrame.Y;
        ppc.stretchFill = false;
    }
}
