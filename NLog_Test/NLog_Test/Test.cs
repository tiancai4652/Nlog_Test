using NLog;
using NLog.Config;
using NLog.Targets;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;


namespace NLog_Test
{
    public class Test
    {
        /// 借用Nlog的测试思路
        /// https://github.com/NLog/NLog/NLog/tests/NLog.UnitTests/LoggerTests.cs
        /// 思路;借用DebugTarget的LastMessage和Counter的属性可以知道日志写的次数和信息，用于和实际值和目标值相比较

        /// 可以通过看配置文件和输出来获取自己想要的配置文件，Like Instance
        /// 按特征分组可以得到分组值描述的信息

        [Trait("Base", "Target.Type;Logger,level,writeTo")]
        [Fact]
        public void Base()
        {
            //logger.Debug("Debug");
            //Like
            //2019-03-21 17:04:55.7835|DEBUG|NLog_Test.Test|Debug
            //2019 - 03 - 21 18:13:27.9291 | FATAL | NLog_Test.Test | Fatal
            //2019 - 03 - 21 18:13:49.7761 | ERROR | NLog_Test.Test | Error
            //2019 - 03 - 21 18:14:03.0481 | WARN | NLog_Test.Test | Warn
            //2019 - 03 - 21 18:14:21.9421 | INFO | NLog_Test.Test | Info
            //2019 - 03 - 21 18:14:39.8131 | DEBUG | NLog_Test.Test | Debug

            //Config
            LogManager.Configuration = XmlLoggingConfiguration.CreateFromXmlString(@"
            <nlog>
                <targets>
                    <target name='debug1' type='Debug'  />
                    <target name='debug2' type='Debug'  />
                    <target name='debug3' type='Debug'  />
                    <target name='debug4' type='Debug'  />
                    <target name='debug5' type='Debug'  />
                </targets>
                <rules>
                    <logger name='*' level='Debug' writeTo='debug1' />
                    <logger name='*' level='Info' writeTo='debug2' />
                    <logger name='*' level='Warn' writeTo='debug3' />
                    <logger name='*' level='Error' writeTo='debug4' />
                    <logger name='*' level='Fatal' writeTo='debug5' />
                </rules>
            </nlog>");

            ILogger logger = LogManager.GetCurrentClassLogger();
            DebugTarget debugTarget_Debug = (DebugTarget)LogManager.Configuration.FindTargetByName("debug1");
            DebugTarget debugTarget_Info = (DebugTarget)LogManager.Configuration.FindTargetByName("debug2");
            DebugTarget debugTarget_Warn = (DebugTarget)LogManager.Configuration.FindTargetByName("debug3");
            DebugTarget debugTarget_Error = (DebugTarget)LogManager.Configuration.FindTargetByName("debug4");
            DebugTarget debugTarget_Fatal = (DebugTarget)LogManager.Configuration.FindTargetByName("debug5");

            logger.Fatal("Fatal");
            Assert.Equal(1, debugTarget_Fatal.Counter);
            string s = debugTarget_Fatal.LastMessage;
            Assert.Contains("Fatal", s);


            logger.Error("Error");
            Assert.Equal(1, debugTarget_Error.Counter);
            s = debugTarget_Error.LastMessage;
            Assert.Contains("Error", s);


            logger.Warn("Warn");
            Assert.Equal(1, debugTarget_Warn.Counter);
            s = debugTarget_Warn.LastMessage;
            Assert.Contains("Warn", s);


            logger.Info("Info");
            Assert.Equal(1, debugTarget_Info.Counter);
            s = debugTarget_Info.LastMessage;
            Assert.Contains("Info", s);


            logger.Debug("Debug");
            Assert.Equal(1, debugTarget_Debug.Counter);
            s = debugTarget_Debug.LastMessage;
            Assert.Contains("Debug", s);


        }

        [Trait("Base", "Target.Type;Logger,level,writeTo")]
        [Fact]
        public void Base1()
        {
            //logger.Debug("Debug");
            //Like
            //2019-03-21 17:04:55.7835|DEBUG|NLog_Test.Test|Debug
            //2019 - 03 - 21 18:13:27.9291 | FATAL | NLog_Test.Test | Fatal
            //2019 - 03 - 21 18:13:49.7761 | ERROR | NLog_Test.Test | Error
            //2019 - 03 - 21 18:14:03.0481 | WARN | NLog_Test.Test | Warn
            //2019 - 03 - 21 18:14:21.9421 | INFO | NLog_Test.Test | Info
            //2019 - 03 - 21 18:14:39.8131 | DEBUG | NLog_Test.Test | Debug

            //Config
            LogManager.Configuration = XmlLoggingConfiguration.CreateFromXmlString(@"
            <nlog>
                <targets>
                    <target name='debug1' type='Debug'  />
                    <target name='debug2' type='Debug'  />
                    <target name='debug3' type='Debug'  />
                    <target name='debug4' type='Debug'  />
                    <target name='debug5' type='Debug'  />
                </targets>
                <rules>
                    <logger name='*' level='Debug' writeTo='debug1' />
                    <logger name='*' level='Info' writeTo='debug2' />
                    <logger name='*' level='Warn' writeTo='debug3' />
                    <logger name='*' level='Error' writeTo='debug4' />
                    <logger name='*' level='Fatal' writeTo='debug5' />
                </rules>
            </nlog>");

            ILogger logger = LogManager.GetCurrentClassLogger();
            DebugTarget debugTarget_Debug = (DebugTarget)LogManager.Configuration.FindTargetByName("debug1");
            DebugTarget debugTarget_Info = (DebugTarget)LogManager.Configuration.FindTargetByName("debug2");
            DebugTarget debugTarget_Warn = (DebugTarget)LogManager.Configuration.FindTargetByName("debug3");
            DebugTarget debugTarget_Error = (DebugTarget)LogManager.Configuration.FindTargetByName("debug4");
            DebugTarget debugTarget_Fatal = (DebugTarget)LogManager.Configuration.FindTargetByName("debug5");

            logger.Fatal("Fatal");
            Assert.Equal(1, debugTarget_Fatal.Counter);
            string s = debugTarget_Fatal.LastMessage;
            Assert.Contains("Fatal", s);


            logger.Error("Error");
            Assert.Equal(1, debugTarget_Error.Counter);
            s = debugTarget_Error.LastMessage;
            Assert.Contains("Error", s);


            logger.Warn("Warn");
            Assert.Equal(1, debugTarget_Warn.Counter);
            s = debugTarget_Warn.LastMessage;
            Assert.Contains("Warn", s);


            logger.Info("Info");
            Assert.Equal(1, debugTarget_Info.Counter);
            s = debugTarget_Info.LastMessage;
            Assert.Contains("Info", s);


            logger.Debug("Debug");
            Assert.Equal(1, debugTarget_Debug.Counter);
            s = debugTarget_Debug.LastMessage;
            Assert.Contains("Debug", s);


        }

        [Trait("Base", "Target.Type;Logger,level,writeTo")]
        [Fact]
        public void Layout()
        {
            //Config
            LogManager.Configuration =new XmlLoggingConfiguration(@"..\..\Layout\CsvLayout\CsvLayout.config");
         
            ILogger logger = LogManager.GetCurrentClassLogger();
           
            logger.Debug("Debug");
        }

        [Trait("Base", "Target.Type;Logger,level,writeTo")]
        [Fact]
        public void Layout2()
        {
            //Config
            LogManager.Configuration = new XmlLoggingConfiguration(@"..\..\Layout\CsvLayout\CsvLayout2.config");
            ILogger logger = LogManager.GetCurrentClassLogger();
            logger.Debug("Debug");

        }
    }
}
