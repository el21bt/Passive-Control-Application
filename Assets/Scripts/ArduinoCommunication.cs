using UnityEngine;
using System.IO.Ports;
using System.Threading;
using System;

public class ArduinoCommunication : MonoBehaviour
{
    public static ArduinoCommunication Instance; // Singleton instance

    SerialPort serialPort;
    Thread readThread;
  

    //used for repetitions remaining
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
        //establish serial connection
        serialPort = new SerialPort("COM3", 9600);
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
                //print("Data recieved = " + receivedData);
                if (receivedChar == '1')
                {
                    NumberOfOnesReceived++;
                }
            }
            catch (TimeoutException)
            {
                //Debug.LogError("Timeout exception ");
            }
            catch (System.Exception e)
            {
                Debug.LogError("Error reading from Arduino: " + e.Message);
            }
        }
    }

    public void WriteToArduino(string data)
    {
        serialPort.Write(data + "\n");
        Debug.Log("Sent data to Arduino: " + data);
    }

    //used for repetitions remaining
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
