using MyInterviewQuestions.Core;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyInterviewQuestions.Data
{
    public class MyInterviewQuestionsContext : DbContext, IDbContext
    {
        public MyInterviewQuestionsContext()
      : base("name=MyInterviewQuestionsConnectionString")
        {
#if DEBUG
            //Database.Log = new Action<string>(s =>
            //{
            //    string str = s.Length > 32766 ? s.Substring(0, 30000) : s;
            //    System.Diagnostics.Debug.WriteLine("{0}", (object)str);
            //});

            Database.SetInitializer<MyInterviewQuestionsContext>(new CreateDatabaseIfNotExists<MyInterviewQuestionsContext>());
#else
             Database.SetInitializer<MyInterviewQuestionsContext>(new NullDatabaseInitializer<MyInterviewQuestionsContext>());
#endif
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }

        public new IDbSet<TEntity> Set<TEntity>() where TEntity : BaseEntity
        {
            return base.Set<TEntity>();
        }

        public virtual DbSet<Question> Questions { get; set; }
        public virtual DbSet<User> Users { get; set; }
    }
}
