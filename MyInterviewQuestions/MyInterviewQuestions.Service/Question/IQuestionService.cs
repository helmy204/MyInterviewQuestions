using MyInterviewQuestions.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyInterviewQuestions.Service
{
    public interface IQuestionService
    {
        /// <summary>
        /// Inserts the question
        /// </summary>
        /// <param name="question">Question</param>
        void Insert(Question question);

        IEnumerable<Question> GetAll();
    }
}
