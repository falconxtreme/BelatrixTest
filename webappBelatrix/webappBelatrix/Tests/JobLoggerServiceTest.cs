using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using NUnit.Framework;
using NUnit.Mocks;
using webappBelatrix.Entidad;
using webappBelatrix.Interfaces;
using webappBelatrix.Negocio;

namespace webappBelatrix.NMock3
{
    [TestFixture]
    public class JobLoggerServiceTest
    {
        private DynamicMock jobLoggerRestructuredMock;
        private beLog obeLogOne = new beLog("Message sent", beEnumLog.MessagesTypes.Messsage, beEnumLog.MessagesTypes.none);
        private beLog obeLogTwo = new beLog("Warning sent", beEnumLog.MessagesTypes.Warning, beEnumLog.MessagesTypes.none);
        private beLog obeLogThree = new beLog("Error sent", beEnumLog.MessagesTypes.Error, beEnumLog.MessagesTypes.none);

        [SetUp]
        public void TestInit()
        {
            jobLoggerRestructuredMock = new DynamicMock(typeof(IJobLoggerRestructured));
        }

        [Test]
        public void TestWriteLogInConsole()
        {
            jobLoggerRestructuredMock.ExpectAndReturn("writeInConsole",  "success", obeLogOne);
            JobLoggerService oJobLoggService = new JobLoggerService((IJobLoggerRestructured)jobLoggerRestructuredMock.MockInstance,beEnumLog.LogTypes.LogToConsole,beEnumLog.MessagesTypes.Messsage);
            string successProcess= oJobLoggService.writeLog(obeLogOne);
            Assert.IsNotNull(successProcess);
            Assert.AreNotEqual("Empty message", successProcess);
            Assert.AreNotEqual("Invalid Configuration", successProcess);
            Assert.AreNotEqual("Error or Warning or Message must be specified", successProcess);
            Assert.AreEqual("success", successProcess);

            jobLoggerRestructuredMock.ExpectAndReturn("writeInConsole", "success", obeLogTwo);
            oJobLoggService = new JobLoggerService((IJobLoggerRestructured)jobLoggerRestructuredMock.MockInstance, beEnumLog.LogTypes.LogToConsole, beEnumLog.MessagesTypes.Warning);
            successProcess = oJobLoggService.writeLog(obeLogTwo);
            Assert.IsNotNull(successProcess);
            Assert.AreNotEqual("Empty message", successProcess);
            Assert.AreNotEqual("Invalid Configuration", successProcess);
            Assert.AreNotEqual("Error or Warning or Message must be specified", successProcess);
            Assert.AreEqual("success", successProcess);

            jobLoggerRestructuredMock.ExpectAndReturn("writeInConsole", "success", obeLogThree);
            oJobLoggService = new JobLoggerService((IJobLoggerRestructured)jobLoggerRestructuredMock.MockInstance, beEnumLog.LogTypes.LogToConsole, beEnumLog.MessagesTypes.Error);
            successProcess = oJobLoggService.writeLog(obeLogThree);
            Assert.IsNotNull(successProcess);
            Assert.AreNotEqual("Empty message", successProcess);
            Assert.AreNotEqual("Invalid Configuration", successProcess);
            Assert.AreNotEqual("Error or Warning or Message must be specified", successProcess);
            Assert.AreEqual("success", successProcess);
        }

