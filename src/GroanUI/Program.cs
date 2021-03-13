using System;
using System.Windows.Forms;
using Microsoft.Extensions.DependencyInjection;

namespace GroanUI
{
    static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.SetHighDpiMode(HighDpiMode.SystemAware);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            ConfigureServices();
            Application.Run((Form)ServiceProvider.GetService(typeof(MainForm)));
        }
        internal static IServiceProvider ServiceProvider { get; set; }
        static void ConfigureServices()
        {
            var services = new ServiceCollection();
            services.AddTransient<MainForm>();
            services.AddTransient<MainPresenter>();
            services.AddTransient<MainModel>();
            services.AddTransient<INoiseFactory, NoiseFactory>();
            ServiceProvider = services.BuildServiceProvider();
        }
    }

}
