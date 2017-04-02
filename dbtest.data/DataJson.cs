using System;
using System.Collections.Generic;

namespace dbtest.Entities
{
    /// <summary>
    /// Entidade utilizada para os gráficos
    /// </summary>
    public class DataJson
    {
        public string Name { get; set; }

        public int Value { get; set; }

        public float ValuePercent { get; set; }

        public string Color { get; set; }

        /// <summary>
        /// Separa os objetos por grupo
        /// </summary>
        /// <param name="dataJson">Lista de objetos que devem ser agrupados por grupos</param>
        /// <returns>Lista de objetos agrupadaos por grupo</returns>
        public List<DataJson> DataJsonGroupValue(List<DataJson> dataJson)
        {
            List<DataJson> dataJsonGroup = new List<DataJson>();
            int cont = 0;
            bool add = true;
            foreach (var item in dataJson)
            {
                if ((item.Name != null) && (item.Color != null))
                {
                    int aux = item.Value;
                    add = dataJsonGroup.Exists(x => x.Name.Equals(Convert.ToString(item.Name)));
                    if (!add)
                    {
                        foreach (var value in dataJson)
                        {
                            if (aux == value.Value)
                                cont++;
                        }
                        dataJsonGroup.Add(new DataJson
                        {
                            Value = cont,
                            Name = Convert.ToString(item.Name),
                            Color = Convert.ToString(item.Color),
                            ValuePercent = item.ValuePercent
                        });
                    }

                    cont = 0;
                }
            }
            return dataJsonGroup;
        }

        /// <summary>
        /// Separa os objetos por porcentagem
        /// </summary>
        /// <param name="dataJson">Lista de objetos que devem ser agrupados por porcentagem</param>
        /// <returns>Lista de objetos agrupadaos por porcentagem</returns>
        public List<DataJson> DataJsonPercent(List<DataJson> listDataJson)
        {
            List<DataJson> dataJsonPercent = new List<DataJson>();
            float valueTotal = 0;
            float percent = 0;
            foreach (var item in listDataJson)
                if ((item.Name != null) && (item.Color != null))
                    valueTotal += item.Value;

            foreach (var item in listDataJson)
            {
                if ((item.Name != null) && (item.Color != null))
                {
                    percent = (item.Value / valueTotal) * 100;
                    DataJson information = new DataJson();
                    information.Name = item.Name;
                    information.ValuePercent = percent;
                    information.Value = item.Value;
                    dataJsonPercent.Add(information);
                    percent = 0;
                }
            }

            return dataJsonPercent;
        }
    }
}
