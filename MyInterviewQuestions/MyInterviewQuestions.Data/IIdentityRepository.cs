using Microsoft.AspNet.Identity;
using MyInterviewQuestions.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyInterviewQuestions.Data
{
    public interface IIdentityRepository : IUserStore<User, int>,IUserPasswordStore<User,int>
    {
    }
}
