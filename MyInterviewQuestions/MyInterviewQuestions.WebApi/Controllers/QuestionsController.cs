using MyInterviewQuestions.Core;
using MyInterviewQuestions.Service;
using MyInterviewQuestions.WebApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace MyInterviewQuestions.WebApi.Controllers
{
    public class QuestionsController : ApiController
    {
        private readonly IQuestionService _questionService;

        public QuestionsController(IQuestionService questionService)
        {
            _questionService = questionService;
        }

        public HttpStatusCode Post([FromBody] QuestionModel questionModel)
        {
            try
            {
                Question question = questionModel.ToEntity();
                _questionService.Insert(question);
                return HttpStatusCode.OK;
            }
            catch (Exception ex)
            {
                return HttpStatusCode.InternalServerError;
            }
        }

        public List<QuestionModel> Get()
        {
            IEnumerable<Question> questions = _questionService.GetAll();
            List<QuestionModel> lstQuestions = questions.ToModels();
            return lstQuestions;
        }
    }
}
