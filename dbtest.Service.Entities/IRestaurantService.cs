using dbtest.Service.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace dbtest.Service.Contracts
{
    [ServiceContract]
    public interface IRestaurantService
    {
        [OperationContract]
        List<RestaurantContract> GetRestaurants();
        
        [OperationContract]
        List<RestaurantContract> GetRestaurantsNotVotedWeek();

        [OperationContract]
        List<RestaurantVotedContract> GetRestaurantsVotedWeek();

        [OperationContract]
        List<RestaurantContract> GetRestaurantsNotVotedToday();

        [OperationContract]
        RestaurantContract GetRestaurant(int id);

        [OperationContract]
        RestaurantContract GetRestaurantWinnerToday();

        [OperationContract]
        List<RestaurantVotedContract> GetRestaurantVotedToday();

        [OperationContract]
        int GetRestaurantsCount();

        [OperationContract]
        List<string> UsersWithTodayVote();
        
        [OperationContract]
        void VoteInRestaurant(string user, int restaurantId, DateTime day);
        
        [OperationContract]
        bool ChecksIfUserVote(string user, DateTime day);
        
        [OperationContract]
        int UserVote(string user);

        [OperationContract]
        void CloseVoting();

        [OperationContract]
        bool VotingClosed();
    }
}
