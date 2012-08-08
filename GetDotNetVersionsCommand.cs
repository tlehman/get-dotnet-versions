using System;
using System.Collections.Generic;
using System.Text;
using System.Management;
using System.Management.Automation;
using System.ComponentModel;
using Microsoft.Win32;

namespace GetDotNetVersions
{
    [RunInstaller(true)]
    public class GetDotNetVersionsSnapIn : PSSnapIn
    {
        public GetDotNetVersionsSnapIn() : base() { }
        public override string Name
        {
            get { return "Get-DotNetVersions"; }
        }
        public override string Vendor
        {
            get { return "tlehman"; }
        }
        public override string Description
        {
            get { return "A cmdlet to get the list of versions of the .NET Framework on your current system.";  }
        }
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
