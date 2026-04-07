using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BridgeLabzTraning.Datastructure.ExamProctorSystem
{
    internal interface IExamProctorService
    {
        void VisitQuestion(int questionId);
        void GoBack();

        void AnswerQuestion(int questionId, string answer);
        void ViewAnswer(int questionId);

        void ShowNavigationHistory();
        void SubmitExam();
    }
}
