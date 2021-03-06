﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace dbtest.Util.ClientServiceReference {
    using System.Runtime.Serialization;
    using System;
    
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="RestaurantContract", Namespace="http://schemas.datacontract.org/2004/07/dbtest.Service.Contracts")]
    [System.SerializableAttribute()]
    public partial class RestaurantContract : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private long IdField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string NameField;
        
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
        public long Id {
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
        public string Name {
            get {
                return this.NameField;
            }
            set {
                if ((object.ReferenceEquals(this.NameField, value) != true)) {
                    this.NameField = value;
                    this.RaisePropertyChanged("Name");
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
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="RestaurantVotedContract", Namespace="http://schemas.datacontract.org/2004/07/dbtest.Service.Contracts")]
    [System.SerializableAttribute()]
    public partial class RestaurantVotedContract : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private long IdField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string NameField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int VotesField;
        
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
        public long Id {
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
        public string Name {
            get {
                return this.NameField;
            }
            set {
                if ((object.ReferenceEquals(this.NameField, value) != true)) {
                    this.NameField = value;
                    this.RaisePropertyChanged("Name");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int Votes {
            get {
                return this.VotesField;
            }
            set {
                if ((this.VotesField.Equals(value) != true)) {
                    this.VotesField = value;
                    this.RaisePropertyChanged("Votes");
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
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="ClientServiceReference.IRestaurantService")]
    public interface IRestaurantService {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IRestaurantService/GetRestaurants", ReplyAction="http://tempuri.org/IRestaurantService/GetRestaurantsResponse")]
        dbtest.Util.ClientServiceReference.RestaurantContract[] GetRestaurants();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IRestaurantService/GetRestaurants", ReplyAction="http://tempuri.org/IRestaurantService/GetRestaurantsResponse")]
        System.Threading.Tasks.Task<dbtest.Util.ClientServiceReference.RestaurantContract[]> GetRestaurantsAsync();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IRestaurantService/GetRestaurantsNotVotedWeek", ReplyAction="http://tempuri.org/IRestaurantService/GetRestaurantsNotVotedWeekResponse")]
        dbtest.Util.ClientServiceReference.RestaurantContract[] GetRestaurantsNotVotedWeek();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IRestaurantService/GetRestaurantsNotVotedWeek", ReplyAction="http://tempuri.org/IRestaurantService/GetRestaurantsNotVotedWeekResponse")]
        System.Threading.Tasks.Task<dbtest.Util.ClientServiceReference.RestaurantContract[]> GetRestaurantsNotVotedWeekAsync();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IRestaurantService/GetRestaurantsVotedWeek", ReplyAction="http://tempuri.org/IRestaurantService/GetRestaurantsVotedWeekResponse")]
        dbtest.Util.ClientServiceReference.RestaurantVotedContract[] GetRestaurantsVotedWeek();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IRestaurantService/GetRestaurantsVotedWeek", ReplyAction="http://tempuri.org/IRestaurantService/GetRestaurantsVotedWeekResponse")]
        System.Threading.Tasks.Task<dbtest.Util.ClientServiceReference.RestaurantVotedContract[]> GetRestaurantsVotedWeekAsync();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IRestaurantService/GetRestaurantsNotVotedToday", ReplyAction="http://tempuri.org/IRestaurantService/GetRestaurantsNotVotedTodayResponse")]
        dbtest.Util.ClientServiceReference.RestaurantContract[] GetRestaurantsNotVotedToday();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IRestaurantService/GetRestaurantsNotVotedToday", ReplyAction="http://tempuri.org/IRestaurantService/GetRestaurantsNotVotedTodayResponse")]
        System.Threading.Tasks.Task<dbtest.Util.ClientServiceReference.RestaurantContract[]> GetRestaurantsNotVotedTodayAsync();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IRestaurantService/GetRestaurant", ReplyAction="http://tempuri.org/IRestaurantService/GetRestaurantResponse")]
        dbtest.Util.ClientServiceReference.RestaurantContract GetRestaurant(int id);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IRestaurantService/GetRestaurant", ReplyAction="http://tempuri.org/IRestaurantService/GetRestaurantResponse")]
        System.Threading.Tasks.Task<dbtest.Util.ClientServiceReference.RestaurantContract> GetRestaurantAsync(int id);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IRestaurantService/GetRestaurantWinnerToday", ReplyAction="http://tempuri.org/IRestaurantService/GetRestaurantWinnerTodayResponse")]
        dbtest.Util.ClientServiceReference.RestaurantContract GetRestaurantWinnerToday();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IRestaurantService/GetRestaurantWinnerToday", ReplyAction="http://tempuri.org/IRestaurantService/GetRestaurantWinnerTodayResponse")]
        System.Threading.Tasks.Task<dbtest.Util.ClientServiceReference.RestaurantContract> GetRestaurantWinnerTodayAsync();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IRestaurantService/GetRestaurantVotedToday", ReplyAction="http://tempuri.org/IRestaurantService/GetRestaurantVotedTodayResponse")]
        dbtest.Util.ClientServiceReference.RestaurantVotedContract[] GetRestaurantVotedToday();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IRestaurantService/GetRestaurantVotedToday", ReplyAction="http://tempuri.org/IRestaurantService/GetRestaurantVotedTodayResponse")]
        System.Threading.Tasks.Task<dbtest.Util.ClientServiceReference.RestaurantVotedContract[]> GetRestaurantVotedTodayAsync();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IRestaurantService/GetRestaurantsCount", ReplyAction="http://tempuri.org/IRestaurantService/GetRestaurantsCountResponse")]
        int GetRestaurantsCount();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IRestaurantService/GetRestaurantsCount", ReplyAction="http://tempuri.org/IRestaurantService/GetRestaurantsCountResponse")]
        System.Threading.Tasks.Task<int> GetRestaurantsCountAsync();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IRestaurantService/UsersWithTodayVote", ReplyAction="http://tempuri.org/IRestaurantService/UsersWithTodayVoteResponse")]
        string[] UsersWithTodayVote();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IRestaurantService/UsersWithTodayVote", ReplyAction="http://tempuri.org/IRestaurantService/UsersWithTodayVoteResponse")]
        System.Threading.Tasks.Task<string[]> UsersWithTodayVoteAsync();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IRestaurantService/VoteInRestaurant", ReplyAction="http://tempuri.org/IRestaurantService/VoteInRestaurantResponse")]
        void VoteInRestaurant(string user, int restaurantId);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IRestaurantService/VoteInRestaurant", ReplyAction="http://tempuri.org/IRestaurantService/VoteInRestaurantResponse")]
        System.Threading.Tasks.Task VoteInRestaurantAsync(string user, int restaurantId);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IRestaurantService/ChecksIfUserVote", ReplyAction="http://tempuri.org/IRestaurantService/ChecksIfUserVoteResponse")]
        bool ChecksIfUserVote(string user);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IRestaurantService/ChecksIfUserVote", ReplyAction="http://tempuri.org/IRestaurantService/ChecksIfUserVoteResponse")]
        System.Threading.Tasks.Task<bool> ChecksIfUserVoteAsync(string user);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IRestaurantService/UserVote", ReplyAction="http://tempuri.org/IRestaurantService/UserVoteResponse")]
        int UserVote(string user);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IRestaurantService/UserVote", ReplyAction="http://tempuri.org/IRestaurantService/UserVoteResponse")]
        System.Threading.Tasks.Task<int> UserVoteAsync(string user);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IRestaurantService/CloseVoting", ReplyAction="http://tempuri.org/IRestaurantService/CloseVotingResponse")]
        void CloseVoting();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IRestaurantService/CloseVoting", ReplyAction="http://tempuri.org/IRestaurantService/CloseVotingResponse")]
        System.Threading.Tasks.Task CloseVotingAsync();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IRestaurantService/VotingClosed", ReplyAction="http://tempuri.org/IRestaurantService/VotingClosedResponse")]
        bool VotingClosed();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IRestaurantService/VotingClosed", ReplyAction="http://tempuri.org/IRestaurantService/VotingClosedResponse")]
        System.Threading.Tasks.Task<bool> VotingClosedAsync();
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IRestaurantServiceChannel : dbtest.Util.ClientServiceReference.IRestaurantService, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class RestaurantServiceClient : System.ServiceModel.ClientBase<dbtest.Util.ClientServiceReference.IRestaurantService>, dbtest.Util.ClientServiceReference.IRestaurantService {
        
        public RestaurantServiceClient() {
        }
        
        public RestaurantServiceClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public RestaurantServiceClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public RestaurantServiceClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public RestaurantServiceClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public dbtest.Util.ClientServiceReference.RestaurantContract[] GetRestaurants() {
            return base.Channel.GetRestaurants();
        }
        
        public System.Threading.Tasks.Task<dbtest.Util.ClientServiceReference.RestaurantContract[]> GetRestaurantsAsync() {
            return base.Channel.GetRestaurantsAsync();
        }
        
        public dbtest.Util.ClientServiceReference.RestaurantContract[] GetRestaurantsNotVotedWeek() {
            return base.Channel.GetRestaurantsNotVotedWeek();
        }
        
        public System.Threading.Tasks.Task<dbtest.Util.ClientServiceReference.RestaurantContract[]> GetRestaurantsNotVotedWeekAsync() {
            return base.Channel.GetRestaurantsNotVotedWeekAsync();
        }
        
        public dbtest.Util.ClientServiceReference.RestaurantVotedContract[] GetRestaurantsVotedWeek() {
            return base.Channel.GetRestaurantsVotedWeek();
        }
        
        public System.Threading.Tasks.Task<dbtest.Util.ClientServiceReference.RestaurantVotedContract[]> GetRestaurantsVotedWeekAsync() {
            return base.Channel.GetRestaurantsVotedWeekAsync();
        }
        
        public dbtest.Util.ClientServiceReference.RestaurantContract[] GetRestaurantsNotVotedToday() {
            return base.Channel.GetRestaurantsNotVotedToday();
        }
        
        public System.Threading.Tasks.Task<dbtest.Util.ClientServiceReference.RestaurantContract[]> GetRestaurantsNotVotedTodayAsync() {
            return base.Channel.GetRestaurantsNotVotedTodayAsync();
        }
        
        public dbtest.Util.ClientServiceReference.RestaurantContract GetRestaurant(int id) {
            return base.Channel.GetRestaurant(id);
        }
        
        public System.Threading.Tasks.Task<dbtest.Util.ClientServiceReference.RestaurantContract> GetRestaurantAsync(int id) {
            return base.Channel.GetRestaurantAsync(id);
        }
        
        public dbtest.Util.ClientServiceReference.RestaurantContract GetRestaurantWinnerToday() {
            return base.Channel.GetRestaurantWinnerToday();
        }
        
        public System.Threading.Tasks.Task<dbtest.Util.ClientServiceReference.RestaurantContract> GetRestaurantWinnerTodayAsync() {
            return base.Channel.GetRestaurantWinnerTodayAsync();
        }
        
        public dbtest.Util.ClientServiceReference.RestaurantVotedContract[] GetRestaurantVotedToday() {
            return base.Channel.GetRestaurantVotedToday();
        }
        
        public System.Threading.Tasks.Task<dbtest.Util.ClientServiceReference.RestaurantVotedContract[]> GetRestaurantVotedTodayAsync() {
            return base.Channel.GetRestaurantVotedTodayAsync();
        }
        
        public int GetRestaurantsCount() {
            return base.Channel.GetRestaurantsCount();
        }
        
        public System.Threading.Tasks.Task<int> GetRestaurantsCountAsync() {
            return base.Channel.GetRestaurantsCountAsync();
        }
        
        public string[] UsersWithTodayVote() {
            return base.Channel.UsersWithTodayVote();
        }
        
        public System.Threading.Tasks.Task<string[]> UsersWithTodayVoteAsync() {
            return base.Channel.UsersWithTodayVoteAsync();
        }
        
        public void VoteInRestaurant(string user, int restaurantId) {
            base.Channel.VoteInRestaurant(user, restaurantId);
        }
        
        public System.Threading.Tasks.Task VoteInRestaurantAsync(string user, int restaurantId) {
            return base.Channel.VoteInRestaurantAsync(user, restaurantId);
        }
        
        public bool ChecksIfUserVote(string user) {
            return base.Channel.ChecksIfUserVote(user);
        }
        
        public System.Threading.Tasks.Task<bool> ChecksIfUserVoteAsync(string user) {
            return base.Channel.ChecksIfUserVoteAsync(user);
        }
        
        public int UserVote(string user) {
            return base.Channel.UserVote(user);
        }
        
        public System.Threading.Tasks.Task<int> UserVoteAsync(string user) {
            return base.Channel.UserVoteAsync(user);
        }
        
        public void CloseVoting() {
            base.Channel.CloseVoting();
        }
        
        public System.Threading.Tasks.Task CloseVotingAsync() {
            return base.Channel.CloseVotingAsync();
        }
        
        public bool VotingClosed() {
            return base.Channel.VotingClosed();
        }
        
        public System.Threading.Tasks.Task<bool> VotingClosedAsync() {
            return base.Channel.VotingClosedAsync();
        }
    }
}
