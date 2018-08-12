using Microsoft.VisualStudio.TestTools.UnitTesting;
using Solution.CrossCutting.DependencyInjection;
using Solution.CrossCutting.Mapping;
using Solution.Model.Enums;
using Solution.Model.Models;

namespace Solution.CrossCutting.Tests
{
    [TestClass]
    public class MappingTest
    {
        public MappingTest()
        {
            DependencyInjector.RegisterServices();
            Mapping = DependencyInjector.GetService<IMapper>();
        }

        private IMapper Mapping { get; }

        [TestMethod]
        public void MappingClone()
        {
            var source = new UserModel
            {
                Email = "email@mail.com",
                Login = "login",
                Name = "Name",
                Password = "password",
                UserId = 1
            };

            var result = Mapping.Clone(source);

            Assert.IsNotNull(result.UserId);
        }

        [TestMethod]
        public void MappingMap()
        {
            var source = new UserModel { UserId = 1, Roles = Roles.Admin };
            var result = Mapping.Map<AuthenticatedModel>(source);

            Assert.IsNotNull(result.UserId);
            Assert.IsNotNull(result.Roles);
        }

        [TestMethod]
        public void MappingMerge()
        {
            var source = new UserModel
            {
                Name = "Name",
                UserId = 1
            };

            var destination = new UserModel
            {
                Email = "email@mail.com",
                Login = "login",
                Password = "password"
            };

            var result = Mapping.Map(source, destination);

            Assert.IsNotNull(result.Email);
            Assert.IsNotNull(result.Login);
            Assert.IsNotNull(result.Name);
            Assert.IsNotNull(result.Password);
            Assert.IsNotNull(result.UserId);
        }
    }
}
