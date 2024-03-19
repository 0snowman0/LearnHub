using LearnHub.Application.Contracts.Support.SupportAdmin;
using LearnHub.Application.Responses;
using LearnHub.Domain.Model.Support;
using Moq;

namespace LearnHub.Test.Mocks.Support.Admin
{
    public class MockSupportAdmin
    {

        public static Mock<ISupportAdmin> Get_SupportAdmin_Repository()
        {
            BaseCommandResponse respose = new BaseCommandResponse();

            var supportAdmins = new List<SupportAdmin_En>()
            {
               new SupportAdmin_En
               { Id = 1,
                 AdminId = 1,
                 Answer = "we will try to fix it",
                 AnswerDate = DateTime.Now,
                 SupportStudentId = 1,
                 UpdateAnswer = DateTime.Now
               }
               ,
               new SupportAdmin_En
               { Id = 2,
                 AdminId = 1,
                 Answer = "we will let you know",
                 AnswerDate = DateTime.Now,
                 SupportStudentId = 2,
                 UpdateAnswer = DateTime.Now
               }
               ,
               new SupportAdmin_En
               { Id = 3,
                 AdminId = 2,
                 Answer = "okay",
                 AnswerDate = DateTime.Now,
                 SupportStudentId = 1,
                 UpdateAnswer = DateTime.Now
               }
            };

            var mockRepo = new Mock<ISupportAdmin>();



            mockRepo.Setup(r => r.GetAll()).ReturnsAsync(supportAdmins);


            mockRepo.Setup(r => r.Get(It.IsAny<int>()))
                .Returns((int id) =>
                {
                    var existing = supportAdmins.Find(x => x.Id == id);
                    return Task.FromResult(existing);
                });


            mockRepo.Setup(r => r.Add(It.IsAny<SupportAdmin_En>()))
                .Returns((SupportAdmin_En supportAdmin) =>
                {
                    supportAdmins.Add(supportAdmin);
                    respose.Data = supportAdmin;
                    return Task.FromResult(respose.Data); // برگرداندن Task
                });



            mockRepo.Setup(r => r.Update(It.IsAny<SupportAdmin_En>()))
                    .Returns((SupportAdmin_En supportAdmin) =>
                    {
                        var existing = supportAdmins.Find(x => x.Id == supportAdmin.Id);
                        if (existing != null)
                        {
                            existing.Answer = supportAdmin.Answer;
                            existing.UpdateAnswer = DateTime.Now;
                            respose.Data = existing;
                        }
                        return Task.FromResult(respose.Data);
                    });




            mockRepo.Setup(r => r.Delete(It.IsAny<List<int>>()))
                .Returns((List<int> Ids) =>
                {

                    foreach (var id in Ids)
                    {
                        var existing = supportAdmins.Find(x => x.Id == id);
                        if (existing != null)
                        {
                            supportAdmins.Remove(existing);
                            respose.Success();
                        }
                    }
                    return Task.FromResult(respose);
                });


            mockRepo.Setup(r => r.GetWithAdminId(It.IsAny<int>()))
                .Returns((int AdminId) =>
                {
                    var Target = supportAdmins.Where(p => p.AdminId == AdminId).ToList();
                    if (!Target.Any())
                    {
                        respose.Success();
                        respose.Data = Target;
                    }
                    else
                    {
                        respose.NotFound();
                    }


                    return Task.FromResult(Target);
                });

            return mockRepo;
        }
    }
}
