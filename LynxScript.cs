using System;
using System.Linq;
using System.Windows.Forms;
using System.Xml;
using System.Data;
using System.Data.DataSetExtensions;
using System.Drawing;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.IO;
using Microsoft;
using MethodManager.Core;
using MMScriptObjects;
using MethodManager.Interop;
using MMScriptObjects.ScriptUtils;
/* 
** The script entry point will be the method Execute() in a unique instance of a class that implements IMMScriptExecutor.
*/
public class MMScriptExecutor : IMMScriptExecutor
{
	
	public static Dictionary<int, string[]> vvpDataOutputDict (string input)
    {
        string vvpChannel = string.Empty;
        string volumeReported = string.Empty;
        string residualVolume = string.Empty;
        string channelStatus = string.Empty;
        string flowRate = string.Empty;
        string valveTime = string.Empty;
        string HPC = string.Empty;
        string sourceWell = string.Empty;
        string barcode = string.Empty;
        string deckLocation = string.Empty;
        string dateTime = string.Empty;

        string cleanString = input.Replace("\"", "");

        string[] commaSeparatedArray = cleanString.Split(',');

        // Initialize a jagged array to store the result
        string[][] resultArray = new string[commaSeparatedArray.Length][];

        // Iterate over each item in the commaSeparatedArray
        for (int i = 0; i < commaSeparatedArray.Length; i++)
        {
            if (i != 0 && i <= 96)
            {
                // Split each item at each semicolon and store it in the resultArray
                resultArray[i] = commaSeparatedArray[i].Split(';');
            }
        }
        barcode = commaSeparatedArray[100];
        deckLocation = commaSeparatedArray[101];
        dateTime = commaSeparatedArray[105];
        //Console.WriteLine(barcode + " " + deckLocation + " " + dateTime);

        Dictionary<int, string[]> vvpDataPackage = new Dictionary<int, string[]>();
        int j = 0;
        // Print the resulting jagged array
        foreach (string[] subArray in resultArray)
        {
            if (j != 0 && j <= 96)
            {
                vvpChannel = subArray[0];
                volumeReported = subArray[1];
                residualVolume = subArray[2];
                channelStatus = subArray[3];
                flowRate = subArray[4];
                valveTime = subArray[5];
                HPC = subArray[6];
                sourceWell = subArray[7];
                //Console.WriteLine(vvpChannel + " " + volumeReported + " " + residualVolume + " " + channelStatus + " " + flowRate + " " + valveTime + " " + HPC + " " + sourceWell);
                vvpDataPackage.Add(j, new string[] { dateTime, barcode, deckLocation, volumeReported, residualVolume, channelStatus, flowRate, valveTime, HPC, sourceWell, vvpChannel });
            }
            j++;
        }
        //return (dateTime, barcode, deckLocation, vvpChannel, volumeReported, residualVolume, channelStatus, flowRate, valveTime, HPC, sourceWell);
        return vvpDataPackage;
    }
	
