using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EasyModbus;
using System.Collections;
using System.Threading;
using UnityEngine;
using Npgsql;


public class sockets : MonoBehaviour{
	public static bool empezar = true;
	public static Thread t;    
    public static Thread t_baseDatos;
    public static bool primera_vez = true;
	public static int contador = 0;
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

    public class PostgresRead{
        // Obtain connection string information from the portal
        //
        //public  string Host = "dbupcur.cst7fbydrgjl.us-east-1.rds.amazonaws.com";
        public  string Host = "3.213.2.249";
        public  string User = "upcur";
        public  string DBname = "dbupcur";
        public  string Password = "1pc4ever";
        public  string Port = "5432";
        public string[] ultimo_usuario = new string[9];
        public string[] moviments = new string[2];
        public NpgsqlConnection conn;
        
        

        public void beginPostgresRead(){
            // Build connection string using parameters from portal
            //
            string connString = String.Format(
                    "Server={0}; User Id={1}; Database={2}; Port={3}; Password={4};",
                    Host,
                    User,
                    DBname,
                    Port,
                    Password
            );

            conn = new NpgsqlConnection(connString);

                //Debug.Log("---------------------------------------Opening connection");
                conn.Open();
                //Debug.Log("---------------------------------------Connection Stablished");
        }

        public void ReadDB(){
	        	try{
                    //Debug.Log("----------------READ DATABASE-------------");

	        		// Cuenta
	                NpgsqlCommand cmd = new NpgsqlCommand("SELECT max(l.id) FROM logins l", conn);

			        // Execute a query
			        NpgsqlDataReader max = cmd.ExecuteReader();

			        // Read all rows and output the first column in each row
			        while (max.Read()){
			        	ultimo_usuario[0] = max[0].ToString();
			        	//Debug.Log(ultimo_usuario[0]);
			        }
			        string string_cmd2 = "select * from logins where id = " + ultimo_usuario[0];
			        NpgsqlCommand cmd2 = new NpgsqlCommand(string_cmd2, conn);

			        // Execute a query
			        NpgsqlDataReader dades_usuariMax = cmd2.ExecuteReader();
			        //Debug.Log("Dades per llegir: " + dades_usuariMax.Read());
			        while (dades_usuariMax.Read()){
			        	
			        	for(int i = 1; i < 9; i++){
			        		if(i < 6){
			        			ultimo_usuario[i] = dades_usuariMax.GetInt32(i).ToString();
			        			//Debug.Log(ultimo_usuario[i]);
			        		}
			        		else if(i < 8){
			        			ultimo_usuario[i] = dades_usuariMax.GetString(i).ToString();
			        			//Debug.Log(ultimo_usuario[i]);
			        		}
			        		else{
			        			ultimo_usuario[i] = dades_usuariMax.GetBoolean(i).ToString();
			        			//Debug.Log(ultimo_usuario[i]);
			        		}
			        	}
			        	
			        }


			     
			        


			        // Cuenta
	                NpgsqlCommand query_mov = new NpgsqlCommand("SELECT max(m.id) FROM moviments m;", conn);

			        // Execute a query
			        NpgsqlDataReader fila_id_moviment = query_mov.ExecuteReader();

			        // Read all rows and output the first column in each row
			        while (fila_id_moviment.Read()){
			        	moviments[0] = fila_id_moviment[0].ToString();
			        	//Debug.Log(moviments[0]);
			        }
			        
			        string string2_mov = "select m1.moviment from moviments m1 where m1.id = " + moviments[0];
			        NpgsqlCommand query_mov2 = new NpgsqlCommand(string2_mov, conn);
			        NpgsqlDataReader fila_id_moviment2 = query_mov2.ExecuteReader();
					while (fila_id_moviment2.Read()){
			        	moviments[1] = fila_id_moviment2[0].ToString();
			        	//Debug.Log("--------" +moviments[1]);
			        }
			    }
			    catch (Exception e){
	                     //Debug.Log("-----------------Error al ReadBase de Datos: " + e.Message);
	                     conn.Close();
	                     conn.Open();
	            }
		}
	            
        
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
        //private ModbusClient client;
        //public Robot(ModbusClient client)
        public Robot()
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
            //this.client = client;
        }

        public void ReadRegs(){
        //270-305 -> 
            try{
            	//Debug.Log("ReadRegsssssss");
                int[] tmp = new int[6];
                int i;
                tmp = modbusClient.ReadHoldingRegisters(260,6);
                for(i = 0; i < 6; i++) regs[(int)RegisterNames.isPowerOnRobot+i].SetData(tmp[i]);
                Thread.Sleep(50);

                tmp = modbusClient.ReadHoldingRegisters(270,6);
                for(i = 0; i < 6; i++) regs[(int)RegisterNames.BaseJointAngle+i].SetData(tmp[i]);
                Thread.Sleep(50);

                tmp = modbusClient.ReadHoldingRegisters(280,6);
                for(i = 0; i < 6; i++) regs[(int)RegisterNames.BaseJointAngleVelocity+i].SetData(tmp[i]);
                Thread.Sleep(50);

                tmp = modbusClient.ReadHoldingRegisters(290,6);
                for(i = 0; i < 6; i++) regs[(int)RegisterNames.BaseJointCurrent+i].SetData(tmp[i]);
                Thread.Sleep(50);

                tmp = modbusClient.ReadHoldingRegisters(300,6);
                for(i = 0; i < 6; i++) regs[(int)RegisterNames.BaseJointTemperature+i].SetData(tmp[i]);
                Thread.Sleep(50);

                int[] tmp1 = modbusClient.ReadHoldingRegisters(768,3);
                for(i = 0; i < 3; i++) regs[(int)RegisterNames.ToolState+i].SetData(tmp1[i]);
                Thread.Sleep(50);
            }
            catch (Exception e){
                Debug.Log("Error: " + e.Message);
                modbusClient.Disconnect();
                Thread.Sleep(100);
                modbusClient.Connect();

            }
        }

