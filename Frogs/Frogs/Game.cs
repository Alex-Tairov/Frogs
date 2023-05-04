using System.Collections.Generic;

namespace Frogs
{
    public class Game
    {
        private string userResultsPath = "userResults.json";
        private List<UserResults> results;
        private UserName user;

        public Game(UserName user)
        {
            this.user = user;
            InitUserResults();
            results = UserResults.GetResultsFromFile();

        }




        //Создает файл с результатами игры
        private void InitUserResults()
        {
            UserResults.CreateFileResultsIfNotExists();
        }

        //Сохраняет результат    
        public void SaveResult()
        {
            //var game = new Game(user);
            var userResult = new UserResults(user.name, user.score);
            results.Add(userResult);
            UserResults.SaveResults(results);

        }
    }
}