    public static Tuple<string, string, string> ErrorInspection(string channelStatus)
    {

        string errorDescription = string.Empty;
        string errorDetail = string.Empty; 
        string errorMessage = string.Empty;

        switch (channelStatus)
        {
            case "-3":
                errorDescription = "Pressure Error";
                errorDetail = "null"; 
                errorMessage = "The Lynx has detected a pressure error";
                break;
            case "-4":
                errorDescription = "Timeout";
                errorDetail = "null";
                errorMessage = "The Lynx has timed out";
                break;
            case "-5":
                errorDescription = "Sensor auto - zero error";
                errorDetail = "null";
                errorMessage = "The Lynx has a sensor auto - zero error";
                break;
            case "-21":
                errorDescription = "Aspiration Error: Empty Well";
                errorDetail = "Aspiration of Air";
                errorMessage = "The Lynx has detected an empty well";
                break;
            case "-22":
                errorDescription = "Aspiration Error: Short Sample";
                errorDetail = "Start in Air; End in Liquid";
                errorMessage = "The Lynx has detected a short sample";
                break;
            case "-23":
                errorDescription = "Aspiration Error: Tracking Error";
                errorDetail = "Start in Liquid; End in Air";
                errorMessage = "The Lynx has detected a bubble in sample";
                break;
            case "-24":
                errorDescription = "Clogging Error";
                errorDetail = "Aspirate and Dispense";
                errorMessage = "The Lynx has a clogged channel";
                break;
            case "-25":
                errorDescription = "Blocked Tip Error";
                errorDetail = "Tip blocked before pick up";
                errorMessage = "The Lynx has a blocked tip";
                break;
            default:
                errorDescription = "ERROR CODE NOT FOUND";
                errorDetail = "ERROR CODE NOT FOUND";
                errorMessage = "ERROR CODE NOT FOUND";
                break;
        }

        return Tuple.Create(errorDescription, errorDetail, errorMessage);
    }
    public static void WriteOutputFile(Dictionary<int, string[]> aspirateLynxOutputDict, Dictionary<int, string[]> dispenseLynxOutputDict,  string inputMethodName, string inputDateTimeStamp)
    {
        //get these from outside script, need to be set at start of method
        string methodName = inputMethodName;
        string dateTimeStamp = inputDateTimeStamp;
        string outputPath = "C:\\MethodManager4\\Workspaces\\LO507\\Output\\" + methodName + "\\" + methodName + "_" + dateTimeStamp + "_" + "TransferOutput.csv";
        string[] headers = { "Source Barcode", "Source Well", "Aspirated Volume Reported", "Aspirate VVP Channel", "Aspirate Channel Status", "Destination Barcode", "Destination Well", "Dispensed Volume Reported", "Dispense VVP Channel", "Dispense Channel Status" };

        if (File.Exists(outputPath))
        {
            using (StreamWriter writer = File.AppendText(outputPath))
            {
                for (int i = 1; i < 97; i++)
                {
                    string barcode_Asp = aspirateLynxOutputDict[i][1];
                    string sourceWell_Asp = aspirateLynxOutputDict[i][9];
                    string volumeReported_Asp = aspirateLynxOutputDict[i][3];
                    string vvpChannel_Asp = aspirateLynxOutputDict[i][10];
                    string channelStatus_Asp = aspirateLynxOutputDict[i][5];

                    string barcode_Disp = dispenseLynxOutputDict[i][1];
                    string sourceWell_Disp = dispenseLynxOutputDict[i][9];
                    string volumeReported_Disp = dispenseLynxOutputDict[i][3];
                    string vvpChannel_Disp = dispenseLynxOutputDict[i][10];
                    string channelStatus_Disp = dispenseLynxOutputDict[i][5];

                    string[] data = { barcode_Asp, sourceWell_Asp, volumeReported_Asp, vvpChannel_Asp, channelStatus_Asp, barcode_Disp, sourceWell_Disp, volumeReported_Disp, vvpChannel_Disp, channelStatus_Disp };
                    writer.WriteLine(string.Join(",", data));
                }
            }
        }
        else
        {
            using (StreamWriter writer = File.CreateText(outputPath))
            {
                // Write the headers to the CSV file
                writer.WriteLine(string.Join(",", headers));

                for (int i = 1; i < 97; i++)
                {
                    string barcode_Asp = aspirateLynxOutputDict[i][1];
                    string sourceWell_Asp = aspirateLynxOutputDict[i][9];
                    string volumeReported_Asp = aspirateLynxOutputDict[i][3];
                    string vvpChannel_Asp = aspirateLynxOutputDict[i][10];
                    string channelStatus_Asp = aspirateLynxOutputDict[i][5];

                    string barcode_Disp = dispenseLynxOutputDict[i][1];
                    string sourceWell_Disp = dispenseLynxOutputDict[i][9];
                    string volumeReported_Disp = dispenseLynxOutputDict[i][3];
                    string vvpChannel_Disp = dispenseLynxOutputDict[i][10];
                    string channelStatus_Disp = dispenseLynxOutputDict[i][5];

                    string[] data = { barcode_Asp, sourceWell_Asp, volumeReported_Asp, vvpChannel_Asp, channelStatus_Asp, barcode_Disp, sourceWell_Disp, volumeReported_Disp, vvpChannel_Disp, channelStatus_Disp };
                    writer.WriteLine(string.Join(",", data));
                }
            }
        }
    }

