using System;
using System.Diagnostics;
using System.IO;
using TacoMovies.ReportService.Contracts;

namespace TacoMovies.ReportService
{
    public class ReportServiceProvider : IReportServiceProvider
    {
        private readonly string reportLocation;

        public ReportServiceProvider(string reportLocation)
        {
            if (string.IsNullOrEmpty(reportLocation))
            {
                throw new ArgumentException("The report location argument cannot be null");
            }

            this.reportLocation = reportLocation;
        }

        public void Start()
        {
            byte[] buffer = File.ReadAllBytes(this.reportLocation);

            // save to temp file
            string path = Path.Combine(Path.GetTempPath(), Guid.NewGuid() + ".pdf");
            File.WriteAllBytes(path, buffer);

            var process = new Process
            {
                StartInfo = new ProcessStartInfo($"{path}")
                {
                    UseShellExecute = true,
                    CreateNoWindow = true,
                }
            };

            process.Start();
            process.EnableRaisingEvents = true;
            process.Exited += delegate
            {
                // clean up temp file
                File.Delete(path);
            };
        }
    }
}