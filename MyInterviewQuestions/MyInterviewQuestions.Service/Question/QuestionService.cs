using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyInterviewQuestions.Core;
using MyInterviewQuestions.Data;

namespace MyInterviewQuestions.Service
{
    public class QuestionService : IQuestionService
    {
        #region Fields

        private readonly IRepository<Question> _questionRepository;

        #endregion Fields

        public QuestionService(IRepository<Question> questionRepository)
        {
            _questionRepository = questionRepository;
        }

        /// <summary>
        /// Inserts the question
        /// </summary>
        /// <param name="question">Question</param>
        public void Insert(Question question)
        {
            Check.ArgumentNotNull<Question>("question", question);

            question.UserId = 1;

            question.InsertedOn = DateTime.Now;
            question.InsertedBy = 1;

            _questionRepository.Insert(question);
        }

        public IEnumerable<Question> GetAll()
        {
            IEnumerable<Question> questions= _questionRepository.Table;
            return questions.ToList();
        }
    }
}
