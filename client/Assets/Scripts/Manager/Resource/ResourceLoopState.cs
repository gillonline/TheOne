using UnityEngine;

enum ResourceLoopState
{
    Start = 0,
    Loading = 1,
    Idle = 2,
    Using = 3,
    Destroy = 4
}