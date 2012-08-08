using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Management;
using System.Management.Automation;
using Microsoft.Win32;

namespace GetDotNetVersions
{
    [Cmdlet("Get", "DotNetVersions")]
    public class GetDotNetVersionsCommand : Cmdlet
    {
        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            // HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\NET Framework Setup\NDP
            RegistryKey rk = Registry.LocalMachine.OpenSubKey("SOFTWARE").OpenSubKey("Microsoft").OpenSubKey("NET Framework Setup").OpenSubKey("NDP");
            WriteObject(rk.GetSubKeyNames());
        }
    }
}
