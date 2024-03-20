using LearnHub.Application.Contracts.Support.SupportAdmin;
using LearnHub.Application.Contracts.Support.SupportStudent;
using LearnHub.Application.Responses;
using LearnHub.Domain.Model.Support;
using Moq;

namespace LearnHub.Test.Mocks.Support.Student
{
    public class MockSupportStudent 
    {
        public static Mock<ISupportStudent> Get_SupportStudent_Repository()
        {
            BaseCommandResponse response = new BaseCommandResponse();

            var supportStudents = new List<SupportStudent_En>()
            {
               new SupportStudent_En
               { Id = 1,
               Date = DateTime.Now,
               Question = "why i cant remember my password",
               UserId = 1,
               }
               ,
               new SupportStudent_En
               { Id = 2,

               Date = DateTime.Now,
               Question = "hello",
               UserId = 2,
               }
               ,
               new SupportStudent_En
               { Id = 3,
               Date = DateTime.Now,
               Question = "i need support",
               UserId = 1,
               }
            };

            var mockRepo = new Mock<ISupportStudent>();



            mockRepo.Setup(r => r.GetAll()).ReturnsAsync(supportStudents);


            mockRepo.Setup(r => r.Get(It.IsAny<int>()))
                .Returns((int id) =>
                {
                    var existing = supportStudents.Find(x => x.Id == id);

                    return Task.FromResult(existing);
                });


            mockRepo.Setup(r => r.Add(It.IsAny<SupportStudent_En>()))
                .Returns((SupportStudent_En supportStudent) =>
                {
                    supportStudents.Add(supportStudent);
                    response.Data = supportStudent;
                    return Task.FromResult(response.Data); // برگرداندن Task
                });



            mockRepo.Setup(r => r.Update(It.IsAny<SupportStudent_En>()))
                    .Returns((SupportStudent_En supportStudent) =>
                    {
                        var existing = supportStudents.Find(x => x.Id == supportStudent.Id);
                        if (existing != null)
                        {
                            existing.Question = supportStudent.Question;
                            existing.UserId = supportStudent.UserId;
                            existing.Date = supportStudent.Date;
                            response.Data = supportStudent; 
                        }
                        return Task.FromResult(response.Data);
                    });




            mockRepo.Setup(r => r.Delete(It.IsAny<List<int>>()))
                .Returns((List<int> Ids) =>
                {

                    foreach (var id in Ids)
                    {
                        var existing = supportStudents.Find(x => x.Id == id);
                        if (existing != null)
                        {
                            supportStudents.Remove(existing);
                            response.Success();
                        }
                    }
                    return Task.FromResult(response);
                });


            mockRepo.Setup(r => r.GetSupportStudentWithUserId(It.IsAny<int>()))
                .Returns((int StudentId) =>
                {
                    var Target = supportStudents.Where(p => p.UserId == StudentId).ToList();
                    if (!Target.Any())
                    {
                        response.Success();
                        response.Data = Target;
                    }
                    else
                    {
                        response.NotFound();
                    }


                    return Task.FromResult(Target);
                });

            return mockRepo;
        }
    }
}
