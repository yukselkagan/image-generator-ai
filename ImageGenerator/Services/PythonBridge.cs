using System.Diagnostics;
using System.Text;
using System.Text.Json;

namespace ImageGenerator.Services
{
    public class PythonBridge : IDisposable
    {
        private readonly Process _process;
        private readonly StreamWriter _stdin;
        private readonly StreamReader _stdout;
        private readonly StreamReader _stderr;

        public PythonBridge()
        {
            string pythonExePath = FindPythonPath();
            string scriptPath = Path.Combine(AppContext.BaseDirectory, @"artificial-intelligence\main.py");
            string outputPath = Path.Combine(AppContext.BaseDirectory, @"artificial-intelligence");

            var psi = new ProcessStartInfo
            {
                FileName = pythonExePath,
                Arguments = $"\"{scriptPath}\"",
                UseShellExecute = false,
                RedirectStandardInput = true,
                RedirectStandardOutput = true,
                RedirectStandardError = true,
                StandardOutputEncoding = Encoding.UTF8,
                WorkingDirectory = outputPath,
                CreateNoWindow = true              
            };

            _process = new Process { StartInfo = psi };
            _process.Start();

            _stdin = _process.StandardInput;
            _stdout = _process.StandardOutput;
            _stderr = _process.StandardError;
        }

        public List<string> CallFunction(string functionName, string parameter1, string parameter2)
        {
            var payload = new
            {
                function = functionName,
                parameter1 = parameter1 ?? "none",
                parameter2 = parameter2 ?? "none"
            };

            string jsonCommand = JsonSerializer.Serialize(payload);
            _stdin.WriteLine(jsonCommand);
            _stdin.Flush();

            string response = _stdout.ReadLine();
            if (string.IsNullOrEmpty(response))
            {
                string errorLog = _stderr.ReadToEnd();
                throw new Exception($"No response from Python. Error: {errorLog}");
            }

            using var doc = JsonDocument.Parse(response);
            if (doc.RootElement.TryGetProperty("result", out var result))
            {
                if (result.ValueKind == JsonValueKind.Array)
                {
                    var list = new List<string>();
                    foreach (var item in result.EnumerateArray())
                    {
                        list.Add(item.GetString() ?? string.Empty);
                    }
                    return list;
                }
                else
                {
                    return new List<string> { result.GetString() ?? string.Empty };
                }               
            }
            else if (doc.RootElement.TryGetProperty("error", out var error))
            {
                throw new Exception($"Python error: {error.GetString()}");
            }

            throw new Exception("Invalid response from Python.");
        }

        private string FindPythonPath()
        {
            try
            {
                var process = new Process
                {
                    StartInfo = new ProcessStartInfo
                    {
                        FileName = "cmd.exe",
                        Arguments = "/c where python",
                        RedirectStandardOutput = true,
                        UseShellExecute = false,
                        CreateNoWindow = true
                    }
                };
                process.Start();
                string output = process.StandardOutput.ReadToEnd();
                process.WaitForExit();

                if (!string.IsNullOrWhiteSpace(output))
                {
                    string path = output.Split(new[] { '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries)[0];
                    if (File.Exists(path))
                    {
                        return path;
                    }
                }
            }
            catch { }
            return null;
        }

        public void Dispose()
        {
            try
            {
                if (!_process.HasExited)
                    _process.Kill();
            }
            catch {  }
            finally
            {
                _stdin?.Dispose();
                _stdout?.Dispose();
                _stderr?.Dispose();
                _process?.Dispose();
            }
        }
    }


}
