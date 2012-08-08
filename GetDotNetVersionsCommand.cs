using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Management;
using System.Management.Automation;
using System.ComponentModel;
using Microsoft.Win32;

namespace GetDotNetVersions
{
    [RunInstaller(true)]
    class GetDotNetVersionsCmdlets : PSSnapIn
    {

    }

    [Cmdlet(VerbsCommon.Get, "DotNetVersions")]
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
