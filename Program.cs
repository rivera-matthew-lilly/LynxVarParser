using System;
class Program
{
    static void Main()
    {
        // Input string containing comma-separated values
        string aspirateLynxOutput = "VO;OK;12;8,A01;2.6;2.2;OK;100.00;0.00;67.4;A01,A02;2.5;2.2;OK;75.00;0.00;69.3;A02,A03;3.7;2.3;OK;155.00;0.01;-6.0;A03,A04;2.4;2.2;OK;66.00;0.00;157.0;A04,A05;2.3;2.1;OK;66.00;0.00;110.2;A05,A06;2.3;2.1;OK;66.00;0.00;179.0;A06,A07;99.7;2.3;OK;168.00;0.58;-0.3;A07,A08;15.2;2.4;OK;193.00;0.07;-1.2;A08,A09;4.9;2.3;OK;185.00;0.01;-4.0;A09,A10;2.5;2.2;OK;100.00;0.00;70.0;A10,A11;3.1;2.3;OK;114.00;0.01;-9.2;A11,A12;2.6;2.3;OK;75.00;0.00;76.3;A12,B01;2.4;2.2;OK;66.00;0.00;112.2;B01,B02;5.0;2.4;OK;173.00;0.02;-2.5;B02,B03;99.7;2.2;OK;161.00;0.60;-0.3;B03,B04;6.4;2.3;OK;186.00;0.02;-4.0;B04,B05;4.1;2.4;OK;170.00;0.01;-4.1;B05,B06;3.0;2.3;OK;140.00;0.01;7.4;B06,B07;2.7;2.2;OK;100.00;0.01;28.8;B07,B08;11.9;2.3;OK;200.00;0.05;-2.4;B08,B09;16.9;2.2;OK;201.00;0.07;-2.0;B09,B10;2.6;2.3;OK;75.00;0.00;94.7;B10,B11;3.9;2.3;OK;145.00;0.01;-7.6;B11,B12;99.8;2.3;OK;169.00;0.58;-0.2;B12,C01;99.8;2.3;OK;163.00;0.60;-0.2;C01,C02;2.9;2.2;OK;116.00;0.01;2.9;C02,C03;99.8;2.4;OK;160.00;0.61;-0.2;C03,C04;6.5;2.3;OK;182.00;0.02;-3.8;C04,C05;99.8;2.3;OK;152.00;0.64;-0.2;C05,C06;2.5;2.3;OK;50.00;0.00;109.8;C06,C07;2.7;2.2;OK;100.00;0.01;18.8;C07,C08;2.6;2.3;OK;75.00;0.00;103.3;C08,C09;13.3;2.3;OK;196.00;0.06;-1.6;C09,C10;2.7;2.3;OK;100.00;0.00;63.9;C10,C11;100.0;2.5;OK;216.00;0.45;0.0;C11,C12;99.8;2.3;OK;175.00;0.56;-0.2;C12,D01;2.6;2.2;OK;100.00;0.00;85.6;D01,D02;3.0;2.4;OK;120.00;0.01;21.8;D02,D03;2.9;2.3;OK;120.00;0.01;12.5;D03,D04;2.7;2.3;OK;100.00;0.00;91.2;D04,D05;2.7;2.2;OK;100.00;0.01;47.7;D05,D06;99.6;2.2;OK;162.00;0.60;-0.4;D06,D07;4.1;2.3;OK;163.00;0.01;-5.7;D07,D08;3.0;2.3;OK;140.00;0.01;0.5;D08,D09;3.1;2.3;OK;133.00;0.01;-0.8;D09,D10;2.5;2.2;OK;75.00;0.00;81.3;D10,D11;2.6;2.2;OK;100.00;0.00;62.5;D11,D12;3.4;2.4;OK;142.00;0.01;-4.1;D12,E01;2.8;2.3;OK;125.00;0.00;34.7;E01,E02;2.5;2.1;OK;100.00;0.00;89.3;E02,E03;2.6;2.3;OK;75.00;0.00;54.2;E03,E04;5.8;2.3;OK;184.00;0.02;-4.9;E04,E05;2.5;2.3;OK;66.00;0.00;127.8;E05,E06;2.6;2.3;OK;75.00;0.00;126.5;E06,E07;2.9;2.2;OK;140.00;0.01;3.2;E07,E08;2.6;2.2;OK;100.00;0.00;80.7;E08,E09;2.7;2.2;OK;100.00;0.01;58.2;E09,E10;3.1;2.3;OK;133.00;0.01;-0.2;E10,E11;2.3;2.1;OK;66.00;0.00;140.4;E11,E12;3.3;2.3;OK;142.00;0.01;-8.3;E12,F01;2.6;2.2;OK;100.00;0.00;77.8;F01,F02;4.0;2.2;OK;163.00;0.01;-8.0;F02,F03;8.7;2.5;OK;187.00;0.03;-0.8;F03,F04;2.7;2.3;OK;100.00;0.00;103.9;F04,F05;2.5;2.2;OK;75.00;0.00;118.5;F05,F06;99.7;2.2;OK;156.00;0.62;-0.3;F06,F07;3.1;2.2;OK;128.00;0.01;-10.7;F07,F08;20.9;2.2;OK;194.00;0.10;-1.8;F08,F09;2.5;2.2;OK;75.00;0.00;40.8;F09,F10;2.7;2.2;OK;100.00;0.01;58.2;F10,F11;12.4;2.3;OK;190.00;0.05;-2.0;F11,F12;3.8;2.3;OK;166.00;0.01;-5.0;F12,G01;2.7;2.2;OK;125.00;0.00;33.1;G01,G02;6.7;2.3;OK;191.00;0.02;-3.5;G02,G03;4.5;2.4;OK;161.00;0.01;-4.1;G03,G04;3.6;2.4;OK;150.00;0.01;-3.9;G04,G05;2.9;2.3;OK;120.00;0.01;11.7;G05,G06;2.5;2.1;OK;100.00;0.00;90.3;G06,G07;2.4;2.2;OK;50.00;0.00;107.4;G07,G08;2.5;2.2;OK;75.00;0.00;70.0;G08,G09;2.8;2.3;OK;125.00;0.00;52.9;G09,G10;2.7;2.2;OK;125.00;0.00;19.1;G10,G11;13.6;2.3;OK;194.00;0.06;-2.1;G11,G12;2.7;2.3;OK;100.00;0.00;68.8;G12,H01;5.9;2.2;OK;176.00;0.02;-5.6;H01,H02;2.5;2.2;OK;75.00;0.00;114.0;H02,H03;2.4;2.1;OK;75.00;0.00;103.0;H03,H04;2.9;2.3;OK;120.00;0.01;14.0;H04,H05;2.6;2.2;OK;100.00;0.00;71.1;H05,H06;2.6;2.2;OK;100.00;0.00;57.6;H06,H07;2.4;2.2;OK;50.00;0.00;133.8;H07,H08;2.5;2.2;OK;75.00;0.00;110.0;H08,H09;99.7;2.2;OK;163.00;0.60;-0.3;H09,H10;6.8;2.3;OK;180.00;0.03;-3.4;H10,H11;2.6;2.2;OK;100.00;0.00;98.6;H11,H12;2.5;2.2;OK;75.00;0.00;69.3;H12,Aspirate,VVP96,\"Sup_03\",aL1CAM01.1CL20,Loc_10,0,0,0,05/03/2023 11:39:45";

        string dispenseLynxOutput = "VO;OK;12;8,A01;950.2;2.8;OK;248.00;3.82;0.0;A01,A02;950.2;2.9;OK;252.00;3.75;0.0;A02,A03;950.3;2.9;OK;253.00;3.74;0.0;A03,A04;950.2;2.9;OK;248.00;3.81;0.0;A04,A05;950.7;3.3;OK;236.00;4.01;0.1;A05,A06;950.2;2.9;OK;239.00;3.96;0.0;A06,A07;950.0;2.6;OK;255.00;3.71;0.0;A07,A08;950.1;2.7;OK;251.00;3.76;0.0;A08,A09;950.1;2.7;OK;256.00;3.69;0.0;A09,A10;950.1;2.7;OK;255.00;3.71;0.0;A10,A11;950.3;2.9;OK;248.00;3.81;0.0;A11,A12;950.2;2.8;OK;258.00;3.67;0.0;A12,B01;950.3;2.9;OK;247.00;3.83;0.0;B01,B02;950.8;3.4;OK;237.00;3.98;0.1;B02,B03;950.1;2.8;OK;248.00;3.82;0.0;B03,B04;950.1;2.7;OK;251.00;3.76;0.0;B04,B05;950.3;3.0;OK;245.00;3.86;0.0;B05,B06;950.4;3.0;OK;247.00;3.82;0.0;B06,B07;950.1;2.7;OK;254.00;3.72;0.0;B07,B08;950.2;2.8;OK;259.00;3.65;0.0;B08,B09;950.2;2.9;OK;262.00;3.61;0.0;B09,B10;950.2;2.9;OK;250.00;3.79;0.0;B10,B11;950.3;2.9;OK;247.00;3.83;0.0;B11,B12;950.3;2.9;OK;261.00;3.62;0.0;B12,C01;950.3;2.9;OK;246.00;3.84;0.0;C01,C02;950.1;2.8;OK;251.00;3.77;0.0;C02,C03;950.6;3.2;OK;245.00;3.86;0.1;C03,C04;950.5;3.1;OK;243.00;3.90;0.1;C04,C05;950.7;3.3;OK;241.00;3.92;0.1;C05,C06;950.5;3.1;OK;244.00;3.88;0.1;C06,C07;950.4;3.0;OK;249.00;3.80;0.0;C07,C08;950.1;2.8;OK;249.00;3.80;0.0;C08,C09;950.3;2.9;OK;253.00;3.74;0.0;C09,C10;950.3;3.0;OK;254.00;3.73;0.0;C10,C11;950.1;2.8;OK;247.00;3.83;0.0;C11,C12;950.2;2.8;OK;266.00;3.56;0.0;C12,D01;950.4;3.0;OK;249.00;3.80;0.0;D01,D02;950.1;2.8;OK;250.00;3.78;0.0;D02,D03;950.4;3.0;OK;247.00;3.83;0.0;D03,D04;950.5;3.1;OK;249.00;3.80;0.1;D04,D05;950.4;3.0;OK;239.00;3.96;0.0;D05,D06;950.2;2.8;OK;252.00;3.76;0.0;D06,D07;950.3;3.0;OK;247.00;3.83;0.0;D07,D08;950.4;3.0;OK;254.00;3.73;0.0;D08,D09;950.3;2.9;OK;249.00;3.79;0.0;D09,D10;950.3;3.0;OK;250.00;3.78;0.0;D10,D11;950.4;3.0;OK;245.00;3.86;0.0;D11,D12;950.1;2.7;OK;264.00;3.59;0.0;D12,E01;950.3;2.9;OK;246.00;3.84;0.0;E01,E02;950.7;3.3;OK;237.00;4.00;0.1;E02,E03;950.4;3.0;OK;247.00;3.83;0.0;E03,E04;950.6;3.2;OK;241.00;3.93;0.1;E04,E05;950.8;3.4;OK;241.00;3.93;0.1;E05,E06;950.4;3.1;OK;243.00;3.88;0.0;E06,E07;950.1;2.8;OK;251.00;3.77;0.0;E07,E08;950.4;3.0;OK;245.00;3.86;0.0;E08,E09;950.0;2.7;-4;252.00;3.76;0.0;E09,E10;950.5;3.1;OK;245.00;3.86;0.1;E10,E11;950.3;2.9;OK;249.00;3.80;0.0;E11,E12;950.2;2.9;OK;252.00;3.75;0.0;E12,F01;950.3;3.0;OK;249.00;3.80;0.0;F01,F02;950.4;3.1;OK;245.00;3.86;0.0;F02,F03;950.6;3.2;OK;245.00;3.87;0.1;F03,F04;950.4;3.0;OK;239.00;3.96;0.0;F04,F05;950.5;3.1;OK;243.00;3.90;0.1;F05,F06;950.5;3.1;OK;242.00;3.91;0.1;F06,F07;950.0;2.6;OK;255.00;3.70;0.0;F07,F08;950.2;2.8;OK;258.00;3.67;0.0;F08,F09;950.1;2.8;OK;253.00;3.74;0.0;F09,F10;950.2;2.9;OK;258.00;3.67;0.0;F10,F11;950.3;2.9;OK;243.00;3.89;0.0;F11,F12;950.3;2.9;OK;251.00;3.77;0.0;F12,G01;950.2;2.8;OK;248.00;3.82;0.0;G01,G02;950.2;2.8;OK;248.00;3.81;0.0;G02,G03;950.4;3.0;OK;248.00;3.81;0.0;G03,G04;950.4;3.0;OK;244.00;3.88;0.0;G04,G05;950.5;3.1;OK;248.00;3.81;0.1;G05,G06;950.5;3.1;OK;246.00;3.85;0.1;G06,G07;950.2;2.8;OK;253.00;3.74;0.0;G07,G08;950.2;2.8;OK;255.00;3.71;0.0;G08,G09;950.2;2.8;OK;258.00;3.66;0.0;G09,G10;950.4;3.0;OK;258.00;3.67;0.0;G10,G11;950.3;2.9;OK;249.00;3.80;0.0;G11,G12;950.4;3.0;OK;272.00;3.48;0.0;G12,H01;950.4;3.0;OK;249.00;3.80;0.0;H01,H02;950.3;2.9;OK;250.00;3.78;0.0;H02,H03;950.5;3.1;OK;245.00;3.87;0.1;H03,H04;950.3;2.9;OK;246.00;3.84;0.0;H04,H05;950.3;3.0;OK;248.00;3.82;0.0;H05,H06;950.4;3.0;OK;250.00;3.79;0.0;H06,H07;950.3;2.9;OK;248.00;3.81;0.0;H07,H08;950.0;2.7;OK;257.00;3.68;0.0;H08,H09;950.2;2.8;OK;255.00;3.71;0.0;H09,H10;950.4;3.0;OK;247.00;3.83;0.0;H10,H11;950.3;2.9;OK;250.00;3.79;0.0;H11,H12;950.1;2.8;OK;255.00;3.71;0.0;H12,Dispense,VVP96,\"96 MasterBlock_19\",,Loc_39,0,0,0,05/04/2023 11:09:02";


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

        var aspirateLynxOutputDict = FunctionBase.vvpDataOutputDict(aspirateLynxOutput);

        string errorDescription_Asp = string.Empty;
        string errorDetail_Asp = string.Empty;
        string errorMessage_Asp = string.Empty;

        foreach (KeyValuePair<string, string[]> kvp in aspirateLynxOutputDict) 
        {
            vvpChannel_Asp = kvp.Key;

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

            if (channelStatus_Asp != "OK")
            {
                var errorDetailsTuple =FunctionBase.ErrorInspection(kvp.Value[6]);
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
        
        var dispenseLynxOutputDict = FunctionBase.vvpDataOutputDict(dispenseLynxOutput);

        string errorDescription_Disp = string.Empty;
        string errorDetail_Disp = string.Empty;
        string errorMessage_Disp = string.Empty;

        foreach (KeyValuePair<string, string[]> kvp in dispenseLynxOutputDict)
        {
            vvpChannel_Disp = kvp.Key;

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

            if (channelStatus_Disp != "OK")
            {
                var errorDetailsTuple = FunctionBase.ErrorInspection(channelStatus_Disp);
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

    }
}
