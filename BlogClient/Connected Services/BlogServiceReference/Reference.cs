﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace BlogClient.BlogServiceReference {
    using System.Runtime.Serialization;
    using System;
    
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="BlogPost", Namespace="http://schemas.datacontract.org/2004/07/BlogLib")]
    [System.SerializableAttribute()]
    public partial class BlogPost : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string ContentField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int IdField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private System.DateTime PostedAtField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string TitleField;
        
        [global::System.ComponentModel.BrowsableAttribute(false)]
        public System.Runtime.Serialization.ExtensionDataObject ExtensionData {
            get {
                return this.extensionDataField;
            }
            set {
                this.extensionDataField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Content {
            get {
                return this.ContentField;
            }
            set {
                if ((object.ReferenceEquals(this.ContentField, value) != true)) {
                    this.ContentField = value;
                    this.RaisePropertyChanged("Content");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int Id {
            get {
                return this.IdField;
            }
            set {
                if ((this.IdField.Equals(value) != true)) {
                    this.IdField = value;
                    this.RaisePropertyChanged("Id");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public System.DateTime PostedAt {
            get {
                return this.PostedAtField;
            }
            set {
                if ((this.PostedAtField.Equals(value) != true)) {
                    this.PostedAtField = value;
                    this.RaisePropertyChanged("PostedAt");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Title {
            get {
                return this.TitleField;
            }
            set {
                if ((object.ReferenceEquals(this.TitleField, value) != true)) {
                    this.TitleField = value;
                    this.RaisePropertyChanged("Title");
                }
            }
        }
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        protected void RaisePropertyChanged(string propertyName) {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null)) {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="BlogServiceReference.IBlogService")]
    public interface IBlogService {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IBlogService/AddPost", ReplyAction="http://tempuri.org/IBlogService/AddPostResponse")]
        BlogClient.BlogServiceReference.BlogPost AddPost(string title, string content);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IBlogService/AddPost", ReplyAction="http://tempuri.org/IBlogService/AddPostResponse")]
        System.Threading.Tasks.Task<BlogClient.BlogServiceReference.BlogPost> AddPostAsync(string title, string content);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IBlogService/GetPosts", ReplyAction="http://tempuri.org/IBlogService/GetPostsResponse")]
        BlogClient.BlogServiceReference.BlogPost[] GetPosts();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IBlogService/GetPosts", ReplyAction="http://tempuri.org/IBlogService/GetPostsResponse")]
        System.Threading.Tasks.Task<BlogClient.BlogServiceReference.BlogPost[]> GetPostsAsync();
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IBlogServiceChannel : BlogClient.BlogServiceReference.IBlogService, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class BlogServiceClient : System.ServiceModel.ClientBase<BlogClient.BlogServiceReference.IBlogService>, BlogClient.BlogServiceReference.IBlogService {
        
        public BlogServiceClient() {
        }
        
        public BlogServiceClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public BlogServiceClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public BlogServiceClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public BlogServiceClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public BlogClient.BlogServiceReference.BlogPost AddPost(string title, string content) {
            return base.Channel.AddPost(title, content);
        }
        
        public System.Threading.Tasks.Task<BlogClient.BlogServiceReference.BlogPost> AddPostAsync(string title, string content) {
            return base.Channel.AddPostAsync(title, content);
        }
        
        public BlogClient.BlogServiceReference.BlogPost[] GetPosts() {
            return base.Channel.GetPosts();
        }
        
        public System.Threading.Tasks.Task<BlogClient.BlogServiceReference.BlogPost[]> GetPostsAsync() {
            return base.Channel.GetPostsAsync();
        }
    }
}
