﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:2.0.50727.3615
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

// 
// This source code was auto-generated by Microsoft.VSDesigner, Version 2.0.50727.3615.
// 
#pragma warning disable 1591

namespace AdegaSOA.external2 {
    using System.Diagnostics;
    using System.Web.Services;
    using System.ComponentModel;
    using System.Web.Services.Protocols;
    using System;
    using System.Xml.Serialization;
    
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "2.0.50727.3053")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Web.Services.WebServiceBindingAttribute(Name="VisaSoap", Namespace="http://ipt.br/soa/ext")]
    public partial class Visa : System.Web.Services.Protocols.SoapHttpClientProtocol {
        
        private System.Threading.SendOrPostCallback CreditarOperationCompleted;
        
        private System.Threading.SendOrPostCallback DebitarOperationCompleted;
        
        private bool useDefaultCredentialsSetExplicitly;
        
        /// <remarks/>
        public Visa() {
            this.Url = global::AdegaSOA.Properties.Settings.Default.AdegaSOA_external2_Visa;
            if ((this.IsLocalFileSystemWebService(this.Url) == true)) {
                this.UseDefaultCredentials = true;
                this.useDefaultCredentialsSetExplicitly = false;
            }
            else {
                this.useDefaultCredentialsSetExplicitly = true;
            }
        }
        
        public new string Url {
            get {
                return base.Url;
            }
            set {
                if ((((this.IsLocalFileSystemWebService(base.Url) == true) 
                            && (this.useDefaultCredentialsSetExplicitly == false)) 
                            && (this.IsLocalFileSystemWebService(value) == false))) {
                    base.UseDefaultCredentials = false;
                }
                base.Url = value;
            }
        }
        
        public new bool UseDefaultCredentials {
            get {
                return base.UseDefaultCredentials;
            }
            set {
                base.UseDefaultCredentials = value;
                this.useDefaultCredentialsSetExplicitly = true;
            }
        }
        
        /// <remarks/>
        public event CreditarCompletedEventHandler CreditarCompleted;
        
        /// <remarks/>
        public event DebitarCompletedEventHandler DebitarCompleted;
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://ipt.br/soa/ext/Creditar", RequestNamespace="http://ipt.br/soa/ext", ResponseNamespace="http://ipt.br/soa/ext", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public bool Creditar(string cartaoId, double valor) {
            object[] results = this.Invoke("Creditar", new object[] {
                        cartaoId,
                        valor});
            return ((bool)(results[0]));
        }
        
        /// <remarks/>
        public void CreditarAsync(string cartaoId, double valor) {
            this.CreditarAsync(cartaoId, valor, null);
        }
        
        /// <remarks/>
        public void CreditarAsync(string cartaoId, double valor, object userState) {
            if ((this.CreditarOperationCompleted == null)) {
                this.CreditarOperationCompleted = new System.Threading.SendOrPostCallback(this.OnCreditarOperationCompleted);
            }
            this.InvokeAsync("Creditar", new object[] {
                        cartaoId,
                        valor}, this.CreditarOperationCompleted, userState);
        }
        
        private void OnCreditarOperationCompleted(object arg) {
            if ((this.CreditarCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.CreditarCompleted(this, new CreditarCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://ipt.br/soa/ext/Debitar", RequestNamespace="http://ipt.br/soa/ext", ResponseNamespace="http://ipt.br/soa/ext", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public bool Debitar(string cartaoId, double valor) {
            object[] results = this.Invoke("Debitar", new object[] {
                        cartaoId,
                        valor});
            return ((bool)(results[0]));
        }
        
        /// <remarks/>
        public void DebitarAsync(string cartaoId, double valor) {
            this.DebitarAsync(cartaoId, valor, null);
        }
        
        /// <remarks/>
        public void DebitarAsync(string cartaoId, double valor, object userState) {
            if ((this.DebitarOperationCompleted == null)) {
                this.DebitarOperationCompleted = new System.Threading.SendOrPostCallback(this.OnDebitarOperationCompleted);
            }
            this.InvokeAsync("Debitar", new object[] {
                        cartaoId,
                        valor}, this.DebitarOperationCompleted, userState);
        }
        
        private void OnDebitarOperationCompleted(object arg) {
            if ((this.DebitarCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.DebitarCompleted(this, new DebitarCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        public new void CancelAsync(object userState) {
            base.CancelAsync(userState);
        }
        
        private bool IsLocalFileSystemWebService(string url) {
            if (((url == null) 
                        || (url == string.Empty))) {
                return false;
            }
            System.Uri wsUri = new System.Uri(url);
            if (((wsUri.Port >= 1024) 
                        && (string.Compare(wsUri.Host, "localHost", System.StringComparison.OrdinalIgnoreCase) == 0))) {
                return true;
            }
            return false;
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "2.0.50727.3053")]
    public delegate void CreditarCompletedEventHandler(object sender, CreditarCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "2.0.50727.3053")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class CreditarCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal CreditarCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        /// <remarks/>
        public bool Result {
            get {
                this.RaiseExceptionIfNecessary();
                return ((bool)(this.results[0]));
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "2.0.50727.3053")]
    public delegate void DebitarCompletedEventHandler(object sender, DebitarCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "2.0.50727.3053")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class DebitarCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal DebitarCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        /// <remarks/>
        public bool Result {
            get {
                this.RaiseExceptionIfNecessary();
                return ((bool)(this.results[0]));
            }
        }
    }
}

#pragma warning restore 1591