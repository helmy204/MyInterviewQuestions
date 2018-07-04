using MyInterviewQuestions.Core;
using MyInterviewQuestions.WebApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyInterviewQuestions.WebApi
{
    public static class QuestionExtensions
    {
        public static Question ToEntity(this QuestionModel questionModel)
        {
            Question question = new Question()
            {
                BodyText = questionModel.BodyText,
                Title = questionModel.Title
            };

            return question;
        }

        public static List<QuestionModel> ToModels(this IEnumerable<Question> questions)
        {
            List<QuestionModel> questionModels = new List<QuestionModel>();

            foreach (var question in questions)
            {
                questionModels.Add(new QuestionModel()
                {
                    Title = question.Title,
                    BodyText = question.BodyText
                });
            }

            return questionModels;
        }
    }
}