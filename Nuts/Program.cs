using log4net;
using Newtonsoft.Json;
using Squirrel;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Nuts
{
    static class Program
    {
        [STAThread]
        static void Main()
        {
            Log.InfoFormat(
                    "static void Main; PackageID: {0}, PackageUrl: {1}",
                    Program.PackageId,
                    Program.PackageUrl);

            // Squirrelize
            SquirrelAwareApp.HandleEvents(
                    onInitialInstall: OnInitialInstall,
                    onAppUpdate: OnAppUpdate,
                    onAppObsoleted: OnAppObsoleted,
                    onAppUninstall: OnAppUninstall,
                    onFirstRun: OnFirstRun,
                    arguments: null);

            // Standard Winforms
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainForm());
        }

        #region Squirrel Events

        private static void OnAppObsoleted(Version version)
        {
            Log.InfoFormat("OnAppObsoleted for version {0}", version);
        }

        private static void OnAppUninstall(Version version)
        {
            try
            {
                Log.InfoFormat("OnAppUninstall for version {0}", version);
                using (var updateManager = new UpdateManager(Program.PackageUrl, Program.PackageId))
                {
                    updateManager.RemoveShortcutsForExecutable("Nuts.exe", ShortcutLocation.Desktop);
                }
            }
            catch (Exception exception)
            {
                Log.Error("OnAppUninstall encountered and exception", exception);
                throw;
            }
        }

        private static void OnAppUpdate(Version version)
        {
            Log.InfoFormat("OnAppUpdate for version {0}", version);
        }

        private static void OnFirstRun()
        {
            Log.Info("OnFirstRun");
        }

        private static void OnInitialInstall(Version version)
        {
            try
            {
                Log.InfoFormat("OnInitialInstall for version {0}", version);
                using (var updateManager = new UpdateManager(Program.PackageUrl, Program.PackageId))
                {
                    updateManager.CreateShortcutsForExecutable("Nuts.exe", ShortcutLocation.Desktop, false);
                }
            }
            catch (Exception exception)
            {
                Log.Error("OnInitialInstall encountered and exception", exception);
                throw;
            }
        }

        #endregion

        #region Static Plumbing

        static Program()
        {
            log4net.Config.XmlConfigurator.Configure();
            Log = LogManager.GetLogger(typeof(Program));
            PackageId = ConfigurationManager.AppSettings["PackageId"];
            PackageUrl = ConfigurationManager.AppSettings["PackageUrl"];
        }
        private static readonly ILog Log;
        public static readonly string PackageId;
        public static readonly string PackageUrl;

        #endregion
    }
}
