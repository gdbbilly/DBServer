using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using dbtest.Methods;
using dbtest.Exceptions;

namespace dbtest.UnitTest
{
    [TestClass]
    public class TestStories
    {
        //História 1
        //Eu como profissional faminto Quero votar no meu restaurante favorito
        //Para que eu consiga democraticamente levar meus colegas a comer onde eu gosto.
        //Critério de Aceitação
        //* Um professional só pode votar em um restaurante por dia.

        [TestMethod]
        public void TestStorie1()
        {
            try
            {
                RestaurantMethods.Vote("DBUser1", 1, DateTime.Now);
                try
                {
                    RestaurantMethods.Vote("DBUser1", 2, DateTime.Now);
                }
                catch (Exception)
                {
                    Assert.IsTrue(true);
                }
                Assert.IsTrue(false);
            }
            catch (BusinessException ex)
            {
                Assert.IsTrue(false);
            }
        }


        [TestMethod]
        public void TestStorie2()
        {
            //História 2
            //Eu como facilitador do processo de votação Quero que um restaurante não possa ser repetido durante a semana
            //Para que não precise ouvir reclamações infinitas!
            //Critério de Aceitação
            //*O mesmo restaurante não pode ser escolhido mais de uma vez durante a semana.
            try
            {
                RestaurantMethods.Vote("DBUser11", 3, DateTime.Now.AddDays(1));
                RestaurantMethods.Vote("DBUser21", 3, DateTime.Now.AddDays(1));

                RestaurantMethods.CloseVoting();

                RestaurantMethods.Vote("DBUser11", 3, DateTime.Now.AddDays(2));
                RestaurantMethods.Vote("DBUser21", 3, DateTime.Now.AddDays(2));
                RestaurantMethods.Vote("DBUser31", 2, DateTime.Now.AddDays(2));

                RestaurantMethods.CloseVoting();

                var result = RestaurantMethods.GetRestaurantsVotedWeek();

                Assert.IsTrue(result[0].Id != result[1].Id);
            }
            catch (BusinessException ex)
            {
                Assert.IsTrue(false);
            }
        }


        [TestMethod]
        public void TestStorie3()
        {
            //História 3
            //Eu como profissional faminto
            //Quero saber antes do meio dia qual foi o restaurante escolhido
            //Para que eu possa me despir de preconceitos e preparar o psicológico.
            //Critério de Aceitação
            //* Mostrar de alguma forma o resultado da votação.
            try
            {
                RestaurantMethods.Vote("DBUser12", 3, DateTime.Now);
                RestaurantMethods.Vote("DBUser22", 3, DateTime.Now);
                RestaurantMethods.Vote("DBUser13", 3, DateTime.Now);
                RestaurantMethods.Vote("DBUser23", 2, DateTime.Now);

                RestaurantMethods.CloseVoting();

                var result = RestaurantMethods.GetRestaurantWinnerToday();

                Assert.IsTrue(result.Votes > 0);
            }
            catch (BusinessException ex)
            {
                Assert.IsTrue(false);
            }
        }
    }
}
