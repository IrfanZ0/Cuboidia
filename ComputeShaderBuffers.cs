using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComputeShaderBuffers : MonoBehaviour {

    public ComputeShader redComputeShader;
    RenderTexture redTransparentTexture;
    int kernel_red;
    int numVertices = 1048576;
    public ComputeShader blueComputeShader;
    RenderTexture blueTransparentTexture;
    int kernel_blue;
    public ComputeShader greenComputeShader;
    RenderTexture greenTransparentTexture;
    int kernel_green;
    public ComputeShader yellowComputeShader;
    RenderTexture yellowTransparentTexture;
    int kernel_yellow;
    private ComputeBuffer posBuffer;
    private ComputeBuffer offsetBuffer;
    private ComputeBuffer colorBuffer;
    private ComputeBuffer outputBuffer;
    int textureWidth = 128;
    int textureHeight = 128;
    MeshRenderer mCubeRenderer;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void CreateBuffers()
    {
        offsetBuffer = new ComputeBuffer(numVertices, 4);

        float[] vertices = new float[numVertices];

        for (int i = 0; i < numVertices; i++)
        {
            vertices[i] = numVertices;
        }

    }

    void ReleaseBuffers()
    {
        posBuffer.Release();
        offsetBuffer.Release();
        colorBuffer.Release();
        outputBuffer.Release();
    }

    public void RedTransparent(MeshRenderer mCubeRenderer)
    {
        kernel_red = redComputeShader.FindKernel("CSMain");

        redTransparentTexture = new RenderTexture(textureWidth, textureHeight, 32, RenderTextureFormat.ARGB32);
        redTransparentTexture.enableRandomWrite = true;
        redTransparentTexture.Create();

        //CreateBuffers();

        redComputeShader.SetTexture(kernel_red, "tex", redTransparentTexture);
        redComputeShader.Dispatch(kernel_red, redTransparentTexture.width / 8, redTransparentTexture.height / 8, 1);


        mCubeRenderer.material.SetTexture("_MainTex", redTransparentTexture);
    }

    public void BlueTransparent(MeshRenderer mCubeRenderer)
    {
        kernel_blue = blueComputeShader.FindKernel("CSMain");

        blueTransparentTexture = new RenderTexture(128, 128, 32, RenderTextureFormat.ARGB32);
        blueTransparentTexture.enableRandomWrite = true;
        blueTransparentTexture.Create();

        blueComputeShader.SetTexture(kernel_blue, "tex", blueTransparentTexture);
        blueComputeShader.Dispatch(kernel_blue, blueTransparentTexture.width / 8, blueTransparentTexture.height / 8, 1);

        mCubeRenderer.material.SetTexture("_MainTex", blueTransparentTexture);
    }

    public void YellowTransparent(MeshRenderer mCubeRenderer)
    {
        kernel_yellow = yellowComputeShader.FindKernel("CSMain");

        yellowTransparentTexture = new RenderTexture(128, 128, 32, RenderTextureFormat.ARGB32);
        yellowTransparentTexture.enableRandomWrite = true;
        yellowTransparentTexture.Create();

        yellowComputeShader.SetTexture(kernel_yellow, "tex", yellowTransparentTexture);
        yellowComputeShader.Dispatch(kernel_yellow, yellowTransparentTexture.width / 8, yellowTransparentTexture.height / 8, 1);

        mCubeRenderer.material.SetTexture("_MainTex", yellowTransparentTexture);
    }

    public void GreenTransparent(MeshRenderer mCubeRenderer)
    {
        kernel_green = greenComputeShader.FindKernel("CSMain");

        greenTransparentTexture = new RenderTexture(128, 128, 32, RenderTextureFormat.ARGB32);
        greenTransparentTexture.enableRandomWrite = true;
        greenTransparentTexture.Create();

        greenComputeShader.SetTexture(kernel_green, "tex", greenTransparentTexture);
        greenComputeShader.Dispatch(kernel_green, greenTransparentTexture.width / 8, greenTransparentTexture.height / 8, 1);

        mCubeRenderer.material.SetTexture("_MainTex", greenTransparentTexture);
    }
}