        [Test]
        public void TestWriteLogInFile()
        {
            jobLoggerRestructuredMock.ExpectAndReturn("writeInFile", "success", obeLogOne);
            JobLoggerService oJobLoggService = new JobLoggerService((IJobLoggerRestructured)jobLoggerRestructuredMock.MockInstance, beEnumLog.LogTypes.LogToFile, beEnumLog.MessagesTypes.Messsage);
            string successProcess = oJobLoggService.writeLog(obeLogOne);
            Assert.IsNotNull(successProcess);
            Assert.AreNotEqual("Empty message", successProcess);
            Assert.AreNotEqual("Invalid Configuration", successProcess);
            Assert.AreNotEqual("Error or Warning or Message must be specified", successProcess);
            Assert.AreEqual("success", successProcess);

            jobLoggerRestructuredMock.ExpectAndReturn("writeInFile", "success", obeLogTwo);
            oJobLoggService = new JobLoggerService((IJobLoggerRestructured)jobLoggerRestructuredMock.MockInstance, beEnumLog.LogTypes.LogToFile, beEnumLog.MessagesTypes.Warning);
            successProcess = oJobLoggService.writeLog(obeLogTwo);
            Assert.IsNotNull(successProcess);
            Assert.AreNotEqual("Empty message", successProcess);
            Assert.AreNotEqual("Invalid Configuration", successProcess);
            Assert.AreNotEqual("Error or Warning or Message must be specified", successProcess);
            Assert.AreEqual("success", successProcess);

            jobLoggerRestructuredMock.ExpectAndReturn("writeInFile", "success", obeLogThree);
            oJobLoggService = new JobLoggerService((IJobLoggerRestructured)jobLoggerRestructuredMock.MockInstance, beEnumLog.LogTypes.LogToFile, beEnumLog.MessagesTypes.Error);
            successProcess = oJobLoggService.writeLog(obeLogThree);
            Assert.IsNotNull(successProcess);
            Assert.AreNotEqual("Empty message", successProcess);
            Assert.AreNotEqual("Invalid Configuration", successProcess);
            Assert.AreNotEqual("Error or Warning or Message must be specified", successProcess);
            Assert.AreEqual("success", successProcess);
        }

        [Test]
        public void TestWriteLogInDatabase()
        {
            jobLoggerRestructuredMock.ExpectAndReturn("writeInDatabase", "success", obeLogOne);
            JobLoggerService oJobLoggService = new JobLoggerService((IJobLoggerRestructured)jobLoggerRestructuredMock.MockInstance, beEnumLog.LogTypes.LogToDatabase, beEnumLog.MessagesTypes.Messsage);
            string successProcess = oJobLoggService.writeLog(obeLogOne);
            Assert.IsNotNull(successProcess);
            Assert.AreNotEqual("Empty message", successProcess);
            Assert.AreNotEqual("Invalid Configuration", successProcess);
            Assert.AreNotEqual("Error or Warning or Message must be specified", successProcess);
            Assert.AreEqual("success", successProcess);

            jobLoggerRestructuredMock.ExpectAndReturn("writeInDatabase", "success", obeLogTwo);
            oJobLoggService = new JobLoggerService((IJobLoggerRestructured)jobLoggerRestructuredMock.MockInstance, beEnumLog.LogTypes.LogToDatabase, beEnumLog.MessagesTypes.Warning);
            successProcess = oJobLoggService.writeLog(obeLogTwo);
            Assert.IsNotNull(successProcess);
            Assert.AreNotEqual("Empty message", successProcess);
            Assert.AreNotEqual("Invalid Configuration", successProcess);
            Assert.AreNotEqual("Error or Warning or Message must be specified", successProcess);
            Assert.AreEqual("success", successProcess);

            jobLoggerRestructuredMock.ExpectAndReturn("writeInDatabase", "success", obeLogThree);
            oJobLoggService = new JobLoggerService((IJobLoggerRestructured)jobLoggerRestructuredMock.MockInstance, beEnumLog.LogTypes.LogToDatabase, beEnumLog.MessagesTypes.Error);
            successProcess = oJobLoggService.writeLog(obeLogThree);
            Assert.IsNotNull(successProcess);
            Assert.AreNotEqual("Empty message", successProcess);
            Assert.AreNotEqual("Invalid Configuration", successProcess);
            Assert.AreNotEqual("Error or Warning or Message must be specified", successProcess);
            Assert.AreEqual("success", successProcess);
        }
    }
}