    public static void WriteVVPDataPackage(Dictionary<int, string[]> aspirateLynxOutputDict, Dictionary<int, string[]> dispenseLynxOutputDict, string inputMethodName, string inputDateTimeStamp)
    {
        //get these from outside script, need to be set at start of method
        string methodName = inputMethodName;
        string dateTimeStamp = inputDateTimeStamp;
        string outputPath = "C:\\MethodManager4\\Workspaces\\LO507\\Output\\ForDevelopers\\" + methodName + "\\" + methodName + "_" + dateTimeStamp + "_" + "TransferOutput.csv";
        string[] headers = { "Asp DateTime", "Asp Barcode", "Asp Deck Loc", "Asp Vol Reported", "Asp Residual Vol", "Asp Channel Status", "Asp Flow Rate", "Asp Valve Time", "Asp HPC", "Asp Source Well", "Asp VVP Channel", "Disp DateTime", "Disp Barcode", "Disp Deck Loc", "Disp Vol Reported", "Disp Residual Vol", "Disp Channel Status", "Disp Flow Rate", "Disp Valve Time", "Disp HPC", "Disp Source Well", "Disp VVP Channel" };

        if (File.Exists(outputPath))
        {
            using (StreamWriter writer = File.AppendText(outputPath))
            {
                for (int i = 1; i < 97; i++)
                {
                    string dateTime_Asp = aspirateLynxOutputDict[i][0];
                    string barcode_Asp = aspirateLynxOutputDict[i][1];
                    string deckLocation_Asp = aspirateLynxOutputDict[i][2];
                    string volumeReported_Asp = aspirateLynxOutputDict[i][3];
                    string residualVolume_Asp = aspirateLynxOutputDict[i][4];
                    string channelStatus_Asp = aspirateLynxOutputDict[i][5];
                    string flowRate_Asp = aspirateLynxOutputDict[i][6];
                    string valveTime_Asp = aspirateLynxOutputDict[i][7];
                    string HPC_Asp = aspirateLynxOutputDict[i][8];
                    string sourceWell_Asp = aspirateLynxOutputDict[i][9];
                    string vvpChannel_Asp = aspirateLynxOutputDict[i][10];

                    string dateTime_Disp = dispenseLynxOutputDict[i][0];
                    string barcode_Disp = dispenseLynxOutputDict[i][1];
                    string deckLocation_Disp = dispenseLynxOutputDict[i][2];
                    string volumeReported_Disp = dispenseLynxOutputDict[i][3];
                    string residualVolume_Disp = dispenseLynxOutputDict[i][4];
                    string channelStatus_Disp = dispenseLynxOutputDict[i][5];
                    string flowRate_Disp = dispenseLynxOutputDict[i][6];
                    string valveTime_Disp = dispenseLynxOutputDict[i][7];
                    string HPC_Disp = dispenseLynxOutputDict[i][8];
                    string sourceWell_Disp = dispenseLynxOutputDict[i][9];
                    string vvpChannel_Disp = dispenseLynxOutputDict[i][10];

                    string[] data = { dateTime_Asp, barcode_Asp, deckLocation_Asp, volumeReported_Asp, residualVolume_Asp, channelStatus_Asp, flowRate_Asp, valveTime_Asp, HPC_Asp, sourceWell_Asp, vvpChannel_Asp, dateTime_Disp, barcode_Disp, deckLocation_Disp, volumeReported_Disp, residualVolume_Disp, channelStatus_Disp, flowRate_Disp, valveTime_Disp, HPC_Disp, sourceWell_Disp, vvpChannel_Disp };
                    writer.WriteLine(string.Join(",", data));
                }
            }
        }
        else
        {
            using (StreamWriter writer = File.CreateText(outputPath))
            {
                // Write the headers to the CSV file
                writer.WriteLine(string.Join(",", headers));

                for (int i = 1; i < 97; i++)
                {
                    string dateTime_Asp = aspirateLynxOutputDict[i][0];
                    string barcode_Asp = aspirateLynxOutputDict[i][1];
                    string deckLocation_Asp = aspirateLynxOutputDict[i][2];
                    string volumeReported_Asp = aspirateLynxOutputDict[i][3];
                    string residualVolume_Asp = aspirateLynxOutputDict[i][4];
                    string channelStatus_Asp = aspirateLynxOutputDict[i][5];
                    string flowRate_Asp = aspirateLynxOutputDict[i][6];
                    string valveTime_Asp = aspirateLynxOutputDict[i][7];
                    string HPC_Asp = aspirateLynxOutputDict[i][8];
                    string sourceWell_Asp = aspirateLynxOutputDict[i][9];
                    string vvpChannel_Asp = aspirateLynxOutputDict[i][10];

                    string dateTime_Disp = dispenseLynxOutputDict[i][0];
                    string barcode_Disp = dispenseLynxOutputDict[i][1];
                    string deckLocation_Disp = dispenseLynxOutputDict[i][2];
                    string volumeReported_Disp = dispenseLynxOutputDict[i][3];
                    string residualVolume_Disp = dispenseLynxOutputDict[i][4];
                    string channelStatus_Disp = dispenseLynxOutputDict[i][5];
                    string flowRate_Disp = dispenseLynxOutputDict[i][6];
                    string valveTime_Disp = dispenseLynxOutputDict[i][7];
                    string HPC_Disp = dispenseLynxOutputDict[i][8];
                    string sourceWell_Disp = dispenseLynxOutputDict[i][9];
                    string vvpChannel_Disp = dispenseLynxOutputDict[i][10];

                    string[] data = { dateTime_Asp, barcode_Asp, deckLocation_Asp, volumeReported_Asp, residualVolume_Asp, channelStatus_Asp, flowRate_Asp, valveTime_Asp, HPC_Asp, sourceWell_Asp, vvpChannel_Asp, dateTime_Disp, barcode_Disp, deckLocation_Disp, volumeReported_Disp, residualVolume_Disp, channelStatus_Disp, flowRate_Disp, valveTime_Disp, HPC_Disp, sourceWell_Disp, vvpChannel_Disp };
                    writer.WriteLine(string.Join(",", data));
                }
            }
        }
	}
	
