﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace HeThongBanDienThoai_Admin.Properties {
    
    
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.VisualStudio.Editors.SettingsDesigner.SettingsSingleFileGenerator", "17.10.0.0")]
    internal sealed partial class Settings : global::System.Configuration.ApplicationSettingsBase {
        
        private static Settings defaultInstance = ((Settings)(global::System.Configuration.ApplicationSettingsBase.Synchronized(new Settings())));
        
        public static Settings Default {
            get {
                return defaultInstance;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("Data Source=DESKTOP-GVRFC16\\BAOTOAN;Initial Catalog=QL_DTDD;Persist Security Info" +
            "=True;User Data Source=DESKTOP-GVRFC16\\BAOTOAN;Initial Catalog=QL_DTDD;Persist S" +
            "ecurity Info=True;User ID=sa;Password=123;Encrypt=True;TrustServerCertificate=Tr" +
            "ue")]
        public string stringConnectSql {
            get {
                return ((string)(this["stringConnectSql"]));
            }
            set {
                this["stringConnectSql"] = value;
            }
        }
    }
}
