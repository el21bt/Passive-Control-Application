using UnityEngine;
using UnityEngine.UI;

//sends signals for motor control during calibration, sends a unique code 
//to be handled by arduino
public class MotorControlCalibration : MonoBehaviour
{

    public Button MoveUp1Button;
    public Button MoveUp5Button;
    public Button MoveDown1Button;
    public Button MoveDown5Button;
    public Button MoveRight1Button;
    public Button MoveRight5Button;
    public Button MoveLeft1Button;
    public Button MoveLeft5Button;
    public Button Up1Button;
    public Button Up5Button;
    public Button Down1Button;
    public Button Down5Button;
    public ArduinoCommunication arduinoCommunication;
    public CalibrateDialogue calibrateDialogue;
    public AngleData angleData;
    public ChooseAngle chooseAngle;

    private void Start()
    {
        arduinoCommunication = ArduinoCommunication.Instance;

        if (arduinoCommunication == null)
        {
            Debug.LogError("ArduinoCommunication script not found in the scene.");
        }
        else
        {

            MoveUp1Button.onClick.AddListener(MoveUp1);
            MoveUp5Button.onClick.AddListener(MoveUp5);
            MoveDown1Button.onClick.AddListener(MoveDown1);
            MoveDown5Button.onClick.AddListener(MoveDown5);
            MoveRight1Button.onClick.AddListener(MoveRight1);
            MoveRight5Button.onClick.AddListener(MoveRight5);
            MoveLeft1Button.onClick.AddListener(MoveLeft1);
            MoveLeft5Button.onClick.AddListener(MoveLeft5);

            Up1Button.onClick.AddListener(SendA);

            Up5Button.onClick.AddListener(SendB);

            Down1Button.onClick.AddListener(() =>
            {

                switch (calibrateDialogue.index)
                {
                    case 4:
                        if (angleData.targetPlantarflexion >= 1)
                        {
                            SendC();
                        }
                        else if (chooseAngle.angleDecreasedFromOneToZero)
                        {
                            chooseAngle.angleDecreasedFromOneToZero = false;
                            SendC();
                        }
                        else
                        {
                            return;
                        }
                        break;
                    case 5:
                        if (angleData.targetDorsiflexion >= 1)
                        {
                            SendC();
                        }
                        else if (chooseAngle.angleDecreasedFromOneToZero)
                        {
                            chooseAngle.angleDecreasedFromOneToZero = false;
                            SendC();
                        }
                        else
                        {
                            return;
                        }
                        break;
                    case 6:
                        if (angleData.targetAbduction>= 1)
                        {
                            SendC();
                        }
                        else if (chooseAngle.angleDecreasedFromOneToZero)
                        {
                            chooseAngle.angleDecreasedFromOneToZero = false;
                            SendC();
                        }
                        else
                        {
                            return;
                        }
                        break;
                    case 7:
                        if (angleData.targetAdduction >= 1)
                        {
                            SendC();
                        }
                        else if (chooseAngle.angleDecreasedFromOneToZero)
                        {
                            chooseAngle.angleDecreasedFromOneToZero = false;
                            SendC();
                        }
                        else
                        {
                            return;
                        }
                        break;
                }
            });

            Down5Button.onClick.AddListener(() =>
            {

                switch (calibrateDialogue.index)
                {
                    case 4:
                        if (angleData.targetPlantarflexion >= 5)
                        {
                            SendD();
                        }
                        else if (chooseAngle.angleDecreasedFromFiveToZero)
                        {
                            chooseAngle.angleDecreasedFromFiveToZero = false;
                            SendD();
                        }
                        else
                        {
                            return;
                        }
                        break;
                    case 5:
                        if (angleData.targetDorsiflexion >= 5)
                        {
                            SendD();
                        }
                        else if (chooseAngle.angleDecreasedFromFiveToZero)
                        {
                            chooseAngle.angleDecreasedFromFiveToZero = false;
                            SendD();
                        }
                        else
                        {
                            return;
                        }
                        break;
                    case 6:
                        if (angleData.targetAbduction  >= 5)
                        {
                            SendD();
                        }
                        else if (chooseAngle.angleDecreasedFromFiveToZero)
                        {
                            chooseAngle.angleDecreasedFromFiveToZero = false;
                            SendD();
                        }
                        else
                        {
                            return;
                        }
                        break;
                    case 7:
                        if (angleData.targetAdduction >= 5)
                        {
                            SendD();
                        }
                        else if (chooseAngle.angleDecreasedFromFiveToZero)
                        {
                            chooseAngle.angleDecreasedFromFiveToZero = false;
                            SendD();
                        }
                        else
                        {
                            return;
                        }
                        break;
                }
            });
        }
    }


    public void EnterSetEquilibrium()
    {
        string data = "e000";
        arduinoCommunication.WriteToArduino(data);
    }

    public void ExitSetEquilibrium()
    {
        string data = "X";
        arduinoCommunication.WriteToArduino(data);
    }

    public void MoveUp1()
    {
        string data = "a";
        arduinoCommunication.WriteToArduino(data);
    }

    public void MoveUp5()
    {
        string data = "b";
        arduinoCommunication.WriteToArduino(data);
    }

    public void MoveDown1()
    {
        string data = "c";
        arduinoCommunication.WriteToArduino(data);
    }

    public void MoveDown5()
    {
        string data = "d";
        arduinoCommunication.WriteToArduino(data);
    }

    public void MoveRight1()
    {
        string data = "e";
        arduinoCommunication.WriteToArduino(data);
    }

    public void MoveRight5()
    {
        string data = "f";
        arduinoCommunication.WriteToArduino(data);
    }

    public void MoveLeft1()
    {
        string data = "g";
        arduinoCommunication.WriteToArduino(data);
    }

    public void MoveLeft5()
    {
        string data = "h";
        arduinoCommunication.WriteToArduino(data);
    }

    public void EnterCalibration()
    {
        string data = "f000";
        arduinoCommunication.WriteToArduino(data);
    }

    public void PreviousCalibrationStage()
    {
        string data = "P";
        arduinoCommunication.WriteToArduino(data);
    }

    public void NextCalibrationStage()
    {
        string data = "X";
        arduinoCommunication.WriteToArduino(data);
    }

    public void ChooseLeftorRight()
    {
        if (calibrateDialogue.Left)
        {
            string data = "g000";
            arduinoCommunication.WriteToArduino(data);
        }
        else
        {
            string data = "g111";
            arduinoCommunication.WriteToArduino(data);
        }
    }

    public void SendA()
    {
        string data = "a";
        arduinoCommunication.WriteToArduino(data);
    }

    public void SendB()
    {
        string data = "b";
        arduinoCommunication.WriteToArduino(data);
    }

    public void SendC()
    {
        string data = "c";
        arduinoCommunication.WriteToArduino(data);
    }

    public void SendD()
    {
        string data = "d";
        arduinoCommunication.WriteToArduino(data);
    }
}