// See https://aka.ms/new-console-template for more information

using System.Diagnostics;

if (args.Length == 0)
{
    Console.WriteLine("No arguments found in Superslicer Startup");
    Console.ReadLine();
    System.Environment.Exit(1);
}
Console.WriteLine($"Starting Superslicer with custom --datadir and argument {args[0].ToString()}");
ProcessStartInfo startInfo = new ProcessStartInfo(@"D:\SynologyDrive\SharedDesktop\Print\SuperSlicer\superslicer.exe");
startInfo.WindowStyle = ProcessWindowStyle.Normal;
startInfo.WorkingDirectory = @"D:\SynologyDrive\SharedDesktop\Print\SuperSlicer";

string stlFileArg = args[0] ;
string dataDir = @" --datadir D:\SynologyDrive\SharedDesktop\Print\SuperslicerDatadir";
startInfo.Arguments = stlFileArg + dataDir;
Console.WriteLine($"Starting Superslicer with arguments {startInfo.Arguments}");
Process.Start(startInfo);


