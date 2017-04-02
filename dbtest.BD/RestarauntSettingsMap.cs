using dbtest.Entities;
using dbtest.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dbtest.Map
{
    public class RestaurantSettingsMap
    {
        private static RestaurantSettingsMap _instance;
        private static Dictionary<string, VoteEntity> _usersWithVote;


        #region Private Methods

        private RestaurantSettingsMap()
        {
            _usersWithVote = new Dictionary<string, VoteEntity>();
            RestaurantMap.Instance.InitializeVotes();
        }

        /// <summary>
        /// Retorna todos usuários com voto
        /// </summary>
        /// <returns></returns>
        private static Dictionary<string, VoteEntity> UsersWithVote()
        {
            if (_usersWithVote == null)
            {
                _usersWithVote = new Dictionary<string, VoteEntity>();
            }

            FindAllFromModel();

            return _usersWithVote;
        }

        /// <summary>
        /// Retorna todos usuários com voto no dia corrente
        /// </summary>
        /// <returns></returns>
        private static Dictionary<string, VoteEntity> UsersWithVoteToday()
        {
            var users = new Dictionary<string, VoteEntity>();
            foreach (var item in UsersWithVote())
            {
                if (item.Value.Date == DateTime.Now.ToShortDateString())
                {
                    users.Add(item.Key, item.Value);
                }
            }

            return users;
        }

        /// <summary>
        /// Método que salva o voto
        /// </summary>
        /// <param name="user">usuário que votou</param>
        /// <param name="restaurantId">Id do restaurante</param>
        /// <param name="ignoreSaveModel">Ignora a parte que salva no banco</param>
        /// <param name="date">Data do voto</param>
        private static void Voting(string user, int restaurantId, bool ignoreSaveModel, DateTime date)
        {

            if (!_usersWithVote.ContainsKey(user))
            {
                _usersWithVote.Add(user, new VoteEntity() { Date = date.ToShortDateString(), RestaurantId = restaurantId });
            }
            else
            {
                _usersWithVote[user] = new VoteEntity() { Date = date.ToShortDateString(), RestaurantId = restaurantId };
            }
            if (!ignoreSaveModel)
            {
                using (var model = new ModelBDContainer())
                {
                    var item = model.RestaurantSettingsSet.FirstOrDefault(x => x.User.Equals(user) &&
                        x.Date.Year == DateTime.Now.Year &&
                        x.Date.Month == DateTime.Now.Month &&
                        x.Date.Day == DateTime.Now.Day);
                    if (item == null)
                    {
                        model.RestaurantSettingsSet.Add(new RestaurantSettings() { User = user, Date = DateTime.Now, RestaurantVotedId = restaurantId });
                    }
                    else
                    {
                        item.RestaurantVotedId = restaurantId;
                    }
                    model.SaveChanges();
                }
            }
        }

        /// <summary>
        /// Carrega todos votos dos usuários do banco
        /// </summary>
        private static void FindAllFromModel()
        {
            using (var model = new ModelBDContainer())
            {
                if (model.RestaurantSettingsSet.Count() != 0)
                {
                    foreach (var item in model.RestaurantSettingsSet)
                    {
                        Voting(item.User, item.RestaurantVotedId, true, item.Date);
                    }
                }
            }
        }
        #endregion

        /// <summary>
        /// Retorna a instancia da classe, caso ela sejá null ele ira inicializar
        /// </summary>
        public static RestaurantSettingsMap Instance
        {
            get
            {
                return _instance ?? (_instance = new RestaurantSettingsMap());
            }
        }

        /// <summary>
        /// Verifica se o usuário votou hoje
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public bool UserWithTodayVote(string user)
        {
            try
            {
                return UsersWithVoteToday().ContainsKey(user);
            }
            catch (Exception)
            {
                return false;
            }
        }

        /// <summary>
        /// Retorna todos usuários que votaram hoje
        /// </summary>
        /// <returns></returns>
        public List<string> UsersWithTodayVote()
        {
            var users = new List<string>();
            try
            {
                foreach (var item in UsersWithVoteToday())
                {
                    users.Add(item.Key);
                }
                return users;
            }
            catch (Exception)
            {
                return users;
            }
        }

        /// <summary>
        /// Método para salva o voto
        /// </summary>
        /// <param name="user"></param>
        /// <param name="restaurantId"></param>
        public void Vote(string user, int restaurantId)
        {
            if (UserWithTodayVote(user))
            {
                throw new BusinessException("Usuário não pode votar mais de uma vez!");
            }
            Voting(user, restaurantId, false, DateTime.Now);
        }

        /// <summary>
        /// Busca qual foi o voto do usuário
        /// </summary>
        /// <param name="user"></param>
        /// <returns>Retorna o id do restaurante que o usuário votou, caso ele não tenha votado em nenhum retorna 0</returns>
        public int UserVote(string user)
        {
            try
            {
                VoteEntity vote;
                UsersWithVote().TryGetValue(user, out vote);
                if (vote.Date.Equals(DateTime.Now.ToShortDateString()))
                    return vote.RestaurantId;
                else
                    return 0;
            }
            catch (Exception)
            {
                return 0;
            }
        }

        /// <summary>
        /// Busca qual foi o restaurante mais votado no dia
        /// </summary>
        /// <returns>Retorna Id do restaurante mais votado e a quantidade de votos</returns>
        public KeyValuePair<int, int> RestaurantWithMostVotesToday()
        {
            var aux = new Dictionary<int, int>();

            try
            {
                foreach (var item in UsersWithVoteToday())
                {
                    if (item.Value.Date.Equals(DateTime.Now.ToShortDateString()))
                    {
                        if (!aux.ContainsKey(item.Value.RestaurantId))
                        {
                            aux.Add(item.Value.RestaurantId, 1);
                        }
                        else
                        {
                            aux[item.Value.RestaurantId] = aux[item.Value.RestaurantId] + 1;
                        }
                    }
                }
                var ret = aux.OrderByDescending(x => x.Value).FirstOrDefault();

                var retValues = new KeyValuePair<int, int>(ret.Key, ret.Value);


                return retValues;
            }
            catch (Exception)
            {
                return new KeyValuePair<int, int>();
            }
        }

        /// <summary>
        /// Busca todos restaurantes que foram votados hoje
        /// </summary>
        /// <returns></returns>
        public List<RestaurantEntity> RestaurantWithVotesToday()
        {
            var ret = new List<RestaurantEntity>();

            var userVotes = UsersWithVoteToday();

            foreach (var item in userVotes)
            {
                if (ret.Exists(x => x.Id == item.Value.RestaurantId))
                {
                    var idx = ret.FindIndex(x => x.Id == item.Value.RestaurantId);

                    ret[idx].Votes++;
                }
                else
                {
                    var rest = RestaurantMap.Instance.FindById(item.Value.RestaurantId);
                    if (rest != null)
                    {
                        ret.Add(new RestaurantEntity() { Id = rest.Id, DateVoted = DateTime.Now, Name = rest.Name, Votes = 1 });
                    }
                }
            }

            return ret.OrderByDescending(x => x.Votes).ToList();
        }

    }
}
