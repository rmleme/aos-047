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

namespace AdegaSOA.localhost6 {
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
    [System.Web.Services.WebServiceBindingAttribute(Name="CompraSoap", Namespace="http://ipt.br/soa")]
    public partial class Compra : System.Web.Services.Protocols.SoapHttpClientProtocol {
        
        private System.Threading.SendOrPostCallback VerificarPedidoUsuarioOperationCompleted;
        
        private System.Threading.SendOrPostCallback ChecarLimitesMinimosOperationCompleted;
        
        private bool useDefaultCredentialsSetExplicitly;
        
        /// <remarks/>
        public Compra() {
            this.Url = global::AdegaSOA.Properties.Settings.Default.AdegaSOA_localhost6_Compra;
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
        public event VerificarPedidoUsuarioCompletedEventHandler VerificarPedidoUsuarioCompleted;
        
        /// <remarks/>
        public event ChecarLimitesMinimosCompletedEventHandler ChecarLimitesMinimosCompleted;
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://ipt.br/soa/VerificarPedidoUsuario", RequestNamespace="http://ipt.br/soa", ResponseNamespace="http://ipt.br/soa", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public bool VerificarPedidoUsuario() {
            object[] results = this.Invoke("VerificarPedidoUsuario", new object[0]);
            return ((bool)(results[0]));
        }
        
        /// <remarks/>
        public void VerificarPedidoUsuarioAsync() {
            this.VerificarPedidoUsuarioAsync(null);
        }
        
        /// <remarks/>
        public void VerificarPedidoUsuarioAsync(object userState) {
            if ((this.VerificarPedidoUsuarioOperationCompleted == null)) {
                this.VerificarPedidoUsuarioOperationCompleted = new System.Threading.SendOrPostCallback(this.OnVerificarPedidoUsuarioOperationCompleted);
            }
            this.InvokeAsync("VerificarPedidoUsuario", new object[0], this.VerificarPedidoUsuarioOperationCompleted, userState);
        }
        
        private void OnVerificarPedidoUsuarioOperationCompleted(object arg) {
            if ((this.VerificarPedidoUsuarioCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.VerificarPedidoUsuarioCompleted(this, new VerificarPedidoUsuarioCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://ipt.br/soa/ChecarLimitesMinimos", RequestNamespace="http://ipt.br/soa", ResponseNamespace="http://ipt.br/soa", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public bool ChecarLimitesMinimos(int quantidade, double valor) {
            object[] results = this.Invoke("ChecarLimitesMinimos", new object[] {
                        quantidade,
                        valor});
            return ((bool)(results[0]));
        }
        
        /// <remarks/>
        public void ChecarLimitesMinimosAsync(int quantidade, double valor) {
            this.ChecarLimitesMinimosAsync(quantidade, valor, null);
        }
        
        /// <remarks/>
        public void ChecarLimitesMinimosAsync(int quantidade, double valor, object userState) {
            if ((this.ChecarLimitesMinimosOperationCompleted == null)) {
                this.ChecarLimitesMinimosOperationCompleted = new System.Threading.SendOrPostCallback(this.OnChecarLimitesMinimosOperationCompleted);
            }
            this.InvokeAsync("ChecarLimitesMinimos", new object[] {
                        quantidade,
                        valor}, this.ChecarLimitesMinimosOperationCompleted, userState);
        }
        
        private void OnChecarLimitesMinimosOperationCompleted(object arg) {
            if ((this.ChecarLimitesMinimosCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.ChecarLimitesMinimosCompleted(this, new ChecarLimitesMinimosCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
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
    public delegate void VerificarPedidoUsuarioCompletedEventHandler(object sender, VerificarPedidoUsuarioCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "2.0.50727.3053")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class VerificarPedidoUsuarioCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal VerificarPedidoUsuarioCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
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
    public delegate void ChecarLimitesMinimosCompletedEventHandler(object sender, ChecarLimitesMinimosCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "2.0.50727.3053")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class ChecarLimitesMinimosCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal ChecarLimitesMinimosCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
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