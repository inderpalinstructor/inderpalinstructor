using Automation.Framework.Core.WebUI.Abstraction;
using Automation.Framework.Core.WebUI.Params;
using Serilog;
using Serilog.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Automation.Framework.Core.WebUI.Reports
{
    public class Logging : ILogging
    {
        LoggingLevelSwitch _loggingLevelSwitch;
        IDefaultVariables _idefaultVariables;
        public Logging(IDefaultVariables idefaultVariables)
        {
            // DefaultVariables defaultVariables = new DefaultVariables();
            _idefaultVariables = idefaultVariables;
            _loggingLevelSwitch =new LoggingLevelSwitch(Serilog.Events.LogEventLevel.Debug);
            Log.Logger = new LoggerConfiguration().MinimumLevel.ControlledBy(_loggingLevelSwitch)
                .WriteTo.File(_idefaultVariables.getLog, outputTemplate: "{Timestamp:yyyy-MM-dd HH:mm:ss.fff zzz} [{Level:u3}] {Message:lj}{NewLine}{Exception}")
                .Enrich.WithThreadName().CreateLogger();
        }

        public void LogLevel(string level)
        {
            switch (level.ToLower())
            {
                case "error":
                    _loggingLevelSwitch.MinimumLevel = Serilog.Events.LogEventLevel.Error;
                    break;
                case "information":
                    _loggingLevelSwitch.MinimumLevel = Serilog.Events.LogEventLevel.Information;
                    break;
                case "warning":
                    _loggingLevelSwitch.MinimumLevel = Serilog.Events.LogEventLevel.Warning;
                    break;
                default:
                    _loggingLevelSwitch.MinimumLevel = Serilog.Events.LogEventLevel.Debug;
                    break;
            }
        }

        public void Debug(string message)
        {
            Log.Debug(message);
        }

        public void Error(string message)
        {
            Log.Error(message);
        }

        public void Fatal(string message)
        {
            Log.Fatal(message);
        }

        public void Warning(string message)
        {
            Log.Warning(message);
        }

        public void Information(string message)
        {
            Log.Information(message);
        }





    }
}
