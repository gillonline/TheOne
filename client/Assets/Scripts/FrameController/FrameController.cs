using UnityEngine;

public class FrameController
{
    public Stage stage;
    public bool isPlaying = false;

    public float startTime;
    public GFloat stageTime;
    public GFloat lastFrameTime;
    public float lastFrameTimeF;
    
    public void Start()
    {
        //从第零帧开始, 时间对应也是0开始;
        startTime = Time.time;
        stageTime = 0f;
    }
    
    public void Update()
    {
        //FrameData fd;
        if (isPlaying)
            stage.Update();
    }

    public void RenderUpdate()
    {
        if (isPlaying)
            stage.RenderUpdate();
    }
}