        public void ReadRegsBlock1(){
            int[] tmp = new int[6];
            int i;
            tmp = modbusClient.ReadHoldingRegisters(260,6);
            for(i = 0; i < 6; i++) regs[(int)RegisterNames.isPowerOnRobot+i].SetData(tmp[i]);
        }
        public void ReadRegsBlock2(){
            int[] tmp = new int[6];
            int i;
            tmp = modbusClient.ReadHoldingRegisters(270,6);
            for(i = 0; i < 6; i++) regs[(int)RegisterNames.BaseJointAngle+i].SetData(tmp[i]);
        }
        public void ReadRegsBlock3(){
            int[] tmp = new int[6];
            int i;
            tmp = modbusClient.ReadHoldingRegisters(280,6);
            for(i = 0; i < 6; i++) regs[(int)RegisterNames.BaseJointAngleVelocity+i].SetData(tmp[i]);
        }
        public void ReadRegsBlock4(){
            int[] tmp = new int[6];
            int i;
            tmp = modbusClient.ReadHoldingRegisters(290,6);
            for(i = 0; i < 6; i++) regs[(int)RegisterNames.BaseJointCurrent+i].SetData(tmp[i]);
        }
        public void ReadRegsBlock5(){
            int[] tmp = new int[6];
            int i;
            tmp = modbusClient.ReadHoldingRegisters(300,6);
            for(i = 0; i < 6; i++) regs[(int)RegisterNames.BaseJointTemperature+i].SetData(tmp[i]);
        }
        public void ReadRegsBlock6(){
            int i;
            int[] tmp1 = modbusClient.ReadHoldingRegisters(768,3);
            for(i = 0; i < 3; i++) regs[(int)RegisterNames.ToolState+i].SetData(tmp1[i]);
        }      
        
    }

    public static ModbusClient modbusClient = new ModbusClient("172.16.17.6", 502);    //Ip-Address and Port of Modbus-TCP-Server
    public static Robot URobot = new Robot();
    public static PostgresRead BaseDatos = new PostgresRead();
    
    

    void Start(){
        empezar = true;
	    //try{
	    	//BaseDatos.beginPostgresRead();
	    	//Debug.Log("Me he Conectado a la Base de Datos");
	    //	t_baseDatos = new Thread(new ThreadStart(BaseDatos.ReadDB));
		//	t_baseDatos.Start();
			//Debug.Log("He hecho start del thread de BD");
	    //}
	    //catch(Exception e){
	    //	Debug.Log("Error de la Base de Dades: " + e.Message);
	    	
	    //}


        try{
            t = new Thread(new ThreadStart(ejecutarCosas));
            t.Start();
            Debug.Log("-------------Thread should be started---------------");
            //modbusClient.Connect();
            //modbusClient.ConnectionTimeout = 1000;


            //t = new Thread(new ThreadStart(ejecutarCosas));
            //t.Start();
            //Debug.Log("-------------Thread should be started---------------");
            
            //modbusClient.Disconnect();                                                //Disconnect from Server

        }
        catch (Exception e){
            Debug.Log("Error del Socket: " + e.Message);

        }
        //StartCoroutine("LeerDB");
    }



    void Update(){ 
        
    	//if(primera_vez){
    	//	BaseDatos.beginPostgresRead(); 
    	//	primera_vez = false;
    	//}
        
    	//if(contador == 60){
    	//	BaseDatos.ReadDB();
    	//	contador  = 0;
    	//}
    	//else contador++;
            //StartCoroutine("ReadRobotRegs");
            //Debug.Log(URobot.regs[(int)RegisterNames.TCPy].GetData());

    }

    void OnApplicationQuit(){
    	empezar = false;
    	//StopCoroutine("LeerDB");
        modbusClient.Disconnect();
    }

    void ejecutarCosas(){
        Debug.Log("---------------HE ENTRADO AL THREAD!!----------------------");
        BaseDatos.beginPostgresRead();
        Debug.Log("Me he Conectado a la Base de Datos");
        while(empezar){
            URobot.ReadRegs();
            Thread.Sleep(300);
            BaseDatos.ReadDB();
        }
        
    }

    //IEnumerator LeerDB(){
    //    if(primera_vez){
    //        BaseDatos.beginPostgresRead(); 
    //        primera_vez = false;
    //    }
    //    while (true){
    //        BaseDatos.ReadDB();
    //        yield return new WaitForSeconds(4);  
    //            
    //    }   
    //}


}
 
