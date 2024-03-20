using AutoMapper;
using LearnHub.Application.Contracts.Support.SupportAdmin;
using LearnHub.Application.Dto.Support.SupportAdmin.command;
using LearnHub.Application.Dto.Support.SupportAdmin.Queries;
using LearnHub.Application.Features.SupportAdmin.Handlers.Commands;
using LearnHub.Application.Features.SupportAdmin.Handlers.Queries;
using LearnHub.Application.Features.SupportAdmin.Requests.Commands;
using LearnHub.Application.Features.SupportAdmin.Requests.Queries;
using LearnHub.Application.Profile;
using LearnHub.Application.Responses;
using LearnHub.Application.Validation.Support.SupportAdmin.command;
using LearnHub.Test.Mocks.Support.Admin;
using Moq;
using Shouldly;


namespace LearnHub.Test.Test.Support.Admin
{
    public class TestSupportAdmin_T
    {
        IMapper _mapper;
        Mock<ISupportAdmin> _mockRepository;

        Update_SupportAdmin_Dto _Update_SupportAdmin_Dto;
        Create_SupportAdmin_Dto _Create_SupportAdmin_Dto;

        public TestSupportAdmin_T()
        {
            var mapperConfig = new MapperConfiguration(m =>
            {
                m.AddProfile<AutoMap>();
            });

            _mapper = mapperConfig.CreateMapper();


            _mockRepository = MockSupportAdmin.Get_SupportAdmin_Repository();


            _Update_SupportAdmin_Dto = new Update_SupportAdmin_Dto()
            {
                Id = 1,
                Answer = "we will try to fix it",
                SupportStudentId = 2,
            };



            _Create_SupportAdmin_Dto = new Create_SupportAdmin_Dto()
            {
                SupportStudentId = 4,
                Answer = "this is a test for inssert to SupportAdmin_En"
            };



        }


        #region Get

        [Fact]
        public async Task GetAll_SupportAdmin_Test()
        {
            var handler = new GetAll_SupportAdmin_H(_mapper, _mockRepository.Object);

            var result = await handler.Handle(new GetAll_SupportAdmin_R(), CancellationToken.None);

            result.ShouldBeOfType<BaseCommandResponse>();

            Assert.NotNull(result);


            result.Data.ShouldBeOfType<List<SupportAdmin_Dto>>().Count().ShouldBe(3);
        }


        [Fact]
        public async Task Get_SupportAdmin_Test()
        {

            var handler = new Get_SupportAdmin_H(_mapper, _mockRepository.Object);

            var result = await handler.Handle(new Get_SupportAdmin_R() { Id = 1 }, CancellationToken.None);



            result.ShouldBeOfType<BaseCommandResponse>();

            Assert.NotNull(result);



            Assert.True(result.IsSuccess);

            result.Data.ShouldBeOfType<SupportAdmin_Dto>().AdminId.ShouldBe(1);

        }



        [Fact]
        public async Task GetWithUserId_SupportAdmin_Test()
        {
            var handler = new GetWithUserId_SupportAdmin_H(_mapper, _mockRepository.Object);

            var result = await handler.Handle(new GetWithUserId_SupportAdmin_R() { AdminId = 1 }, CancellationToken.None);



            result.ShouldBeOfType<BaseCommandResponse>();

            Assert.NotNull(result);

            Assert.True(result.IsSuccess);

            result.Data.ShouldBeOfType<List<SupportAdmin_Dto>>().Count.ShouldBe(2);


            result = await handler.Handle(new GetWithUserId_SupportAdmin_R() { AdminId = 12 }, CancellationToken.None);


            result.ShouldBeOfType<BaseCommandResponse>();

            Assert.False(result.IsSuccess);

            result.StatusCode.ShouldBe(404);

        }

        #endregion


        #region Post

        [Fact]
        public async Task Create_SupportAdmin_Test()
        {
            var realValidator = new Create_SupportAdmin_V();

            var handler = new Create_SupportAdmin_H(_mapper, _mockRepository.Object, realValidator);


            var result = await handler.Handle(new Create_SupportAdmin_R()
            {
                create_SupportAdmin_Dto = _Create_SupportAdmin_Dto,
                AdminId = 1,
            }, CancellationToken.None);

            result.ShouldBeOfType<BaseCommandResponse>();



            var SupportAdmins = await _mockRepository.Object.GetAll();

            SupportAdmins.Count().ShouldBe(4);



            var LastAdd = SupportAdmins.LastOrDefault();

            Assert.Equal(LastAdd.AdminId, 1);
            Assert.NotEmpty(LastAdd.Answer);


        }
        #endregion



        #region Update


        [Fact]
        public async Task Update_SupportAdmin_Test()
        {
            var realValidator = new Update_SupportAdmin_V();

            var handler = new Update_SupportAdmin_H(_mapper, _mockRepository.Object, realValidator);


            var result = await handler.Handle(new Update_SupportAdmin_R()
            {
                update_SupportAdmin_Dto = _Update_SupportAdmin_Dto
            }, CancellationToken.None);

            result.ShouldBeOfType<BaseCommandResponse>();


            var SupportAdmin = await _mockRepository.Object.Get(_Update_SupportAdmin_Dto.Id);

            Assert.Equal(SupportAdmin.SupportStudentId, 2);

        }

        #endregion


        #region Delete


        [Fact]
        public async Task Delete_SupportAdmin_Test()
        {
            var handler = new Delete_SupportAdmin_H(_mapper, _mockRepository.Object);

            var result = await handler.Handle(new Delete_SupportAdmin_R()
            {
                Ids = new List<int> { 1, 2 }
            }, CancellationToken.None);


            result.ShouldBeOfType<BaseCommandResponse>();

            var SupportAdmins = await _mockRepository.Object.GetAll();

            Assert.Equal(SupportAdmins.Count(), 1);

        }

        #endregion


    }
}
