using dbtest.Methods;
using dbtest.Service.Contracts;
using System.Collections.Generic;
using System.ServiceModel;

namespace dbtest.service
{
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.PerSession)]
    public class RestaurantService : IRestaurantService
    {
        /// <summary>
        /// Retorna todos os restaurantes
        /// </summary>
        /// <returns>Lista de entidade de restaurante</returns>
        public List<RestaurantContract> GetRestaurants()
        {
            var ret = new List<RestaurantContract>();
            var rest = RestaurantMethods.GetRestaurants();
            foreach (var item in rest)
            {
                ret.Add(new RestaurantContract() { Id = item.Id, Name = item.Name });
            }

            return ret;
        }

        /// <summary>
        /// Busca todos restaurantes que não foram os mais votados na semana.
        /// </summary>
        /// <returns>Lista de entidade de restaurante</returns>
        public List<RestaurantContract> GetRestaurantsNotVotedWeek()
        {
            var ret = new List<RestaurantContract>();
            var rest = RestaurantMethods.GetRestaurantsNotVotedWeek();
            foreach (var item in rest)
            {
                ret.Add(new RestaurantContract() { Id = item.Id, Name = item.Name });
            }

            return ret;
        }

        /// <summary>
        /// Busca todos restaurantes que foram os mais votados na semana.
        /// </summary>
        /// <returns>Lista de entidade de restaurante</returns>
        public List<RestaurantVotedContract> GetRestaurantsVotedWeek()
        {
            var ret = new List<RestaurantVotedContract>();
            var rest = RestaurantMethods.GetRestaurantsVotedWeek();
            foreach (var item in rest)
            {
                ret.Add(new RestaurantVotedContract() { Id = item.Id, Name = item.Name, Votes = item.Votes });
            }

            return ret;
        }

        /// <summary>
        /// Busca todos restaurantes que foram votados hoje
        /// </summary>
        /// <returns>Lista de entidade de restaurante</returns>
        public List<RestaurantVotedContract> GetRestaurantVotedToday()
        {
            var ret = new List<RestaurantVotedContract>();

            foreach (var item in RestaurantMethods.GetRestaurantVotedToday())
            {
                ret.Add(new RestaurantVotedContract() { Id = item.Id, Name = item.Name, Votes = item.Votes });
            }

            return ret;
        }

        /// <summary>
        /// Busca todos restaurantes que não foram votados no dia.
        /// </summary>
        /// <returns>Lista de entidade de restaurante</returns>
        public List<RestaurantContract> GetRestaurantsNotVotedToday()
        {
            var ret = new List<RestaurantContract>();
            var rest = RestaurantMethods.GetRestaurantsNotVotedToday();
            foreach (var item in rest)
            {
                ret.Add(new RestaurantContract() { Id = item.Id, Name = item.Name });
            }

            return ret;
        }

        /// <summary>
        /// Busca o restaurante pelo Id.
        /// </summary>
        /// <returns>Entidade de restaurante</returns>
        public RestaurantContract GetRestaurant(int id)
        {
            var rest = RestaurantMethods.GetRestaurant(id);

            var contract = new RestaurantContract();
            contract.Id = rest.Id;
            contract.Name = rest.Name;

            return contract;
        }

        /// <summary>
        /// Busca restaurante que ganhou a votação hoje
        /// </summary>
        /// <returns>Entidade de restaurante</returns>
        public RestaurantContract GetRestaurantWinnerToday()
        {
            var rest = RestaurantMethods.GetRestaurantWinnerToday();

            var contract = new RestaurantContract();
            contract.Id = rest.Id;
            contract.Name = rest.Name;

            return contract;
        }

        /// <summary>
        /// Quantidade de restaurantes
        /// </summary>
        /// <returns>Quantidade de restaurantes</returns>
        public int GetRestaurantsCount()
        {
            return RestaurantMethods.GetRestaurantsCount();
        }

        /// <summary>
        /// Retorna todos usuários que votaram hoje
        /// </summary>
        /// <returns>Lista com os usuários</returns>
        public List<string> UsersWithTodayVote()
        {
            return RestaurantMethods.UsersWithTodayVote();
        }

        /// <summary>
        /// Verifica se o usuário votou hoje
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public bool ChecksIfUserVote(string user)
        {
            return RestaurantMethods.UserWithTodayVote(user);
        }

        /// <summary>
        /// Busca qual foi o voto do usuário
        /// </summary>
        /// <param name="user"></param>
        /// <returns>Retorna o id do restaurante que o usuário votou, caso ele não tenha votado em nenhum retorna 0</returns>
        public int UserVote(string user)
        {
            return RestaurantMethods.UserVote(user);
        }

        /// <summary>
        /// Método para salva o voto
        /// </summary>
        /// <param name="user">Usuário</param>
        /// <param name="restaurantId">Id do restaurante</param>
        public void VoteInRestaurant(string user, int restaurantId)
        {
            RestaurantMethods.Vote(user, restaurantId);
        }

        /// <summary>
        /// Encerra a votação
        /// </summary>
        public void CloseVoting()
        {
            RestaurantMethods.CloseVoting();
        }

        /// <summary>
        /// Verificar se a votação está encerrada
        /// </summary>
        /// <returns>True se a votação está encerrada, caso não esteja retorna false</returns>
        public bool VotingClosed()
        {
            return RestaurantMethods.VotingClosed();
        }
    }
}
