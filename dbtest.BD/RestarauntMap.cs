using dbtest.Entities;
using dbtest.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dbtest.Map
{
    /// <summary>
    /// Classe de acesso a dados da tabela de restaurantes
    /// </summary>
    public class RestaurantMap
    {
        private static bool _clear;
        private static List<RestaurantEntity> _list
        {
            get
            {
                ClearVotes();

                return FindAllFromModel();
            }
        }
        private static RestaurantMap _instance;

        #region Private Methods
        /// <summary>
        /// Salva o restaurante mais votado do dia e a quantidade de votos, fazendo com que ele sejá um dos votados na semana.
        /// </summary>
        /// <param name="restaurantId">Id do Restaurante</param>
        /// <param name="votes">Quantidade de votos</param>
        private static void SetVotedWeekFromModel(long restaurantId, int votes)
        {
            using (var model = new ModelBDContainer())
            {
                var item = model.RestaurantSet.FirstOrDefault(x => x.Id == restaurantId);
                if (item != null)
                {
                    item.VotedInWeek = true;
                    item.DateVoted = DateTime.Now;
                    item.Votes = votes;
                    model.SaveChanges();
                }
            }
        }

        /// <summary>
        /// Limpa os restaurantes mais votados na semana
        /// </summary>
        private static void ClearVotedInWeekFromModel()
        {
            using (var model = new ModelBDContainer())
            {
                foreach (var item in model.RestaurantSet)
                {
                    if (item.DateVoted == null)
                    {
                        item.VotedInWeek = false;
                        item.Votes = 0;
                    }
                    else
                    {
                        if (item.DateVoted.Value.DayOfYear != DateTime.Now.DayOfYear)
                        {
                            item.VotedInWeek = false;
                            item.Votes = 0;
                        }
                    }
                }
                model.SaveChanges();
            }
        }

        /// <summary>
        /// Busca todos Restaurantes no banco
        /// </summary>
        /// <returns>Lista de entidades dos restaurantes</returns>
        private static List<RestaurantEntity> FindAllFromModel()
        {
            var ret = new List<RestaurantEntity>();
            using (var model = new ModelBDContainer())
            {
                var list = model.RestaurantSet.ToList();
                if (list.Count == 0)
                {
                    foreach (var item in GetFake())
                    {
                        model.RestaurantSet.Add(new Restaurant() { Id = item.Id, Name = item.Name, VotedInWeek = false });
                        model.SaveChanges();
                    }
                }
                foreach (var item in model.RestaurantSet)
                {
                    ret.Add(new RestaurantEntity()
                    {
                        Id = Convert.ToInt32(item.Id),
                        Name = item.Name,
                        VotedInWeek = item.VotedInWeek,
                        DateVoted = Convert.ToDateTime(item.DateVoted),
                        Votes = item.Votes
                    });
                }
            }

            return ret;
        }

        /// <summary>
        /// Busca restaurante no banco pelo Id
        /// </summary>
        /// <param name="id">Id do restaurante</param>
        /// <returns>Entidade do restaurante</returns>
        private static RestaurantEntity FindByIdFromModel(int id)
        {
            var ret = new RestaurantEntity();
            using (var model = new ModelBDContainer())
            {
                var list = model.RestaurantSet.ToList();
                if (list.Count == 0)
                {
                    foreach (var item in GetFake())
                    {
                        model.RestaurantSet.Add(new Restaurant() { Id = item.Id, Name = item.Name, VotedInWeek = false });
                        model.SaveChanges();
                    }
                }
                var aux = model.RestaurantSet.FirstOrDefault(x => x.Id == id);
                ret.Id = Convert.ToInt32(aux.Id);
                ret.Name = aux.Name;
                ret.VotedInWeek = aux.VotedInWeek;
                ret.DateVoted = Convert.ToDateTime(aux.DateVoted);
            }

            return ret;
        }

        /// <summary>
        /// Retorna uma lista de restaurantes fake para testes
        /// </summary>
        /// <returns></returns>
        private static List<RestaurantEntity> GetFake()
        {
            var list = new List<RestaurantEntity>();
            for (int i = 1; i <= 50; i++)
            {
                list.Add(new RestaurantEntity() { Id = i, Name = string.Format("Restaurante {0}", i) });
            }

            return list;
        }

        private RestaurantMap()
        {
            ClearVotes();
        }

        /// <summary>
        /// Verificar se já limpou os votos da semana, caso não tenha limpado vai se limpo
        /// </summary>
        private static void ClearVotes()
        {
            if (DateTime.Now.DayOfWeek == DayOfWeek.Monday && _clear == false)
            {
                ClearVotedInWeekFromModel();
                _clear = true;
            }
            else
            {
                _clear = false;
            }
        }
        #endregion

        #region Internal Methods
        internal void InitializeVotes()
        {
            ClearVotes();
        }
        #endregion

        #region Public Methods
        /// <summary>
        /// Retorna a instancia da classe, caso ela sejá null ele ira inicializar
        /// </summary>
        public static RestaurantMap Instance
        {
            get
            {
                return _instance ?? (_instance = new RestaurantMap());
            }
        }

        /// <summary>
        /// Retorna todos os restaurantes
        /// </summary>
        /// <returns>Lista de entidade de restaurante</returns>
        public List<RestaurantEntity> FindAll()
        {
            try
            {
                return _list;
            }
            catch (Exception ex)
            {
                throw new BusinessException(ex);
            }
        }

        /// <summary>
        /// Quantidade de restaurantes
        /// </summary>
        /// <returns>Quantidade de restaurantes</returns>
        public int Count()
        {
            try
            {
                return _list.Count();
            }
            catch (Exception ex)
            {
                throw new BusinessException(ex);
            }
        }

        /// <summary>
        /// Busca todos restaurantes que não foram os mais votados na semana.
        /// </summary>
        /// <returns>Lista de entidade de restaurante</returns>
        public List<RestaurantEntity> FindAllNotVotedWeek()
        {
            try
            {
                return _list.Where(x => !x.VotedInWeek).ToList();
            }
            catch (Exception ex)
            {
                throw new BusinessException(ex);
            }
        }

        /// <summary>
        /// Busca todos restaurantes que foram os mais votados na semana.
        /// </summary>
        /// <returns>Lista de entidade de restaurante</returns>
        public List<RestaurantEntity> FindAllVotedWeek(DateTime lessDate, DateTime greaterDate)
        {
            try
            {
                return _list
                    .Where(x => x.VotedInWeek
                            && Convert.ToDateTime(x.DateVoted.ToShortDateString()) >= Convert.ToDateTime(lessDate.ToShortDateString())
                            && Convert.ToDateTime(x.DateVoted.ToShortDateString()) <= Convert.ToDateTime(greaterDate.ToShortDateString()))
                    .ToList();
            }
            catch (Exception ex)
            {
                throw new BusinessException(ex);
            }
        }

        /// <summary>
        /// Busca o restaurante pelo Id.
        /// </summary>
        /// <returns>Entidade de restaurante</returns>
        public RestaurantEntity FindById(int id)
        {
            try
            {
                return FindByIdFromModel(id);
            }
            catch (Exception ex)
            {
                return new RestaurantEntity();
            }
        }

        /// <summary>
        /// Busca todos restaurantes que não foram votados no dia.
        /// </summary>
        /// <returns>Lista de entidade de restaurante</returns>
        public List<RestaurantEntity> RestaurantWithoutVotesToday()
        {
            var list = RestaurantSettingsMap.Instance.RestaurantWithVotesToday();

            var ret = FindAll().Where(x => list.Count(l => l.Id == x.Id) == 0).ToList();

            return ret;
        }

        /// <summary>
        /// Salva o restaurante mais votado do dia e a quantidade de votos, fazendo com que ele sejá um dos votados na semana.
        /// </summary>
        /// <param name="restaurantId">Id do Restaurante</param>
        /// <param name="votes">Quantidade de votos</param>
        public void SetVotedWeek(long restaurantId, int votes)
        {
            try
            {
                SetVotedWeekFromModel(restaurantId, votes);
            }
            catch (Exception ex)
            {
                throw new BusinessException(ex);
            }
        }

        /// <summary>
        /// Verificar se a votação está encerrada
        /// </summary>
        /// <returns>True se a votação está encerrada, caso não esteja retorna false</returns>
        public bool VotingClosed()
        {
            try
            {
                var aux = _list.Where(x => x.VotedInWeek &&
                                    x.DateVoted != null);

                return aux.Where(x => x.DateVoted.Year == DateTime.Now.Year &&
                               x.DateVoted.Month == DateTime.Now.Month &&
                               x.DateVoted.Day == DateTime.Now.Day).Count() > 0;
            }
            catch (Exception ex)
            {
                throw new BusinessException(ex);
            }
        }

        public void Initialize()
        {
            FindAllFromModel();
        }

        #endregion
    }
}
