using Commons.Api.FlashScope;
using System.Threading.Tasks;
using Xunit;

namespace Commons.Api.XTests.FlashScope
{
    public class TestFlashScope
    {
        [Fact]
        public void TestFlashService()
        {
            //Given
            var flashService = new MemoryFlashService();
            //When
            flashService.Set("key", "value");
            //Then
            var value = flashService.Get("key");
            Assert.Equal("value", value);
        }

        [Fact]
        public async Task TestConcurrentFlashService()
        {
            //Given
            var flashService = new MemoryFlashService();
            //When
            var task1 = new Task(() => { flashService.Set("key1", "value1"); });
            var task2 = new Task(() => { flashService.Set("key2", "value2"); });

            task1.Start();
            task2.Start();

            await Task.WhenAll(task1, task2);

            var task3 = new Task<string>(() => { return flashService.Get("key1"); });
            var task4 = new Task<string>(() => { return flashService.Get("key2"); });

            task3.Start();
            task4.Start();

            await Task.WhenAll(task3, task4);

            //Then
            Assert.Equal("value1", task3.Result);
            Assert.Equal("value2", task4.Result);
        }
    }
}