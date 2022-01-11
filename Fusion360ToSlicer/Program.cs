// See https://aka.ms/new-console-template for more information

using System.Diagnostics;
using Fusion360ToSlicer;
using Microsoft.Extensions.Configuration;
using Microsoft.VisualBasic.FileIO;

var builder = new ConfigurationBuilder()
    .AddJsonFile($"appsettings.json", false, true);
var config = builder.Build();

// Get values from the config given their key and their target type.
Settings settings = config.GetRequiredSection("Settings").Get<Settings>();

// Write the values to the console.
Console.WriteLine($"SlicerExePath = {settings.SlicerExePath}");
Console.WriteLine($"SlicerExeFolder = {FileSystem.GetParentPath(settings.SlicerExePath)}");
Console.WriteLine($"Datadirpath = {settings.SlicerDataDirPath}");

if (args.Length == 0)
{
    Console.WriteLine("No arguments found in Superslicer Startup");
    Console.ReadLine();
    System.Environment.Exit(1);
}
Console.WriteLine($"Starting Superslicer with custom --datadir and argument {args[0].ToString()}");
ProcessStartInfo startInfo = new ProcessStartInfo(settings.SlicerExePath);
startInfo.WindowStyle = ProcessWindowStyle.Normal;
startInfo.WorkingDirectory = FileSystem.GetParentPath(settings.SlicerExePath);

string stlFileArg = args[0];
string dataDir = @$" --datadir {settings.SlicerDataDirPath}";
startInfo.Arguments = stlFileArg + dataDir;
Console.WriteLine($"Starting Superslicer with arguments {startInfo.Arguments}");
Process.Start(startInfo);



