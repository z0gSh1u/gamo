using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using Microsoft.VisualBasic.Devices;
using System.Management;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Gamo
{
  class ReportBody {
    [JsonInclude]
    public float cpuUtility;
  }

  class DataReporter
  {
    private PerformanceCounter cpuUtilityCounter { get; } // %
    private PerformanceCounter cpuPerformanceCounter { get; } // %
    private ManagementObject cpuManagementObject { get; }
    private uint cpuMaxClockSpeed { get; } // Hz

    private PerformanceCounter ramAvailableCounter { get; }
    private PerformanceCounter ramCommitedCounter { get; }
    private ulong ramPhysicalTotal { get; }  // Byte
    private ComputerInfo computerInfo { get; }


    public DataReporter()
    {
      this.cpuUtilityCounter = new PerformanceCounter("Processor Information", "% Processor Utility", "_Total");
      this.cpuPerformanceCounter = new PerformanceCounter("Processor Information", "% Processor Performance", "_Total");
      this.ramAvailableCounter = new PerformanceCounter("Memory", "Available Bytes");
      this.ramCommitedCounter = new PerformanceCounter("Memory", "Committed Bytes");
      this.computerInfo = new ComputerInfo();
      this.ramPhysicalTotal = computerInfo.TotalPhysicalMemory;
      this.cpuManagementObject = new ManagementObject("Win32_Processor.DeviceID='CPU0'");
      this.cpuMaxClockSpeed = (uint)(this.cpuManagementObject["MaxClockSpeed"]);
    }

    /// <summary>
    /// Get current CPU utility rate [%].
    /// </summary>
    public float GetCPUUtility()
    {
      var cpuUtility = this.cpuUtilityCounter.NextValue();

      return cpuUtility;
    }

    /// <summary>
    /// Get current clock speed of CPU(0) [Hz].
    /// </summary>
    public float GetCPUClockSpeed()
    {
      var cpuPerformance = this.cpuPerformanceCounter.NextValue();

      return this.cpuMaxClockSpeed * cpuPerformance / 100;
    }

    /// <summary>
    /// Get current available RAM [Byte].
    /// </summary>
    public float GetRAMAvailble()
    {
      var ramAvailable = this.ramAvailableCounter.NextValue();

      return ramAvailable;
    }

    /// <summary>
    /// Get current commited RAM [Byte].
    /// </summary>
    public float GetRAMCommited()
    {
      var ramCommited = this.ramCommitedCounter.NextValue();

      return ramCommited;
    }

    // public string CollectAsJSON() {

    // }

  }
}
