using System;
using System.Data.SqlClient;

public class FunctionBase
{
    //public static (string, string, string, string, string, string, string, string, string, string, string) TransferStringParser(string input)
    public static Dictionary<string, string[]> vvpDataOutputDict (string input)
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

        Dictionary<string, string[]> vvpDataPackage = new Dictionary<string, string[]>();
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
                vvpDataPackage.Add(vvpChannel, new string[] { dateTime, barcode, deckLocation, volumeReported, residualVolume, channelStatus, flowRate, valveTime, HPC, sourceWell });
            }
            j++;
        }
        //return (dateTime, barcode, deckLocation, vvpChannel, volumeReported, residualVolume, channelStatus, flowRate, valveTime, HPC, sourceWell);
        return vvpDataPackage;
    }

    //Not working for me right no :(
    public static void InsertRow(string dateTime, string barcode, string deckLocation, string vvpChannel, string volumeReported, string residualVolume, string channelStatus, string flowRate, string valveTime, string HPC, string sourceWell)
    {
        // Create a connection string
        //string databaseName = "C:\\Matthew IC Copy For Test\\Database\\LynxData.db";
        string connectionString = "server=HYBRID-9HQ56T8G;database=lynxalpha;uid=root;password=Alphacompany13#a;";

        // Create a SQL query
        string query = "INSERT INTO myTable (Column1, Column2, Column3, Column4, Column5, Column6, Column7, Column8, Column9, Column10, Column11) VALUES (@Value1, @Value2, @Value3, @Value4, @Value5, @Value6, @Value7, @Value8, @Value9, @Value10, @Value11)";

        // Create a connection and command objects
        using (SqlConnection connection = new SqlConnection(connectionString))
        using (SqlCommand command = new SqlCommand(query, connection))
        {
            // Add parameters to the command
            command.Parameters.AddWithValue("@Value1", dateTime);
            command.Parameters.AddWithValue("@Value2", barcode);
            command.Parameters.AddWithValue("@Value3", deckLocation);
            command.Parameters.AddWithValue("@Value4", vvpChannel);
            command.Parameters.AddWithValue("@Value5", volumeReported);
            command.Parameters.AddWithValue("@Value6", residualVolume);
            command.Parameters.AddWithValue("@Value7", channelStatus);
            command.Parameters.AddWithValue("@Value8", flowRate);
            command.Parameters.AddWithValue("@Value9", valveTime);
            command.Parameters.AddWithValue("@Value10", HPC);
            command.Parameters.AddWithValue("@Value11", sourceWell);

            // Open the connection and execute the command
            connection.Open();
            command.ExecuteNonQuery();
        }
    }

    /*
     Error Code	|   Description                         |	Details	                    |   Message for operator                        |   Additional Search Key
    -3	        |   Pressure Error                      |	                            |   The Lynx has detected a pressure error      |   Aspirate results: 
    -4      	|   Timeout		                        |                               |   The Lynx has timed out                      |   Aspirate results: 
    -5          |   Sensor auto-zero error	            |	                            |   The Lynx has a sensor auto-zero error       |   Aspirate results: 
    -21	        |   Aspiration Error: Empty Well        |   Aspiration of Air           |	The Lynx has detected an empty well         |   
    -22	        |   Aspiration Error: Short Sample      |   Start in Air; End in Liquid	|   The Lynx has detected a short sample        |   
    -23	        |   Aspiration Error: Tracking Error    |   Start in Liquid; End in Air	|   The Lynx has detected a bubble in sample    |   
    -24	        |   Clogging Error	                    |   Aspirate and Dispense	    |   The Lynx has a clogged channel              |   Aspirate results: 
    -25	        |   Blocked Tip Error	                |   Tip blocked before pick up	|   The Lynx has a blocked tip                  |   Dispense results: 
    */

    public static (string, string, string) ErrorInspection(string channelStatus)
    {
        /*
        Dictionary<string, string[]> errorInspectionDict = new Dictionary<string, string[]>();
        errorInspectionDict.Add("-3", new string[] { "Pressure Error", "", "The Lynx has detected a pressure error" });
        errorInspectionDict.Add("-4", new string[] { "Timeout", "", "The Lynx has timed out" });
        errorInspectionDict.Add("-5", new string[] { "Sensor auto - zero error", "", "The Lynx has a sensor auto - zero error" });
        errorInspectionDict.Add("-21", new string[] { "Aspiration Error: Empty Well", "Aspiration of Air", "The Lynx has detected an empty well" });
        errorInspectionDict.Add("-22", new string[] { "Aspiration Error: Short Sample", "Start in Air; End in Liquid", "The Lynx has detected a short sample" });
        errorInspectionDict.Add("-23", new string[] { "Aspiration Error: Tracking Error", "Start in Liquid; End in Air", "The Lynx has detected a bubble in sample" });
        errorInspectionDict.Add("-24", new string[] { "Clogging Error",	"Aspirate and Dispense", "The Lynx has a clogged channel" });
        errorInspectionDict.Add("-25", new string[] { "Blocked Tip Error", "Tip blocked before pick up", "The Lynx has a blocked tip" });
        */
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

        return (errorDescription, errorDetail, errorMessage);
    }
}
