using AutoMapper;
using LearnHub.Application.Contracts.Support.SupportStudent;
using LearnHub.Application.Dto.Support.SupportStudent.command;
using LearnHub.Application.Dto.Support.SupportStudent.Queries;
using LearnHub.Application.Features.SupportStudent.Handlers.Commands;
using LearnHub.Application.Features.SupportStudent.Handlers.Queries;
using LearnHub.Application.Features.SupportStudent.Requests.Commands;
using LearnHub.Application.Features.SupportStudent.Requests.Queries;
using LearnHub.Application.Profile;
using LearnHub.Application.Responses;
using LearnHub.Application.Validation.Support.SupportStudent.command;
using LearnHub.Test.Mocks.Support.Student;
using Moq;
using Shouldly;

namespace LearnHub.Test.Test.Support.Student
{
    public class TestSupportStuednt_T
    {
        IMapper _mapper;
        Mock<ISupportStudent> _mockRepository;

        Update_SupportStudent_Dto _Update_SupportStudent_Dto;
        Create_SupportStudent_Dto _Create_SupportStudent_Dto;

        public TestSupportStuednt_T()
        {
            var mapperConfig = new MapperConfiguration(m =>
            {
                m.AddProfile<AutoMap>();
            });

            _mapper = mapperConfig.CreateMapper();


            _mockRepository = MockSupportStudent.Get_SupportStudent_Repository();


            _Update_SupportStudent_Dto = new Update_SupportStudent_Dto()
            {
                Id = 1,
                Question = "Update"
            };



            _Create_SupportStudent_Dto = new Create_SupportStudent_Dto()
            {
                Question = "new Question",
            };

        }


        #region Get


        [Fact]
        public async Task Get_SupportStudent_Test()
        {
            var handler = new Get_SupportStudent_H(_mapper, _mockRepository.Object);

            var result = await handler.Handle(new Get_SupportStudent_R() { Id = 1 }, CancellationToken.None);



            result.ShouldBeOfType<BaseCommandResponse>();

            Assert.NotNull(result);

            Assert.True(result.IsSuccess);

            result.Data.ShouldBeOfType<SupportStudent_Dto>().UserId.ShouldBe(1);



            result = await handler.Handle(new Get_SupportStudent_R() { Id = 7 }, CancellationToken.None);

            result.StatusCode.ShouldBe(404);

            result.IsSuccess.ShouldBeFalse();
        }



        [Fact]
        public async Task GetAll_SupportStudent_Test()
        {
            var handler = new GetAll_SupportStudent_H(_mapper, _mockRepository.Object);

            var result = await handler.Handle(new GetAll_SupportStudent_R(), CancellationToken.None);

            result.ShouldBeOfType<BaseCommandResponse>();

            Assert.NotNull(result);

            result.Data.ShouldBeOfType<List<SupportStudent_Dto>>().Count().ShouldBe(3);

        }



        [Fact]
        public async Task GetWithUserId_SupportStudent_Test()
        {
            var handler = new GetWithUserId_SupportStudent_H(_mapper, _mockRepository.Object);

            var result = await handler.Handle(new GetWithUserId_SupportStudent_R() { UserId = 1 }, CancellationToken.None);

            result.ShouldBeOfType<BaseCommandResponse>();

            Assert.NotNull(result);

            result.Data.ShouldBeOfType<List<SupportStudent_Dto>>().Count().ShouldBe(2);

        }

        #endregion


        #region Post

        [Fact]
        public async Task Create_SupportStudent_Test()
        {
            var realValidator = new Create_SupportStudent_V();

            var handler = new Create_SupportStudent_H(_mapper, _mockRepository.Object, realValidator);


            var result = await handler.Handle(new Create_SupportStudent_R()
            {
                create_SupportStudent_Dto = _Create_SupportStudent_Dto,
                UserId = 1,
            }, CancellationToken.None);

            result.ShouldBeOfType<BaseCommandResponse>();



            var SupportAdmins = await _mockRepository.Object.GetAll();

            SupportAdmins.Count().ShouldBe(4);



            var LastAdd = SupportAdmins.LastOrDefault();

            Assert.Equal(LastAdd.UserId, 1);
            Assert.NotEmpty(LastAdd.Question);


            var InValid = new Create_SupportStudent_Dto()
            {
                Question = ""
            };


            result = await handler.Handle(new Create_SupportStudent_R()
            {
                create_SupportStudent_Dto = InValid,
                UserId = 1,
            }, CancellationToken.None);

            result.ShouldBeOfType<BaseCommandResponse>();
            result.StatusCode.ShouldBe(400);
            result.Errors.Count().ShouldBeGreaterThan(0);
        }

        #endregion


        #region Delete


        [Fact]
        public async Task Delete_SupportStudent_Test()
        {
            var handler = new Delete_SupportStudent_H(_mapper, _mockRepository.Object);

            var result = await handler.Handle(new Delete_SupportStudent_R()
            {
                Ids = new List<int> { 1, 2 }
            }, CancellationToken.None);


            result.ShouldBeOfType<BaseCommandResponse>();

            var SupportAdmins = await _mockRepository.Object.GetAll();

            Assert.Equal(SupportAdmins.Count(), 1);
        }

        #endregion


        #region Update


        [Fact]
        public async Task Update_SupportStudent_Test()
        {
            var realValidator = new Update_SupportStudent_V();

            var handler = new Update_SupportStudent_H(_mapper, _mockRepository.Object, realValidator);


            var result = await handler.Handle(new Update_SupportStudent_R()
            {
                update_SupportStudent_Dto = _Update_SupportStudent_Dto
            }, CancellationToken.None);

            result.ShouldBeOfType<BaseCommandResponse>();


            var SupportAdmin = await _mockRepository.Object.Get(_Update_SupportStudent_Dto.Id);

            Assert.Equal(SupportAdmin.UserId, 1);
        }

        #endregion

    }
}
