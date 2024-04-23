using Dfe.Complete.Utils;
using FluentAssertions;


namespace Dfe.Complete.Tests.Utils
{
    public class StringChunkerTests
    {
        [Theory]
        [InlineData("", 5 ,"")]
        [InlineData("abcd", 5, "abcd")]
        [InlineData("abcdefg", 5, "abcde", "fg")]
        [InlineData("abcdefghijklm", 5, "abcde", "fghij", "klm")]
        [InlineData("abcdefghijklmop", 5, "abcde", "fghij", "klmop")]
        [InlineData("abcdefghijklmop", 9, "abcdefghi", "jklmop")]
        public void ChunkTests(string ageRange, int chunkSize, params string[] result)
        {
            StringChunker.Chunk(ageRange, chunkSize).Should().BeEquivalentTo(result);
        }
    }
}
