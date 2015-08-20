using log4net;
using Newtonsoft.Json;
using Squirrel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Nuts
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
            assembliesButton.Click += (o, e) => ShowAssemblyList();
            checkButton.Click += (o, e) => CheckAndUpdate(true);
            debuggerButton.Click += (o, e) => System.Diagnostics.Debugger.Launch();
            resetButton.Click += (o, e) => Reset();
            updateButton.Click += (o, e) => CheckAndUpdate();
        }


        /// <summary>
        /// Add a message to the log and form's display.
        /// </summary>
        private void AddMessage(string message)
        {
            if (String.IsNullOrWhiteSpace(message)) { return; }
            Log.Info(message);
            messageArea.Text = String.Concat(messageArea.Text, message, Environment.NewLine);
            messageArea.Select(messageArea.Text.Length, 0);
            messageArea.ScrollToCaret();
        }

        /// <summary>
        /// Squirrel check and update.
        /// </summary>
        private async Task CheckAndUpdate(bool checkOnly = false)
        {
            // 6/27/15 - Task.Wait always times out. Seems to be an issue with the return of Squirrel's async methods.
            try
            {
                AddMessage("Start of CheckAndUpdate");
                using (var updateManager = new UpdateManager(Program.PackageUrl, Program.PackageId))
                {
                    // Check
                    AddMessage(String.Format("UpdateManager: {0}", JsonConvert.SerializeObject(updateManager, Formatting.Indented)));
                    AddMessage("Calling UpdateManager.CheckForUpdate");
                    var updateInfo = await updateManager.CheckForUpdate();
                    AddMessage(String.Format(
                                        "UpdateManager.CheckForUpdate returned UpdateInfo: {0}", 
                                        JsonConvert.SerializeObject(updateInfo, Formatting.Indented)));
                    if (checkOnly) { return; }

                    // Update
                    if (updateInfo.ReleasesToApply.Count > 0)
                    {
                        AddMessage("Calling UpdateManager.UpdateApp");
                        var releaseEntry = await updateManager.UpdateApp();
                        AddMessage(String.Format(
                                            "UpdateManager.UpdateApp returned ReleaseEntry: {0}",
                                            JsonConvert.SerializeObject(releaseEntry, Formatting.Indented)));
                    }
                    else { AddMessage("No updates to apply"); }
                }
            }
            catch (Exception exception) 
            { 
                Log.Error("Exception in CheckAndUpdate", exception);
                throw;
            }
        }

        private void Reset()
        {
            messageArea.Text = String.Empty;
        }

        /// <summary>
        /// Message a list of all Assembly (.dll and .exe) files in the working directory.
        /// </summary>
        private void ShowAssemblyList()
        {
            var workingDirectory = new DirectoryInfo(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location));
            var assemblyFiles = workingDirectory.GetFiles("*.dll", SearchOption.AllDirectories).ToList();
            assemblyFiles.AddRange(workingDirectory.GetFiles("*.exe", SearchOption.AllDirectories));
            var assemblies = assemblyFiles.Select(f => Assembly.ReflectionOnlyLoadFrom(f.FullName))
                                        .OrderBy(a => a.GetName().Name)
                                        .ToList();
            StringBuilder stringBuilder = new StringBuilder();
            assemblies.ForEach(a =>
                {
                    var assemblyName = a.GetName();
                    stringBuilder.AppendLine(String.Format("{0} - {1}", assemblyName.Name, assemblyName.Version));
                });
            AddMessage(stringBuilder.ToString());
        }


        private static readonly ILog Log = LogManager.GetLogger(typeof(MainForm));
    }
}
