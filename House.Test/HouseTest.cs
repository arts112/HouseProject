using House.Core.Dtos;
using House.Core.ServiceInterface;
using System;
using System.Threading.Tasks;
using Xunit;

namespace House.Test
{
    public class HouseTest : TestBase
    {
        [Fact]
        public async Task WhenAddHouse_ReturnResult_ShouldNotBeNull()
        {
            string guid = "0A3EE96F-6F8D-43A4-B40B-595DED96DE68";
            HouseDto House = new HouseDto();

            House.Id = Guid.Parse(guid);
            House.Address = "Eden Street";
            House.Size = 5;
            House.Price = 250000;
            House.Description = "Mid-size apartment with nice view";

            var result = await Svc<IHouseService>().Add(House);
            Assert.NotNull(result);
        }

        [Fact]
        public async Task WhenUpdate_ShouldUpdate()
        {
            var guid = new Guid("775E07DD-2D7E-4228-A9F9-5ECB2D1200F0");
            HouseDto House = new HouseDto();

            House.Id = guid;
            House.Address = "La Costa Street";
            House.Size = 3;
            House.Price = 150000;
            House.Description = "Small apartment in the city center";

            var HouseIdNew = guid;
            var HouseUpdateNew = new HouseDto()

            {
                Price = 120000,
                Address = "Ehitajate tee"
            };

            await Svc<IHouseService>().Update(HouseUpdateNew);

            Assert.Equal(House.Id.ToString(), HouseIdNew.ToString());
            Assert.DoesNotMatch(House.Price.ToString(), HouseUpdateNew.Price.ToString());
            Assert.DoesNotMatch(House.Address, HouseUpdateNew.Address);

        }

        [Fact]
        public async Task WhenAdd_ResultShouldBeSame()
        {
            string guid = "FF2C876E-37CE-4E6A-8F92-61C73281415F";
            HouseDto House = new HouseDto();

            House.Id = Guid.Parse(guid);
            House.Address = "Sauga 13";
            House.Size = 2;
            House.Price = 50000;
            House.Description = "Small flat with 2 bedrooms";

            var NewHouseInfo = await Svc<IHouseService>().Add(House);

            Assert.Equal(House.Price.ToString(), NewHouseInfo.Price.ToString());


        }

        [Fact]
        public async Task GUIDShouldBeEqual()
        {
            string guid = "FB850C58-9774-4E65-BCA4-DA7E9DBDAB89";
            string guid2 = "FB850C58-9774-4E65-BCA4-DA7E9DBDAB89";

            var Guid1 = Guid.Parse(guid);
            var Guid2 = Guid.Parse(guid2);

            await Svc<IHouseService>().GetAsync(Guid1);

            Assert.Equal(Guid1, Guid2);
        }

        [Fact]
        public async Task GUIDShouldNotBeEqual()
        {
            string guid = "9D68BFE6-5B51-49A0-9243-9E742BD45750";
            string guid2 = "C90A197E-59C6-4EFF-A161-F0F5C7F07EDF";

            var Guid1 = Guid.Parse(guid);
            var Guid2 = Guid.Parse(guid2);

            await Svc<IHouseService>().GetAsync(Guid1);
            Assert.NotEqual(Guid1, Guid2);
        }
    }   
}
