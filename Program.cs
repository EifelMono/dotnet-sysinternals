using System;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;

namespace DotNetCode
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args?.Length > 0 && (args[0] == "--help" || args[0] == "-h"))
            {
                string Help = $"dotnet-sysinternals {System.Reflection.Assembly.GetExecutingAssembly().GetName().Version.ToString()} starts the selected sysinternal program.";
                Console.WriteLine(Help);
                return;
            }
            var isWindows = System.Runtime.InteropServices.RuntimeInformation.IsOSPlatform(System.Runtime.InteropServices.OSPlatform.Windows);

            if (!isWindows)
            {
                Console.WriteLine("sysinternals works only on Windows");
                return;
            }

            var dotnetDllPath = Path.GetDirectoryName(Environment.GetCommandLineArgs()[0]);
            var sysinternalsPath = Path.Combine(dotnetDllPath, "sysinternals");

            if (!Directory.Exists(sysinternalsPath))
            {
                try
                {
                    System.IO.Compression.ZipFile.ExtractToDirectory(Path.Combine(dotnetDllPath, "sysinternals.zip"), dotnetDllPath, true);
                }
                catch { }
            }

            var program = args.Length > 0 ? args[0] : "";
            if (!string.IsNullOrEmpty(program))
            {
                if (program == "list")
                {
                    var param = args.Length > 1 ? args[1] : "*";
                    foreach (var file in Directory.GetFiles(sysinternalsPath, param))
                        Console.WriteLine(Path.GetFileName(file));
                }
                else
                {
                    var exeFiles = Directory.GetFiles(sysinternalsPath, program + "*.exe");
                    if (exeFiles.Length == 1)
                    {
                        try
                        {
                            var exe = exeFiles[0];
                            var dir = Directory.GetCurrentDirectory();
                            Process.Start(exe, dir);
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine("Can no start sysinternalsPath {program}");
                            Console.WriteLine(ex);
                        }
                    }
                    else
                    {
                        Console.WriteLine("more than 1 exe file found");
                         foreach (var file in exeFiles)
                            Console.WriteLine(Path.GetFileName(file));
                    }
                }
            }
            else
            {
                Console.WriteLine("program missing");
            }
        }
    }
}