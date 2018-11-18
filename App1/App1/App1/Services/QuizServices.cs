using System;
using System.Security.Authentication;
using MongoDB.Driver;
using System.Threading.Tasks;
using System.Collections.Generic;
using MongoDB.Driver.Linq;
using System.Linq;
using App1.Model;
using MongoDB.Bson;

namespace App1.Services

{
    public class QuizServices
    {
        string dbName = "Test DB";
        string collectionName = "Test Collection";

        IMongoCollection<Quiz> quizCollection;

        IMongoCollection<Quiz> QuizCollection
        {
            get
            {
                if (quizCollection == null)
                {
                    // APIKeys.Connection string is found in the portal under the "Connection String" blade
                    MongoClientSettings settings = MongoClientSettings.FromUrl(
                        new MongoUrl(Helpers.APIKeys.ConnectionString)
                    );

                    settings.SslSettings =
                        new SslSettings() {EnabledSslProtocols = SslProtocols.Tls12};

                    // Initialize the client
                    var mongoClient = new MongoClient(settings);

                    // This will create or get the database
                    var db = mongoClient.GetDatabase(dbName);

                    // This will create or get the collection
                    var collectionSettings = new MongoCollectionSettings {ReadPreference = ReadPreference.Nearest};
                    quizCollection = db.GetCollection<Quiz>(collectionName, collectionSettings);
                }

                return quizCollection;
            }
        }

        #region Get Funktioner

        public async Task<List<Quiz>> GetAllQuizzes()
        {
            try
            {
                var allQuizzes = await QuizCollection
                    .Find(new BsonDocument())
                    .ToListAsync();

                return allQuizzes;
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.Message);
            }
            return null;
        }

        public async Task<Quiz> GetQuizById(Guid quizId)
        {
            var singleTask = await QuizCollection
                .Find(f => f.Id.Equals(quizId))
                .FirstOrDefaultAsync();

            return singleTask;
        }

        public async Task<Quiz> GetQuizByName(string quizName)
        {
            var Quiz = await QuizCollection
                .AsQueryable()
                .Where(q => q.QuizName == quizName)
                .FirstOrDefaultAsync();
            return Quiz;
        }

        #endregion

        #region Search Funktioner

        public async Task<List<Quiz>> GetQuizByCategory(string category)
        {
            var quizzes = await QuizCollection
                .AsQueryable()
                .Where(t => t.Category == category)
                .ToListAsync();

            return quizzes;
        }

        #endregion

        #region Save/Delete Funktioner

        public async Task CreateTask(Quiz quiz)
        {
            await QuizCollection.InsertOneAsync(quiz);
        }

        public async Task UpdateTask(Quiz quiz)
        {
            await QuizCollection.ReplaceOneAsync(t => t.Id.Equals(quiz.Id), quiz);
        }

        public async Task DeleteTask(Quiz quiz)
        {
            await QuizCollection.DeleteOneAsync(t => t.Id.Equals(quiz.Id));
        }

        #endregion
    }
}
