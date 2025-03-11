using System;
using UnityEngine;
using UnityEngine.Serialization;

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

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
