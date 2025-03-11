using System.Threading.Tasks;
using UnityEngine;
using Random = Unity.Mathematics.Random;

public class Slot : MonoBehaviour
{
    private const float FullRotation = 360f;
    private int _currentState = 0;
    
    public async Task<int> Spin()
    {
        _currentState = UnityEngine.Random.Range(0, 8);
        float rotateDegrees = (UnityEngine.Random.Range(3, 7) + _currentState / 8f) * FullRotation;
        float end = Time.time + rotateDegrees/FullRotation;
        while (Time.time < end)
        {
            transform.Rotate(Vector3.right, FullRotation * Time.deltaTime);
            await Task.Yield();
        }
        return _currentState;
    }
}
