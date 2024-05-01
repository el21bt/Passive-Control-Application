using UnityEngine;
using System.IO.Ports;
using System.Threading;
using System;

public class ArduinoCommunication : MonoBehaviour
{
    public static ArduinoCommunication Instance; // Singleton instance

    SerialPort serialPort;
    Thread readThread;
  //bool isRunning = true;

    // Public properties
    //public string ReceivedData { get; private set; }
    public int NumberOfOnesReceived { get; private set; }

    void Awake()
    {
        // Singleton pattern
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); // Ensure this object persists between scenes
        }
        else
        {
            Destroy(gameObject); // If an instance already exists, destroy this one
        }
    }
    void Start()
    {
        serialPort = new SerialPort("COM7", 9600);
        serialPort.Open();

        serialPort.ReadTimeout = 100;

        // Start a separate thread to read data from the serial port
        readThread = new Thread(ReadFromArduino);
        readThread.Start();
    }

    void ReadFromArduino()
    {
        while (true)
        {
            try
            {
                int receivedData = serialPort.ReadByte();
                char receivedChar = (char)receivedData;
                print(receivedData);
                if (receivedChar == '1')
                {
                    NumberOfOnesReceived++;
                }
            }
            catch (TimeoutException)
            {
                // Handle timeout (no data received within the specified time)
                //print("Read timeout - no data received");
            }
            catch (System.Exception e)
            {
                Debug.LogError("Error reading from Arduino: " + e.Message);
            }
        }
    }

    public void WriteToArduino(string data)
    {
        serialPort.Write(data);
        Debug.Log("Sent data to Arduino: " + data);
    }

    public void ResetNumberOfOnesReceived()
    {
        NumberOfOnesReceived = 0;
        Debug.Log("Number of ones received reset to 0");
    }

    void OnDestroy()
    {
        //isRunning = false;
        if (serialPort != null && serialPort.IsOpen)
        {
            serialPort.Close();
        }
    }
}