	public void Execute(IMMApp app)
	{
		string methodName = app.GetVariableValue("MethodName");
        string dateTimeStamp = app.GetVariableValue("timeStamp");
        string aspirateLynxOutput = app.GetVariableValue("Lynx.VVP96.Aspirate.Output");
        string dispenseLynxOutput = app.GetVariableValue("Lynx.VVP96.Dispense.Output");

        /////////////////////////////////////////////////
        ///             ASPIRATE                      ///
        /////////////////////////////////////////////////

        // key vvpChannel
        // values: dateTime, barcode, deckLocation, volumeReported, residualVolume, channelStatus, flowRate, valveTime, HPC, sourceWell

        string dateTime_Asp = string.Empty;
        string barcode_Asp = string.Empty;
        string deckLocation_Asp = string.Empty;
        string vvpChannel_Asp = string.Empty;
        string volumeReported_Asp = string.Empty;
        string residualVolume_Asp = string.Empty;
        string channelStatus_Asp = string.Empty;
        string flowRate_Asp = string.Empty;
        string valveTime_Asp = string.Empty;
        string HPC_Asp = string.Empty;
        string sourceWell_Asp = string.Empty;

        var aspirateLynxOutputDict = vvpDataOutputDict(aspirateLynxOutput);

        string errorDescription_Asp = string.Empty;
        string errorDetail_Asp = string.Empty;
        string errorMessage_Asp = string.Empty;

        foreach (KeyValuePair<int, string[]> kvp in aspirateLynxOutputDict) 
        {
            dateTime_Asp = kvp.Value[0];
            barcode_Asp = kvp.Value[1];
            deckLocation_Asp = kvp.Value[2];
            volumeReported_Asp = kvp.Value[3];
            residualVolume_Asp = kvp.Value[4];
            channelStatus_Asp = kvp.Value[5];
            flowRate_Asp = kvp.Value[6];
            valveTime_Asp = kvp.Value[7];
            HPC_Asp = kvp.Value[8];
            sourceWell_Asp = kvp.Value[9];
            vvpChannel_Asp = kvp.Value[10];

            if (channelStatus_Asp != "OK")
            {
                var errorDetailsTuple = ErrorInspection(kvp.Value[6]);
                errorDescription_Asp = errorDetailsTuple.Item1;
                errorDetail_Asp = errorDetailsTuple.Item2;
                errorMessage_Asp = errorDetailsTuple.Item3;
                Console.WriteLine(errorDescription_Asp);
                Console.WriteLine(errorDetail_Asp);
                Console.WriteLine(errorMessage_Asp);
            }

            Console.WriteLine("Aspirate: ");
            Console.WriteLine("  VVP Channel: " + vvpChannel_Asp);
            Console.WriteLine("  Date Time: " + dateTime_Asp);
            Console.WriteLine("  Barcode: " + barcode_Asp);
            Console.WriteLine("  Deck Location: " + deckLocation_Asp);
            Console.WriteLine("  Volume Reported: " + volumeReported_Asp);
            Console.WriteLine("  Residual Volume: " + residualVolume_Asp);
            Console.WriteLine("  Channel Status: " + channelStatus_Asp);
            Console.WriteLine("  Flow Rate: " + flowRate_Asp);
            Console.WriteLine("  Valve Time: " + valveTime_Asp);
            Console.WriteLine("  HPC: " + HPC_Asp);
            Console.WriteLine("  Source Well: " + sourceWell_Asp);
        }


        /////////////////////////////////////////////////
        ///             DISPENSE                      ///
        /////////////////////////////////////////////////


        string dateTime_Disp = string.Empty;
        string barcode_Disp = string.Empty;
        string deckLocation_Disp = string.Empty;
        string vvpChannel_Disp = string.Empty;
        string volumeReported_Disp = string.Empty;
        string residualVolume_Disp = string.Empty;
        string channelStatus_Disp = string.Empty;
        string flowRate_Disp = string.Empty;
        string valveTime_Disp = string.Empty;
        string HPC_Disp = string.Empty;
        string sourceWell_Disp = string.Empty;
        
        var dispenseLynxOutputDict = vvpDataOutputDict(dispenseLynxOutput);

        string errorDescription_Disp = string.Empty;
        string errorDetail_Disp = string.Empty;
        string errorMessage_Disp = string.Empty;

        foreach (KeyValuePair<int, string[]> kvp in dispenseLynxOutputDict)
        {
            dateTime_Disp = kvp.Value[0];
            barcode_Disp = kvp.Value[1];
            deckLocation_Disp = kvp.Value[2];
            volumeReported_Disp = kvp.Value[3];
            residualVolume_Disp = kvp.Value[4];
            channelStatus_Disp = kvp.Value[5];
            flowRate_Disp = kvp.Value[6];
            valveTime_Disp = kvp.Value[7];
            HPC_Disp = kvp.Value[8];
            sourceWell_Disp = kvp.Value[9];
            vvpChannel_Disp = kvp.Value[10];

            if (channelStatus_Disp != "OK")
            {
                var errorDetailsTuple = ErrorInspection(channelStatus_Disp);
                errorDescription_Disp = errorDetailsTuple.Item1;
                errorDetail_Disp = errorDetailsTuple.Item2;
                errorMessage_Disp = errorDetailsTuple.Item3;
                Console.WriteLine(errorDescription_Disp);
                Console.WriteLine(errorDetail_Disp);
                Console.WriteLine(errorMessage_Disp);
            }

            Console.WriteLine("Dispense: ");
            Console.WriteLine("  VVP Channel: " + vvpChannel_Disp);
            Console.WriteLine("  Date Time: " + dateTime_Disp);
            Console.WriteLine("  Barcode: " + barcode_Disp);
            Console.WriteLine("  Deck Location: " + deckLocation_Disp);
            Console.WriteLine("  Volume Reported: " + volumeReported_Disp);
            Console.WriteLine("  Residual Volume: " + residualVolume_Disp);
            Console.WriteLine("  Channel Status: " + channelStatus_Disp);
            Console.WriteLine("  Flow Rate: " + flowRate_Disp);
            Console.WriteLine("  Valve Time: " + valveTime_Disp);
            Console.WriteLine("  HPC: " + HPC_Disp);
            Console.WriteLine("  Source Well: " + sourceWell_Disp);
        }
       	WriteOutputFile(aspirateLynxOutputDict, dispenseLynxOutputDict, methodName, dateTimeStamp);
        WriteVVPDataPackage(aspirateLynxOutputDict, dispenseLynxOutputDict, methodName, dateTimeStamp);
    }
}
//.dL
