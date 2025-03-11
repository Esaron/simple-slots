using System.Threading.Tasks;
using UnityEngine;
using Random = Unity.Mathematics.Random;

public class Slot : MonoBehaviour
{
    private const float FullRotation = 360f;
    private int _currentState = 0;
    private int _previousState = 0;
    
    public async Task<int> Spin()
    {
        _previousState = _currentState;
        _currentState = UnityEngine.Random.Range(0, 8);
        float rotateDegrees = (UnityEngine.Random.Range(2, 5) + (_previousState - _currentState) / 8f) * FullRotation;
        float end = Time.time + rotateDegrees/FullRotation;
        while (Time.time < end)
        {
            transform.Rotate(Vector3.left, FullRotation * Time.deltaTime, Space.Self);
            await Task.Yield();
        }
        transform.rotation = Quaternion.Euler(Vector3.left * (_currentState / 8f * FullRotation));
        return _currentState;
    }
}
