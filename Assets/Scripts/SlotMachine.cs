using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using System.Linq;

public class SlotMachine : MonoBehaviour
{
    private const int SlotCount = 3;
    [SerializeField] private Slot[] slots = new Slot[SlotCount];
    [SerializeField] private Slot slotPrefab;

    private void Awake()
    {
        Camera cam = Camera.main;
        if (cam == null)
        {
            Debug.LogError("Unable to find main camera");
            return;
        }
        
        float distance = 20f;
        float viewportY = 0.5f;
        for (int i = 0; i < SlotCount; i++)
        {
            float viewportX = (i + 0.5f)/SlotCount;
            Vector3 worldPos = cam.ViewportToWorldPoint(new Vector3(viewportX, viewportY, distance));
            slots[i] = Instantiate(slotPrefab, worldPos, Quaternion.identity);
        }
    }
    
    public async void Spin()
    {
        List<Task<int>> tasks = new List<Task<int>>(SlotCount);
        for (int i = 0; i < SlotCount; i++)
        {
            tasks.Add(slots[i].Spin());
        }

        await Task.WhenAll(tasks);

        int[] results = tasks.Select(task => task.GetAwaiter().GetResult()).ToArray();
        int first = results.First();
        bool win = results.All(result => result == first);
        Debug.Log(win ? "You win!" : "You lose!");
        Debug.Log($"Results: {string.Join(", ", results)}");
    }
}
