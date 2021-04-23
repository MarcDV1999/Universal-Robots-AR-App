using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EasyModbus;
using System.Collections;
using UnityEngine;

public class sockets_v2 : MonoBehaviour{

    public enum RegisterNames : byte{
        isPowerOnRobot,
        isProtectiveStopped,
        isEmergencyStopped,
        isFreedriveActive,
        isPowerPuttonPressed,
        isSafetySignalSuchThatWeShouldStop,


         BaseJointAngle,//(in mrad)
         ShoulderJoint_angle,//(in mrad)
         ElbowJointAngle, //(in mrad)
         Wrist1JointAngle, //(in mrad)
         Wrist2JointAngle, //(in mrad)
         Wrist3JointAngle, //(in mrad)


         BaseJointAngleVelocity, //(in mrad/s)
         ShoulderJointAngleVelocity, //(in mrad/s)
         ElbowJointAngleVelocity,//(in mrad/s)
         Wrist1JointAngleVelocity,//(in mrad/s)
         Wrist2JointAngleVelocity,//(in mrad/s)
         Wrist3JointAngleVelocity,//(in mrad/s)


         BaseJointCurrent, //(in mA)
         ShoulderJointCurrent, //(in mA)
         ElbowJointCurrent, //(in mA)
         Wrist1JointCurrent, //(in mA)
         Wrist2JointCurrent, //(in mA)
         Wrist3JointCurrent, //(in mA)


         BaseJointTemperature, //(in C)
         ShoulderJointTemperature, //(in C)
         ElbowJointTemperature, //(in C)
         Wrist1JointTemperature, //(in C)
         Wrist2JointTemperature, //(in C)
         Wrist3JointTemperature, //(in C)


         BaseJointMode,
         ShoulderJointMode,
         ElbowJointMode,
         Wrist1JointMode,
         Wrist2JointMode,
         Wrist3JointMode,

        /*  List of Joint Modes
    *                   JOINT_SHUTTING_DOWN_MODE = 236;
                JOINT_PART_D_CALIBRATION_MODE = 237;
                JOINT_BACKDRIVE_MODE = 238;
                JOINT_POWER_OFF_MODE = 239;
                JOINT_NOT_RESPONDING_MODE = 245;
                JOINT_MOTOR_INITIALISATION_MODE = 246;
                JOINT_BOOTING_MODE = 247; 	 
                JOINT_PART_D_CALIBRATION_ERROR_MODE = 248;
                JOINT_BOOTLOADER_MODE = 249;
                JOINT_CALIBRATION_MODE = 250;
                JOINT_FAULT_MODE = 252;	 
                JOINT_RUNNING_MODE = 253;	 
                JOINT_IDLE_MODE = 255;	 
        */

         BaseJointRevolutionCount,//(number of full turns, typically 0 or 1)
         ShoulderJointRevolutionCount,
         ElbowJointRevolutionCount,
         Wrist1JointRevolutionCount,
         Wrist2JointRevolutionCount,
         Wrist3JointRevolutionCount,

        //NOTE: Be aware that the aggregated position based on the revolution counter 
        //and the joint angle can be one revolution off when passing 0 or 2*pi if 
        //the values are not read at the same time.

         TCPx, //in tenth of mm(in base frame)
         TCPy, //in tenth of mm(in base frame)
         TCPz,//in tenth of mm(in base frame)
         TCPrx,//in mrad(in base frame)
         TCPry,//in mrad(in base frame)
         TCPrz,//in mrad(in base frame)


         TCPxSpeed,//in mm/s(in base frame)
         TCPySpeed,//in mm/s(in base frame)
         TCPzSpeed,//in mm/s(in base frame)
         TCPrxSpeed,//in mrad/s(in base frame)
         TCPrySpeed,//in mrad/s(in base frame)
         TCPrzSpeed,//in mrad/s(in base frame)


         TCPxOffset,//in mm(in tool frame)
         TCPyOffset,//in mm(in tool frame)
         TCPzOffset,//in mm(in tool frame)
         TCPrxOffset,//in mrad(in tool frame)
         TCPryOffset,//in mrad(in tool frame)
         TCPrzOffset,//in mrad(in tool frame)


         RobotCurrent,//(in mA)
         IOCurrent,//(in mA)


         ToolState,
         ToolTemperature,//(in C)
         ToolCurrent //(in mA)
    }





    public class reg{
        private int adress;
        private int data;

        public reg(int a)
        {
            adress = a;
            data = 0;
        }

        public int GetAdress()
        {
            return adress;
        }

        public void SetData(int d)
        {
            data = d;
        }

        public int GetData()
        {
            return data;
        }

    }





    public class Robot{

        public reg[] regs = new reg[66];
        private ModbusClient client;
        public Robot(ModbusClient client)
        {
            for (int i = 0, j = 260; j <= 425; i++, j++)
            {
                if (j == 326) j = 400;
                else if (j % 10 == 6) j += 4;
                regs[i] = new reg(j);
            }
     
            regs[61] = new reg(450);
            regs[62] = new reg(451);
            regs[63] = new reg(768);
            regs[64] = new reg(769);
            regs[65] = new reg(770);
            this.client = client;
        }
/*
        public Boolean ReadRegs(ModbusClient client){
            try { 
                for (int i = 0; i < 66; i++)
                {

                    int[] tmp = client.ReadHoldingRegisters(regs[i].GetAdress(), 1);
                    regs[i].SetData(tmp[0]);
                    //Debug.Log("Register " + regs[i].GetAdress() + " = " + regs[i].GetData());
                }
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }
        */
        public IEnumerator ReadRegs(){
            //270-305 -> 
                int[] tmp = new int[6];
                int i;
                tmp = client.ReadHoldingRegisters(260,6);
                for(i = 0; i < 6; i++) regs[(int)RegisterNames.isPowerOnRobot+i].SetData(tmp[i]);
                yield return null;
                tmp = client.ReadHoldingRegisters(270,6);
                for(i = 0; i < 6; i++) regs[(int)RegisterNames.BaseJointAngle+i].SetData(tmp[i]);
                yield return null;
                tmp = client.ReadHoldingRegisters(280,6);
                for(i = 0; i < 6; i++) regs[(int)RegisterNames.BaseJointAngleVelocity+i].SetData(tmp[i]);
                yield return null;
                tmp = client.ReadHoldingRegisters(290,6);
                for(i = 0; i < 6; i++) regs[(int)RegisterNames.BaseJointCurrent+i].SetData(tmp[i]);
                yield return null;
                tmp = client.ReadHoldingRegisters(300,6);
                for(i = 0; i < 6; i++) regs[(int)RegisterNames.BaseJointTemperature+i].SetData(tmp[i]);
                yield return null;
                int[] tmp1 = client.ReadHoldingRegisters(768,3);
                for(i = 0; i < 3; i++) regs[(int)RegisterNames.ToolState+i].SetData(tmp1[i]);
           
        }
        
    }

    public static ModbusClient modbusClient = new ModbusClient("192.168.1.4", 502);    //Ip-Address and Port of Modbus-TCP-Server
    public static Robot URobot = new Robot(modbusClient);
    
    void Start(){

        try{
            modbusClient.Connect();   
            //modbusClient.Disconnect();                                                //Disconnect from Server

        }
        catch (Exception e){
            Debug.Log("Error: " + e.Message);

        }
    }

    void Update(){  
            StartCoroutine("URobot.ReadRegs");
            //Debug.Log(URobot.regs[(int)RegisterNames.TCPy].GetData());
    }



}
 
