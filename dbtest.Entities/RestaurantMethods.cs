using dbtest.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using dbtest.Map;

namespace dbtest.Methods
{
    public static class RestaurantMethods
    {
        /// <summary>
        /// Busca o restaurante pelo Id.
        /// </summary>
        /// <returns>Entidade de restaurante</returns>
        public static RestaurantEntity GetRestaurant(int id)
        {
            return RestaurantMap.Instance.FindById(id);
        }

        /// <summary>
        /// Retorna todos os restaurantes
        /// </summary>
        /// <returns>Lista de entidade de restaurante</returns>
        public static List<RestaurantEntity> GetRestaurants()
        {
            return RestaurantMap.Instance.FindAll();
        }

        /// <summary>
        /// Busca todos restaurantes que não foram os mais votados na semana.
        /// </summary>
        /// <returns>Lista de entidade de restaurante</returns>
        public static List<RestaurantEntity> GetRestaurantsNotVotedWeek() 
        {
            return RestaurantMap.Instance.FindAllNotVotedWeek();
        }

        /// <summary>
        /// Busca restaurante que ganhou a votação hoje
        /// </summary>
        /// <returns>Entidade de restaurante</returns>
        public static RestaurantEntity GetRestaurantWinnerToday()
        {
            var values = RestaurantSettingsMap.Instance.RestaurantWithMostVotesToday();
            var rest = RestaurantMap.Instance.FindById(values.Key);
            rest.Votes = values.Value;

            return rest;
        }

        /// <summary>
        /// Busca todos restaurantes que foram votados hoje
        /// </summary>
        /// <returns></returns>
        public static List<RestaurantEntity> GetRestaurantVotedToday()
        {
            return RestaurantSettingsMap.Instance.RestaurantWithVotesToday();
        }

        /// <summary>
        /// Verifica se o usuário votou hoje
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public static bool UserWithTodayVote(string user)
        {
            return RestaurantSettingsMap.Instance.UserWithTodayVote(user);
        }

        /// <summary>
        /// Retorna todos usuários que votaram hoje
        /// </summary>
        /// <returns></returns>
        public static List<string> UsersWithTodayVote()
        {
            return RestaurantSettingsMap.Instance.UsersWithTodayVote();
        }

        /// <summary>
        /// Método para salva o voto
        /// </summary>
        /// <param name="user"></param>
        /// <param name="restaurantId"></param>
        public static void Vote(string user, int restaurantId)
        {
            RestaurantSettingsMap.Instance.Vote(user, restaurantId);
        }

        /// <summary>
        /// Busca qual foi o voto do usuário
        /// </summary>
        /// <param name="user"></param>
        /// <returns>Retorna o id do restaurante que o usuário votou, caso ele não tenha votado em nenhum retorna 0</returns>
        public static int UserVote(string user)
        {
            return RestaurantSettingsMap.Instance.UserVote(user);
        }

        /// <summary>
        /// Encerra a votação
        /// </summary>
        public static void CloseVoting()
        {
            RestaurantMap.Instance.Initialize();
            var rest = GetRestaurantWinnerToday();
            RestaurantMap.Instance.SetVotedWeek(rest.Id, rest.Votes);
        }

        /// <summary>
        /// Verificar se a votação está encerrada
        /// </summary>
        /// <returns>True se a votação está encerrada, caso não esteja retorna false</returns>
        public static bool VotingClosed()
        {
            return RestaurantMap.Instance.VotingClosed();
        }

        /// <summary>
        /// Quantidade de restaurantes
        /// </summary>
        /// <returns>Quantidade de restaurantes</returns>
        public static int GetRestaurantsCount()
        {
            return RestaurantMap.Instance.Count();
        }

        /// <summary>
        /// Busca todos restaurantes que não foram votados no dia.
        /// </summary>
        /// <returns>Lista de entidade de restaurante</returns>
        public static List<RestaurantEntity> GetRestaurantsNotVotedToday()
        {
            return RestaurantMap.Instance.RestaurantWithoutVotesToday();
        }

        /// <summary>
        /// Busca todos restaurantes que foram os mais votados na semana.
        /// </summary>
        /// <returns>Lista de entidade de restaurante</returns>
        public static List<RestaurantEntity> GetRestaurantsVotedWeek() 
        {
            return RestaurantMap.Instance.FindAllVotedWeek();
        }
    }
}
